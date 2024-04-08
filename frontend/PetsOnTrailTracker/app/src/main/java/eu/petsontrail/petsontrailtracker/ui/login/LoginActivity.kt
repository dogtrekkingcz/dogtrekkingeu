package eu.petsontrail.petsontrailtracker.ui.login

import android.content.ContentValues.TAG
import android.content.Intent
import android.net.Uri
import android.os.Bundle
import android.util.Log
import androidx.appcompat.app.AppCompatActivity
import net.openid.appauth.AuthorizationException
import net.openid.appauth.AuthorizationRequest
import net.openid.appauth.AuthorizationResponse
import net.openid.appauth.AuthorizationService
import net.openid.appauth.AuthorizationServiceConfiguration
import net.openid.appauth.ResponseTypeValues


class LoginActivity : AppCompatActivity() {
    private var RC_AUTH: Int = 3254

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        var serviceConfig: AuthorizationServiceConfiguration? = null

        AuthorizationServiceConfiguration.fetchFromIssuer(
            Uri.parse("https://petsontrail.eu:8443/realms/PetsOnTrail"),
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
                            "tracker-app",  // the client ID, typically pre-registered and static
                            ResponseTypeValues.CODE,  // the response_type value: we want a code
                            Uri.parse("petsontrail:/tracker")
                        )
                    }

                val authRequest = authRequestBuilder
                    ?.setScope("openid email profile")
                    ?.setLoginHint("jdoe@user.example.com")
                    ?.build()

                val authService = AuthorizationService(this)
                val authIntent = authRequest?.let { authService.getAuthorizationRequestIntent(it) }

                if (authIntent != null) {
                    startActivityForResult(authIntent, RC_AUTH)
                }
            })
    }

    override fun onActivityResult(requestCode: Int, resultCode: Int, data: Intent?) {
        super.onActivityResult(requestCode, resultCode, data)
        if (requestCode == RC_AUTH) {
            val resp = AuthorizationResponse.fromIntent(data!!)
            val ex = AuthorizationException.fromIntent(data)
            // ... process the response or exception ...
        } else {
            // ...
        }
    }
}
