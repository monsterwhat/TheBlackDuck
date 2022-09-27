package com.thelaunchpad
import android.content.Context
import com.database.sqldelight.TLPDatabase
import com.squareup.sqldelight.android.AndroidSqliteDriver

lateinit var appContext: Context

class AndroidPlatform : Platform {
    override val name: String = "Android ${android.os.Build.VERSION.SDK_INT}"
}

actual fun getPlatform(): Platform = AndroidPlatform()

internal actual fun cache(): TLPDatabase{
    val driver = AndroidSqliteDriver(TLPDatabase.Schema, appContext)
    return TLPDatabase(driver)
}
