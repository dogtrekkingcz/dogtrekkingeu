package eu.petsontrail.tracker

import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel

class ActivityViewModel : ViewModel() {
    val name: MutableLiveData<String> by lazy {
        MutableLiveData<String>()
    }

    val speed: MutableLiveData<Float> by lazy {
        MutableLiveData<Float>()
    }

    val distance: MutableLiveData<Float> by lazy {
        MutableLiveData<Float>()
    }

    val duration: MutableLiveData<Long> by lazy {
        MutableLiveData<Long>()
    }
}