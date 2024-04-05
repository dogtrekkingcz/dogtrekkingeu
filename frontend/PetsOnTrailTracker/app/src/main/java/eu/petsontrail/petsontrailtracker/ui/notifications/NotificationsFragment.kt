package eu.petsontrail.petsontrailtracker.ui.notifications

import android.content.Intent
import android.net.Uri
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import androidx.credentials.CredentialManager
import androidx.fragment.app.Fragment
import androidx.lifecycle.ViewModelProvider
import eu.petsontrail.petsontrailtracker.databinding.FragmentNotificationsBinding
import net.openid.appauth.AuthorizationException
import net.openid.appauth.AuthorizationRequest
import net.openid.appauth.AuthorizationResponse
import net.openid.appauth.AuthorizationService
import net.openid.appauth.AuthorizationServiceConfiguration
import net.openid.appauth.ResponseTypeValues


class NotificationsFragment : Fragment() {
    private var RC_AUTH: Int = 11122
    private var TAG: String = "User settings"

    private var _binding: FragmentNotificationsBinding? = null

    // This property is only valid between onCreateView and
    // onDestroyView.
    private val binding get() = _binding!!

    private lateinit var credentialManager: CredentialManager

    override fun onCreateView(
            inflater: LayoutInflater,
            container: ViewGroup?,
            savedInstanceState: Bundle?
    ): View {
        val notificationsViewModel =
                ViewModelProvider(this).get(NotificationsViewModel::class.java)

        _binding = FragmentNotificationsBinding.inflate(inflater, container, false)
        val root: View = binding.root
        var context = this.requireContext()

        val btnLogin: Button = binding.btnUserLogin
        btnLogin.setOnClickListener {
            val serviceConfig = AuthorizationServiceConfiguration(
                Uri.parse("https://petsontrail.eu:8443/auth/realms/petsontrail.eu/account"),
                Uri.parse("https://petsontrail.eu:8443/realms/petsontrail.eu/") // token endpoint
            )

            val clientId = "public"
            val redirectUri = Uri.parse("eu.petsontrail.petsontrailtracker.appauth:/oauth2callback")
            val builder = AuthorizationRequest.Builder(
                serviceConfig,
                clientId,
                ResponseTypeValues.CODE,
                redirectUri
            )
            builder.setScopes("profile")

            val authRequest = builder.build()

            val authService = AuthorizationService(requireContext())
            val authIntent = authService.getAuthorizationRequestIntent(authRequest)
            startActivityForResult(authIntent, RC_AUTH)
        }

        return root
    }

    override fun onDestroyView() {
        super.onDestroyView()
        _binding = null
    }

    override fun onActivityResult(requestCode: Int, resultCode: Int, data: Intent?) {
        if (requestCode == RC_AUTH) {
            val resp = AuthorizationResponse.fromIntent(data!!)
            val ex = AuthorizationException.fromIntent(data)

            // … process the response or exception …
        } else {

            // …
        }
    }
}