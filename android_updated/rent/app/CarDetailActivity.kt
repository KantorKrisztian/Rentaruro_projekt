package com.example.rentaruro


import android.app.AlertDialog
import android.os.Bundle
import android.view.LayoutInflater
import android.widget.Button
import android.widget.EditText
import android.widget.ImageView
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity

class CarDetailActivity : AppCompatActivity() {

    // Ez például lehet a bejelentkezés állapotát tároló változó
    private var isLoggedIn = false

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.car_card)

        // Vissza gomb kezelése
        findViewById<ImageView>(R.id.back_button).setOnClickListener {
            finish()
        }

        // Cím beállítása intentből
        val carName = intent.getStringExtra("carName") ?: "Autó neve"
        findViewById<TextView>(R.id.detail_title).text = carName

        // Foglalás gomb
        findViewById<Button>(R.id.btn_book_car).setOnClickListener {
            if (!isLoggedIn) {
                showBookingDialog()
            } else {
                // TODO: tovább a valós foglalási folyamathoz
            }
        }
    }

    private fun showBookingDialog() {
        // Layout betöltése
        val dialogView = LayoutInflater.from(this)
            .inflate(R.layout.foglalas, null)

        // EditText-ek lekérése (ha később ki akarod olvasni)
        val etName      = dialogView.findViewById<EditText>(R.id.et_name)
        val etPhone     = dialogView.findViewById<EditText>(R.id.et_phone)
        val etEmail     = dialogView.findViewById<EditText>(R.id.et_email)
        val etStartDate = dialogView.findViewById<EditText>(R.id.et_start_date)
        val etEndDate   = dialogView.findViewById<EditText>(R.id.et_end_date)
        val etNotes     = dialogView.findViewById<EditText>(R.id.et_notes)

        // AlertDialog összeállítása
        val dialog = AlertDialog.Builder(this)
            .setView(dialogView)
            .setPositiveButton("Küldés") { dlg, _ ->
                // Itt olvasd ki az értékeket és küldd el / ellenőrizd
                val name  = etName.text.toString()
                val phone = etPhone.text.toString()
                // ...
                dlg.dismiss()
            }
            .setNegativeButton("Mégse") { dlg, _ ->
                dlg.dismiss()
            }
            .create()

        dialog.show()
    }
}
