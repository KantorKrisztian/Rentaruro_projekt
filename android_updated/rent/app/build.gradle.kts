plugins {
    id("com.android.application")
    kotlin("android")
}

android {
    namespace = "com.example.rentaruro"

    // Legalább 26 kell az adaptive-icon-hoz, itt 34-et használunk
    compileSdk = 34

    defaultConfig {
        applicationId = "com.example.rentaruro"
        minSdk = 21
        targetSdk = 34       // Legalább 26 kell az adaptive-icon-hoz
        versionCode = 1
        versionName = "1.0"
    }

    buildTypes {
        release {
            // Kotlin DSL-ben így tiltod le a kódminifikálást
            isMinifyEnabled = false
            // (ha ProGuard/ R8 fájlokat is szeretnél megadni, itt teheted meg)
        }
    }

    compileOptions {
        sourceCompatibility = JavaVersion.VERSION_17
        targetCompatibility = JavaVersion.VERSION_17
    }
    kotlinOptions {
        jvmTarget = "17"
    }

    // Ha adaptive-icon helyett legacy ikonokat használsz, nem kell semmi extra
    // Ha marad adaptive, ezzel a compileSdk/targetSdk párossal már jó
}

dependencies {
    implementation("androidx.core:core-ktx:1.10.1")
    implementation("androidx.appcompat:appcompat:1.6.1")
    implementation("androidx.lifecycle:lifecycle-runtime-ktx:2.6.1")
    implementation("com.google.android.material:material:1.9.0")
    implementation("com.squareup.retrofit2:retrofit:2.9.0")
    implementation("com.squareup.retrofit2:converter-gson:2.9.0")
    implementation("org.jetbrains.kotlinx:kotlinx-coroutines-android:1.7.3")
}
