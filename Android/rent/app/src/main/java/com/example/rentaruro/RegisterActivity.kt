package com.example.rentaruro

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity

class RegisterActivity: AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        setContentView(R.layout.registration)

        // Layout elemek lekérése
        val etName     = findViewById<EditText>(R.id.et_reg_name)
        val etEmail    = findViewById<EditText>(R.id.et_reg_email)
        val etPass     = findViewById<EditText>(R.id.et_reg_password)
        val etPassConf = findViewById<EditText>(R.id.et_reg_password_confirm)
        val btnReg     = findViewById<Button>(R.id.btn_register)
        val tvLogin    = findViewById<TextView>(R.id.tv_go_login)

        // Regisztráció gomb eseménye
        btnReg.setOnClickListener {
            val name  = etName.text.toString().trim()
            val email = etEmail.text.toString().trim()
            val pass  = etPass.text.toString()
            val pass2 = etPassConf.text.toString()

            when {
                name.isEmpty() || email.isEmpty() || pass.isEmpty() || pass2.isEmpty() -> {
                    Toast.makeText(this,
                        "Kérlek töltsd ki az összes mezőt",
                        Toast.LENGTH_SHORT).show()
                }
                pass != pass2 -> {
                    Toast.makeText(this,
                        "A jelszavak nem egyeznek",
                        Toast.LENGTH_SHORT).show()
                }
                else -> {
                    // TODO: itt tedd meg a valódi regisztrációs logikát (API hívás stb.)
                    Toast.makeText(this,
                        "Sikeres regisztráció",
                        Toast.LENGTH_SHORT).show()
                    // Vissza a bejelentkező képernyőre
                    startActivity(Intent(this, LoginActivity::class.java))
                    finish()
                }
            }
        }

        // Átirányítás Bejelentkezés oldalra
        tvLogin.setOnClickListener {
            startActivity(Intent(this, LoginActivity::class.java))
            finish()
        }
    }
}