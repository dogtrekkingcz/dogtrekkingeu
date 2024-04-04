package eu.petsontrail.petsontrailtracker.PetListSelector

import android.content.Context
import android.widget.AdapterView
import android.widget.ListView
import eu.petsontrail.petsontrailtracker.data.AppDatabase
import eu.petsontrail.petsontrailtracker.data.PetDto
import eu.petsontrail.petsontrailtracker.helper.DbHelper
import kotlinx.coroutines.runBlocking

class RawPetListView {
    private var selectedPets: ArrayList<RawPetListItemDataModel>? = null
    private lateinit var _db: AppDatabase
    private var _context: Context
    private var _petListView: ListView

    constructor(context: Context, petListView: ListView) {
        _context = context
        _petListView = petListView
    }

    fun reload() {
        _db = DbHelper().InitializeDatabase(_context)

        runBlocking {
            var adapter: RawPetListAdapter

            selectedPets = ArrayList<RawPetListItemDataModel>()

            var pets = _db.petDao().getAll()
            for (pet in pets) {
                selectedPets!!.add(RawPetListItemDataModel(pet, false))
            }

            adapter = RawPetListAdapter(selectedPets!!, _context)
            _petListView.adapter = adapter

            // Upon item click, checkbox will be set to checked
            _petListView.onItemClickListener = AdapterView.OnItemClickListener { _, _, position, _ ->
                val dataModel: RawPetListItemDataModel = selectedPets!![position] as RawPetListItemDataModel
                dataModel.checked = !dataModel.checked
                adapter.notifyDataSetChanged()
            }
        }
    }

    fun SelectedPets() : ArrayList<PetDto> {
        var ret = ArrayList<PetDto>()

        for (pet in selectedPets!!) {
            if (pet.checked) {
                ret.add(pet.pet!!)
            }
        }

        return ret
    }
}