; ModuleID = 'marshal_methods.arm64-v8a.ll'
source_filename = "marshal_methods.arm64-v8a.ll"
target datalayout = "e-m:e-i8:8:32-i16:16:32-i64:64-i128:128-n32:64-S128"
target triple = "aarch64-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [182 x ptr] zeroinitializer, align 8

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [364 x i64] [
	i64 98382396393917666, ; 0: Microsoft.Extensions.Primitives.dll => 0x15d8644ad360ce2 => 70
	i64 120698629574877762, ; 1: Mono.Android => 0x1accec39cafe242 => 181
	i64 131669012237370309, ; 2: Microsoft.Maui.Essentials.dll => 0x1d3c844de55c3c5 => 75
	i64 196720943101637631, ; 3: System.Linq.Expressions.dll => 0x2bae4a7cd73f3ff => 134
	i64 210515253464952879, ; 4: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 87
	i64 232391251801502327, ; 5: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 104
	i64 560278790331054453, ; 6: System.Reflection.Primitives => 0x7c6829760de3975 => 152
	i64 683390398661839228, ; 7: Microsoft.Extensions.FileProviders.Embedded => 0x97be3f26326c97c => 63
	i64 738719460296176884, ; 8: Microsoft.AspNetCore.Components.WebAssembly.Authentication => 0xa40756f6b9f34f4 => 53
	i64 750875890346172408, ; 9: System.Threading.Thread => 0xa6ba5a4da7d1ff8 => 170
	i64 799765834175365804, ; 10: System.ComponentModel.dll => 0xb1956c9f18442ac => 124
	i64 805302231655005164, ; 11: hu\Microsoft.Maui.Controls.resources.dll => 0xb2d021ceea03bec => 12
	i64 870603111519317375, ; 12: SQLitePCLRaw.lib.e_sqlite3.android => 0xc1500ead2756d7f => 80
	i64 872800313462103108, ; 13: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 92
	i64 875677659902526502, ; 14: IdentityModel.dll => 0xc270831303c4426 => 43
	i64 1010599046655515943, ; 15: System.Reflection.Primitives.dll => 0xe065e7a82401d27 => 152
	i64 1120440138749646132, ; 16: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 110
	i64 1268860745194512059, ; 17: System.Drawing.dll => 0x119be62002c19ebb => 129
	i64 1301485588176585670, ; 18: SQLitePCLRaw.core => 0x120fce3f338e43c6 => 79
	i64 1369545283391376210, ; 19: Xamarin.AndroidX.Navigation.Fragment.dll => 0x13019a2dd85acb52 => 100
	i64 1404195534211153682, ; 20: System.IO.FileSystem.Watcher.dll => 0x137cb4660bd87f12 => 133
	i64 1436912622218371485, ; 21: Mapster.DependencyInjection => 0x13f0f06ab499e19d => 47
	i64 1476839205573959279, ; 22: System.Net.Primitives.dll => 0x147ec96ece9b1e6f => 141
	i64 1486715745332614827, ; 23: Microsoft.Maui.Controls.dll => 0x14a1e017ea87d6ab => 72
	i64 1513467482682125403, ; 24: Mono.Android.Runtime => 0x1500eaa8245f6c5b => 180
	i64 1518315023656898250, ; 25: SQLitePCLRaw.provider.e_sqlite3 => 0x151223783a354eca => 81
	i64 1537168428375924959, ; 26: System.Threading.Thread.dll => 0x15551e8a954ae0df => 170
	i64 1624659445732251991, ; 27: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 84
	i64 1628611045998245443, ; 28: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 97
	i64 1743969030606105336, ; 29: System.Memory.dll => 0x1833d297e88f2af8 => 137
	i64 1767386781656293639, ; 30: System.Private.Uri.dll => 0x188704e9f5582107 => 147
	i64 1769105627832031750, ; 31: Google.Protobuf => 0x188d203205129a06 => 37
	i64 1776954265264967804, ; 32: Microsoft.JSInterop.dll => 0x18a9027d533bd07c => 71
	i64 1795316252682057001, ; 33: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 83
	i64 1825687700144851180, ; 34: System.Runtime.InteropServices.RuntimeInformation.dll => 0x1956254a55ef08ec => 155
	i64 1835311033149317475, ; 35: es\Microsoft.Maui.Controls.resources => 0x197855a927386163 => 6
	i64 1836611346387731153, ; 36: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 104
	i64 1875417405349196092, ; 37: System.Drawing.Primitives => 0x1a06d2319b6c713c => 128
	i64 1881198190668717030, ; 38: tr\Microsoft.Maui.Controls.resources => 0x1a1b5bc992ea9be6 => 28
	i64 1888734231285419719, ; 39: Blazored.LocalStorage => 0x1a3621c6c2e34ec7 => 36
	i64 1920760634179481754, ; 40: Microsoft.Maui.Controls.Xaml => 0x1aa7e99ec2d2709a => 73
	i64 1972385128188460614, ; 41: System.Security.Cryptography.Algorithms => 0x1b5f51d2edefbe46 => 161
	i64 1981742497975770890, ; 42: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 96
	i64 2102659300918482391, ; 43: System.Drawing.Primitives.dll => 0x1d2e257e6aead5d7 => 128
	i64 2165725771938924357, ; 44: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 85
	i64 2262844636196693701, ; 45: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 92
	i64 2287834202362508563, ; 46: System.Collections.Concurrent => 0x1fc00515e8ce7513 => 117
	i64 2295368378960711535, ; 47: Microsoft.AspNetCore.Components.WebView.Maui.dll => 0x1fdac961189e0f6f => 55
	i64 2329709569556905518, ; 48: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 95
	i64 2335503487726329082, ; 49: System.Text.Encodings.Web => 0x2069600c4d9d1cfa => 165
	i64 2470498323731680442, ; 50: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 88
	i64 2497223385847772520, ; 51: System.Runtime => 0x22a7eb7046413568 => 159
	i64 2547086958574651984, ; 52: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 82
	i64 2602673633151553063, ; 53: th\Microsoft.Maui.Controls.resources => 0x241e8de13a460e27 => 27
	i64 2632269733008246987, ; 54: System.Net.NameResolution => 0x2487b36034f808cb => 139
	i64 2656907746661064104, ; 55: Microsoft.Extensions.DependencyInjection => 0x24df3b84c8b75da8 => 59
	i64 2662981627730767622, ; 56: cs\Microsoft.Maui.Controls.resources => 0x24f4cfae6c48af06 => 2
	i64 2781169761569919449, ; 57: Microsoft.JSInterop => 0x2698b329b26ed1d9 => 71
	i64 2895129759130297543, ; 58: fi\Microsoft.Maui.Controls.resources => 0x282d912d479fa4c7 => 7
	i64 3017704767998173186, ; 59: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 110
	i64 3266690593535380875, ; 60: Microsoft.AspNetCore.Authorization => 0x2d559dc982c94d8b => 48
	i64 3289520064315143713, ; 61: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 94
	i64 3311221304742556517, ; 62: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 145
	i64 3325875462027654285, ; 63: System.Runtime.Numerics => 0x2e27e21c8958b48d => 158
	i64 3328853167529574890, ; 64: System.Net.Sockets.dll => 0x2e327651a008c1ea => 144
	i64 3344514922410554693, ; 65: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x2e6a1a9a18463545 => 112
	i64 3396143930648122816, ; 66: Microsoft.Extensions.FileProviders.Abstractions => 0x2f2186e9506155c0 => 61
	i64 3429672777697402584, ; 67: Microsoft.Maui.Essentials => 0x2f98a5385a7b1ed8 => 75
	i64 3494946837667399002, ; 68: Microsoft.Extensions.Configuration => 0x30808ba1c00a455a => 56
	i64 3522470458906976663, ; 69: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 105
	i64 3536216251757907477, ; 70: BlazorBootstrap.dll => 0x311329f1fefe4e15 => 35
	i64 3551103847008531295, ; 71: System.Private.CoreLib.dll => 0x31480e226177735f => 178
	i64 3567343442040498961, ; 72: pt\Microsoft.Maui.Controls.resources => 0x3181bff5bea4ab11 => 22
	i64 3571415421602489686, ; 73: System.Runtime.dll => 0x319037675df7e556 => 159
	i64 3638003163729360188, ; 74: Microsoft.Extensions.Configuration.Abstractions => 0x327cc89a39d5f53c => 57
	i64 3647754201059316852, ; 75: System.Xml.ReaderWriter => 0x329f6d1e86145474 => 175
	i64 3655542548057982301, ; 76: Microsoft.Extensions.Configuration.dll => 0x32bb18945e52855d => 56
	i64 3716579019761409177, ; 77: netstandard.dll => 0x3393f0ed5c8c5c99 => 177
	i64 3727469159507183293, ; 78: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 103
	i64 3753897248517198740, ; 79: Microsoft.AspNetCore.Components.WebView.dll => 0x341885a8952f1394 => 54
	i64 3869221888984012293, ; 80: Microsoft.Extensions.Logging.dll => 0x35b23cceda0ed605 => 67
	i64 3889433610606858880, ; 81: Microsoft.Extensions.FileProviders.Physical.dll => 0x35fa0b4301afd280 => 64
	i64 3890352374528606784, ; 82: Microsoft.Maui.Controls.Xaml.dll => 0x35fd4edf66e00240 => 73
	i64 3932735068352166191, ; 83: GpsTracker.dll => 0x3693e1b548da392f => 115
	i64 3933965368022646939, ; 84: System.Net.Requests => 0x369840a8bfadc09b => 142
	i64 3966267475168208030, ; 85: System.Memory => 0x370b03412596249e => 137
	i64 4070326265757318011, ; 86: da\Microsoft.Maui.Controls.resources.dll => 0x387cb42c56683b7b => 3
	i64 4073500526318903918, ; 87: System.Private.Xml.dll => 0x3887fb25779ae26e => 149
	i64 4120493066591692148, ; 88: zh-Hant\Microsoft.Maui.Controls.resources => 0x392eee9cdda86574 => 33
	i64 4154383907710350974, ; 89: System.ComponentModel => 0x39a7562737acb67e => 124
	i64 4168469861834746866, ; 90: System.Security.Claims.dll => 0x39d96140fb94ebf2 => 160
	i64 4187479170553454871, ; 91: System.Linq.Expressions => 0x3a1cea1e912fa117 => 134
	i64 4205801962323029395, ; 92: System.ComponentModel.TypeConverter => 0x3a5e0299f7e7ad93 => 123
	i64 4282138915307457788, ; 93: System.Reflection.Emit => 0x3b6d36a7ddc70cfc => 151
	i64 4337444564132831293, ; 94: SQLitePCLRaw.batteries_v2.dll => 0x3c31b2d9ae16203d => 78
	i64 4360412976914417659, ; 95: tr\Microsoft.Maui.Controls.resources.dll => 0x3c834c8002fcc7fb => 28
	i64 4384840217421645357, ; 96: Microsoft.AspNetCore.Components.Forms => 0x3cda14f22443862d => 51
	i64 4477672992252076438, ; 97: System.Web.HttpUtility.dll => 0x3e23e3dcdb8ba196 => 173
	i64 4533124835995628778, ; 98: System.Reflection.Emit.dll => 0x3ee8e505540534ea => 151
	i64 4636684751163556186, ; 99: Xamarin.AndroidX.VersionedParcelable.dll => 0x4058d0370893015a => 106
	i64 4657212095206026001, ; 100: Microsoft.Extensions.Http.dll => 0x40a1bdb9c2686b11 => 66
	i64 4672453897036726049, ; 101: System.IO.FileSystem.Watcher => 0x40d7e4104a437f21 => 133
	i64 4743821336939966868, ; 102: System.ComponentModel.Annotations => 0x41d5705f4239b194 => 121
	i64 4794310189461587505, ; 103: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 82
	i64 4795410492532947900, ; 104: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 105
	i64 4809057822547766521, ; 105: System.Drawing => 0x42bd349c3145ecf9 => 129
	i64 4814660307502931973, ; 106: System.Net.NameResolution.dll => 0x42d11c0a5ee2a005 => 139
	i64 4853321196694829351, ; 107: System.Runtime.Loader.dll => 0x435a75ea15de7927 => 157
	i64 4871824391508510238, ; 108: nb\Microsoft.Maui.Controls.resources.dll => 0x439c3278d7f2c61e => 18
	i64 4953714692329509532, ; 109: sv\Microsoft.Maui.Controls.resources.dll => 0x44bf21444aef129c => 26
	i64 5081566143765835342, ; 110: System.Resources.ResourceManager.dll => 0x4685597c05d06e4e => 153
	i64 5099468265966638712, ; 111: System.Resources.ResourceManager => 0x46c4f35ea8519678 => 153
	i64 5103417709280584325, ; 112: System.Collections.Specialized => 0x46d2fb5e161b6285 => 119
	i64 5182934613077526976, ; 113: System.Collections.Specialized.dll => 0x47ed7b91fa9009c0 => 119
	i64 5197073077358930460, ; 114: Microsoft.AspNetCore.Components.Web.dll => 0x481fb66db7b9aa1c => 52
	i64 5290786973231294105, ; 115: System.Runtime.Loader => 0x496ca6b869b72699 => 157
	i64 5423376490970181369, ; 116: System.Runtime.InteropServices.RuntimeInformation => 0x4b43b42f2b7b6ef9 => 155
	i64 5446034149219586269, ; 117: System.Diagnostics.Debug => 0x4b94333452e150dd => 126
	i64 5471532531798518949, ; 118: sv\Microsoft.Maui.Controls.resources => 0x4beec9d926d82ca5 => 26
	i64 5522859530602327440, ; 119: uk\Microsoft.Maui.Controls.resources => 0x4ca5237b51eead90 => 29
	i64 5570799893513421663, ; 120: System.IO.Compression.Brotli => 0x4d4f74fcdfa6c35f => 131
	i64 5573260873512690141, ; 121: System.Security.Cryptography.dll => 0x4d58333c6e4ea1dd => 164
	i64 5650097808083101034, ; 122: System.Security.Cryptography.Algorithms.dll => 0x4e692e055d01a56a => 161
	i64 5692067934154308417, ; 123: Xamarin.AndroidX.ViewPager2.dll => 0x4efe49a0d4a8bb41 => 108
	i64 5774062992689267704, ; 124: Mapster => 0x502197b315f903f8 => 45
	i64 5979151488806146654, ; 125: System.Formats.Asn1 => 0x52fa3699a489d25e => 130
	i64 5984759512290286505, ; 126: System.Security.Cryptography.Primitives => 0x530e23115c33dba9 => 162
	i64 6046211982703393097, ; 127: IdentityModel.OidcClient.dll => 0x53e875c399bef949 => 44
	i64 6182525717148725503, ; 128: Microsoft.AspNetCore.Components.Authorization => 0x55ccbe62215df0ff => 50
	i64 6183170893902868313, ; 129: SQLitePCLRaw.batteries_v2 => 0x55cf092b0c9d6f59 => 78
	i64 6200764641006662125, ; 130: ro\Microsoft.Maui.Controls.resources => 0x560d8a96830131ed => 23
	i64 6222399776351216807, ; 131: System.Text.Json.dll => 0x565a67a0ffe264a7 => 166
	i64 6284145129771520194, ; 132: System.Reflection.Emit.ILGeneration => 0x5735c4b3610850c2 => 150
	i64 6300676701234028427, ; 133: es\Microsoft.Maui.Controls.resources.dll => 0x57708013cda25f8b => 6
	i64 6357457916754632952, ; 134: _Microsoft.Android.Resource.Designer => 0x583a3a4ac2a7a0f8 => 34
	i64 6401687960814735282, ; 135: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 95
	i64 6471714727257221498, ; 136: fi\Microsoft.Maui.Controls.resources.dll => 0x59d026417dd4a97a => 7
	i64 6478287442656530074, ; 137: hr\Microsoft.Maui.Controls.resources => 0x59e7801b0c6a8e9a => 11
	i64 6504860066809920875, ; 138: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 85
	i64 6548213210057960872, ; 139: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 91
	i64 6557084851308642443, ; 140: Xamarin.AndroidX.Window.dll => 0x5aff71ee6c58c08b => 109
	i64 6560151584539558821, ; 141: Microsoft.Extensions.Options => 0x5b0a571be53243a5 => 69
	i64 6743165466166707109, ; 142: nl\Microsoft.Maui.Controls.resources => 0x5d948943c08c43a5 => 19
	i64 6876862101832370452, ; 143: System.Xml.Linq => 0x5f6f85a57d108914 => 174
	i64 6894844156784520562, ; 144: System.Numerics.Vectors => 0x5faf683aead1ad72 => 145
	i64 6920570528939222495, ; 145: Microsoft.AspNetCore.Components.WebView => 0x600ace3ab475a5df => 54
	i64 7083547580668757502, ; 146: System.Private.Xml.Linq.dll => 0x624dd0fe8f56c5fe => 148
	i64 7270811800166795866, ; 147: System.Linq => 0x64e71ccf51a90a5a => 136
	i64 7377312882064240630, ; 148: System.ComponentModel.TypeConverter.dll => 0x66617afac45a2ff6 => 123
	i64 7488575175965059935, ; 149: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 174
	i64 7489048572193775167, ; 150: System.ObjectModel => 0x67ee71ff6b419e3f => 146
	i64 7654504624184590948, ; 151: System.Net.Http => 0x6a3a4366801b8264 => 138
	i64 7714652370974252055, ; 152: System.Private.CoreLib => 0x6b0ff375198b9c17 => 178
	i64 7735176074855944702, ; 153: Microsoft.CSharp => 0x6b58dda848e391fe => 116
	i64 7735352534559001595, ; 154: Xamarin.Kotlin.StdLib.dll => 0x6b597e2582ce8bfb => 111
	i64 7742555799473854801, ; 155: it\Microsoft.Maui.Controls.resources.dll => 0x6b73157a51479951 => 14
	i64 7836164640616011524, ; 156: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 84
	i64 7975724199463739455, ; 157: sk\Microsoft.Maui.Controls.resources.dll => 0x6eaf76e6f785e03f => 25
	i64 8014722069583580780, ; 158: Microsoft.AspNetCore.Components.Forms.dll => 0x6f3a03422b034e6c => 51
	i64 8064050204834738623, ; 159: System.Collections.dll => 0x6fe942efa61731bf => 120
	i64 8083354569033831015, ; 160: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 94
	i64 8087206902342787202, ; 161: System.Diagnostics.DiagnosticSource => 0x703b87d46f3aa082 => 127
	i64 8108129031893776750, ; 162: ko\Microsoft.Maui.Controls.resources.dll => 0x7085dc65530f796e => 16
	i64 8167236081217502503, ; 163: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 179
	i64 8185542183669246576, ; 164: System.Collections => 0x7198e33f4794aa70 => 120
	i64 8246048515196606205, ; 165: Microsoft.Maui.Graphics.dll => 0x726fd96f64ee56fd => 76
	i64 8290740647658429042, ; 166: System.Runtime.Extensions => 0x730ea0b15c929a72 => 154
	i64 8368701292315763008, ; 167: System.Security.Cryptography => 0x7423997c6fd56140 => 164
	i64 8386351099740279196, ; 168: zh-HK\Microsoft.Maui.Controls.resources.dll => 0x74624de475b9d19c => 31
	i64 8400357532724379117, ; 169: Xamarin.AndroidX.Navigation.UI.dll => 0x749410ab44503ded => 102
	i64 8563666267364444763, ; 170: System.Private.Uri => 0x76d841191140ca5b => 147
	i64 8626175481042262068, ; 171: Java.Interop => 0x77b654e585b55834 => 179
	i64 8638972117149407195, ; 172: Microsoft.CSharp.dll => 0x77e3cb5e8b31d7db => 116
	i64 8639588376636138208, ; 173: Xamarin.AndroidX.Navigation.Runtime => 0x77e5fbdaa2fda2e0 => 101
	i64 8677882282824630478, ; 174: pt-BR\Microsoft.Maui.Controls.resources => 0x786e07f5766b00ce => 21
	i64 8725526185868997716, ; 175: System.Diagnostics.DiagnosticSource.dll => 0x79174bd613173454 => 127
	i64 9045785047181495996, ; 176: zh-HK\Microsoft.Maui.Controls.resources => 0x7d891592e3cb0ebc => 31
	i64 9312692141327339315, ; 177: Xamarin.AndroidX.ViewPager2 => 0x813d54296a634f33 => 108
	i64 9324707631942237306, ; 178: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 83
	i64 9363564275759486853, ; 179: el\Microsoft.Maui.Controls.resources.dll => 0x81f21019382e9785 => 5
	i64 9404599086328396064, ; 180: Grpc.Net.Client.dll => 0x8283d90a93913920 => 39
	i64 9551379474083066910, ; 181: uk\Microsoft.Maui.Controls.resources.dll => 0x848d5106bbadb41e => 29
	i64 9650158550865574924, ; 182: Microsoft.Extensions.Configuration.Json => 0x85ec4012c28a7c0c => 58
	i64 9659729154652888475, ; 183: System.Text.RegularExpressions => 0x860e407c9991dd9b => 167
	i64 9678050649315576968, ; 184: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 88
	i64 9702891218465930390, ; 185: System.Collections.NonGeneric.dll => 0x86a79827b2eb3c96 => 118
	i64 9773637193738963987, ; 186: ca\Microsoft.Maui.Controls.resources.dll => 0x87a2ef3ea85b4c13 => 1
	i64 9808709177481450983, ; 187: Mono.Android.dll => 0x881f890734e555e7 => 181
	i64 9933555792566666578, ; 188: System.Linq.Queryable.dll => 0x89db145cf475c552 => 135
	i64 9956195530459977388, ; 189: Microsoft.Maui => 0x8a2b8315b36616ac => 74
	i64 9959907718382012208, ; 190: Grpc.Net.Client.Web => 0x8a38b34ccdd4c730 => 40
	i64 10038780035334861115, ; 191: System.Net.Http.dll => 0x8b50e941206af13b => 138
	i64 10051358222726253779, ; 192: System.Private.Xml => 0x8b7d990c97ccccd3 => 149
	i64 10051920404523413229, ; 193: Grpc.Net.Common => 0x8b7f9859be1e6eed => 42
	i64 10091210234654869289, ; 194: GpsTracker => 0x8c0b2e3e2e63c729 => 115
	i64 10092835686693276772, ; 195: Microsoft.Maui.Controls => 0x8c10f49539bd0c64 => 72
	i64 10143853363526200146, ; 196: da\Microsoft.Maui.Controls.resources => 0x8cc634e3c2a16b52 => 3
	i64 10209869394718195525, ; 197: nl\Microsoft.Maui.Controls.resources.dll => 0x8db0be1ecb4f7f45 => 19
	i64 10229024438826829339, ; 198: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 91
	i64 10364469296367737616, ; 199: System.Reflection.Emit.ILGeneration.dll => 0x8fd5fde967711b10 => 150
	i64 10406448008575299332, ; 200: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x906b2153fcb3af04 => 112
	i64 10430153318873392755, ; 201: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 89
	i64 10506226065143327199, ; 202: ca\Microsoft.Maui.Controls.resources => 0x91cd9cf11ed169df => 1
	i64 10634102643060048396, ; 203: IdentityModel => 0x9393ec0310a3020c => 43
	i64 10714184849103829812, ; 204: System.Runtime.Extensions.dll => 0x94b06e5aa4b4bb34 => 154
	i64 10734191584620811116, ; 205: Microsoft.Extensions.FileProviders.Embedded.dll => 0x94f7825fc04f936c => 63
	i64 10761706286639228993, ; 206: zh-Hant\Microsoft.Maui.Controls.resources.dll => 0x955942d988382841 => 33
	i64 10778626088875308765, ; 207: Grpc.Net.ClientFactory.dll => 0x95955f51fa2bb6dd => 41
	i64 10785150219063592792, ; 208: System.Net.Primitives => 0x95ac8cfb68830758 => 141
	i64 10822644899632537592, ; 209: System.Linq.Queryable => 0x9631c23204ca5ff8 => 135
	i64 10854473764158213966, ; 210: Grpc.Core.Api.dll => 0x96a2d66108728f4e => 38
	i64 11002576679268595294, ; 211: Microsoft.Extensions.Logging.Abstractions => 0x98b1013215cd365e => 68
	i64 11009005086950030778, ; 212: Microsoft.Maui.dll => 0x98c7d7cc621ffdba => 74
	i64 11051904132540108364, ; 213: Microsoft.Extensions.FileProviders.Composite.dll => 0x99604040c7b98e4c => 62
	i64 11103970607964515343, ; 214: hu\Microsoft.Maui.Controls.resources => 0x9a193a6fc41a6c0f => 12
	i64 11156122287428000958, ; 215: th\Microsoft.Maui.Controls.resources.dll => 0x9ad2821cdcf6dcbe => 27
	i64 11157797727133427779, ; 216: fr\Microsoft.Maui.Controls.resources.dll => 0x9ad875ea9172e843 => 8
	i64 11162124722117608902, ; 217: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 107
	i64 11218356222449480316, ; 218: Microsoft.AspNetCore.Components => 0x9baf9b8c02e4f27c => 49
	i64 11220793807500858938, ; 219: ja\Microsoft.Maui.Controls.resources => 0x9bb8448481fdd63a => 15
	i64 11226290749488709958, ; 220: Microsoft.Extensions.Options.dll => 0x9bcbcbf50c874146 => 69
	i64 11329751333533450475, ; 221: System.Threading.Timer.dll => 0x9d3b5ccf6cc500eb => 171
	i64 11340910727871153756, ; 222: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 90
	i64 11380782361707310188, ; 223: IdentityModel.OidcClient => 0x9df0a9428f986c6c => 44
	i64 11435314654401632883, ; 224: Grpc.Core.Api => 0x9eb266175e6d9a73 => 38
	i64 11441445377436144712, ; 225: Grpc.Net.Common.dll => 0x9ec82df38f1dd448 => 42
	i64 11485890710487134646, ; 226: System.Runtime.InteropServices => 0x9f6614bf0f8b71b6 => 156
	i64 11518296021396496455, ; 227: id\Microsoft.Maui.Controls.resources => 0x9fd9353475222047 => 13
	i64 11529969570048099689, ; 228: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 107
	i64 11530571088791430846, ; 229: Microsoft.Extensions.Logging => 0xa004d1504ccd66be => 67
	i64 11543207250219725293, ; 230: Grpc.Net.Client => 0xa031b5d5e60f71ed => 39
	i64 11597940890313164233, ; 231: netstandard => 0xa0f429ca8d1805c9 => 177
	i64 11739066727115742305, ; 232: SQLite-net.dll => 0xa2e98afdf8575c61 => 77
	i64 11743665907891708234, ; 233: System.Threading.Tasks => 0xa2f9e1ec30c0214a => 169
	i64 11806260347154423189, ; 234: SQLite-net => 0xa3d8433bc5eb5d95 => 77
	i64 11855031688536399763, ; 235: vi\Microsoft.Maui.Controls.resources.dll => 0xa485888294361f93 => 30
	i64 12048689113179125827, ; 236: Microsoft.Extensions.FileProviders.Physical => 0xa7358ae968287843 => 64
	i64 12058074296353848905, ; 237: Microsoft.Extensions.FileSystemGlobbing.dll => 0xa756e2afa5707e49 => 65
	i64 12145679461940342714, ; 238: System.Text.Json => 0xa88e1f1ebcb62fba => 166
	i64 12279246230491828964, ; 239: SQLitePCLRaw.provider.e_sqlite3.dll => 0xaa68a5636e0512e4 => 81
	i64 12356166309264962316, ; 240: Grpc.Net.ClientFactory => 0xab79ebcae163330c => 41
	i64 12451044538927396471, ; 241: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 93
	i64 12459959602091767212, ; 242: Microsoft.AspNetCore.Components.Authorization.dll => 0xaceaab3e0e65b5ac => 50
	i64 12466513435562512481, ; 243: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 98
	i64 12475113361194491050, ; 244: _Microsoft.Android.Resource.Designer.dll => 0xad2081818aba1caa => 34
	i64 12538491095302438457, ; 245: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 86
	i64 12550732019250633519, ; 246: System.IO.Compression => 0xae2d28465e8e1b2f => 132
	i64 12700543734426720211, ; 247: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 87
	i64 12735608139946161795, ; 248: Mapster.Core.dll => 0xb0bdf8208c107683 => 46
	i64 12753841065332862057, ; 249: Xamarin.AndroidX.Window => 0xb0febee04cf46c69 => 109
	i64 12843321153144804894, ; 250: Microsoft.Extensions.Primitives => 0xb23ca48abd74d61e => 70
	i64 12989346753972519995, ; 251: ar\Microsoft.Maui.Controls.resources.dll => 0xb4436e0d5ee7c43b => 0
	i64 13003699287675270979, ; 252: Microsoft.AspNetCore.Components.WebView.Maui => 0xb4766b9b07e27743 => 55
	i64 13005833372463390146, ; 253: pt-BR\Microsoft.Maui.Controls.resources.dll => 0xb47e008b5d99ddc2 => 21
	i64 13035301984983866396, ; 254: Grpc.Net.Client.Web.dll => 0xb4e6b21762e85c1c => 40
	i64 13343850469010654401, ; 255: Mono.Android.Runtime.dll => 0xb92ee14d854f44c1 => 180
	i64 13381594904270902445, ; 256: he\Microsoft.Maui.Controls.resources => 0xb9b4f9aaad3e94ad => 9
	i64 13465488254036897740, ; 257: Xamarin.Kotlin.StdLib => 0xbadf06394d106fcc => 111
	i64 13540124433173649601, ; 258: vi\Microsoft.Maui.Controls.resources => 0xbbe82f6eede718c1 => 30
	i64 13550417756503177631, ; 259: Microsoft.Extensions.FileProviders.Abstractions.dll => 0xbc0cc1280684799f => 61
	i64 13572454107664307259, ; 260: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 103
	i64 13597693765308912490, ; 261: Blazored.LocalStorage.dll => 0xbcb4b66f95c8136a => 36
	i64 13717397318615465333, ; 262: System.ComponentModel.Primitives.dll => 0xbe5dfc2ef2f87d75 => 122
	i64 13881769479078963060, ; 263: System.Console.dll => 0xc0a5f3cade5c6774 => 125
	i64 13959074834287824816, ; 264: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 93
	i64 14124974489674258913, ; 265: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 86
	i64 14125464355221830302, ; 266: System.Threading.dll => 0xc407bafdbc707a9e => 172
	i64 14327709162229390963, ; 267: System.Security.Cryptography.X509Certificates => 0xc6d63f9253cade73 => 163
	i64 14327924848409182502, ; 268: BlazorBootstrap => 0xc6d703bcadec0126 => 35
	i64 14349907877893689639, ; 269: ro\Microsoft.Maui.Controls.resources.dll => 0xc7251d2f956ed127 => 23
	i64 14392919184951328125, ; 270: SharedLib => 0xc7bdebbde3edbd7d => 114
	i64 14461014870687870182, ; 271: System.Net.Requests.dll => 0xc8afd8683afdece6 => 142
	i64 14464374589798375073, ; 272: ru\Microsoft.Maui.Controls.resources => 0xc8bbc80dcb1e5ea1 => 24
	i64 14491877563792607819, ; 273: zh-Hans\Microsoft.Maui.Controls.resources.dll => 0xc91d7ddcee4fca4b => 32
	i64 14551742072151931844, ; 274: System.Text.Encodings.Web.dll => 0xc9f22c50f1b8fbc4 => 165
	i64 14561513370130550166, ; 275: System.Security.Cryptography.Primitives.dll => 0xca14e3428abb8d96 => 162
	i64 14610046442689856844, ; 276: cs\Microsoft.Maui.Controls.resources.dll => 0xcac14fd5107d054c => 2
	i64 14669215534098758659, ; 277: Microsoft.Extensions.DependencyInjection.dll => 0xcb9385ceb3993c03 => 59
	i64 14690985099581930927, ; 278: System.Web.HttpUtility => 0xcbe0dd1ca5233daf => 173
	i64 14705122255218365489, ; 279: ko\Microsoft.Maui.Controls.resources => 0xcc1316c7b0fb5431 => 16
	i64 14735017007120366644, ; 280: ja\Microsoft.Maui.Controls.resources.dll => 0xcc7d4be604bfbc34 => 15
	i64 14744092281598614090, ; 281: zh-Hans\Microsoft.Maui.Controls.resources => 0xcc9d89d004439a4a => 32
	i64 14832630590065248058, ; 282: System.Security.Claims => 0xcdd816ef5d6e873a => 160
	i64 14852515768018889994, ; 283: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 90
	i64 14904040806490515477, ; 284: ar\Microsoft.Maui.Controls.resources => 0xced5ca2604cb2815 => 0
	i64 14954917835170835695, ; 285: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xcf8a8a895a82ecef => 60
	i64 14987728460634540364, ; 286: System.IO.Compression.dll => 0xcfff1ba06622494c => 132
	i64 15015154896917945444, ; 287: System.Net.Security.dll => 0xd0608bd33642dc64 => 143
	i64 15076659072870671916, ; 288: System.ObjectModel.dll => 0xd13b0d8c1620662c => 146
	i64 15111608613780139878, ; 289: ms\Microsoft.Maui.Controls.resources => 0xd1b737f831192f66 => 17
	i64 15115185479366240210, ; 290: System.IO.Compression.Brotli.dll => 0xd1c3ed1c1bc467d2 => 131
	i64 15133485256822086103, ; 291: System.Linq.dll => 0xd204f0a9127dd9d7 => 136
	i64 15203009853192377507, ; 292: pt\Microsoft.Maui.Controls.resources.dll => 0xd2fbf0e9984b94a3 => 22
	i64 15227001540531775957, ; 293: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd3512d3999b8e9d5 => 57
	i64 15370334346939861994, ; 294: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 89
	i64 15391712275433856905, ; 295: Microsoft.Extensions.DependencyInjection.Abstractions => 0xd59a58c406411f89 => 60
	i64 15427448221306938193, ; 296: Microsoft.AspNetCore.Components.Web => 0xd6194e6b4dbb6351 => 52
	i64 15481710163200268842, ; 297: Microsoft.Extensions.FileProviders.Composite => 0xd6da155e291b5a2a => 62
	i64 15527772828719725935, ; 298: System.Console => 0xd77dbb1e38cd3d6f => 125
	i64 15536481058354060254, ; 299: de\Microsoft.Maui.Controls.resources => 0xd79cab34eec75bde => 4
	i64 15541854775306130054, ; 300: System.Security.Cryptography.X509Certificates.dll => 0xd7afc292e8d49286 => 163
	i64 15557562860424774966, ; 301: System.Net.Sockets => 0xd7e790fe7a6dc536 => 144
	i64 15582737692548360875, ; 302: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 97
	i64 15592226634512578529, ; 303: Microsoft.AspNetCore.Authorization.dll => 0xd862b7834f81b7e1 => 48
	i64 15609085926864131306, ; 304: System.dll => 0xd89e9cf3334914ea => 176
	i64 15661133872274321916, ; 305: System.Xml.ReaderWriter.dll => 0xd9578647d4bfb1fc => 175
	i64 15783653065526199428, ; 306: el\Microsoft.Maui.Controls.resources => 0xdb0accd674b1c484 => 5
	i64 15817206913877585035, ; 307: System.Threading.Tasks.dll => 0xdb8201e29086ac8b => 169
	i64 15827202283623377193, ; 308: Microsoft.Extensions.Configuration.Json.dll => 0xdba5849eef9f6929 => 58
	i64 15847085070278954535, ; 309: System.Threading.Channels.dll => 0xdbec27e8f35f8e27 => 168
	i64 16018552496348375205, ; 310: System.Net.NetworkInformation.dll => 0xde4d54a020caa8a5 => 140
	i64 16056281320585338352, ; 311: ru\Microsoft.Maui.Controls.resources.dll => 0xded35eca8f3a9df0 => 24
	i64 16069446337368318755, ; 312: Protos.dll => 0xdf02244de40a6323 => 113
	i64 16154507427712707110, ; 313: System => 0xe03056ea4e39aa26 => 176
	i64 16219561732052121626, ; 314: System.Net.Security => 0xe1177575db7c781a => 143
	i64 16288847719894691167, ; 315: nb\Microsoft.Maui.Controls.resources => 0xe20d9cb300c12d5f => 18
	i64 16321164108206115771, ; 316: Microsoft.Extensions.Logging.Abstractions.dll => 0xe2806c487e7b0bbb => 68
	i64 16454459195343277943, ; 317: System.Net.NetworkInformation => 0xe459fb756d988f77 => 140
	i64 16558262036769511634, ; 318: Microsoft.Extensions.Http => 0xe5cac397cf7b98d2 => 66
	i64 16649148416072044166, ; 319: Microsoft.Maui.Graphics => 0xe70da84600bb4e86 => 76
	i64 16677317093839702854, ; 320: Xamarin.AndroidX.Navigation.UI => 0xe771bb8960dd8b46 => 102
	i64 16755018182064898362, ; 321: SQLitePCLRaw.core.dll => 0xe885c843c330813a => 79
	i64 16803648858859583026, ; 322: ms\Microsoft.Maui.Controls.resources.dll => 0xe9328d9b8ab93632 => 17
	i64 16890310621557459193, ; 323: System.Text.RegularExpressions.dll => 0xea66700587f088f9 => 167
	i64 16942731696432749159, ; 324: sk\Microsoft.Maui.Controls.resources => 0xeb20acb622a01a67 => 25
	i64 16998075588627545693, ; 325: Xamarin.AndroidX.Navigation.Fragment => 0xebe54bb02d623e5d => 100
	i64 17008137082415910100, ; 326: System.Collections.NonGeneric => 0xec090a90408c8cd4 => 118
	i64 17031351772568316411, ; 327: Xamarin.AndroidX.Navigation.Common.dll => 0xec5b843380a769fb => 99
	i64 17062143951396181894, ; 328: System.ComponentModel.Primitives => 0xecc8e986518c9786 => 122
	i64 17079998892748052666, ; 329: Microsoft.AspNetCore.Components.dll => 0xed08587fce5018ba => 49
	i64 17118171214553292978, ; 330: System.Threading.Channels => 0xed8ff6060fc420b2 => 168
	i64 17187273293601214786, ; 331: System.ComponentModel.Annotations.dll => 0xee8575ff9aa89142 => 121
	i64 17203614576212522419, ; 332: pl\Microsoft.Maui.Controls.resources.dll => 0xeebf844ef3e135b3 => 20
	i64 17205988430934219272, ; 333: Microsoft.Extensions.FileSystemGlobbing => 0xeec7f35113509a08 => 65
	i64 17230721278011714856, ; 334: System.Private.Xml.Linq => 0xef1fd1b5c7a72d28 => 148
	i64 17310278548634113468, ; 335: hi\Microsoft.Maui.Controls.resources.dll => 0xf03a76a04e6695bc => 10
	i64 17342750010158924305, ; 336: hi\Microsoft.Maui.Controls.resources => 0xf0add33f97ecc211 => 10
	i64 17470386307322966175, ; 337: System.Threading.Timer => 0xf27347c8d0d5709f => 171
	i64 17514990004910432069, ; 338: fr\Microsoft.Maui.Controls.resources => 0xf311be9c6f341f45 => 8
	i64 17553799493972570483, ; 339: Google.Protobuf.dll => 0xf39b9fa2c0aab173 => 37
	i64 17623219336845711842, ; 340: Mapster.Core => 0xf492409d737bd9e2 => 46
	i64 17623389608345532001, ; 341: pl\Microsoft.Maui.Controls.resources => 0xf492db79dfbef661 => 20
	i64 17685921127322830888, ; 342: System.Diagnostics.Debug.dll => 0xf571038fafa74828 => 126
	i64 17704177640604968747, ; 343: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 98
	i64 17710060891934109755, ; 344: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 96
	i64 17712670374920797664, ; 345: System.Runtime.InteropServices.dll => 0xf5d00bdc38bd3de0 => 156
	i64 17726260449924396358, ; 346: SharedLib.dll => 0xf60053f621ccb546 => 114
	i64 17749296158631996898, ; 347: Mapster.DependencyInjection.dll => 0xf6522ad104772de2 => 47
	i64 17777860260071588075, ; 348: System.Runtime.Numerics.dll => 0xf6b7a5b72419c0eb => 158
	i64 17797094921434547711, ; 349: Protos => 0xf6fbfb89ba03c5ff => 113
	i64 17827813215687577648, ; 350: hr\Microsoft.Maui.Controls.resources.dll => 0xf7691da9f3129030 => 11
	i64 17867952478176214637, ; 351: Mapster.dll => 0xf7f7b81c4540fe6d => 45
	i64 17900270406636610742, ; 352: Microsoft.AspNetCore.Components.WebAssembly.Authentication.dll => 0xf86a89185b0324b6 => 53
	i64 17942426894774770628, ; 353: de\Microsoft.Maui.Controls.resources.dll => 0xf9004e329f771bc4 => 4
	i64 18025913125965088385, ; 354: System.Threading => 0xfa28e87b91334681 => 172
	i64 18121036031235206392, ; 355: Xamarin.AndroidX.Navigation.Common => 0xfb7ada42d3d42cf8 => 99
	i64 18146411883821974900, ; 356: System.Formats.Asn1.dll => 0xfbd50176eb22c574 => 130
	i64 18245806341561545090, ; 357: System.Collections.Concurrent.dll => 0xfd3620327d587182 => 117
	i64 18305135509493619199, ; 358: Xamarin.AndroidX.Navigation.Runtime.dll => 0xfe08e7c2d8c199ff => 101
	i64 18324163916253801303, ; 359: it\Microsoft.Maui.Controls.resources => 0xfe4c81ff0a56ab57 => 14
	i64 18342408478508122430, ; 360: id\Microsoft.Maui.Controls.resources.dll => 0xfe8d53543697013e => 13
	i64 18358161419737137786, ; 361: he\Microsoft.Maui.Controls.resources.dll => 0xfec54a8ba8b6827a => 9
	i64 18370042311372477656, ; 362: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0xfeef80274e4094d8 => 80
	i64 18380184030268848184 ; 363: Xamarin.AndroidX.VersionedParcelable => 0xff1387fe3e7b7838 => 106
], align 8

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [364 x i32] [
	i32 70, ; 0
	i32 181, ; 1
	i32 75, ; 2
	i32 134, ; 3
	i32 87, ; 4
	i32 104, ; 5
	i32 152, ; 6
	i32 63, ; 7
	i32 53, ; 8
	i32 170, ; 9
	i32 124, ; 10
	i32 12, ; 11
	i32 80, ; 12
	i32 92, ; 13
	i32 43, ; 14
	i32 152, ; 15
	i32 110, ; 16
	i32 129, ; 17
	i32 79, ; 18
	i32 100, ; 19
	i32 133, ; 20
	i32 47, ; 21
	i32 141, ; 22
	i32 72, ; 23
	i32 180, ; 24
	i32 81, ; 25
	i32 170, ; 26
	i32 84, ; 27
	i32 97, ; 28
	i32 137, ; 29
	i32 147, ; 30
	i32 37, ; 31
	i32 71, ; 32
	i32 83, ; 33
	i32 155, ; 34
	i32 6, ; 35
	i32 104, ; 36
	i32 128, ; 37
	i32 28, ; 38
	i32 36, ; 39
	i32 73, ; 40
	i32 161, ; 41
	i32 96, ; 42
	i32 128, ; 43
	i32 85, ; 44
	i32 92, ; 45
	i32 117, ; 46
	i32 55, ; 47
	i32 95, ; 48
	i32 165, ; 49
	i32 88, ; 50
	i32 159, ; 51
	i32 82, ; 52
	i32 27, ; 53
	i32 139, ; 54
	i32 59, ; 55
	i32 2, ; 56
	i32 71, ; 57
	i32 7, ; 58
	i32 110, ; 59
	i32 48, ; 60
	i32 94, ; 61
	i32 145, ; 62
	i32 158, ; 63
	i32 144, ; 64
	i32 112, ; 65
	i32 61, ; 66
	i32 75, ; 67
	i32 56, ; 68
	i32 105, ; 69
	i32 35, ; 70
	i32 178, ; 71
	i32 22, ; 72
	i32 159, ; 73
	i32 57, ; 74
	i32 175, ; 75
	i32 56, ; 76
	i32 177, ; 77
	i32 103, ; 78
	i32 54, ; 79
	i32 67, ; 80
	i32 64, ; 81
	i32 73, ; 82
	i32 115, ; 83
	i32 142, ; 84
	i32 137, ; 85
	i32 3, ; 86
	i32 149, ; 87
	i32 33, ; 88
	i32 124, ; 89
	i32 160, ; 90
	i32 134, ; 91
	i32 123, ; 92
	i32 151, ; 93
	i32 78, ; 94
	i32 28, ; 95
	i32 51, ; 96
	i32 173, ; 97
	i32 151, ; 98
	i32 106, ; 99
	i32 66, ; 100
	i32 133, ; 101
	i32 121, ; 102
	i32 82, ; 103
	i32 105, ; 104
	i32 129, ; 105
	i32 139, ; 106
	i32 157, ; 107
	i32 18, ; 108
	i32 26, ; 109
	i32 153, ; 110
	i32 153, ; 111
	i32 119, ; 112
	i32 119, ; 113
	i32 52, ; 114
	i32 157, ; 115
	i32 155, ; 116
	i32 126, ; 117
	i32 26, ; 118
	i32 29, ; 119
	i32 131, ; 120
	i32 164, ; 121
	i32 161, ; 122
	i32 108, ; 123
	i32 45, ; 124
	i32 130, ; 125
	i32 162, ; 126
	i32 44, ; 127
	i32 50, ; 128
	i32 78, ; 129
	i32 23, ; 130
	i32 166, ; 131
	i32 150, ; 132
	i32 6, ; 133
	i32 34, ; 134
	i32 95, ; 135
	i32 7, ; 136
	i32 11, ; 137
	i32 85, ; 138
	i32 91, ; 139
	i32 109, ; 140
	i32 69, ; 141
	i32 19, ; 142
	i32 174, ; 143
	i32 145, ; 144
	i32 54, ; 145
	i32 148, ; 146
	i32 136, ; 147
	i32 123, ; 148
	i32 174, ; 149
	i32 146, ; 150
	i32 138, ; 151
	i32 178, ; 152
	i32 116, ; 153
	i32 111, ; 154
	i32 14, ; 155
	i32 84, ; 156
	i32 25, ; 157
	i32 51, ; 158
	i32 120, ; 159
	i32 94, ; 160
	i32 127, ; 161
	i32 16, ; 162
	i32 179, ; 163
	i32 120, ; 164
	i32 76, ; 165
	i32 154, ; 166
	i32 164, ; 167
	i32 31, ; 168
	i32 102, ; 169
	i32 147, ; 170
	i32 179, ; 171
	i32 116, ; 172
	i32 101, ; 173
	i32 21, ; 174
	i32 127, ; 175
	i32 31, ; 176
	i32 108, ; 177
	i32 83, ; 178
	i32 5, ; 179
	i32 39, ; 180
	i32 29, ; 181
	i32 58, ; 182
	i32 167, ; 183
	i32 88, ; 184
	i32 118, ; 185
	i32 1, ; 186
	i32 181, ; 187
	i32 135, ; 188
	i32 74, ; 189
	i32 40, ; 190
	i32 138, ; 191
	i32 149, ; 192
	i32 42, ; 193
	i32 115, ; 194
	i32 72, ; 195
	i32 3, ; 196
	i32 19, ; 197
	i32 91, ; 198
	i32 150, ; 199
	i32 112, ; 200
	i32 89, ; 201
	i32 1, ; 202
	i32 43, ; 203
	i32 154, ; 204
	i32 63, ; 205
	i32 33, ; 206
	i32 41, ; 207
	i32 141, ; 208
	i32 135, ; 209
	i32 38, ; 210
	i32 68, ; 211
	i32 74, ; 212
	i32 62, ; 213
	i32 12, ; 214
	i32 27, ; 215
	i32 8, ; 216
	i32 107, ; 217
	i32 49, ; 218
	i32 15, ; 219
	i32 69, ; 220
	i32 171, ; 221
	i32 90, ; 222
	i32 44, ; 223
	i32 38, ; 224
	i32 42, ; 225
	i32 156, ; 226
	i32 13, ; 227
	i32 107, ; 228
	i32 67, ; 229
	i32 39, ; 230
	i32 177, ; 231
	i32 77, ; 232
	i32 169, ; 233
	i32 77, ; 234
	i32 30, ; 235
	i32 64, ; 236
	i32 65, ; 237
	i32 166, ; 238
	i32 81, ; 239
	i32 41, ; 240
	i32 93, ; 241
	i32 50, ; 242
	i32 98, ; 243
	i32 34, ; 244
	i32 86, ; 245
	i32 132, ; 246
	i32 87, ; 247
	i32 46, ; 248
	i32 109, ; 249
	i32 70, ; 250
	i32 0, ; 251
	i32 55, ; 252
	i32 21, ; 253
	i32 40, ; 254
	i32 180, ; 255
	i32 9, ; 256
	i32 111, ; 257
	i32 30, ; 258
	i32 61, ; 259
	i32 103, ; 260
	i32 36, ; 261
	i32 122, ; 262
	i32 125, ; 263
	i32 93, ; 264
	i32 86, ; 265
	i32 172, ; 266
	i32 163, ; 267
	i32 35, ; 268
	i32 23, ; 269
	i32 114, ; 270
	i32 142, ; 271
	i32 24, ; 272
	i32 32, ; 273
	i32 165, ; 274
	i32 162, ; 275
	i32 2, ; 276
	i32 59, ; 277
	i32 173, ; 278
	i32 16, ; 279
	i32 15, ; 280
	i32 32, ; 281
	i32 160, ; 282
	i32 90, ; 283
	i32 0, ; 284
	i32 60, ; 285
	i32 132, ; 286
	i32 143, ; 287
	i32 146, ; 288
	i32 17, ; 289
	i32 131, ; 290
	i32 136, ; 291
	i32 22, ; 292
	i32 57, ; 293
	i32 89, ; 294
	i32 60, ; 295
	i32 52, ; 296
	i32 62, ; 297
	i32 125, ; 298
	i32 4, ; 299
	i32 163, ; 300
	i32 144, ; 301
	i32 97, ; 302
	i32 48, ; 303
	i32 176, ; 304
	i32 175, ; 305
	i32 5, ; 306
	i32 169, ; 307
	i32 58, ; 308
	i32 168, ; 309
	i32 140, ; 310
	i32 24, ; 311
	i32 113, ; 312
	i32 176, ; 313
	i32 143, ; 314
	i32 18, ; 315
	i32 68, ; 316
	i32 140, ; 317
	i32 66, ; 318
	i32 76, ; 319
	i32 102, ; 320
	i32 79, ; 321
	i32 17, ; 322
	i32 167, ; 323
	i32 25, ; 324
	i32 100, ; 325
	i32 118, ; 326
	i32 99, ; 327
	i32 122, ; 328
	i32 49, ; 329
	i32 168, ; 330
	i32 121, ; 331
	i32 20, ; 332
	i32 65, ; 333
	i32 148, ; 334
	i32 10, ; 335
	i32 10, ; 336
	i32 171, ; 337
	i32 8, ; 338
	i32 37, ; 339
	i32 46, ; 340
	i32 20, ; 341
	i32 126, ; 342
	i32 98, ; 343
	i32 96, ; 344
	i32 156, ; 345
	i32 114, ; 346
	i32 47, ; 347
	i32 158, ; 348
	i32 113, ; 349
	i32 11, ; 350
	i32 45, ; 351
	i32 53, ; 352
	i32 4, ; 353
	i32 172, ; 354
	i32 99, ; 355
	i32 130, ; 356
	i32 117, ; 357
	i32 101, ; 358
	i32 14, ; 359
	i32 13, ; 360
	i32 9, ; 361
	i32 80, ; 362
	i32 106 ; 363
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 8

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 8

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 8

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 8, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+fix-cortex-a53-835769,+neon,+outline-atomics,+v8a" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+fix-cortex-a53-835769,+neon,+outline-atomics,+v8a" }

; Metadata
!llvm.module.flags = !{!0, !1, !7, !8, !9, !10}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.1xx-preview7 @ d8764fc950e5e864f357bb0c4d44b6d5a2675229"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"branch-target-enforcement", i32 0}
!8 = !{i32 1, !"sign-return-address", i32 0}
!9 = !{i32 1, !"sign-return-address-all", i32 0}
!10 = !{i32 1, !"sign-return-address-with-bkey", i32 0}
