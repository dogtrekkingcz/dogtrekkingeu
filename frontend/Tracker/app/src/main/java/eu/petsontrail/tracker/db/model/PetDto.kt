package eu.petsontrail.tracker.db.model

import androidx.room.ColumnInfo
import androidx.room.Entity
import androidx.room.PrimaryKey
import eu.petsontrail.tracker.services.CreateOrUpdateActivityPetDto
import java.time.LocalDate
import java.util.Date
import java.util.UUID

@Entity(tableName = "pets")
data class PetDto(
    @PrimaryKey val uid: UUID,
    @ColumnInfo(name = "group") val groupId: UUID,
    @ColumnInfo(name = "name") val name: String?,
    @ColumnInfo(name = "kennel") val kennel: String?,
    @ColumnInfo(name = "chip") val chip: String?,
    @ColumnInfo(name = "birthday") val birthday: Long?,
    @ColumnInfo(name = "breed") val breed: String?,
    @ColumnInfo(name = "color") val color: String?
)
