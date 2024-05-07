import com.android.kotlin.multiplatform.models.AndroidSourceSet
import com.google.protobuf.gradle.*

plugins {
    alias(libs.plugins.androidApplication)
    alias(libs.plugins.jetbrainsKotlinAndroid)

    // KSP @ ROOM database
    id("com.google.devtools.ksp") version "1.9.21-1.0.15"

    // gRPC
    id("idea")
    id("com.google.protobuf") version "0.9.4"
}

android {
    namespace = "eu.petsontrail.tracker"
    compileSdk = 34

    defaultConfig {
        applicationId = "eu.petsontrail.tracker"
        minSdk = 24
        targetSdk = 34
        versionCode = 1
        versionName = "1.0"

        testInstrumentationRunner = "androidx.test.runner.AndroidJUnitRunner"

        // @ ROOM database
        ksp {
            arg("room.schemaLocation", "$projectDir/schemas")
        }
    }

    buildTypes {
        release {
            isMinifyEnabled = false
            proguardFiles(
                getDefaultProguardFile("proguard-android-optimize.txt"),
                "proguard-rules.pro"
            )
        }
    }
    compileOptions {
        sourceCompatibility = JavaVersion.VERSION_1_8
        targetCompatibility = JavaVersion.VERSION_1_8
    }
    kotlinOptions {
        jvmTarget = "1.8"
    }
    buildFeatures {
        viewBinding = true
    }
}

dependencies {
    implementation(libs.androidx.core.ktx)
    implementation(libs.androidx.appcompat)
    implementation(libs.material)
    implementation(libs.androidx.constraintlayout)
    implementation(libs.androidx.navigation.fragment.ktx)
    implementation(libs.androidx.navigation.ui.ktx)
    implementation(libs.androidx.room.common)
    implementation(libs.androidx.room.ktx)
    implementation(libs.play.services.location)
    testImplementation(libs.junit)
    androidTestImplementation(libs.androidx.junit)
    androidTestImplementation(libs.androidx.espresso.core)

    // ROOM database implementation
    val room_version = "2.6.1"
    implementation("androidx.room:room-runtime:$room_version")
    annotationProcessor("androidx.room:room-compiler:$room_version")
    implementation("androidx.room:room-ktx:$room_version")//KTX Extensions/Coroutines for Room
    ksp("androidx.room:room-compiler:$room_version")

    implementation("com.google.protobuf:protobuf-javalite:4.26.1")

    if (JavaVersion.current().isJava9Compatible()) {
        // Workaround for @javax.annotation.Generated
        // see: https://github.com/grpc/grpc-java/issues/3633
        implementation("javax.annotation:javax.annotation-api:1.3.1")
    }
/*
    protobuf(files("../../../Protos/Entities/ActionRights/"))
    protobuf(files("../../../Protos/Entities/Actions/"))
    protobuf(files("../../../Protos/Entities/Activities/"))
    protobuf(files("../../../Protos/Entities/Checkpoints/"))
    protobuf(files("../../../Protos/Entities/LiveUpdatesSubscription/"))
    protobuf(files("../../../Protos/Entities/Pets/"))
    protobuf(files("../../../Protos/Entities/Results/"))
    protobuf(files("../../../Protos/Entities/UserProfiles/"))

 */
    protobuf(files("../../../Protos.Java/"))
    protobuf(files("../../../Protos/"))
}

protobuf {
    protoc {
        artifact = "com.google.protobuf:protoc:4.26.1"
    }

    generateProtoTasks {
        all().forEach {
            it.builtins {
                create("java") {
                    option("lite")
                }
            }
        }
    }
}
