package eu.petsontrail.tracker.ui.pets

import android.content.Context
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ArrayAdapter
import android.widget.Filter
import android.widget.Filterable
import android.widget.TextView
import eu.petsontrail.tracker.dtos.ActivityTypeDto


class ActivityTypesAdapter(private val context: Context, private var arrayList: java.util.ArrayList<ActivityTypeDto>) : ArrayAdapter<ActivityTypeDto>(context, 0, arrayList),
    Filterable {
    override fun getView(position: Int, convertView: View?, parent: ViewGroup): View {
        var convertView = convertView

        convertView = LayoutInflater.from(context).inflate(eu.petsontrail.tracker.R.layout.layout_pet_type_row, parent, false)

        var nameTextView = convertView.findViewById(eu.petsontrail.tracker.R.id.name) as TextView
        var descriptionTextView = convertView.findViewById(eu.petsontrail.tracker.R.id.description) as TextView

        nameTextView.text = arrayList[position].name
        descriptionTextView.text = arrayList[position].description

        return convertView
    }

    override fun getCount(): Int {
        return arrayList.size
    }
    override fun getItem(position: Int): ActivityTypeDto {
        return arrayList[position]
    }

    override fun getItemId(position: Int): Long {
        return position.toLong()
    }

    override fun getFilter(): Filter {
        val filter: Filter = object : Filter() {
            override fun performFiltering(constraint: CharSequence): FilterResults {
                val filterResults = FilterResults()
                if (constraint != null) {
                    // Retrieve the autocomplete results.
                    arrayList = autocomplete(constraint.toString())

                    // Assign the data to the FilterResults
                    filterResults.values = arrayList
                    filterResults.count = arrayList.size
                }
                return filterResults
            }

            override fun publishResults(constraint: CharSequence, results: FilterResults) {
                if (results != null && results.count > 0) {
                    notifyDataSetChanged()
                } else {
                    notifyDataSetInvalidated()
                }
            }
        }
        return filter
    }

    private fun autocomplete(constraint: String): ArrayList<ActivityTypeDto> {
        val results = ArrayList<ActivityTypeDto>()
        for (activityType in arrayList) {
            if (activityType.name.lowercase().contains(constraint.toString().lowercase())) {
                results.add(activityType)
            }
        }
        return results
    }
}