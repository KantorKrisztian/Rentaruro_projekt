package com.example.rentaruro

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import androidx.lifecycle.lifecycleScope
import com.example.rentaruro.model.RegisterRequest
import com.example.rentaruro.network.RetrofitClient
import kotlinx.coroutines.launch

class RegisterActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.registration)

        val etName     = findViewById<EditText>(R.id.et_reg_name)
        val etEmail    = findViewById<EditText>(R.id.et_reg_email)
        val etPhone     = findViewById<EditText>(R.id.et_reg_phone)
        val etUsername     = findViewById<EditText>(R.id.et_reg_username)
        val etPass     = findViewById<EditText>(R.id.et_reg_password)
        val etPassConf = findViewById<EditText>(R.id.et_reg_password_confirm)
        val btnReg     = findViewById<Button>(R.id.btn_register)
        val tvLogin    = findViewById<TextView>(R.id.tv_go_login)

        btnReg.setOnClickListener {
            val name  = etName.text.toString().trim()
            val username  = etUsername.text.toString().trim()
            val phone=etPhone.text.toString().trim()
            val email = etEmail.text.toString().trim()
            val pass  = etPass.text.toString()
            val pass2 = etPassConf.text.toString()
            if (name.isEmpty() || email.isEmpty() || pass.isEmpty() || pass2.isEmpty()||username.isEmpty()||phone.isEmpty()) {
                Toast.makeText(this, "Töltsd ki az összes mezőt", Toast.LENGTH_SHORT).show()
                return@setOnClickListener
            }
            if (pass != pass2) {
                Toast.makeText(this, "A jelszavak nem egyeznek", Toast.LENGTH_SHORT).show()
                return@setOnClickListener
            }
            lifecycleScope.launch {
                try {
                    val res = RetrofitClient.apiService.register(
                        RegisterRequest(
                            registerNev = name,
                            registerPassword = pass,
                            registerName = username, // Assuming 'name' from the input maps to 'registerName' on the server
                            registerEmail = email,
                            registerPhone = phone
                        )
                    )
                    Toast.makeText(this@RegisterActivity, res.message, Toast.LENGTH_SHORT).show()
                    startActivity(Intent(this@RegisterActivity, LoginActivity::class.java))
                    finish()
                } catch (e: Exception) {
                    Toast.makeText(this@RegisterActivity, "Hiba: ${e.message}", Toast.LENGTH_LONG).show()
                }
            }
        }

        tvLogin.setOnClickListener {
            startActivity(Intent(this, LoginActivity::class.java))
        }
    }
}