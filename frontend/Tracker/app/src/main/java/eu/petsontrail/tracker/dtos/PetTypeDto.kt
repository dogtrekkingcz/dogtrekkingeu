package eu.petsontrail.tracker.dtos

import java.util.UUID

data class MyPetDto(
    val id: UUID,
    val name: String,
    val chip: String
)
