package com.example.rentaruro

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity

class LoginActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        setContentView(R.layout.login)

        // Layout elemek lekérése
        val etEmail    = findViewById<EditText>(R.id.et_login_email)
        val etPassword = findViewById<EditText>(R.id.et_login_password)
        val btnLogin   = findViewById<Button>(R.id.btn_login)
        val tvRegister = findViewById<TextView>(R.id.tv_go_register)

        // Bejelentkezés gomb eseménye
        btnLogin.setOnClickListener {
            val email = etEmail.text.toString().trim()
            val pass  = etPassword.text.toString()

            when {
                email.isEmpty() || pass.isEmpty() -> {
                    Toast.makeText(
                        this,
                        "Kérlek töltsd ki az összes mezőt",
                        Toast.LENGTH_SHORT
                    ).show()
                }
                else -> {
                    // TODO: itt hívd meg az API-d / hitelesítését
                    // Példa:
                    // if (authSuccess) { … } else { … }
                    Toast.makeText(
                        this,
                        "Sikeres bejelentkezés",
                        Toast.LENGTH_SHORT
                    ).show()

                    // Ha bejött, indítsd a fő Activity-t:
                    startActivity(Intent(this, MainActivity::class.java))
                    finish()
                }
            }
        }

        // Átirányítás a regisztrációs képernyőre
        tvRegister.setOnClickListener {
            startActivity(Intent(this, RegisterActivity::class.java))
            finish()
        }
    }
}
