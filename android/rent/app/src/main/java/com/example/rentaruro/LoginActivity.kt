package com.example.rentaruro

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import androidx.lifecycle.lifecycleScope
import com.example.rentaruro.model.LoginRequest
import com.example.rentaruro.network.RetrofitClient
import kotlinx.coroutines.launch

class LoginActivity : AppCompatActivity() {

    private lateinit var etUsername: EditText
    private lateinit var etPassword: EditText
    private lateinit var btnLogin: Button
    private lateinit var tvRegister: TextView

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.login)

        // Initialize views
        etUsername = findViewById(R.id.et_login_email) // Reusing the same EditText, but will change hint
        etPassword = findViewById(R.id.et_login_password)
        btnLogin = findViewById(R.id.btn_login)
        tvRegister = findViewById(R.id.tv_go_register)

        // Set the hint for the username field
        etUsername.hint = "Felhasználónév"

        btnLogin.setOnClickListener {
            attemptLogin()
        }

        tvRegister.setOnClickListener {
            navigateToRegister()
        }
    }

    private fun attemptLogin() {
        val username = etUsername.text.toString().trim()
        val password = etPassword.text.toString()

        if (username.isEmpty() || password.isEmpty()) {
            showToast("Töltsd ki az összes mezőt")
            return
        }

        lifecycleScope.launch {
            try {
                val loginRequest = LoginRequest(loginNev = username, loginPassword = password)
                val response = RetrofitClient.apiService.login(loginRequest)

                // Store the JWT token securely
                getSharedPreferences("prefs", MODE_PRIVATE)
                    .edit()
                    .putString("jwt", response.token)
                    .apply()

                showToast(response.message)

                navigateToMain()
            } catch (e: Exception) {
                showToast("Hiba: ${e.message}")
            }
        }
    }

    private fun navigateToRegister() {
        startActivity(Intent(this, RegisterActivity::class.java))
    }

    private fun navigateToMain() {
        startActivity(Intent(this, MainActivity::class.java))
        finish() // Prevent going back to the login screen
    }

    private fun showToast(message: String) {
        Toast.makeText(this, message, Toast.LENGTH_SHORT).show()
    }
}