package eu.petsontrail.tracker.dtos

import java.util.UUID

data class PetTypeDto(
    val id: UUID,
    val name: String,
    val description: String
)
