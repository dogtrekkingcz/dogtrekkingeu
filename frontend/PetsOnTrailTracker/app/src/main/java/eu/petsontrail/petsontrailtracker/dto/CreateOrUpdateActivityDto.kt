package eu.petsontrail.petsontrailtracker.dto

import androidx.room.ColumnInfo
import java.time.LocalDateTime
import java.util.UUID

data class CreateOrUpdateActivityDto(
    val id: UUID,
    val actionId: UUID?,
    val raceId: UUID?,
    val categoryId: UUID?,
    val name: String?,
    val description: String?,
    val start: LocalDateTime?,
    val end: LocalDateTime?,
    val isPublic: Boolean,
    val positions: Array<CreateOrUpdateActivityPositionDto>,
    val pets: Array<CreateOrUpdateActivityPetDto>,
)

data class CreateOrUpdateActivityPositionDto(
    val id: UUID,
    val time: LocalDateTime,
    val latitude: Double?,
    val longitude: Double?,
    val altitude: Double?,
    val accuracy: Float?,
    val course: Long?,
    val note: String?,
    val photoUris: Array<String>?
)

data class CreateOrUpdateActivityPetDto(
    val id: UUID,
    val chip: String?,
    val name: String?,
    val breed: String?,
    val color: String?,
    val kennel: String?,
    val birthDate: LocalDateTime?
)