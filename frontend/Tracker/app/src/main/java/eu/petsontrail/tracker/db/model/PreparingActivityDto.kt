package eu.petsontrail.tracker.db.model

import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.PrimaryKey
import java.util.UUID

@Entity(tableName = "preparing_activity")
data class PreparingActivityDto(
    @PrimaryKey val uid: UUID,
    @ColumnInfo(name = "name") val name: String?,
    @ColumnInfo(name = "description") val description: String?,
    @ColumnInfo(name = "type") val type: UUID?,
    @ColumnInfo(name = "action_id") val actionId: UUID?,
    @ColumnInfo(name = "pet01") var pet_01: UUID?,
    @ColumnInfo(name = "pet02") var pet_02: UUID?,
    @ColumnInfo(name = "pet03") var pet_03: UUID?,
    @ColumnInfo(name = "pet04") var pet_04: UUID?,
    @ColumnInfo(name = "pet05") var pet_05: UUID?,
    @ColumnInfo(name = "pet06") var pet_06: UUID?,
    @ColumnInfo(name = "pet07") var pet_07: UUID?,
    @ColumnInfo(name = "pet08") var pet_08: UUID?,
    @ColumnInfo(name = "pet09") var pet_09: UUID?,
    @ColumnInfo(name = "pet10") var pet_10: UUID?,
    @ColumnInfo(name = "pet11") var pet_11: UUID?,
    @ColumnInfo(name = "pet12") var pet_12: UUID?,
    @ColumnInfo(name = "pet13") var pet_13: UUID?,
    @ColumnInfo(name = "pet14") var pet_14: UUID?,
    @ColumnInfo(name = "pet15") var pet_15: UUID?,
    @ColumnInfo(name = "pet16") var pet_16: UUID?,
    @ColumnInfo(name = "pet17") var pet_17: UUID?,
    @ColumnInfo(name = "pet18") var pet_18: UUID?,
    @ColumnInfo(name = "pet19") var pet_19: UUID?,
    @ColumnInfo(name = "pet20") var pet_20: UUID?,
    @ColumnInfo(name = "pet21") var pet_21: UUID?,
    @ColumnInfo(name = "pet22") var pet_22: UUID?,
    @ColumnInfo(name = "pet23") var pet_23: UUID?,
    @ColumnInfo(name = "pet24") var pet_24: UUID?,
    @ColumnInfo(name = "pet25") var pet_25: UUID?,
    @ColumnInfo(name = "pet26") var pet_26: UUID?,
    @ColumnInfo(name = "pet27") var pet_27: UUID?,
    @ColumnInfo(name = "pet28") var pet_28: UUID?,
    @ColumnInfo(name = "pet29") var pet_29: UUID?,
    @ColumnInfo(name = "pet30") var pet_30: UUID?
)
