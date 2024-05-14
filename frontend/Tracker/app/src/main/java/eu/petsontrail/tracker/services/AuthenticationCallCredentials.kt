package eu.petsontrail.tracker.services

import io.grpc.CallCredentials
import io.grpc.Metadata
import io.grpc.Status
import java.util.concurrent.Executor


var META_DATA_KEY: Metadata.Key<String> =
    Metadata.Key.of("Authentication", Metadata.ASCII_STRING_MARSHALLER)

class AuthenticationCallCredentials(private val token: String) : CallCredentials() {
    override fun applyRequestMetadata(
        requestInfo: RequestInfo,
        executor: Executor,
        metadataApplier: MetadataApplier
    ) {
        executor.execute {
            try {
                val headers = Metadata()
                headers.put(META_DATA_KEY, "Bearer $token")
                metadataApplier.apply(headers)
            } catch (e: Throwable) {
                metadataApplier.fail(Status.UNAUTHENTICATED.withCause(e))
            }
        }
    }

    override fun thisUsesUnstableApi() {
        // yes this is unstable :(
    }
}