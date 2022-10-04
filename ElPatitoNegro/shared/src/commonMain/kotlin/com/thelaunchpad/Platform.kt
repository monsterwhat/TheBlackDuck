package com.thelaunchpad
import com.database.sqldelight.TLPDatabase

interface Platform {
    val name: String
}

expect fun getPlatform(): Platform

internal expect fun cache(): TLPDatabase