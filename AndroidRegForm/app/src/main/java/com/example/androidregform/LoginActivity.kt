package com.example.androidregform

import android.content.Intent
import android.os.Bundle
import android.util.Patterns
import android.widget.Button
import android.widget.EditText
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity

class LoginActivity : AppCompatActivity() {

    private lateinit var emailInput: EditText
    private lateinit var passwordInput: EditText
    private lateinit var loginButton: Button

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        emailInput = findViewById(R.id.editTextEmailLogin)
        passwordInput = findViewById(R.id.editTextPasswordLogin)
        loginButton = findViewById(R.id.buttonLogin)

        loginButton.setOnClickListener {
            val email = emailInput.text.toString().trim()
            val password = passwordInput.text.toString()

            if (validateInput(email, password)) {
                Toast.makeText(this, "Добро пожаловать!", Toast.LENGTH_SHORT).show()
                // Переход на MainActivity
                val intent = Intent(this, MainActivity::class.java)
                startActivity(intent)
                finish() // Закрываем LoginActivity
            }
        }
    }

    private fun validateInput(email: String, password: String): Boolean {
        if (email.isEmpty() || !Patterns.EMAIL_ADDRESS.matcher(email).matches()) {
            emailInput.error = "Введите корректный email"
            return false
        }

        if (password.length < 6) {
            passwordInput.error = "Пароль минимум 6 символов"
            return false
        }

        return true
    }
}