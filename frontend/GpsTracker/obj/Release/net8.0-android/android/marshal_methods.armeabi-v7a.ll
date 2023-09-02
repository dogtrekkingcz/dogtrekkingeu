; ModuleID = 'marshal_methods.armeabi-v7a.ll'
source_filename = "marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [182 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [364 x i32] [
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 140
	i32 10166715, ; 1: System.Net.NameResolution.dll => 0x9b21bb => 139
	i32 38948123, ; 2: ar\Microsoft.Maui.Controls.resources.dll => 0x2524d1b => 0
	i32 42244203, ; 3: he\Microsoft.Maui.Controls.resources.dll => 0x284986b => 9
	i32 42639949, ; 4: System.Threading.Thread => 0x28aa24d => 170
	i32 67008169, ; 5: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 33
	i32 68219467, ; 6: System.Security.Cryptography.Primitives => 0x410f24b => 162
	i32 72070932, ; 7: Microsoft.Maui.Graphics.dll => 0x44bb714 => 76
	i32 83839681, ; 8: ms\Microsoft.Maui.Controls.resources.dll => 0x4ff4ac1 => 17
	i32 117431740, ; 9: System.Runtime.InteropServices => 0x6ffddbc => 156
	i32 122350210, ; 10: System.Threading.Channels.dll => 0x74aea82 => 168
	i32 136584136, ; 11: zh-Hans\Microsoft.Maui.Controls.resources.dll => 0x8241bc8 => 32
	i32 136700176, ; 12: GpsTracker => 0x825e110 => 115
	i32 140062828, ; 13: sk\Microsoft.Maui.Controls.resources.dll => 0x859306c => 25
	i32 149972175, ; 14: System.Security.Cryptography.Primitives.dll => 0x8f064cf => 162
	i32 159306688, ; 15: System.ComponentModel.Annotations => 0x97ed3c0 => 121
	i32 165246403, ; 16: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 87
	i32 182336117, ; 17: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 105
	i32 205061960, ; 18: System.ComponentModel => 0xc38ff48 => 124
	i32 209399409, ; 19: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 85
	i32 220171995, ; 20: System.Diagnostics.Debug => 0xd1f8edb => 126
	i32 230752869, ; 21: Microsoft.CSharp.dll => 0xdc10265 => 116
	i32 244348769, ; 22: Microsoft.AspNetCore.Components.Authorization => 0xe907761 => 50
	i32 254259026, ; 23: Microsoft.AspNetCore.Components.dll => 0xf27af52 => 49
	i32 276479776, ; 24: System.Threading.Timer.dll => 0x107abf20 => 171
	i32 291275502, ; 25: Microsoft.Extensions.Http.dll => 0x115c82ee => 66
	i32 317674968, ; 26: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 30
	i32 318968648, ; 27: Xamarin.AndroidX.Activity.dll => 0x13031348 => 82
	i32 321963286, ; 28: fr\Microsoft.Maui.Controls.resources.dll => 0x1330c516 => 8
	i32 342366114, ; 29: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 94
	i32 347068432, ; 30: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0x14afd810 => 80
	i32 364956269, ; 31: Grpc.Net.Common => 0x15c0ca6d => 42
	i32 371306672, ; 32: Grpc.Core.Api.dll => 0x1621b0b0 => 38
	i32 379916513, ; 33: System.Threading.Thread.dll => 0x16a510e1 => 170
	i32 385762202, ; 34: System.Memory.dll => 0x16fe439a => 137
	i32 391886110, ; 35: Grpc.Net.Client.dll => 0x175bb51e => 39
	i32 395744057, ; 36: _Microsoft.Android.Resource.Designer => 0x17969339 => 34
	i32 409257351, ; 37: tr\Microsoft.Maui.Controls.resources.dll => 0x1864c587 => 28
	i32 442470736, ; 38: Mapster.DependencyInjection.dll => 0x1a5f9150 => 47
	i32 442565967, ; 39: System.Collections => 0x1a61054f => 120
	i32 450948140, ; 40: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 93
	i32 451504562, ; 41: System.Security.Cryptography.X509Certificates => 0x1ae969b2 => 163
	i32 456227837, ; 42: System.Web.HttpUtility.dll => 0x1b317bfd => 173
	i32 469710990, ; 43: System.dll => 0x1bff388e => 176
	i32 489220957, ; 44: es\Microsoft.Maui.Controls.resources.dll => 0x1d28eb5d => 6
	i32 498788369, ; 45: System.ObjectModel => 0x1dbae811 => 146
	i32 513247710, ; 46: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 70
	i32 530272170, ; 47: System.Linq.Queryable => 0x1f9b4faa => 135
	i32 538707440, ; 48: th\Microsoft.Maui.Controls.resources.dll => 0x201c05f0 => 27
	i32 539058512, ; 49: Microsoft.Extensions.Logging => 0x20216150 => 67
	i32 545304856, ; 50: System.Runtime.Extensions => 0x2080b118 => 154
	i32 571435654, ; 51: Microsoft.Extensions.FileProviders.Embedded.dll => 0x220f6a86 => 63
	i32 613668793, ; 52: System.Security.Cryptography.Algorithms => 0x2493d7b9 => 161
	i32 617706511, ; 53: Protos.dll => 0x24d1740f => 113
	i32 627609679, ; 54: Xamarin.AndroidX.CustomView => 0x2568904f => 91
	i32 627931235, ; 55: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 19
	i32 662205335, ; 56: System.Text.Encodings.Web.dll => 0x27787397 => 165
	i32 663517072, ; 57: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 106
	i32 672442732, ; 58: System.Collections.Concurrent => 0x2814a96c => 117
	i32 683518922, ; 59: System.Net.Security => 0x28bdabca => 143
	i32 690569205, ; 60: System.Xml.Linq.dll => 0x29293ff5 => 174
	i32 699345723, ; 61: System.Reflection.Emit => 0x29af2b3b => 151
	i32 722857257, ; 62: System.Runtime.Loader.dll => 0x2b15ed29 => 157
	i32 748832960, ; 63: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 78
	i32 759454413, ; 64: System.Net.Requests => 0x2d445acd => 142
	i32 775507847, ; 65: System.IO.Compression => 0x2e394f87 => 132
	i32 777317022, ; 66: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 25
	i32 789151979, ; 67: Microsoft.Extensions.Options => 0x2f0980eb => 69
	i32 804008546, ; 68: Microsoft.AspNetCore.Components.WebView.Maui => 0x2fec3262 => 55
	i32 823281589, ; 69: System.Private.Uri.dll => 0x311247b5 => 147
	i32 830298997, ; 70: System.IO.Compression.Brotli => 0x317d5b75 => 131
	i32 869139383, ; 71: hi\Microsoft.Maui.Controls.resources.dll => 0x33ce03b7 => 10
	i32 880668424, ; 72: ru\Microsoft.Maui.Controls.resources.dll => 0x347def08 => 24
	i32 888076676, ; 73: IdentityModel.OidcClient.dll => 0x34eef984 => 44
	i32 904024072, ; 74: System.ComponentModel.Primitives.dll => 0x35e25008 => 122
	i32 918734561, ; 75: pt-BR\Microsoft.Maui.Controls.resources.dll => 0x36c2c6e1 => 21
	i32 940202475, ; 76: Mapster => 0x380a59eb => 45
	i32 961460050, ; 77: it\Microsoft.Maui.Controls.resources.dll => 0x394eb752 => 14
	i32 967690846, ; 78: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 94
	i32 979695631, ; 79: Mapster.DependencyInjection => 0x3a64f80f => 47
	i32 990727110, ; 80: ro\Microsoft.Maui.Controls.resources.dll => 0x3b0d4bc6 => 23
	i32 992768348, ; 81: System.Collections.dll => 0x3b2c715c => 120
	i32 999186168, ; 82: Microsoft.Extensions.FileSystemGlobbing.dll => 0x3b8e5ef8 => 65
	i32 1012816738, ; 83: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 104
	i32 1019214401, ; 84: System.Drawing => 0x3cbffa41 => 129
	i32 1028951442, ; 85: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 60
	i32 1035644815, ; 86: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 83
	i32 1036536393, ; 87: System.Drawing.Primitives.dll => 0x3dc84a49 => 128
	i32 1040019210, ; 88: Mapster.Core.dll => 0x3dfd6f0a => 46
	i32 1043950537, ; 89: de\Microsoft.Maui.Controls.resources.dll => 0x3e396bc9 => 4
	i32 1044663988, ; 90: System.Linq.Expressions.dll => 0x3e444eb4 => 134
	i32 1052210849, ; 91: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 96
	i32 1082857460, ; 92: System.ComponentModel.TypeConverter => 0x408b17f4 => 123
	i32 1084122840, ; 93: Xamarin.Kotlin.StdLib => 0x409e66d8 => 111
	i32 1098259244, ; 94: System => 0x41761b2c => 176
	i32 1106284210, ; 95: Protos => 0x41f08eb2 => 113
	i32 1108272742, ; 96: sv\Microsoft.Maui.Controls.resources.dll => 0x420ee666 => 26
	i32 1117529484, ; 97: pl\Microsoft.Maui.Controls.resources.dll => 0x429c258c => 20
	i32 1118262833, ; 98: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 16
	i32 1149092582, ; 99: Xamarin.AndroidX.Window => 0x447dc2e6 => 109
	i32 1168523401, ; 100: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 22
	i32 1173126369, ; 101: Microsoft.Extensions.FileProviders.Abstractions.dll => 0x45ec7ce1 => 61
	i32 1178241025, ; 102: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 101
	i32 1203173028, ; 103: Grpc.Net.Client => 0x47b6f6a4 => 39
	i32 1260983243, ; 104: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 2
	i32 1292207520, ; 105: SQLitePCLRaw.core.dll => 0x4d0585a0 => 79
	i32 1293217323, ; 106: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 92
	i32 1308624726, ; 107: hr\Microsoft.Maui.Controls.resources.dll => 0x4e000756 => 11
	i32 1322716291, ; 108: Xamarin.AndroidX.Window.dll => 0x4ed70c83 => 109
	i32 1324164729, ; 109: System.Linq => 0x4eed2679 => 136
	i32 1336711579, ; 110: zh-HK\Microsoft.Maui.Controls.resources.dll => 0x4fac999b => 31
	i32 1373134921, ; 111: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 32
	i32 1376866003, ; 112: Xamarin.AndroidX.SavedState => 0x52114ed3 => 104
	i32 1379779777, ; 113: System.Resources.ResourceManager => 0x523dc4c1 => 153
	i32 1406073936, ; 114: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 88
	i32 1430672901, ; 115: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 0
	i32 1440495139, ; 116: SharedLib.dll => 0x55dc3623 => 114
	i32 1452070440, ; 117: System.Formats.Asn1.dll => 0x568cd628 => 130
	i32 1454105418, ; 118: Microsoft.Extensions.FileProviders.Composite => 0x56abe34a => 62
	i32 1457743152, ; 119: System.Runtime.Extensions.dll => 0x56e36530 => 154
	i32 1458022317, ; 120: System.Net.Security.dll => 0x56e7a7ad => 143
	i32 1461004990, ; 121: es\Microsoft.Maui.Controls.resources => 0x57152abe => 6
	i32 1462112819, ; 122: System.IO.Compression.dll => 0x57261233 => 132
	i32 1469204771, ; 123: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 84
	i32 1470490898, ; 124: Microsoft.Extensions.Primitives => 0x57a5e912 => 70
	i32 1480492111, ; 125: System.IO.Compression.Brotli.dll => 0x583e844f => 131
	i32 1505131794, ; 126: Microsoft.Extensions.Http => 0x59b67d12 => 66
	i32 1521091094, ; 127: Microsoft.Extensions.FileSystemGlobbing => 0x5aaa0216 => 65
	i32 1526286932, ; 128: vi\Microsoft.Maui.Controls.resources.dll => 0x5af94a54 => 30
	i32 1543031311, ; 129: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 167
	i32 1543355203, ; 130: System.Reflection.Emit.dll => 0x5bfdbb43 => 151
	i32 1546581739, ; 131: Microsoft.AspNetCore.Components.WebView.Maui.dll => 0x5c2ef6eb => 55
	i32 1622152042, ; 132: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 98
	i32 1624863272, ; 133: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 108
	i32 1632842087, ; 134: Microsoft.Extensions.Configuration.Json => 0x61533167 => 58
	i32 1636350590, ; 135: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 90
	i32 1639515021, ; 136: System.Net.Http.dll => 0x61b9038d => 138
	i32 1639986890, ; 137: System.Text.RegularExpressions => 0x61c036ca => 167
	i32 1654881142, ; 138: Microsoft.AspNetCore.Components.WebView => 0x62a37b76 => 54
	i32 1657153582, ; 139: System.Runtime => 0x62c6282e => 159
	i32 1658251792, ; 140: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 110
	i32 1677501392, ; 141: System.Net.Primitives.dll => 0x63fca3d0 => 141
	i32 1679018464, ; 142: Blazored.LocalStorage => 0x6413c9e0 => 36
	i32 1679769178, ; 143: System.Security.Cryptography => 0x641f3e5a => 164
	i32 1701541528, ; 144: System.Diagnostics.Debug.dll => 0x656b7698 => 126
	i32 1711441057, ; 145: SQLitePCLRaw.lib.e_sqlite3.android => 0x660284a1 => 80
	i32 1729485958, ; 146: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 86
	i32 1743415430, ; 147: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 1
	i32 1760259689, ; 148: Microsoft.AspNetCore.Components.Web.dll => 0x68eb6e69 => 52
	i32 1766324549, ; 149: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 105
	i32 1770582343, ; 150: Microsoft.Extensions.Logging.dll => 0x6988f147 => 67
	i32 1780572499, ; 151: Mono.Android.Runtime.dll => 0x6a216153 => 180
	i32 1782161461, ; 152: Grpc.Core.Api => 0x6a39a035 => 38
	i32 1782862114, ; 153: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 17
	i32 1788241197, ; 154: Xamarin.AndroidX.Fragment => 0x6a96652d => 93
	i32 1793755602, ; 155: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 9
	i32 1795738900, ; 156: Mapster.Core => 0x6b08cd14 => 46
	i32 1808609942, ; 157: Xamarin.AndroidX.Loader => 0x6bcd3296 => 98
	i32 1813058853, ; 158: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 111
	i32 1813201214, ; 159: Xamarin.Google.Android.Material => 0x6c13413e => 110
	i32 1818569960, ; 160: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 102
	i32 1827745125, ; 161: Microsoft.AspNetCore.Components.WebAssembly.Authentication => 0x6cf12d65 => 53
	i32 1828688058, ; 162: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 68
	i32 1853025655, ; 163: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 26
	i32 1858542181, ; 164: System.Linq.Expressions => 0x6ec71a65 => 134
	i32 1870277092, ; 165: System.Reflection.Primitives => 0x6f7a29e4 => 152
	i32 1875480394, ; 166: IdentityModel => 0x6fc98f4a => 43
	i32 1875935024, ; 167: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 8
	i32 1893218855, ; 168: cs\Microsoft.Maui.Controls.resources.dll => 0x70d83a27 => 2
	i32 1900610850, ; 169: System.Resources.ResourceManager.dll => 0x71490522 => 153
	i32 1910275211, ; 170: System.Collections.NonGeneric.dll => 0x71dc7c8b => 118
	i32 1939592360, ; 171: System.Private.Xml.Linq => 0x739bd4a8 => 148
	i32 1953182387, ; 172: id\Microsoft.Maui.Controls.resources.dll => 0x746b32b3 => 13
	i32 1968388702, ; 173: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 56
	i32 2003115576, ; 174: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 5
	i32 2019465201, ; 175: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 96
	i32 2045470958, ; 176: System.Private.Xml => 0x79eb68ee => 149
	i32 2055257422, ; 177: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 95
	i32 2066184531, ; 178: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 4
	i32 2072397586, ; 179: Microsoft.Extensions.FileProviders.Physical => 0x7b864712 => 64
	i32 2079903147, ; 180: System.Runtime.dll => 0x7bf8cdab => 159
	i32 2090596640, ; 181: System.Numerics.Vectors => 0x7c9bf920 => 145
	i32 2103459038, ; 182: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 81
	i32 2127167465, ; 183: System.Console => 0x7ec9ffe9 => 125
	i32 2142473426, ; 184: System.Collections.Specialized => 0x7fb38cd2 => 119
	i32 2159891885, ; 185: Microsoft.Maui => 0x80bd55ad => 74
	i32 2169148018, ; 186: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 12
	i32 2181898931, ; 187: Microsoft.Extensions.Options.dll => 0x820d22b3 => 69
	i32 2192057212, ; 188: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 68
	i32 2192166651, ; 189: Microsoft.AspNetCore.Components.Authorization.dll => 0x82a9cefb => 50
	i32 2193016926, ; 190: System.ObjectModel.dll => 0x82b6c85e => 146
	i32 2201107256, ; 191: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 112
	i32 2201231467, ; 192: System.Net.Http => 0x8334206b => 138
	i32 2207618523, ; 193: it\Microsoft.Maui.Controls.resources => 0x839595db => 14
	i32 2266799131, ; 194: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 57
	i32 2279755925, ; 195: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 103
	i32 2295906218, ; 196: System.Net.Sockets => 0x88d8bfaa => 144
	i32 2303942373, ; 197: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 18
	i32 2305521784, ; 198: System.Private.CoreLib.dll => 0x896b7878 => 178
	i32 2311968808, ; 199: Blazored.LocalStorage.dll => 0x89cdd828 => 36
	i32 2340441535, ; 200: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 155
	i32 2353062107, ; 201: System.Net.Primitives => 0x8c40e0db => 141
	i32 2366048013, ; 202: hu\Microsoft.Maui.Controls.resources.dll => 0x8d07070d => 12
	i32 2368005991, ; 203: System.Xml.ReaderWriter.dll => 0x8d24e767 => 175
	i32 2371007202, ; 204: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 56
	i32 2395872292, ; 205: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 13
	i32 2401565422, ; 206: System.Web.HttpUtility => 0x8f24faee => 173
	i32 2411328690, ; 207: Microsoft.AspNetCore.Components => 0x8fb9f4b2 => 49
	i32 2427813419, ; 208: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 10
	i32 2435356389, ; 209: System.Console.dll => 0x912896e5 => 125
	i32 2442556106, ; 210: Microsoft.JSInterop.dll => 0x919672ca => 71
	i32 2458678730, ; 211: System.Net.Sockets.dll => 0x928c75ca => 144
	i32 2465273461, ; 212: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 78
	i32 2471841756, ; 213: netstandard.dll => 0x93554fdc => 177
	i32 2475788418, ; 214: Java.Interop.dll => 0x93918882 => 179
	i32 2480646305, ; 215: Microsoft.Maui.Controls => 0x93dba8a1 => 72
	i32 2503351294, ; 216: ko\Microsoft.Maui.Controls.resources.dll => 0x95361bfe => 16
	i32 2537015816, ; 217: Microsoft.AspNetCore.Authorization => 0x9737ca08 => 48
	i32 2550873716, ; 218: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 11
	i32 2562349572, ; 219: Microsoft.CSharp => 0x98ba5a04 => 116
	i32 2570120770, ; 220: System.Text.Encodings.Web => 0x9930ee42 => 165
	i32 2576534780, ; 221: ja\Microsoft.Maui.Controls.resources.dll => 0x9992ccfc => 15
	i32 2585813321, ; 222: Microsoft.AspNetCore.Components.Forms => 0x9a206149 => 51
	i32 2592341985, ; 223: Microsoft.Extensions.FileProviders.Abstractions => 0x9a83ffe1 => 61
	i32 2593496499, ; 224: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 20
	i32 2605712449, ; 225: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 112
	i32 2617129537, ; 226: System.Private.Xml.dll => 0x9bfe3a41 => 149
	i32 2620871830, ; 227: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 90
	i32 2626831493, ; 228: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 15
	i32 2657731189, ; 229: Microsoft.AspNetCore.Components.WebAssembly.Authentication.dll => 0x9e69c275 => 53
	i32 2662834856, ; 230: Mapster.dll => 0x9eb7a2a8 => 45
	i32 2663698177, ; 231: System.Runtime.Loader => 0x9ec4cf01 => 157
	i32 2665622720, ; 232: System.Drawing.Primitives => 0x9ee22cc0 => 128
	i32 2692077919, ; 233: Microsoft.AspNetCore.Components.WebView.dll => 0xa075d95f => 54
	i32 2715334215, ; 234: System.Threading.Tasks.dll => 0xa1d8b647 => 169
	i32 2717744543, ; 235: System.Security.Claims => 0xa1fd7d9f => 160
	i32 2724373263, ; 236: System.Runtime.Numerics.dll => 0xa262a30f => 158
	i32 2732626843, ; 237: Xamarin.AndroidX.Activity => 0xa2e0939b => 82
	i32 2735172069, ; 238: System.Threading.Channels => 0xa30769e5 => 168
	i32 2735631878, ; 239: Microsoft.AspNetCore.Authorization.dll => 0xa30e6e06 => 48
	i32 2737747696, ; 240: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 84
	i32 2740698338, ; 241: ca\Microsoft.Maui.Controls.resources.dll => 0xa35bbce2 => 1
	i32 2752995522, ; 242: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 21
	i32 2758225723, ; 243: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 73
	i32 2764765095, ; 244: Microsoft.Maui.dll => 0xa4caf7a7 => 74
	i32 2778768386, ; 245: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 107
	i32 2785988530, ; 246: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 27
	i32 2801831435, ; 247: Microsoft.Maui.Graphics => 0xa7008e0b => 76
	i32 2810250172, ; 248: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 88
	i32 2853208004, ; 249: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 107
	i32 2861189240, ; 250: Microsoft.Maui.Essentials => 0xaa8a4878 => 75
	i32 2888921313, ; 251: Grpc.Net.ClientFactory.dll => 0xac3170e1 => 41
	i32 2892341533, ; 252: Microsoft.AspNetCore.Components.Web => 0xac65a11d => 52
	i32 2909740682, ; 253: System.Private.CoreLib => 0xad6f1e8a => 178
	i32 2911054922, ; 254: Microsoft.Extensions.FileProviders.Physical.dll => 0xad832c4a => 64
	i32 2916838712, ; 255: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 108
	i32 2919462931, ; 256: System.Numerics.Vectors.dll => 0xae037813 => 145
	i32 2959614098, ; 257: System.ComponentModel.dll => 0xb0682092 => 124
	i32 2972252294, ; 258: System.Security.Cryptography.Algorithms.dll => 0xb128f886 => 161
	i32 2978675010, ; 259: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 92
	i32 3038032645, ; 260: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 34
	i32 3053864966, ; 261: fi\Microsoft.Maui.Controls.resources.dll => 0xb6064806 => 7
	i32 3057625584, ; 262: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 99
	i32 3059408633, ; 263: Mono.Android.Runtime => 0xb65adef9 => 180
	i32 3059793426, ; 264: System.ComponentModel.Primitives => 0xb660be12 => 122
	i32 3075834255, ; 265: System.Threading.Tasks => 0xb755818f => 169
	i32 3090735792, ; 266: System.Security.Cryptography.X509Certificates.dll => 0xb838e2b0 => 163
	i32 3099732863, ; 267: System.Security.Claims.dll => 0xb8c22b7f => 160
	i32 3103600923, ; 268: System.Formats.Asn1 => 0xb8fd311b => 130
	i32 3106263381, ; 269: Grpc.Net.Common.dll => 0xb925d155 => 42
	i32 3159123045, ; 270: System.Reflection.Primitives.dll => 0xbc4c6465 => 152
	i32 3178803400, ; 271: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 100
	i32 3220365878, ; 272: System.Threading => 0xbff2e236 => 172
	i32 3258312781, ; 273: Xamarin.AndroidX.CardView => 0xc235e84d => 86
	i32 3265493905, ; 274: System.Linq.Queryable.dll => 0xc2a37b91 => 135
	i32 3280506390, ; 275: System.ComponentModel.Annotations.dll => 0xc3888e16 => 121
	i32 3286872994, ; 276: SQLite-net.dll => 0xc3e9b3a2 => 77
	i32 3305363605, ; 277: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 7
	i32 3316684772, ; 278: System.Net.Requests.dll => 0xc5b097e4 => 142
	i32 3317135071, ; 279: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 91
	i32 3346324047, ; 280: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 101
	i32 3357674450, ; 281: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 24
	i32 3358260929, ; 282: System.Text.Json => 0xc82afec1 => 166
	i32 3360279109, ; 283: SQLitePCLRaw.core => 0xc849ca45 => 79
	i32 3362522851, ; 284: Xamarin.AndroidX.Core => 0xc86c06e3 => 89
	i32 3366347497, ; 285: Java.Interop => 0xc8a662e9 => 179
	i32 3374999561, ; 286: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 103
	i32 3381016424, ; 287: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 3
	i32 3406629867, ; 288: Microsoft.Extensions.FileProviders.Composite.dll => 0xcb0d0beb => 62
	i32 3428513518, ; 289: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 59
	i32 3430777524, ; 290: netstandard => 0xcc7d82b4 => 177
	i32 3458724246, ; 291: pt\Microsoft.Maui.Controls.resources.dll => 0xce27f196 => 22
	i32 3464190856, ; 292: Microsoft.AspNetCore.Components.Forms.dll => 0xce7b5b88 => 51
	i32 3471940407, ; 293: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 123
	i32 3476120550, ; 294: Mono.Android => 0xcf3163e6 => 181
	i32 3484440000, ; 295: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 23
	i32 3485117614, ; 296: System.Text.Json.dll => 0xcfbaacae => 166
	i32 3499097210, ; 297: Google.Protobuf.dll => 0xd08ffc7a => 37
	i32 3500000672, ; 298: Microsoft.JSInterop => 0xd09dc5a0 => 71
	i32 3509114376, ; 299: System.Xml.Linq => 0xd128d608 => 174
	i32 3546531070, ; 300: BlazorBootstrap => 0xd363c4fe => 35
	i32 3552735000, ; 301: Grpc.Net.Client.Web.dll => 0xd3c26f18 => 40
	i32 3560100363, ; 302: System.Threading.Timer => 0xd432d20b => 171
	i32 3580758918, ; 303: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 31
	i32 3592228221, ; 304: zh-Hant\Microsoft.Maui.Controls.resources.dll => 0xd61d0d7d => 33
	i32 3608519521, ; 305: System.Linq.dll => 0xd715a361 => 136
	i32 3624195450, ; 306: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 155
	i32 3641597786, ; 307: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 95
	i32 3643446276, ; 308: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 28
	i32 3643854240, ; 309: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 100
	i32 3645630983, ; 310: Google.Protobuf => 0xd94bea07 => 37
	i32 3657292374, ; 311: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 57
	i32 3660523487, ; 312: System.Net.NetworkInformation => 0xda2f27df => 140
	i32 3672681054, ; 313: Mono.Android.dll => 0xdae8aa5e => 181
	i32 3682565725, ; 314: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 85
	i32 3722202641, ; 315: Microsoft.Extensions.Configuration.Json.dll => 0xdddc4e11 => 58
	i32 3724971120, ; 316: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 99
	i32 3732100267, ; 317: System.Net.NameResolution => 0xde7354ab => 139
	i32 3748608112, ; 318: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 127
	i32 3751619990, ; 319: da\Microsoft.Maui.Controls.resources.dll => 0xdf9d2d96 => 3
	i32 3754567612, ; 320: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 81
	i32 3786282454, ; 321: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 87
	i32 3792276235, ; 322: System.Collections.NonGeneric => 0xe2098b0b => 118
	i32 3802395368, ; 323: System.Collections.Specialized.dll => 0xe2a3f2e8 => 119
	i32 3823082795, ; 324: System.Security.Cryptography.dll => 0xe3df9d2b => 164
	i32 3837493441, ; 325: BlazorBootstrap.dll => 0xe4bb80c1 => 35
	i32 3841636137, ; 326: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 60
	i32 3849253459, ; 327: System.Runtime.InteropServices.dll => 0xe56ef253 => 156
	i32 3871810066, ; 328: Grpc.Net.ClientFactory => 0xe6c72212 => 41
	i32 3876362041, ; 329: SQLite-net => 0xe70c9739 => 77
	i32 3896106733, ; 330: System.Collections.Concurrent.dll => 0xe839deed => 117
	i32 3896760992, ; 331: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 89
	i32 3920221145, ; 332: nl\Microsoft.Maui.Controls.resources.dll => 0xe9a9d3d9 => 19
	i32 3921031405, ; 333: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 106
	i32 3928044579, ; 334: System.Xml.ReaderWriter => 0xea213423 => 175
	i32 3931092270, ; 335: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 102
	i32 3955647286, ; 336: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 83
	i32 4025784931, ; 337: System.Memory => 0xeff49a63 => 137
	i32 4044257358, ; 338: IdentityModel.dll => 0xf10e784e => 43
	i32 4046471985, ; 339: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 73
	i32 4054681211, ; 340: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 150
	i32 4068434129, ; 341: System.Private.Xml.Linq.dll => 0xf27f60d1 => 148
	i32 4073602200, ; 342: System.Threading.dll => 0xf2ce3c98 => 172
	i32 4091086043, ; 343: el\Microsoft.Maui.Controls.resources.dll => 0xf3d904db => 5
	i32 4094352644, ; 344: Microsoft.Maui.Essentials.dll => 0xf40add04 => 75
	i32 4099507663, ; 345: System.Drawing.dll => 0xf45985cf => 129
	i32 4100113165, ; 346: System.Private.Uri => 0xf462c30d => 147
	i32 4103439459, ; 347: uk\Microsoft.Maui.Controls.resources.dll => 0xf4958463 => 29
	i32 4126470640, ; 348: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 59
	i32 4127667938, ; 349: System.IO.FileSystem.Watcher => 0xf60736e2 => 133
	i32 4147896353, ; 350: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 150
	i32 4150914736, ; 351: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 29
	i32 4152369130, ; 352: IdentityModel.OidcClient => 0xf7801fea => 44
	i32 4164802419, ; 353: System.IO.FileSystem.Watcher.dll => 0xf83dd773 => 133
	i32 4182413190, ; 354: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 97
	i32 4208300564, ; 355: Grpc.Net.Client.Web => 0xfad59214 => 40
	i32 4213026141, ; 356: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 127
	i32 4216061222, ; 357: SharedLib => 0xfb4bfd26 => 114
	i32 4223918059, ; 358: GpsTracker.dll => 0xfbc3dfeb => 115
	i32 4249188766, ; 359: nb\Microsoft.Maui.Controls.resources.dll => 0xfd45799e => 18
	i32 4271975918, ; 360: Microsoft.Maui.Controls.dll => 0xfea12dee => 72
	i32 4274976490, ; 361: System.Runtime.Numerics => 0xfecef6ea => 158
	i32 4292120959, ; 362: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 97
	i32 4294648842 ; 363: Microsoft.Extensions.FileProviders.Embedded => 0xfffb240a => 63
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [364 x i32] [
	i32 140, ; 0
	i32 139, ; 1
	i32 0, ; 2
	i32 9, ; 3
	i32 170, ; 4
	i32 33, ; 5
	i32 162, ; 6
	i32 76, ; 7
	i32 17, ; 8
	i32 156, ; 9
	i32 168, ; 10
	i32 32, ; 11
	i32 115, ; 12
	i32 25, ; 13
	i32 162, ; 14
	i32 121, ; 15
	i32 87, ; 16
	i32 105, ; 17
	i32 124, ; 18
	i32 85, ; 19
	i32 126, ; 20
	i32 116, ; 21
	i32 50, ; 22
	i32 49, ; 23
	i32 171, ; 24
	i32 66, ; 25
	i32 30, ; 26
	i32 82, ; 27
	i32 8, ; 28
	i32 94, ; 29
	i32 80, ; 30
	i32 42, ; 31
	i32 38, ; 32
	i32 170, ; 33
	i32 137, ; 34
	i32 39, ; 35
	i32 34, ; 36
	i32 28, ; 37
	i32 47, ; 38
	i32 120, ; 39
	i32 93, ; 40
	i32 163, ; 41
	i32 173, ; 42
	i32 176, ; 43
	i32 6, ; 44
	i32 146, ; 45
	i32 70, ; 46
	i32 135, ; 47
	i32 27, ; 48
	i32 67, ; 49
	i32 154, ; 50
	i32 63, ; 51
	i32 161, ; 52
	i32 113, ; 53
	i32 91, ; 54
	i32 19, ; 55
	i32 165, ; 56
	i32 106, ; 57
	i32 117, ; 58
	i32 143, ; 59
	i32 174, ; 60
	i32 151, ; 61
	i32 157, ; 62
	i32 78, ; 63
	i32 142, ; 64
	i32 132, ; 65
	i32 25, ; 66
	i32 69, ; 67
	i32 55, ; 68
	i32 147, ; 69
	i32 131, ; 70
	i32 10, ; 71
	i32 24, ; 72
	i32 44, ; 73
	i32 122, ; 74
	i32 21, ; 75
	i32 45, ; 76
	i32 14, ; 77
	i32 94, ; 78
	i32 47, ; 79
	i32 23, ; 80
	i32 120, ; 81
	i32 65, ; 82
	i32 104, ; 83
	i32 129, ; 84
	i32 60, ; 85
	i32 83, ; 86
	i32 128, ; 87
	i32 46, ; 88
	i32 4, ; 89
	i32 134, ; 90
	i32 96, ; 91
	i32 123, ; 92
	i32 111, ; 93
	i32 176, ; 94
	i32 113, ; 95
	i32 26, ; 96
	i32 20, ; 97
	i32 16, ; 98
	i32 109, ; 99
	i32 22, ; 100
	i32 61, ; 101
	i32 101, ; 102
	i32 39, ; 103
	i32 2, ; 104
	i32 79, ; 105
	i32 92, ; 106
	i32 11, ; 107
	i32 109, ; 108
	i32 136, ; 109
	i32 31, ; 110
	i32 32, ; 111
	i32 104, ; 112
	i32 153, ; 113
	i32 88, ; 114
	i32 0, ; 115
	i32 114, ; 116
	i32 130, ; 117
	i32 62, ; 118
	i32 154, ; 119
	i32 143, ; 120
	i32 6, ; 121
	i32 132, ; 122
	i32 84, ; 123
	i32 70, ; 124
	i32 131, ; 125
	i32 66, ; 126
	i32 65, ; 127
	i32 30, ; 128
	i32 167, ; 129
	i32 151, ; 130
	i32 55, ; 131
	i32 98, ; 132
	i32 108, ; 133
	i32 58, ; 134
	i32 90, ; 135
	i32 138, ; 136
	i32 167, ; 137
	i32 54, ; 138
	i32 159, ; 139
	i32 110, ; 140
	i32 141, ; 141
	i32 36, ; 142
	i32 164, ; 143
	i32 126, ; 144
	i32 80, ; 145
	i32 86, ; 146
	i32 1, ; 147
	i32 52, ; 148
	i32 105, ; 149
	i32 67, ; 150
	i32 180, ; 151
	i32 38, ; 152
	i32 17, ; 153
	i32 93, ; 154
	i32 9, ; 155
	i32 46, ; 156
	i32 98, ; 157
	i32 111, ; 158
	i32 110, ; 159
	i32 102, ; 160
	i32 53, ; 161
	i32 68, ; 162
	i32 26, ; 163
	i32 134, ; 164
	i32 152, ; 165
	i32 43, ; 166
	i32 8, ; 167
	i32 2, ; 168
	i32 153, ; 169
	i32 118, ; 170
	i32 148, ; 171
	i32 13, ; 172
	i32 56, ; 173
	i32 5, ; 174
	i32 96, ; 175
	i32 149, ; 176
	i32 95, ; 177
	i32 4, ; 178
	i32 64, ; 179
	i32 159, ; 180
	i32 145, ; 181
	i32 81, ; 182
	i32 125, ; 183
	i32 119, ; 184
	i32 74, ; 185
	i32 12, ; 186
	i32 69, ; 187
	i32 68, ; 188
	i32 50, ; 189
	i32 146, ; 190
	i32 112, ; 191
	i32 138, ; 192
	i32 14, ; 193
	i32 57, ; 194
	i32 103, ; 195
	i32 144, ; 196
	i32 18, ; 197
	i32 178, ; 198
	i32 36, ; 199
	i32 155, ; 200
	i32 141, ; 201
	i32 12, ; 202
	i32 175, ; 203
	i32 56, ; 204
	i32 13, ; 205
	i32 173, ; 206
	i32 49, ; 207
	i32 10, ; 208
	i32 125, ; 209
	i32 71, ; 210
	i32 144, ; 211
	i32 78, ; 212
	i32 177, ; 213
	i32 179, ; 214
	i32 72, ; 215
	i32 16, ; 216
	i32 48, ; 217
	i32 11, ; 218
	i32 116, ; 219
	i32 165, ; 220
	i32 15, ; 221
	i32 51, ; 222
	i32 61, ; 223
	i32 20, ; 224
	i32 112, ; 225
	i32 149, ; 226
	i32 90, ; 227
	i32 15, ; 228
	i32 53, ; 229
	i32 45, ; 230
	i32 157, ; 231
	i32 128, ; 232
	i32 54, ; 233
	i32 169, ; 234
	i32 160, ; 235
	i32 158, ; 236
	i32 82, ; 237
	i32 168, ; 238
	i32 48, ; 239
	i32 84, ; 240
	i32 1, ; 241
	i32 21, ; 242
	i32 73, ; 243
	i32 74, ; 244
	i32 107, ; 245
	i32 27, ; 246
	i32 76, ; 247
	i32 88, ; 248
	i32 107, ; 249
	i32 75, ; 250
	i32 41, ; 251
	i32 52, ; 252
	i32 178, ; 253
	i32 64, ; 254
	i32 108, ; 255
	i32 145, ; 256
	i32 124, ; 257
	i32 161, ; 258
	i32 92, ; 259
	i32 34, ; 260
	i32 7, ; 261
	i32 99, ; 262
	i32 180, ; 263
	i32 122, ; 264
	i32 169, ; 265
	i32 163, ; 266
	i32 160, ; 267
	i32 130, ; 268
	i32 42, ; 269
	i32 152, ; 270
	i32 100, ; 271
	i32 172, ; 272
	i32 86, ; 273
	i32 135, ; 274
	i32 121, ; 275
	i32 77, ; 276
	i32 7, ; 277
	i32 142, ; 278
	i32 91, ; 279
	i32 101, ; 280
	i32 24, ; 281
	i32 166, ; 282
	i32 79, ; 283
	i32 89, ; 284
	i32 179, ; 285
	i32 103, ; 286
	i32 3, ; 287
	i32 62, ; 288
	i32 59, ; 289
	i32 177, ; 290
	i32 22, ; 291
	i32 51, ; 292
	i32 123, ; 293
	i32 181, ; 294
	i32 23, ; 295
	i32 166, ; 296
	i32 37, ; 297
	i32 71, ; 298
	i32 174, ; 299
	i32 35, ; 300
	i32 40, ; 301
	i32 171, ; 302
	i32 31, ; 303
	i32 33, ; 304
	i32 136, ; 305
	i32 155, ; 306
	i32 95, ; 307
	i32 28, ; 308
	i32 100, ; 309
	i32 37, ; 310
	i32 57, ; 311
	i32 140, ; 312
	i32 181, ; 313
	i32 85, ; 314
	i32 58, ; 315
	i32 99, ; 316
	i32 139, ; 317
	i32 127, ; 318
	i32 3, ; 319
	i32 81, ; 320
	i32 87, ; 321
	i32 118, ; 322
	i32 119, ; 323
	i32 164, ; 324
	i32 35, ; 325
	i32 60, ; 326
	i32 156, ; 327
	i32 41, ; 328
	i32 77, ; 329
	i32 117, ; 330
	i32 89, ; 331
	i32 19, ; 332
	i32 106, ; 333
	i32 175, ; 334
	i32 102, ; 335
	i32 83, ; 336
	i32 137, ; 337
	i32 43, ; 338
	i32 73, ; 339
	i32 150, ; 340
	i32 148, ; 341
	i32 172, ; 342
	i32 5, ; 343
	i32 75, ; 344
	i32 129, ; 345
	i32 147, ; 346
	i32 29, ; 347
	i32 59, ; 348
	i32 133, ; 349
	i32 150, ; 350
	i32 29, ; 351
	i32 44, ; 352
	i32 133, ; 353
	i32 97, ; 354
	i32 40, ; 355
	i32 127, ; 356
	i32 114, ; 357
	i32 115, ; 358
	i32 18, ; 359
	i32 72, ; 360
	i32 158, ; 361
	i32 97, ; 362
	i32 63 ; 363
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

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
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
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
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.1xx-preview7 @ d8764fc950e5e864f357bb0c4d44b6d5a2675229"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"min_enum_size", i32 4}
