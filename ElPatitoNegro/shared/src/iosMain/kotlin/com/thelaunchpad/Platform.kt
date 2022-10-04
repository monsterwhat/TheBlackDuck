package com.thelaunchpad

import com.squareup.sqldelight.drivers.native.NativeSqliteDriver
import com.database.sqldelight.TLPDatabase

import platform.UIKit.UIDevice

class IOSPlatform: Platform {
    override val name: String = UIDevice.currentDevice.systemName() + " " + UIDevice.currentDevice.systemVersion
}

actual fun getPlatform(): Platform = IOSPlatform()

internal actual fun cache():TLPDatabase{
    val driver = NativeSqliteDriver(TLPDatabase.schema)
    return TLPDatabase(driver)
}