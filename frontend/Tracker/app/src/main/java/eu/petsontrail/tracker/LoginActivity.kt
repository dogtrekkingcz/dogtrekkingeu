package eu.petsontrail.tracker

import android.content.ContentValues.TAG
import android.content.Intent
import android.net.Uri
import android.os.Bundle
import android.util.Log
import androidx.appcompat.app.AppCompatActivity
import eu.petsontrail.tracker.db.AppDatabase
import eu.petsontrail.tracker.db.DbHelper
import kotlinx.coroutines.runBlocking
import net.openid.appauth.AuthState
import net.openid.appauth.AuthState.AuthStateAction
import net.openid.appauth.AuthorizationException
import net.openid.appauth.AuthorizationRequest
import net.openid.appauth.AuthorizationResponse
import net.openid.appauth.AuthorizationService
import net.openid.appauth.AuthorizationServiceConfiguration
import net.openid.appauth.ClientAuthentication
import net.openid.appauth.ClientSecretBasic
import net.openid.appauth.ResponseTypeValues
import net.openid.appauth.TokenRequest
import okhttp3.OkHttpClient
import okhttp3.Request
import okhttp3.Response


class LoginActivity : AppCompatActivity() {
    private var RC_AUTH: Int = 3254
    private lateinit var authService: AuthorizationService
    private lateinit var authState: AuthState
    private lateinit var authClientAuthentication: ClientAuthentication
    private var authIssuer: String = "https://petsontrail.eu:8443/realms/PetsOnTrail"
    private var authClientId: String = "tracker-app"
    private var authClientSecret: String = "NmdTc3gQZr7AQM33ZIQ9TdjXV7wJA92m"
    private var authRequiredScopes: String = "openid email profile"
    private var authRedirectUri: String = "petsontrail:/tracker"

    private lateinit var db: AppDatabase

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        db = DbHelper().InitializeDatabase(this)

        authClientAuthentication = ClientSecretBasic(authClientSecret)

        var serviceConfig: AuthorizationServiceConfiguration? = null

        AuthorizationServiceConfiguration.fetchFromIssuer(
            Uri.parse(authIssuer),
            AuthorizationServiceConfiguration.RetrieveConfigurationCallback { serviceConfiguration, ex ->
                if (ex != null) {
                    Log.e(TAG, "failed to fetch configuration")
                    return@RetrieveConfigurationCallback
                }

                serviceConfig = serviceConfiguration

                val authRequestBuilder =
                    serviceConfig?.let {
                        AuthorizationRequest.Builder(
                            it,  // the authorization service configuration
                            authClientId,  // the client ID, typically pre-registered and static
                            ResponseTypeValues.CODE,  // the response_type value: we want a code
                            Uri.parse(authRedirectUri)
                        )
                    }

                val authRequest = authRequestBuilder
                    ?.setScope(authRequiredScopes)
                    // ?.setLoginHint("jdoe@user.example.com")
                    ?.build()

                authService = AuthorizationService(this)
                val authIntent = authRequest?.let { authService.getAuthorizationRequestIntent(it) }

                if (authIntent != null) {
                    startActivityForResult(authIntent, RC_AUTH)
                }
            })
    }

    @Deprecated("Deprecated in Java")
    override fun onActivityResult(requestCode: Int, resultCode: Int, intent: Intent?) {
        super.onActivityResult(requestCode, resultCode, intent)
        if (requestCode != RC_AUTH) {
            return
        }
        val authResponse = AuthorizationResponse.fromIntent(intent!!)
        val authException = AuthorizationException.fromIntent(intent)
        authState = AuthState(authResponse, authException)

        // Handle authorization response error here
        retrieveTokens(authResponse!!)

        val mainActivityIntent = Intent(this, MainActivity::class.java)
        startActivity(mainActivityIntent)
    }

    private fun retrieveTokens(authResponse: AuthorizationResponse) {
        val tokenRequest: TokenRequest = authResponse.createTokenExchangeRequest()
        val service = AuthorizationService(this)
        service.performTokenRequest(
            tokenRequest, authClientAuthentication
        ) { tokenResponse, tokenException ->
            authState.update(tokenResponse, tokenException)

            if (tokenResponse != null) {
                runBlocking {
                    db.userSettingsDao().updateAccessToken(tokenResponse.accessToken!!)
                }
            }
        }
    }

    private fun prepareApiCall() {
        val service = AuthorizationService(this)
        authState.performActionWithFreshTokens(service, authClientAuthentication,
            AuthStateAction { accessToken, idToken, authException -> // Handle token refresh error here
                runBlocking {
                    executeApiCall(accessToken!!)
                }
            })
    }

    private fun executeApiCall(accessToken: String) : String {
        var client = OkHttpClient()

        var request = Request.Builder()
            .url("https://example.com/api/...") // API URL
            .addHeader("Authorization", String.format("Bearer %s", accessToken))
            .build()

        try {
            var response = client.newCall(request).execute()

            return response.body!!.string()
        } catch (e: Exception) {
            // Handle API error here
        }

        return ""
    }
}
