package eu.petsontrail.tracker.data

import android.net.Uri
import android.util.Log
import eu.petsontrail.tracker.data.model.LoggedInUser
import net.openid.appauth.AuthorizationServiceConfiguration
import net.openid.appauth.AuthorizationServiceConfiguration.RetrieveConfigurationCallback
import java.io.IOException


// TODO:
//  fill in the authentication by this howto:
//  https://github.com/openid/AppAuth-Android/tree/c6137b7db306d9c097c0d5763f3fb944cd0122d2

/**
 * Class that handles authentication w/ login credentials and retrieves user information.
 */
class LoginDataSource {
    private var TAG: String = "LoginDataSource"

    fun login(username: String, password: String): Result<LoggedInUser> {
        try {
            AuthorizationServiceConfiguration.fetchFromIssuer(
                Uri.parse("https://petsontrail.eu:8443"),
                RetrieveConfigurationCallback { serviceConfiguration, ex ->
                    if (ex != null) {
                        Log.e(TAG, "failed to fetch configuration")
                        return@RetrieveConfigurationCallback
                    }

                    // use serviceConfiguration as needed
                })
            // TODO: handle loggedInUser authentication
            val fakeUser = LoggedInUser(java.util.UUID.randomUUID().toString(), "Jane Doe")
            return Result.Success(fakeUser)
        } catch (e: Throwable) {
            return Result.Error(IOException("Error logging in", e))
        }
    }

    fun logout() {
        // TODO: revoke authentication
    }
}