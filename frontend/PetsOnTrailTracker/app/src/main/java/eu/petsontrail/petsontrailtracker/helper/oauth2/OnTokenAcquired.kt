package eu.petsontrail.petsontrailtracker.helper.oauth2

import android.accounts.AccountManager
import android.accounts.AccountManagerCallback
import android.accounts.AccountManagerFuture
import android.app.Activity
import android.os.Bundle
import android.util.Log
import kotlinx.coroutines.runBlocking
import okhttp3.Call
import okhttp3.Callback
import okhttp3.MediaType;
import okhttp3.MultipartBody;
import okhttp3.OkHttpClient
import okhttp3.Request
import okhttp3.RequestBody;
import okhttp3.Response
import okhttp3.ResponseBody;
import okio.IOException


class OnTokenAcquired : AccountManagerCallback<Bundle> {

    override fun run(result: AccountManagerFuture<Bundle>) {
        // Get the result of the operation from the AccountManagerFuture.
        val bundle: Bundle = result.getResult()

        // The token is a named value in the bundle. The name of the value
        // is stored in the constant AccountManager.KEY_AUTHTOKEN.
        val token: String = bundle.getString(AccountManager.KEY_AUTHTOKEN)!!
    }
}