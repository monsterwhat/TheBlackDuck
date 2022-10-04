package com.thelaunchpad

import io.realm.kotlin.Realm
import io.realm.kotlin.RealmConfiguration
import io.realm.kotlin.ext.query
import io.realm.kotlin.notifications.ResultsChange
import io.realm.kotlin.notifications.UpdatedResults
import io.realm.kotlin.query.RealmResults
import io.realm.kotlin.types.ObjectId
import io.realm.kotlin.types.RealmObject
import io.realm.kotlin.types.annotations.PrimaryKey
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch

class Greeting {

    private val platform: Platform = getPlatform()

    fun greeting(): String {

        class administradores() : RealmObject {
            @PrimaryKey
            var idAdministrador: ObjectId = ObjectId.create()
            var codAdminstrador: Int = 0
            var userAdministrador: String = ""
            var passAdministrador: String = ""
        }

        class clientesPagos(): RealmObject {
            @PrimaryKey
            var idClientePagos: ObjectId = ObjectId.create()
            var montoPagos: Double = 0.0
            var fechaPago: String = ""
            var estadoPago: Int = 0
        }

        class superAdministradores(): RealmObject {
            @PrimaryKey
            var idSuperAdmin: ObjectId = ObjectId.create()
            var superAdminUser: String =""
            var superAdminPass: String =""
        }

        class clientes(): RealmObject {
            @PrimaryKey
            var idCliente: ObjectId = ObjectId.create()
            var clienteHijo: String = ""
            var clientePadre: String = ""
            var idClientePagos: Int = 0
            var clienteNumero: Int = 0
            var clientePass: String = ""
        }

        val config = RealmConfiguration.Builder(schema = setOf(administradores::class,superAdministradores::class,clientes::class,clientesPagos::class))
            .build()
        val realm: Realm = Realm.open(config)

        realm.writeBlocking {
            copyToRealm(administradores().apply {
                codAdminstrador = 1
                userAdministrador = "Al"
                passAdministrador = "1234"
            })
        }

        val items: RealmResults<administradores> = realm.query<administradores>().find()


        // delete the first item in the realm
        realm.writeBlocking {
            val writeTransactionItems = query<administradores>().find()
            delete(writeTransactionItems.first())
        }

        // flow.collect() is blocking -- run it in a background context
        val job = CoroutineScope(Dispatchers.Default).launch {
            // create a Flow from the Item collection, then add a listener to the Flow
            val itemsFlow = items.asFlow()
            itemsFlow.collect { changes: ResultsChange<administradores> ->
                when (changes) {
                    // UpdatedResults means this change represents an update/insert/delete operation
                    is UpdatedResults -> {
                        changes.insertions // indexes of inserted objects
                        changes.insertionRanges // ranges of inserted objects
                        changes.changes // indexes of modified objects
                        changes.changeRanges // ranges of modified objects
                        changes.deletions // indexes of deleted objects
                        changes.deletionRanges // ranges of deleted objects
                        changes.list // the full collection of objects
                    }
                    else -> {
                        // types other than UpdatedResults are not changes -- ignore them
                    }
                }
            }
        }
        job.cancel() // cancel the coroutine containing the listener
        realm.close()


        //return "Hello, ${platform.name}!"

        return "These are the Admins! " + items.toString()
    }
}