package eu.petsontrail.tracker.ui.pets

import android.content.Context
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ArrayAdapter
import android.widget.TextView
import eu.petsontrail.tracker.dtos.ActivityTypeDto


class ActivityTypesAdapter(private val context: Context, private val arrayList: java.util.ArrayList<ActivityTypeDto>) : ArrayAdapter<ActivityTypeDto>(context, 0, arrayList) {
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
}