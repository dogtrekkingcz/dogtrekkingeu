; ModuleID = 'marshal_methods.x86.ll'
source_filename = "marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [350 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [694 x i32] [
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 68
	i32 10166715, ; 1: System.Net.NameResolution.dll => 0x9b21bb => 67
	i32 15721112, ; 2: System.Runtime.Intrinsics.dll => 0xefe298 => 108
	i32 32687329, ; 3: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 268
	i32 34715100, ; 4: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 302
	i32 34839235, ; 5: System.IO.FileSystem.DriveInfo => 0x2139ac3 => 48
	i32 38948123, ; 6: ar\Microsoft.Maui.Controls.resources.dll => 0x2524d1b => 310
	i32 39485524, ; 7: System.Net.WebSockets.dll => 0x25a8054 => 80
	i32 42244203, ; 8: he\Microsoft.Maui.Controls.resources.dll => 0x284986b => 319
	i32 42639949, ; 9: System.Threading.Thread => 0x28aa24d => 145
	i32 66541672, ; 10: System.Diagnostics.StackTrace => 0x3f75868 => 30
	i32 67008169, ; 11: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 343
	i32 68219467, ; 12: System.Security.Cryptography.Primitives => 0x410f24b => 124
	i32 72070932, ; 13: Microsoft.Maui.Graphics.dll => 0x44bb714 => 220
	i32 82292897, ; 14: System.Runtime.CompilerServices.VisualC.dll => 0x4e7b0a1 => 102
	i32 83839681, ; 15: ms\Microsoft.Maui.Controls.resources.dll => 0x4ff4ac1 => 327
	i32 101534019, ; 16: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 286
	i32 117431740, ; 17: System.Runtime.InteropServices => 0x6ffddbc => 107
	i32 120558881, ; 18: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 286
	i32 122350210, ; 19: System.Threading.Channels.dll => 0x74aea82 => 139
	i32 134690465, ; 20: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 306
	i32 136584136, ; 21: zh-Hans\Microsoft.Maui.Controls.resources.dll => 0x8241bc8 => 342
	i32 136700176, ; 22: GpsTracker => 0x825e110 => 0
	i32 140062828, ; 23: sk\Microsoft.Maui.Controls.resources.dll => 0x859306c => 335
	i32 142721839, ; 24: System.Net.WebHeaderCollection => 0x881c32f => 77
	i32 149972175, ; 25: System.Security.Cryptography.Primitives.dll => 0x8f064cf => 124
	i32 159306688, ; 26: System.ComponentModel.Annotations => 0x97ed3c0 => 13
	i32 165246403, ; 27: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 242
	i32 176265551, ; 28: System.ServiceProcess => 0xa81994f => 132
	i32 182336117, ; 29: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 288
	i32 184328833, ; 30: System.ValueTuple.dll => 0xafca281 => 151
	i32 205061960, ; 31: System.ComponentModel => 0xc38ff48 => 18
	i32 209399409, ; 32: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 240
	i32 220171995, ; 33: System.Diagnostics.Debug => 0xd1f8edb => 26
	i32 230216969, ; 34: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 262
	i32 230752869, ; 35: Microsoft.CSharp.dll => 0xdc10265 => 1
	i32 231409092, ; 36: System.Linq.Parallel => 0xdcb05c4 => 59
	i32 231814094, ; 37: System.Globalization => 0xdd133ce => 42
	i32 244348769, ; 38: Microsoft.AspNetCore.Components.Authorization => 0xe907761 => 189
	i32 246610117, ; 39: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 91
	i32 254259026, ; 40: Microsoft.AspNetCore.Components.dll => 0xf27af52 => 188
	i32 261689757, ; 41: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 245
	i32 276479776, ; 42: System.Threading.Timer.dll => 0x107abf20 => 147
	i32 278686392, ; 43: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 264
	i32 280482487, ; 44: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 261
	i32 291076382, ; 45: System.IO.Pipes.AccessControl.dll => 0x1159791e => 54
	i32 291275502, ; 46: Microsoft.Extensions.Http.dll => 0x115c82ee => 208
	i32 298918909, ; 47: System.Net.Ping.dll => 0x11d123fd => 69
	i32 317674968, ; 48: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 340
	i32 318968648, ; 49: Xamarin.AndroidX.Activity.dll => 0x13031348 => 231
	i32 321597661, ; 50: System.Numerics => 0x132b30dd => 83
	i32 321963286, ; 51: fr\Microsoft.Maui.Controls.resources.dll => 0x1330c516 => 318
	i32 342366114, ; 52: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 263
	i32 347068432, ; 53: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0x14afd810 => 224
	i32 360082299, ; 54: System.ServiceModel.Web => 0x15766b7b => 131
	i32 364956269, ; 55: Grpc.Net.Common => 0x15c0ca6d => 181
	i32 367780167, ; 56: System.IO.Pipes => 0x15ebe147 => 55
	i32 371306672, ; 57: Grpc.Core.Api.dll => 0x1621b0b0 => 177
	i32 374914964, ; 58: System.Transactions.Local => 0x1658bf94 => 149
	i32 375677976, ; 59: System.Net.ServicePoint.dll => 0x16646418 => 74
	i32 379916513, ; 60: System.Threading.Thread.dll => 0x16a510e1 => 145
	i32 385762202, ; 61: System.Memory.dll => 0x16fe439a => 62
	i32 391886110, ; 62: Grpc.Net.Client.dll => 0x175bb51e => 178
	i32 392610295, ; 63: System.Threading.ThreadPool.dll => 0x1766c1f7 => 146
	i32 395744057, ; 64: _Microsoft.Android.Resource.Designer => 0x17969339 => 346
	i32 403441872, ; 65: WindowsBase => 0x180c08d0 => 165
	i32 409257351, ; 66: tr\Microsoft.Maui.Controls.resources.dll => 0x1864c587 => 338
	i32 441335492, ; 67: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 246
	i32 442470736, ; 68: Mapster.DependencyInjection.dll => 0x1a5f9150 => 186
	i32 442565967, ; 69: System.Collections => 0x1a61054f => 12
	i32 450948140, ; 70: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 259
	i32 451504562, ; 71: System.Security.Cryptography.X509Certificates => 0x1ae969b2 => 125
	i32 456227837, ; 72: System.Web.HttpUtility.dll => 0x1b317bfd => 152
	i32 459347974, ; 73: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 113
	i32 465846621, ; 74: mscorlib => 0x1bc4415d => 166
	i32 469710990, ; 75: System.dll => 0x1bff388e => 164
	i32 476646585, ; 76: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 261
	i32 486930444, ; 77: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 274
	i32 489220957, ; 78: es\Microsoft.Maui.Controls.resources.dll => 0x1d28eb5d => 316
	i32 498788369, ; 79: System.ObjectModel => 0x1dbae811 => 84
	i32 513247710, ; 80: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 213
	i32 526420162, ; 81: System.Transactions.dll => 0x1f6088c2 => 150
	i32 527452488, ; 82: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 306
	i32 530272170, ; 83: System.Linq.Queryable => 0x1f9b4faa => 60
	i32 538707440, ; 84: th\Microsoft.Maui.Controls.resources.dll => 0x201c05f0 => 337
	i32 539058512, ; 85: Microsoft.Extensions.Logging => 0x20216150 => 209
	i32 540030774, ; 86: System.IO.FileSystem.dll => 0x20303736 => 51
	i32 545304856, ; 87: System.Runtime.Extensions => 0x2080b118 => 103
	i32 546455878, ; 88: System.Runtime.Serialization.Xml => 0x20924146 => 114
	i32 549171840, ; 89: System.Globalization.Calendars => 0x20bbb280 => 40
	i32 557405415, ; 90: Jsr305Binding => 0x213954e7 => 299
	i32 569601784, ; 91: Xamarin.AndroidX.Window.Extensions.Core.Core => 0x21f36ef8 => 297
	i32 571435654, ; 92: Microsoft.Extensions.FileProviders.Embedded.dll => 0x220f6a86 => 205
	i32 577335427, ; 93: System.Security.Cryptography.Cng => 0x22697083 => 120
	i32 601371474, ; 94: System.IO.IsolatedStorage.dll => 0x23d83352 => 52
	i32 605376203, ; 95: System.IO.Compression.FileSystem => 0x24154ecb => 44
	i32 613668793, ; 96: System.Security.Cryptography.Algorithms => 0x2493d7b9 => 119
	i32 617706511, ; 97: Protos.dll => 0x24d1740f => 344
	i32 627609679, ; 98: Xamarin.AndroidX.CustomView => 0x2568904f => 251
	i32 627931235, ; 99: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 329
	i32 639843206, ; 100: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x26233b86 => 257
	i32 643868501, ; 101: System.Net => 0x2660a755 => 81
	i32 662205335, ; 102: System.Text.Encodings.Web.dll => 0x27787397 => 136
	i32 663517072, ; 103: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 293
	i32 666292255, ; 104: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 238
	i32 672442732, ; 105: System.Collections.Concurrent => 0x2814a96c => 8
	i32 683518922, ; 106: System.Net.Security => 0x28bdabca => 73
	i32 690569205, ; 107: System.Xml.Linq.dll => 0x29293ff5 => 155
	i32 691348768, ; 108: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 308
	i32 693804605, ; 109: System.Windows => 0x295a9e3d => 154
	i32 699345723, ; 110: System.Reflection.Emit => 0x29af2b3b => 92
	i32 700284507, ; 111: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 303
	i32 700358131, ; 112: System.IO.Compression.ZipFile => 0x29be9df3 => 45
	i32 720511267, ; 113: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 307
	i32 722857257, ; 114: System.Runtime.Loader.dll => 0x2b15ed29 => 109
	i32 735137430, ; 115: System.Security.SecureString.dll => 0x2bd14e96 => 129
	i32 748832960, ; 116: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 222
	i32 752232764, ; 117: System.Diagnostics.Contracts.dll => 0x2cd6293c => 25
	i32 755313932, ; 118: Xamarin.Android.Glide.Annotations.dll => 0x2d052d0c => 228
	i32 759454413, ; 119: System.Net.Requests => 0x2d445acd => 72
	i32 762598435, ; 120: System.IO.Pipes.dll => 0x2d745423 => 55
	i32 775507847, ; 121: System.IO.Compression => 0x2e394f87 => 46
	i32 777317022, ; 122: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 335
	i32 789151979, ; 123: Microsoft.Extensions.Options => 0x2f0980eb => 212
	i32 790371945, ; 124: Xamarin.AndroidX.CustomView.PoolingContainer.dll => 0x2f1c1e69 => 252
	i32 804008546, ; 125: Microsoft.AspNetCore.Components.WebView.Maui => 0x2fec3262 => 194
	i32 804715423, ; 126: System.Data.Common => 0x2ff6fb9f => 22
	i32 807930345, ; 127: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx.dll => 0x302809e9 => 266
	i32 823281589, ; 128: System.Private.Uri.dll => 0x311247b5 => 86
	i32 830298997, ; 129: System.IO.Compression.Brotli => 0x317d5b75 => 43
	i32 832635846, ; 130: System.Xml.XPath.dll => 0x31a103c6 => 160
	i32 834051424, ; 131: System.Net.Quic => 0x31b69d60 => 71
	i32 843511501, ; 132: Xamarin.AndroidX.Print => 0x3246f6cd => 279
	i32 869139383, ; 133: hi\Microsoft.Maui.Controls.resources.dll => 0x33ce03b7 => 320
	i32 873119928, ; 134: Microsoft.VisualBasic => 0x340ac0b8 => 3
	i32 877678880, ; 135: System.Globalization.dll => 0x34505120 => 42
	i32 878954865, ; 136: System.Net.Http.Json => 0x3463c971 => 63
	i32 880668424, ; 137: ru\Microsoft.Maui.Controls.resources.dll => 0x347def08 => 334
	i32 888076676, ; 138: IdentityModel.OidcClient.dll => 0x34eef984 => 183
	i32 904024072, ; 139: System.ComponentModel.Primitives.dll => 0x35e25008 => 16
	i32 911108515, ; 140: System.IO.MemoryMappedFiles.dll => 0x364e69a3 => 53
	i32 918734561, ; 141: pt-BR\Microsoft.Maui.Controls.resources.dll => 0x36c2c6e1 => 331
	i32 928116545, ; 142: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 302
	i32 940202475, ; 143: Mapster => 0x380a59eb => 184
	i32 952186615, ; 144: System.Runtime.InteropServices.JavaScript.dll => 0x38c136f7 => 105
	i32 956575887, ; 145: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 307
	i32 961460050, ; 146: it\Microsoft.Maui.Controls.resources.dll => 0x394eb752 => 324
	i32 966729478, ; 147: Xamarin.Google.Crypto.Tink.Android => 0x399f1f06 => 300
	i32 967690846, ; 148: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 263
	i32 975236339, ; 149: System.Diagnostics.Tracing => 0x3a20ecf3 => 34
	i32 975874589, ; 150: System.Xml.XDocument => 0x3a2aaa1d => 158
	i32 979695631, ; 151: Mapster.DependencyInjection => 0x3a64f80f => 186
	i32 986514023, ; 152: System.Private.DataContractSerialization.dll => 0x3acd0267 => 85
	i32 987214855, ; 153: System.Diagnostics.Tools => 0x3ad7b407 => 32
	i32 990727110, ; 154: ro\Microsoft.Maui.Controls.resources.dll => 0x3b0d4bc6 => 333
	i32 992768348, ; 155: System.Collections.dll => 0x3b2c715c => 12
	i32 994442037, ; 156: System.IO.FileSystem => 0x3b45fb35 => 51
	i32 999186168, ; 157: Microsoft.Extensions.FileSystemGlobbing.dll => 0x3b8e5ef8 => 207
	i32 1001831731, ; 158: System.IO.UnmanagedMemoryStream.dll => 0x3bb6bd33 => 56
	i32 1012816738, ; 159: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 283
	i32 1019214401, ; 160: System.Drawing => 0x3cbffa41 => 36
	i32 1028951442, ; 161: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 202
	i32 1031528504, ; 162: Xamarin.Google.ErrorProne.Annotations.dll => 0x3d7be038 => 301
	i32 1035644815, ; 163: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 236
	i32 1036536393, ; 164: System.Drawing.Primitives.dll => 0x3dc84a49 => 35
	i32 1040019210, ; 165: Mapster.Core.dll => 0x3dfd6f0a => 185
	i32 1043950537, ; 166: de\Microsoft.Maui.Controls.resources.dll => 0x3e396bc9 => 314
	i32 1044663988, ; 167: System.Linq.Expressions.dll => 0x3e444eb4 => 58
	i32 1052210849, ; 168: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 270
	i32 1067306892, ; 169: GoogleGson => 0x3f9dcf8c => 176
	i32 1082857460, ; 170: System.ComponentModel.TypeConverter => 0x408b17f4 => 17
	i32 1084122840, ; 171: Xamarin.Kotlin.StdLib => 0x409e66d8 => 304
	i32 1098259244, ; 172: System => 0x41761b2c => 164
	i32 1106284210, ; 173: Protos => 0x41f08eb2 => 344
	i32 1106973742, ; 174: Microsoft.Extensions.Configuration.FileExtensions.dll => 0x41fb142e => 199
	i32 1108272742, ; 175: sv\Microsoft.Maui.Controls.resources.dll => 0x420ee666 => 336
	i32 1117529484, ; 176: pl\Microsoft.Maui.Controls.resources.dll => 0x429c258c => 330
	i32 1118262833, ; 177: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 326
	i32 1121599056, ; 178: Xamarin.AndroidX.Lifecycle.Runtime.Ktx.dll => 0x42da3e50 => 269
	i32 1127624469, ; 179: Microsoft.Extensions.Logging.Debug => 0x43362f15 => 211
	i32 1149092582, ; 180: Xamarin.AndroidX.Window => 0x447dc2e6 => 296
	i32 1168523401, ; 181: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 332
	i32 1170634674, ; 182: System.Web.dll => 0x45c677b2 => 153
	i32 1173126369, ; 183: Microsoft.Extensions.FileProviders.Abstractions.dll => 0x45ec7ce1 => 203
	i32 1175144683, ; 184: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 292
	i32 1178241025, ; 185: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 277
	i32 1203173028, ; 186: Grpc.Net.Client => 0x47b6f6a4 => 178
	i32 1204270330, ; 187: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 238
	i32 1208641965, ; 188: System.Diagnostics.Process => 0x480a69ad => 29
	i32 1219128291, ; 189: System.IO.IsolatedStorage => 0x48aa6be3 => 52
	i32 1243150071, ; 190: Xamarin.AndroidX.Window.Extensions.Core.Core.dll => 0x4a18f6f7 => 297
	i32 1253011324, ; 191: Microsoft.Win32.Registry => 0x4aaf6f7c => 5
	i32 1260983243, ; 192: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 312
	i32 1264511973, ; 193: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 287
	i32 1267360935, ; 194: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 291
	i32 1273260888, ; 195: Xamarin.AndroidX.Collection.Ktx => 0x4be46b58 => 243
	i32 1275534314, ; 196: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 308
	i32 1278448581, ; 197: Xamarin.AndroidX.Annotation.Jvm => 0x4c3393c5 => 235
	i32 1292207520, ; 198: SQLitePCLRaw.core.dll => 0x4d0585a0 => 223
	i32 1293217323, ; 199: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 254
	i32 1308624726, ; 200: hr\Microsoft.Maui.Controls.resources.dll => 0x4e000756 => 321
	i32 1309188875, ; 201: System.Private.DataContractSerialization => 0x4e08a30b => 85
	i32 1322716291, ; 202: Xamarin.AndroidX.Window.dll => 0x4ed70c83 => 296
	i32 1324164729, ; 203: System.Linq => 0x4eed2679 => 61
	i32 1335329327, ; 204: System.Runtime.Serialization.Json.dll => 0x4f97822f => 112
	i32 1336711579, ; 205: zh-HK\Microsoft.Maui.Controls.resources.dll => 0x4fac999b => 341
	i32 1364015309, ; 206: System.IO => 0x514d38cd => 57
	i32 1373134921, ; 207: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 342
	i32 1376866003, ; 208: Xamarin.AndroidX.SavedState => 0x52114ed3 => 283
	i32 1379779777, ; 209: System.Resources.ResourceManager => 0x523dc4c1 => 99
	i32 1402170036, ; 210: System.Configuration.dll => 0x53936ab4 => 19
	i32 1406073936, ; 211: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 247
	i32 1408764838, ; 212: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 111
	i32 1411638395, ; 213: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 101
	i32 1422545099, ; 214: System.Runtime.CompilerServices.VisualC => 0x54ca50cb => 102
	i32 1430672901, ; 215: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 310
	i32 1434145427, ; 216: System.Runtime.Handles => 0x557b5293 => 104
	i32 1435222561, ; 217: Xamarin.Google.Crypto.Tink.Android.dll => 0x558bc221 => 300
	i32 1439761251, ; 218: System.Net.Quic.dll => 0x55d10363 => 71
	i32 1440495139, ; 219: SharedLib.dll => 0x55dc3623 => 345
	i32 1452070440, ; 220: System.Formats.Asn1.dll => 0x568cd628 => 38
	i32 1453312822, ; 221: System.Diagnostics.Tools.dll => 0x569fcb36 => 32
	i32 1454105418, ; 222: Microsoft.Extensions.FileProviders.Composite => 0x56abe34a => 204
	i32 1457743152, ; 223: System.Runtime.Extensions.dll => 0x56e36530 => 103
	i32 1458022317, ; 224: System.Net.Security.dll => 0x56e7a7ad => 73
	i32 1461004990, ; 225: es\Microsoft.Maui.Controls.resources => 0x57152abe => 316
	i32 1461234159, ; 226: System.Collections.Immutable.dll => 0x5718a9ef => 9
	i32 1461719063, ; 227: System.Security.Cryptography.OpenSsl => 0x57201017 => 123
	i32 1462112819, ; 228: System.IO.Compression.dll => 0x57261233 => 46
	i32 1469204771, ; 229: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 237
	i32 1470490898, ; 230: Microsoft.Extensions.Primitives => 0x57a5e912 => 213
	i32 1479771757, ; 231: System.Collections.Immutable => 0x5833866d => 9
	i32 1480492111, ; 232: System.IO.Compression.Brotli.dll => 0x583e844f => 43
	i32 1487239319, ; 233: Microsoft.Win32.Primitives => 0x58a57897 => 4
	i32 1490025113, ; 234: Xamarin.AndroidX.SavedState.SavedState.Ktx.dll => 0x58cffa99 => 284
	i32 1505131794, ; 235: Microsoft.Extensions.Http => 0x59b67d12 => 208
	i32 1521091094, ; 236: Microsoft.Extensions.FileSystemGlobbing => 0x5aaa0216 => 207
	i32 1526286932, ; 237: vi\Microsoft.Maui.Controls.resources.dll => 0x5af94a54 => 340
	i32 1536373174, ; 238: System.Diagnostics.TextWriterTraceListener => 0x5b9331b6 => 31
	i32 1543031311, ; 239: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 138
	i32 1543355203, ; 240: System.Reflection.Emit.dll => 0x5bfdbb43 => 92
	i32 1546581739, ; 241: Microsoft.AspNetCore.Components.WebView.Maui.dll => 0x5c2ef6eb => 194
	i32 1550322496, ; 242: System.Reflection.Extensions.dll => 0x5c680b40 => 93
	i32 1565862583, ; 243: System.IO.FileSystem.Primitives => 0x5d552ab7 => 49
	i32 1566207040, ; 244: System.Threading.Tasks.Dataflow.dll => 0x5d5a6c40 => 141
	i32 1573704789, ; 245: System.Runtime.Serialization.Json => 0x5dccd455 => 112
	i32 1580037396, ; 246: System.Threading.Overlapped => 0x5e2d7514 => 140
	i32 1582372066, ; 247: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 253
	i32 1592978981, ; 248: System.Runtime.Serialization.dll => 0x5ef2ee25 => 115
	i32 1597949149, ; 249: Xamarin.Google.ErrorProne.Annotations => 0x5f3ec4dd => 301
	i32 1601112923, ; 250: System.Xml.Serialization => 0x5f6f0b5b => 157
	i32 1604827217, ; 251: System.Net.WebClient => 0x5fa7b851 => 76
	i32 1618516317, ; 252: System.Net.WebSockets.Client.dll => 0x6078995d => 79
	i32 1622152042, ; 253: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 273
	i32 1622358360, ; 254: System.Dynamic.Runtime => 0x60b33958 => 37
	i32 1624863272, ; 255: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 295
	i32 1632842087, ; 256: Microsoft.Extensions.Configuration.Json => 0x61533167 => 200
	i32 1635184631, ; 257: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x6176eff7 => 257
	i32 1636350590, ; 258: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 250
	i32 1639515021, ; 259: System.Net.Http.dll => 0x61b9038d => 64
	i32 1639986890, ; 260: System.Text.RegularExpressions => 0x61c036ca => 138
	i32 1641389582, ; 261: System.ComponentModel.EventBasedAsync.dll => 0x61d59e0e => 15
	i32 1654881142, ; 262: Microsoft.AspNetCore.Components.WebView => 0x62a37b76 => 193
	i32 1657153582, ; 263: System.Runtime => 0x62c6282e => 116
	i32 1658241508, ; 264: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 289
	i32 1658251792, ; 265: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 298
	i32 1670060433, ; 266: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 245
	i32 1675553242, ; 267: System.IO.FileSystem.DriveInfo.dll => 0x63dee9da => 48
	i32 1677501392, ; 268: System.Net.Primitives.dll => 0x63fca3d0 => 70
	i32 1678508291, ; 269: System.Net.WebSockets => 0x640c0103 => 80
	i32 1679018464, ; 270: Blazored.LocalStorage => 0x6413c9e0 => 174
	i32 1679769178, ; 271: System.Security.Cryptography => 0x641f3e5a => 126
	i32 1691477237, ; 272: System.Reflection.Metadata => 0x64d1e4f5 => 94
	i32 1696967625, ; 273: System.Security.Cryptography.Csp => 0x6525abc9 => 121
	i32 1698840827, ; 274: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 305
	i32 1701541528, ; 275: System.Diagnostics.Debug.dll => 0x656b7698 => 26
	i32 1711441057, ; 276: SQLitePCLRaw.lib.e_sqlite3.android => 0x660284a1 => 224
	i32 1720223769, ; 277: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx => 0x66888819 => 266
	i32 1726116996, ; 278: System.Reflection.dll => 0x66e27484 => 97
	i32 1728033016, ; 279: System.Diagnostics.FileVersionInfo.dll => 0x66ffb0f8 => 28
	i32 1729485958, ; 280: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 241
	i32 1743415430, ; 281: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 311
	i32 1744735666, ; 282: System.Transactions.Local.dll => 0x67fe8db2 => 149
	i32 1746115085, ; 283: System.IO.Pipelines.dll => 0x68139a0d => 226
	i32 1746316138, ; 284: Mono.Android.Export => 0x6816ab6a => 169
	i32 1750313021, ; 285: Microsoft.Win32.Primitives.dll => 0x6853a83d => 4
	i32 1758240030, ; 286: System.Resources.Reader.dll => 0x68cc9d1e => 98
	i32 1760259689, ; 287: Microsoft.AspNetCore.Components.Web.dll => 0x68eb6e69 => 191
	i32 1763938596, ; 288: System.Diagnostics.TraceSource.dll => 0x69239124 => 33
	i32 1765942094, ; 289: System.Reflection.Extensions => 0x6942234e => 93
	i32 1766324549, ; 290: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 288
	i32 1770582343, ; 291: Microsoft.Extensions.Logging.dll => 0x6988f147 => 209
	i32 1776026572, ; 292: System.Core.dll => 0x69dc03cc => 21
	i32 1777075843, ; 293: System.Globalization.Extensions.dll => 0x69ec0683 => 41
	i32 1780572499, ; 294: Mono.Android.Runtime.dll => 0x6a216153 => 170
	i32 1782161461, ; 295: Grpc.Core.Api => 0x6a39a035 => 177
	i32 1782862114, ; 296: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 327
	i32 1788241197, ; 297: Xamarin.AndroidX.Fragment => 0x6a96652d => 259
	i32 1793755602, ; 298: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 319
	i32 1795738900, ; 299: Mapster.Core => 0x6b08cd14 => 185
	i32 1808609942, ; 300: Xamarin.AndroidX.Loader => 0x6bcd3296 => 273
	i32 1813058853, ; 301: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 304
	i32 1813201214, ; 302: Xamarin.Google.Android.Material => 0x6c13413e => 298
	i32 1818569960, ; 303: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 278
	i32 1818787751, ; 304: Microsoft.VisualBasic.Core => 0x6c687fa7 => 2
	i32 1824175904, ; 305: System.Text.Encoding.Extensions => 0x6cbab720 => 134
	i32 1824722060, ; 306: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 111
	i32 1827745125, ; 307: Microsoft.AspNetCore.Components.WebAssembly.Authentication => 0x6cf12d65 => 192
	i32 1828688058, ; 308: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 210
	i32 1847515442, ; 309: Xamarin.Android.Glide.Annotations => 0x6e1ed932 => 228
	i32 1853025655, ; 310: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 336
	i32 1858542181, ; 311: System.Linq.Expressions => 0x6ec71a65 => 58
	i32 1870277092, ; 312: System.Reflection.Primitives => 0x6f7a29e4 => 95
	i32 1875480394, ; 313: IdentityModel => 0x6fc98f4a => 182
	i32 1875935024, ; 314: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 318
	i32 1879696579, ; 315: System.Formats.Tar.dll => 0x7009e4c3 => 39
	i32 1885316902, ; 316: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 239
	i32 1888955245, ; 317: System.Diagnostics.Contracts => 0x70972b6d => 25
	i32 1889954781, ; 318: System.Reflection.Metadata.dll => 0x70a66bdd => 94
	i32 1893218855, ; 319: cs\Microsoft.Maui.Controls.resources.dll => 0x70d83a27 => 312
	i32 1898237753, ; 320: System.Reflection.DispatchProxy => 0x7124cf39 => 89
	i32 1900610850, ; 321: System.Resources.ResourceManager.dll => 0x71490522 => 99
	i32 1910275211, ; 322: System.Collections.NonGeneric.dll => 0x71dc7c8b => 10
	i32 1939592360, ; 323: System.Private.Xml.Linq => 0x739bd4a8 => 87
	i32 1953182387, ; 324: id\Microsoft.Maui.Controls.resources.dll => 0x746b32b3 => 323
	i32 1956758971, ; 325: System.Resources.Writer => 0x74a1c5bb => 100
	i32 1961813231, ; 326: Xamarin.AndroidX.Security.SecurityCrypto.dll => 0x74eee4ef => 285
	i32 1968388702, ; 327: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 196
	i32 1983156543, ; 328: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 305
	i32 1985761444, ; 329: Xamarin.Android.Glide.GifDecoder => 0x765c50a4 => 230
	i32 2003115576, ; 330: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 315
	i32 2011961780, ; 331: System.Buffers.dll => 0x77ec19b4 => 7
	i32 2019465201, ; 332: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 270
	i32 2031763787, ; 333: Xamarin.Android.Glide => 0x791a414b => 227
	i32 2045470958, ; 334: System.Private.Xml => 0x79eb68ee => 88
	i32 2048278909, ; 335: Microsoft.Extensions.Configuration.Binder.dll => 0x7a16417d => 198
	i32 2055257422, ; 336: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 265
	i32 2060060697, ; 337: System.Windows.dll => 0x7aca0819 => 154
	i32 2066184531, ; 338: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 314
	i32 2070888862, ; 339: System.Diagnostics.TraceSource => 0x7b6f419e => 33
	i32 2072397586, ; 340: Microsoft.Extensions.FileProviders.Physical => 0x7b864712 => 206
	i32 2079903147, ; 341: System.Runtime.dll => 0x7bf8cdab => 116
	i32 2090596640, ; 342: System.Numerics.Vectors => 0x7c9bf920 => 82
	i32 2103459038, ; 343: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 225
	i32 2127167465, ; 344: System.Console => 0x7ec9ffe9 => 20
	i32 2142473426, ; 345: System.Collections.Specialized => 0x7fb38cd2 => 11
	i32 2143790110, ; 346: System.Xml.XmlSerializer.dll => 0x7fc7a41e => 162
	i32 2146852085, ; 347: Microsoft.VisualBasic.dll => 0x7ff65cf5 => 3
	i32 2159891885, ; 348: Microsoft.Maui => 0x80bd55ad => 218
	i32 2169148018, ; 349: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 322
	i32 2181898931, ; 350: Microsoft.Extensions.Options.dll => 0x820d22b3 => 212
	i32 2192057212, ; 351: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 210
	i32 2192166651, ; 352: Microsoft.AspNetCore.Components.Authorization.dll => 0x82a9cefb => 189
	i32 2193016926, ; 353: System.ObjectModel.dll => 0x82b6c85e => 84
	i32 2201107256, ; 354: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 309
	i32 2201231467, ; 355: System.Net.Http => 0x8334206b => 64
	i32 2207618523, ; 356: it\Microsoft.Maui.Controls.resources => 0x839595db => 324
	i32 2217644978, ; 357: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 292
	i32 2222056684, ; 358: System.Threading.Tasks.Parallel => 0x8471e4ec => 143
	i32 2244775296, ; 359: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 274
	i32 2252106437, ; 360: System.Xml.Serialization.dll => 0x863c6ac5 => 157
	i32 2256313426, ; 361: System.Globalization.Extensions => 0x867c9c52 => 41
	i32 2265110946, ; 362: System.Security.AccessControl.dll => 0x8702d9a2 => 117
	i32 2266799131, ; 363: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 197
	i32 2267999099, ; 364: Xamarin.Android.Glide.DiskLruCache.dll => 0x872eeb7b => 229
	i32 2279755925, ; 365: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 281
	i32 2293034957, ; 366: System.ServiceModel.Web.dll => 0x88acefcd => 131
	i32 2295906218, ; 367: System.Net.Sockets => 0x88d8bfaa => 75
	i32 2298471582, ; 368: System.Net.Mail => 0x88ffe49e => 66
	i32 2303942373, ; 369: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 328
	i32 2305521784, ; 370: System.Private.CoreLib.dll => 0x896b7878 => 172
	i32 2311968808, ; 371: Blazored.LocalStorage.dll => 0x89cdd828 => 174
	i32 2315684594, ; 372: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 233
	i32 2320631194, ; 373: System.Threading.Tasks.Parallel.dll => 0x8a52059a => 143
	i32 2340441535, ; 374: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 106
	i32 2344264397, ; 375: System.ValueTuple => 0x8bbaa2cd => 151
	i32 2353062107, ; 376: System.Net.Primitives => 0x8c40e0db => 70
	i32 2366048013, ; 377: hu\Microsoft.Maui.Controls.resources.dll => 0x8d07070d => 322
	i32 2368005991, ; 378: System.Xml.ReaderWriter.dll => 0x8d24e767 => 156
	i32 2371007202, ; 379: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 196
	i32 2378619854, ; 380: System.Security.Cryptography.Csp.dll => 0x8dc6dbce => 121
	i32 2383496789, ; 381: System.Security.Principal.Windows.dll => 0x8e114655 => 127
	i32 2395872292, ; 382: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 323
	i32 2401565422, ; 383: System.Web.HttpUtility => 0x8f24faee => 152
	i32 2403452196, ; 384: Xamarin.AndroidX.Emoji2.dll => 0x8f41c524 => 256
	i32 2411328690, ; 385: Microsoft.AspNetCore.Components => 0x8fb9f4b2 => 188
	i32 2421380589, ; 386: System.Threading.Tasks.Dataflow => 0x905355ed => 141
	i32 2423080555, ; 387: Xamarin.AndroidX.Collection.Ktx.dll => 0x906d466b => 243
	i32 2427813419, ; 388: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 320
	i32 2435356389, ; 389: System.Console.dll => 0x912896e5 => 20
	i32 2435904999, ; 390: System.ComponentModel.DataAnnotations.dll => 0x9130f5e7 => 14
	i32 2442556106, ; 391: Microsoft.JSInterop.dll => 0x919672ca => 214
	i32 2454642406, ; 392: System.Text.Encoding.dll => 0x924edee6 => 135
	i32 2458678730, ; 393: System.Net.Sockets.dll => 0x928c75ca => 75
	i32 2459001652, ; 394: System.Linq.Parallel.dll => 0x92916334 => 59
	i32 2465273461, ; 395: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 222
	i32 2465532216, ; 396: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 246
	i32 2471841756, ; 397: netstandard.dll => 0x93554fdc => 167
	i32 2475788418, ; 398: Java.Interop.dll => 0x93918882 => 168
	i32 2480646305, ; 399: Microsoft.Maui.Controls => 0x93dba8a1 => 216
	i32 2483903535, ; 400: System.ComponentModel.EventBasedAsync => 0x940d5c2f => 15
	i32 2484371297, ; 401: System.Net.ServicePoint => 0x94147f61 => 74
	i32 2490993605, ; 402: System.AppContext.dll => 0x94798bc5 => 6
	i32 2501346920, ; 403: System.Data.DataSetExtensions => 0x95178668 => 23
	i32 2503351294, ; 404: ko\Microsoft.Maui.Controls.resources.dll => 0x95361bfe => 326
	i32 2505896520, ; 405: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 268
	i32 2522472828, ; 406: Xamarin.Android.Glide.dll => 0x9659e17c => 227
	i32 2537015816, ; 407: Microsoft.AspNetCore.Authorization => 0x9737ca08 => 187
	i32 2538310050, ; 408: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 91
	i32 2550873716, ; 409: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 321
	i32 2562349572, ; 410: Microsoft.CSharp => 0x98ba5a04 => 1
	i32 2570120770, ; 411: System.Text.Encodings.Web => 0x9930ee42 => 136
	i32 2576534780, ; 412: ja\Microsoft.Maui.Controls.resources.dll => 0x9992ccfc => 325
	i32 2581783588, ; 413: Xamarin.AndroidX.Lifecycle.Runtime.Ktx => 0x99e2e424 => 269
	i32 2581819634, ; 414: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 291
	i32 2585220780, ; 415: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 134
	i32 2585805581, ; 416: System.Net.Ping => 0x9a20430d => 69
	i32 2585813321, ; 417: Microsoft.AspNetCore.Components.Forms => 0x9a206149 => 190
	i32 2589602615, ; 418: System.Threading.ThreadPool => 0x9a5a3337 => 146
	i32 2592341985, ; 419: Microsoft.Extensions.FileProviders.Abstractions => 0x9a83ffe1 => 203
	i32 2593496499, ; 420: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 330
	i32 2605712449, ; 421: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 309
	i32 2615233544, ; 422: Xamarin.AndroidX.Fragment.Ktx => 0x9be14c08 => 260
	i32 2616218305, ; 423: Microsoft.Extensions.Logging.Debug.dll => 0x9bf052c1 => 211
	i32 2617129537, ; 424: System.Private.Xml.dll => 0x9bfe3a41 => 88
	i32 2618712057, ; 425: System.Reflection.TypeExtensions.dll => 0x9c165ff9 => 96
	i32 2620871830, ; 426: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 250
	i32 2624644809, ; 427: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 255
	i32 2626831493, ; 428: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 325
	i32 2627185994, ; 429: System.Diagnostics.TextWriterTraceListener.dll => 0x9c97ad4a => 31
	i32 2629843544, ; 430: System.IO.Compression.ZipFile.dll => 0x9cc03a58 => 45
	i32 2633051222, ; 431: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 264
	i32 2657731189, ; 432: Microsoft.AspNetCore.Components.WebAssembly.Authentication.dll => 0x9e69c275 => 192
	i32 2662834856, ; 433: Mapster.dll => 0x9eb7a2a8 => 184
	i32 2663391936, ; 434: Xamarin.Android.Glide.DiskLruCache => 0x9ec022c0 => 229
	i32 2663698177, ; 435: System.Runtime.Loader => 0x9ec4cf01 => 109
	i32 2664396074, ; 436: System.Xml.XDocument.dll => 0x9ecf752a => 158
	i32 2665622720, ; 437: System.Drawing.Primitives => 0x9ee22cc0 => 35
	i32 2676780864, ; 438: System.Data.Common.dll => 0x9f8c6f40 => 22
	i32 2686887180, ; 439: System.Runtime.Serialization.Xml.dll => 0xa026a50c => 114
	i32 2692077919, ; 440: Microsoft.AspNetCore.Components.WebView.dll => 0xa075d95f => 193
	i32 2693849962, ; 441: System.IO.dll => 0xa090e36a => 57
	i32 2701096212, ; 442: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 289
	i32 2715334215, ; 443: System.Threading.Tasks.dll => 0xa1d8b647 => 144
	i32 2717744543, ; 444: System.Security.Claims => 0xa1fd7d9f => 118
	i32 2719963679, ; 445: System.Security.Cryptography.Cng.dll => 0xa21f5a1f => 120
	i32 2724373263, ; 446: System.Runtime.Numerics.dll => 0xa262a30f => 110
	i32 2732626843, ; 447: Xamarin.AndroidX.Activity => 0xa2e0939b => 231
	i32 2735172069, ; 448: System.Threading.Channels => 0xa30769e5 => 139
	i32 2735631878, ; 449: Microsoft.AspNetCore.Authorization.dll => 0xa30e6e06 => 187
	i32 2737747696, ; 450: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 237
	i32 2740698338, ; 451: ca\Microsoft.Maui.Controls.resources.dll => 0xa35bbce2 => 311
	i32 2740948882, ; 452: System.IO.Pipes.AccessControl => 0xa35f8f92 => 54
	i32 2748088231, ; 453: System.Runtime.InteropServices.JavaScript => 0xa3cc7fa7 => 105
	i32 2752995522, ; 454: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 331
	i32 2758225723, ; 455: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 217
	i32 2764765095, ; 456: Microsoft.Maui.dll => 0xa4caf7a7 => 218
	i32 2765824710, ; 457: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 133
	i32 2770495804, ; 458: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 303
	i32 2778768386, ; 459: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 294
	i32 2779977773, ; 460: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0xa5b3182d => 282
	i32 2785988530, ; 461: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 337
	i32 2788224221, ; 462: Xamarin.AndroidX.Fragment.Ktx.dll => 0xa630ecdd => 260
	i32 2801831435, ; 463: Microsoft.Maui.Graphics => 0xa7008e0b => 220
	i32 2803228030, ; 464: System.Xml.XPath.XDocument.dll => 0xa715dd7e => 159
	i32 2810250172, ; 465: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 247
	i32 2819470561, ; 466: System.Xml.dll => 0xa80db4e1 => 163
	i32 2821205001, ; 467: System.ServiceProcess.dll => 0xa8282c09 => 132
	i32 2821294376, ; 468: Xamarin.AndroidX.ResourceInspection.Annotation => 0xa8298928 => 282
	i32 2824502124, ; 469: System.Xml.XmlDocument => 0xa85a7b6c => 161
	i32 2833784645, ; 470: Microsoft.AspNetCore.Metadata => 0xa8e81f45 => 195
	i32 2838993487, ; 471: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx.dll => 0xa9379a4f => 271
	i32 2849599387, ; 472: System.Threading.Overlapped.dll => 0xa9d96f9b => 140
	i32 2853208004, ; 473: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 294
	i32 2855708567, ; 474: Xamarin.AndroidX.Transition => 0xaa36a797 => 290
	i32 2861098320, ; 475: Mono.Android.Export.dll => 0xaa88e550 => 169
	i32 2861189240, ; 476: Microsoft.Maui.Essentials => 0xaa8a4878 => 219
	i32 2870099610, ; 477: Xamarin.AndroidX.Activity.Ktx.dll => 0xab123e9a => 232
	i32 2875164099, ; 478: Jsr305Binding.dll => 0xab5f85c3 => 299
	i32 2875220617, ; 479: System.Globalization.Calendars.dll => 0xab606289 => 40
	i32 2884993177, ; 480: Xamarin.AndroidX.ExifInterface => 0xabf58099 => 258
	i32 2887636118, ; 481: System.Net.dll => 0xac1dd496 => 81
	i32 2888921313, ; 482: Grpc.Net.ClientFactory.dll => 0xac3170e1 => 180
	i32 2892341533, ; 483: Microsoft.AspNetCore.Components.Web => 0xac65a11d => 191
	i32 2899753641, ; 484: System.IO.UnmanagedMemoryStream => 0xacd6baa9 => 56
	i32 2900621748, ; 485: System.Dynamic.Runtime.dll => 0xace3f9b4 => 37
	i32 2901442782, ; 486: System.Reflection => 0xacf080de => 97
	i32 2905242038, ; 487: mscorlib.dll => 0xad2a79b6 => 166
	i32 2909740682, ; 488: System.Private.CoreLib => 0xad6f1e8a => 172
	i32 2911054922, ; 489: Microsoft.Extensions.FileProviders.Physical.dll => 0xad832c4a => 206
	i32 2916838712, ; 490: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 295
	i32 2919462931, ; 491: System.Numerics.Vectors.dll => 0xae037813 => 82
	i32 2921128767, ; 492: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 234
	i32 2936416060, ; 493: System.Resources.Reader => 0xaf06273c => 98
	i32 2940926066, ; 494: System.Diagnostics.StackTrace.dll => 0xaf4af872 => 30
	i32 2942453041, ; 495: System.Xml.XPath.XDocument => 0xaf624531 => 159
	i32 2959614098, ; 496: System.ComponentModel.dll => 0xb0682092 => 18
	i32 2968338931, ; 497: System.Security.Principal.Windows => 0xb0ed41f3 => 127
	i32 2972252294, ; 498: System.Security.Cryptography.Algorithms.dll => 0xb128f886 => 119
	i32 2978675010, ; 499: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 254
	i32 2987532451, ; 500: Xamarin.AndroidX.Security.SecurityCrypto => 0xb21220a3 => 285
	i32 2996846495, ; 501: Xamarin.AndroidX.Lifecycle.Process.dll => 0xb2a03f9f => 267
	i32 3016983068, ; 502: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 287
	i32 3023353419, ; 503: WindowsBase.dll => 0xb434b64b => 165
	i32 3024354802, ; 504: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 262
	i32 3038032645, ; 505: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 346
	i32 3053864966, ; 506: fi\Microsoft.Maui.Controls.resources.dll => 0xb6064806 => 317
	i32 3056245963, ; 507: Xamarin.AndroidX.SavedState.SavedState.Ktx => 0xb62a9ccb => 284
	i32 3057625584, ; 508: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 275
	i32 3059408633, ; 509: Mono.Android.Runtime => 0xb65adef9 => 170
	i32 3059793426, ; 510: System.ComponentModel.Primitives => 0xb660be12 => 16
	i32 3075834255, ; 511: System.Threading.Tasks => 0xb755818f => 144
	i32 3090735792, ; 512: System.Security.Cryptography.X509Certificates.dll => 0xb838e2b0 => 125
	i32 3099732863, ; 513: System.Security.Claims.dll => 0xb8c22b7f => 118
	i32 3103600923, ; 514: System.Formats.Asn1 => 0xb8fd311b => 38
	i32 3106263381, ; 515: Grpc.Net.Common.dll => 0xb925d155 => 181
	i32 3111772706, ; 516: System.Runtime.Serialization => 0xb979e222 => 115
	i32 3121463068, ; 517: System.IO.FileSystem.AccessControl.dll => 0xba0dbf1c => 47
	i32 3124832203, ; 518: System.Threading.Tasks.Extensions => 0xba4127cb => 142
	i32 3132293585, ; 519: System.Security.AccessControl => 0xbab301d1 => 117
	i32 3147165239, ; 520: System.Diagnostics.Tracing.dll => 0xbb95ee37 => 34
	i32 3148237826, ; 521: GoogleGson.dll => 0xbba64c02 => 176
	i32 3159123045, ; 522: System.Reflection.Primitives.dll => 0xbc4c6465 => 95
	i32 3160747431, ; 523: System.IO.MemoryMappedFiles => 0xbc652da7 => 53
	i32 3178803400, ; 524: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 276
	i32 3192346100, ; 525: System.Security.SecureString => 0xbe4755f4 => 129
	i32 3193515020, ; 526: System.Web => 0xbe592c0c => 153
	i32 3204380047, ; 527: System.Data.dll => 0xbefef58f => 24
	i32 3209718065, ; 528: System.Xml.XmlDocument.dll => 0xbf506931 => 161
	i32 3211777861, ; 529: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 253
	i32 3220365878, ; 530: System.Threading => 0xbff2e236 => 148
	i32 3226221578, ; 531: System.Runtime.Handles.dll => 0xc04c3c0a => 104
	i32 3251039220, ; 532: System.Reflection.DispatchProxy.dll => 0xc1c6ebf4 => 89
	i32 3258312781, ; 533: Xamarin.AndroidX.CardView => 0xc235e84d => 241
	i32 3265493905, ; 534: System.Linq.Queryable.dll => 0xc2a37b91 => 60
	i32 3265893370, ; 535: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 142
	i32 3277815716, ; 536: System.Resources.Writer.dll => 0xc35f7fa4 => 100
	i32 3279906254, ; 537: Microsoft.Win32.Registry.dll => 0xc37f65ce => 5
	i32 3280506390, ; 538: System.ComponentModel.Annotations.dll => 0xc3888e16 => 13
	i32 3286872994, ; 539: SQLite-net.dll => 0xc3e9b3a2 => 221
	i32 3290767353, ; 540: System.Security.Cryptography.Encoding => 0xc4251ff9 => 122
	i32 3299363146, ; 541: System.Text.Encoding => 0xc4a8494a => 135
	i32 3303498502, ; 542: System.Diagnostics.FileVersionInfo => 0xc4e76306 => 28
	i32 3305363605, ; 543: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 317
	i32 3316684772, ; 544: System.Net.Requests.dll => 0xc5b097e4 => 72
	i32 3317135071, ; 545: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 251
	i32 3317144872, ; 546: System.Data => 0xc5b79d28 => 24
	i32 3340431453, ; 547: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 239
	i32 3345895724, ; 548: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 280
	i32 3346324047, ; 549: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 277
	i32 3357674450, ; 550: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 334
	i32 3358260929, ; 551: System.Text.Json => 0xc82afec1 => 137
	i32 3360279109, ; 552: SQLitePCLRaw.core => 0xc849ca45 => 223
	i32 3362336904, ; 553: Xamarin.AndroidX.Activity.Ktx => 0xc8693088 => 232
	i32 3362522851, ; 554: Xamarin.AndroidX.Core => 0xc86c06e3 => 248
	i32 3366347497, ; 555: Java.Interop => 0xc8a662e9 => 168
	i32 3374999561, ; 556: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 281
	i32 3381016424, ; 557: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 313
	i32 3395150330, ; 558: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 101
	i32 3403906625, ; 559: System.Security.Cryptography.OpenSsl.dll => 0xcae37e41 => 123
	i32 3405233483, ; 560: Xamarin.AndroidX.CustomView.PoolingContainer => 0xcaf7bd4b => 252
	i32 3406629867, ; 561: Microsoft.Extensions.FileProviders.Composite.dll => 0xcb0d0beb => 204
	i32 3421170118, ; 562: Microsoft.Extensions.Configuration.Binder => 0xcbeae9c6 => 198
	i32 3428513518, ; 563: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 201
	i32 3429136800, ; 564: System.Xml => 0xcc6479a0 => 163
	i32 3430777524, ; 565: netstandard => 0xcc7d82b4 => 167
	i32 3441283291, ; 566: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 255
	i32 3445260447, ; 567: System.Formats.Tar => 0xcd5a809f => 39
	i32 3452344032, ; 568: Microsoft.Maui.Controls.Compatibility.dll => 0xcdc696e0 => 215
	i32 3458724246, ; 569: pt\Microsoft.Maui.Controls.resources.dll => 0xce27f196 => 332
	i32 3464190856, ; 570: Microsoft.AspNetCore.Components.Forms.dll => 0xce7b5b88 => 190
	i32 3471940407, ; 571: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 17
	i32 3476120550, ; 572: Mono.Android => 0xcf3163e6 => 171
	i32 3484440000, ; 573: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 333
	i32 3485117614, ; 574: System.Text.Json.dll => 0xcfbaacae => 137
	i32 3486566296, ; 575: System.Transactions => 0xcfd0c798 => 150
	i32 3493954962, ; 576: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 244
	i32 3499097210, ; 577: Google.Protobuf.dll => 0xd08ffc7a => 175
	i32 3500000672, ; 578: Microsoft.JSInterop => 0xd09dc5a0 => 214
	i32 3509114376, ; 579: System.Xml.Linq => 0xd128d608 => 155
	i32 3515174580, ; 580: System.Security.dll => 0xd1854eb4 => 130
	i32 3530912306, ; 581: System.Configuration => 0xd2757232 => 19
	i32 3539954161, ; 582: System.Net.HttpListener => 0xd2ff69f1 => 65
	i32 3546531070, ; 583: BlazorBootstrap => 0xd363c4fe => 173
	i32 3552735000, ; 584: Grpc.Net.Client.Web.dll => 0xd3c26f18 => 179
	i32 3560100363, ; 585: System.Threading.Timer => 0xd432d20b => 147
	i32 3570554715, ; 586: System.IO.FileSystem.AccessControl => 0xd4d2575b => 47
	i32 3580758918, ; 587: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 341
	i32 3592228221, ; 588: zh-Hant\Microsoft.Maui.Controls.resources.dll => 0xd61d0d7d => 343
	i32 3597029428, ; 589: Xamarin.Android.Glide.GifDecoder.dll => 0xd6665034 => 230
	i32 3598340787, ; 590: System.Net.WebSockets.Client => 0xd67a52b3 => 79
	i32 3608519521, ; 591: System.Linq.dll => 0xd715a361 => 61
	i32 3624195450, ; 592: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 106
	i32 3627220390, ; 593: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 279
	i32 3633644679, ; 594: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 234
	i32 3638274909, ; 595: System.IO.FileSystem.Primitives.dll => 0xd8dbab5d => 49
	i32 3641597786, ; 596: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 265
	i32 3643446276, ; 597: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 338
	i32 3643854240, ; 598: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 276
	i32 3645089577, ; 599: System.ComponentModel.DataAnnotations => 0xd943a729 => 14
	i32 3645630983, ; 600: Google.Protobuf => 0xd94bea07 => 175
	i32 3657292374, ; 601: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 197
	i32 3660523487, ; 602: System.Net.NetworkInformation => 0xda2f27df => 68
	i32 3672681054, ; 603: Mono.Android.dll => 0xdae8aa5e => 171
	i32 3682565725, ; 604: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 240
	i32 3684561358, ; 605: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 244
	i32 3700866549, ; 606: System.Net.WebProxy.dll => 0xdc96bdf5 => 78
	i32 3706696989, ; 607: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 249
	i32 3716563718, ; 608: System.Runtime.Intrinsics => 0xdd864306 => 108
	i32 3718780102, ; 609: Xamarin.AndroidX.Annotation => 0xdda814c6 => 233
	i32 3722202641, ; 610: Microsoft.Extensions.Configuration.Json.dll => 0xdddc4e11 => 200
	i32 3724971120, ; 611: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 275
	i32 3732100267, ; 612: System.Net.NameResolution => 0xde7354ab => 67
	i32 3732214720, ; 613: Microsoft.AspNetCore.Metadata.dll => 0xde7513c0 => 195
	i32 3737834244, ; 614: System.Net.Http.Json.dll => 0xdecad304 => 63
	i32 3748608112, ; 615: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 27
	i32 3751444290, ; 616: System.Xml.XPath => 0xdf9a7f42 => 160
	i32 3751619990, ; 617: da\Microsoft.Maui.Controls.resources.dll => 0xdf9d2d96 => 313
	i32 3754567612, ; 618: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 225
	i32 3758424670, ; 619: Microsoft.Extensions.Configuration.FileExtensions => 0xe005025e => 199
	i32 3786282454, ; 620: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 242
	i32 3792276235, ; 621: System.Collections.NonGeneric => 0xe2098b0b => 10
	i32 3800979733, ; 622: Microsoft.Maui.Controls.Compatibility => 0xe28e5915 => 215
	i32 3802395368, ; 623: System.Collections.Specialized.dll => 0xe2a3f2e8 => 11
	i32 3819260425, ; 624: System.Net.WebProxy => 0xe3a54a09 => 78
	i32 3823082795, ; 625: System.Security.Cryptography.dll => 0xe3df9d2b => 126
	i32 3829621856, ; 626: System.Numerics.dll => 0xe4436460 => 83
	i32 3837493441, ; 627: BlazorBootstrap.dll => 0xe4bb80c1 => 173
	i32 3841636137, ; 628: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 202
	i32 3844307129, ; 629: System.Net.Mail.dll => 0xe52378b9 => 66
	i32 3849253459, ; 630: System.Runtime.InteropServices.dll => 0xe56ef253 => 107
	i32 3870376305, ; 631: System.Net.HttpListener.dll => 0xe6b14171 => 65
	i32 3871810066, ; 632: Grpc.Net.ClientFactory => 0xe6c72212 => 180
	i32 3873536506, ; 633: System.Security.Principal => 0xe6e179fa => 128
	i32 3875112723, ; 634: System.Security.Cryptography.Encoding.dll => 0xe6f98713 => 122
	i32 3876362041, ; 635: SQLite-net => 0xe70c9739 => 221
	i32 3885497537, ; 636: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 77
	i32 3885922214, ; 637: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 290
	i32 3888767677, ; 638: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 280
	i32 3896106733, ; 639: System.Collections.Concurrent.dll => 0xe839deed => 8
	i32 3896760992, ; 640: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 248
	i32 3901907137, ; 641: Microsoft.VisualBasic.Core.dll => 0xe89260c1 => 2
	i32 3920221145, ; 642: nl\Microsoft.Maui.Controls.resources.dll => 0xe9a9d3d9 => 329
	i32 3920810846, ; 643: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 44
	i32 3921031405, ; 644: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 293
	i32 3928044579, ; 645: System.Xml.ReaderWriter => 0xea213423 => 156
	i32 3930554604, ; 646: System.Security.Principal.dll => 0xea4780ec => 128
	i32 3931092270, ; 647: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 278
	i32 3945713374, ; 648: System.Data.DataSetExtensions.dll => 0xeb2ecede => 23
	i32 3953953790, ; 649: System.Text.Encoding.CodePages => 0xebac8bfe => 133
	i32 3955647286, ; 650: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 236
	i32 3959773229, ; 651: Xamarin.AndroidX.Lifecycle.Process => 0xec05582d => 267
	i32 4003436829, ; 652: System.Diagnostics.Process.dll => 0xee9f991d => 29
	i32 4015948917, ; 653: Xamarin.AndroidX.Annotation.Jvm.dll => 0xef5e8475 => 235
	i32 4023392905, ; 654: System.IO.Pipelines => 0xefd01a89 => 226
	i32 4025784931, ; 655: System.Memory => 0xeff49a63 => 62
	i32 4044257358, ; 656: IdentityModel.dll => 0xf10e784e => 182
	i32 4046471985, ; 657: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 217
	i32 4054681211, ; 658: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 90
	i32 4068434129, ; 659: System.Private.Xml.Linq.dll => 0xf27f60d1 => 87
	i32 4073602200, ; 660: System.Threading.dll => 0xf2ce3c98 => 148
	i32 4091086043, ; 661: el\Microsoft.Maui.Controls.resources.dll => 0xf3d904db => 315
	i32 4094352644, ; 662: Microsoft.Maui.Essentials.dll => 0xf40add04 => 219
	i32 4099507663, ; 663: System.Drawing.dll => 0xf45985cf => 36
	i32 4100113165, ; 664: System.Private.Uri => 0xf462c30d => 86
	i32 4101593132, ; 665: Xamarin.AndroidX.Emoji2 => 0xf479582c => 256
	i32 4103439459, ; 666: uk\Microsoft.Maui.Controls.resources.dll => 0xf4958463 => 339
	i32 4126470640, ; 667: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 201
	i32 4127667938, ; 668: System.IO.FileSystem.Watcher => 0xf60736e2 => 50
	i32 4130442656, ; 669: System.AppContext => 0xf6318da0 => 6
	i32 4147896353, ; 670: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 90
	i32 4150914736, ; 671: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 339
	i32 4151237749, ; 672: System.Core => 0xf76edc75 => 21
	i32 4152369130, ; 673: IdentityModel.OidcClient => 0xf7801fea => 183
	i32 4159265925, ; 674: System.Xml.XmlSerializer => 0xf7e95c85 => 162
	i32 4161255271, ; 675: System.Reflection.TypeExtensions => 0xf807b767 => 96
	i32 4164802419, ; 676: System.IO.FileSystem.Watcher.dll => 0xf83dd773 => 50
	i32 4181436372, ; 677: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 113
	i32 4182413190, ; 678: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 272
	i32 4185676441, ; 679: System.Security => 0xf97c5a99 => 130
	i32 4196529839, ; 680: System.Net.WebClient.dll => 0xfa21f6af => 76
	i32 4208300564, ; 681: Grpc.Net.Client.Web => 0xfad59214 => 179
	i32 4213026141, ; 682: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 27
	i32 4216061222, ; 683: SharedLib => 0xfb4bfd26 => 345
	i32 4223918059, ; 684: GpsTracker.dll => 0xfbc3dfeb => 0
	i32 4249188766, ; 685: nb\Microsoft.Maui.Controls.resources.dll => 0xfd45799e => 328
	i32 4256097574, ; 686: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 249
	i32 4258378803, ; 687: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx => 0xfdd1b433 => 271
	i32 4260525087, ; 688: System.Buffers => 0xfdf2741f => 7
	i32 4271975918, ; 689: Microsoft.Maui.Controls.dll => 0xfea12dee => 216
	i32 4274976490, ; 690: System.Runtime.Numerics => 0xfecef6ea => 110
	i32 4292120959, ; 691: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 272
	i32 4294648842, ; 692: Microsoft.Extensions.FileProviders.Embedded => 0xfffb240a => 205
	i32 4294763496 ; 693: Xamarin.AndroidX.ExifInterface.dll => 0xfffce3e8 => 258
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [694 x i32] [
	i32 68, ; 0
	i32 67, ; 1
	i32 108, ; 2
	i32 268, ; 3
	i32 302, ; 4
	i32 48, ; 5
	i32 310, ; 6
	i32 80, ; 7
	i32 319, ; 8
	i32 145, ; 9
	i32 30, ; 10
	i32 343, ; 11
	i32 124, ; 12
	i32 220, ; 13
	i32 102, ; 14
	i32 327, ; 15
	i32 286, ; 16
	i32 107, ; 17
	i32 286, ; 18
	i32 139, ; 19
	i32 306, ; 20
	i32 342, ; 21
	i32 0, ; 22
	i32 335, ; 23
	i32 77, ; 24
	i32 124, ; 25
	i32 13, ; 26
	i32 242, ; 27
	i32 132, ; 28
	i32 288, ; 29
	i32 151, ; 30
	i32 18, ; 31
	i32 240, ; 32
	i32 26, ; 33
	i32 262, ; 34
	i32 1, ; 35
	i32 59, ; 36
	i32 42, ; 37
	i32 189, ; 38
	i32 91, ; 39
	i32 188, ; 40
	i32 245, ; 41
	i32 147, ; 42
	i32 264, ; 43
	i32 261, ; 44
	i32 54, ; 45
	i32 208, ; 46
	i32 69, ; 47
	i32 340, ; 48
	i32 231, ; 49
	i32 83, ; 50
	i32 318, ; 51
	i32 263, ; 52
	i32 224, ; 53
	i32 131, ; 54
	i32 181, ; 55
	i32 55, ; 56
	i32 177, ; 57
	i32 149, ; 58
	i32 74, ; 59
	i32 145, ; 60
	i32 62, ; 61
	i32 178, ; 62
	i32 146, ; 63
	i32 346, ; 64
	i32 165, ; 65
	i32 338, ; 66
	i32 246, ; 67
	i32 186, ; 68
	i32 12, ; 69
	i32 259, ; 70
	i32 125, ; 71
	i32 152, ; 72
	i32 113, ; 73
	i32 166, ; 74
	i32 164, ; 75
	i32 261, ; 76
	i32 274, ; 77
	i32 316, ; 78
	i32 84, ; 79
	i32 213, ; 80
	i32 150, ; 81
	i32 306, ; 82
	i32 60, ; 83
	i32 337, ; 84
	i32 209, ; 85
	i32 51, ; 86
	i32 103, ; 87
	i32 114, ; 88
	i32 40, ; 89
	i32 299, ; 90
	i32 297, ; 91
	i32 205, ; 92
	i32 120, ; 93
	i32 52, ; 94
	i32 44, ; 95
	i32 119, ; 96
	i32 344, ; 97
	i32 251, ; 98
	i32 329, ; 99
	i32 257, ; 100
	i32 81, ; 101
	i32 136, ; 102
	i32 293, ; 103
	i32 238, ; 104
	i32 8, ; 105
	i32 73, ; 106
	i32 155, ; 107
	i32 308, ; 108
	i32 154, ; 109
	i32 92, ; 110
	i32 303, ; 111
	i32 45, ; 112
	i32 307, ; 113
	i32 109, ; 114
	i32 129, ; 115
	i32 222, ; 116
	i32 25, ; 117
	i32 228, ; 118
	i32 72, ; 119
	i32 55, ; 120
	i32 46, ; 121
	i32 335, ; 122
	i32 212, ; 123
	i32 252, ; 124
	i32 194, ; 125
	i32 22, ; 126
	i32 266, ; 127
	i32 86, ; 128
	i32 43, ; 129
	i32 160, ; 130
	i32 71, ; 131
	i32 279, ; 132
	i32 320, ; 133
	i32 3, ; 134
	i32 42, ; 135
	i32 63, ; 136
	i32 334, ; 137
	i32 183, ; 138
	i32 16, ; 139
	i32 53, ; 140
	i32 331, ; 141
	i32 302, ; 142
	i32 184, ; 143
	i32 105, ; 144
	i32 307, ; 145
	i32 324, ; 146
	i32 300, ; 147
	i32 263, ; 148
	i32 34, ; 149
	i32 158, ; 150
	i32 186, ; 151
	i32 85, ; 152
	i32 32, ; 153
	i32 333, ; 154
	i32 12, ; 155
	i32 51, ; 156
	i32 207, ; 157
	i32 56, ; 158
	i32 283, ; 159
	i32 36, ; 160
	i32 202, ; 161
	i32 301, ; 162
	i32 236, ; 163
	i32 35, ; 164
	i32 185, ; 165
	i32 314, ; 166
	i32 58, ; 167
	i32 270, ; 168
	i32 176, ; 169
	i32 17, ; 170
	i32 304, ; 171
	i32 164, ; 172
	i32 344, ; 173
	i32 199, ; 174
	i32 336, ; 175
	i32 330, ; 176
	i32 326, ; 177
	i32 269, ; 178
	i32 211, ; 179
	i32 296, ; 180
	i32 332, ; 181
	i32 153, ; 182
	i32 203, ; 183
	i32 292, ; 184
	i32 277, ; 185
	i32 178, ; 186
	i32 238, ; 187
	i32 29, ; 188
	i32 52, ; 189
	i32 297, ; 190
	i32 5, ; 191
	i32 312, ; 192
	i32 287, ; 193
	i32 291, ; 194
	i32 243, ; 195
	i32 308, ; 196
	i32 235, ; 197
	i32 223, ; 198
	i32 254, ; 199
	i32 321, ; 200
	i32 85, ; 201
	i32 296, ; 202
	i32 61, ; 203
	i32 112, ; 204
	i32 341, ; 205
	i32 57, ; 206
	i32 342, ; 207
	i32 283, ; 208
	i32 99, ; 209
	i32 19, ; 210
	i32 247, ; 211
	i32 111, ; 212
	i32 101, ; 213
	i32 102, ; 214
	i32 310, ; 215
	i32 104, ; 216
	i32 300, ; 217
	i32 71, ; 218
	i32 345, ; 219
	i32 38, ; 220
	i32 32, ; 221
	i32 204, ; 222
	i32 103, ; 223
	i32 73, ; 224
	i32 316, ; 225
	i32 9, ; 226
	i32 123, ; 227
	i32 46, ; 228
	i32 237, ; 229
	i32 213, ; 230
	i32 9, ; 231
	i32 43, ; 232
	i32 4, ; 233
	i32 284, ; 234
	i32 208, ; 235
	i32 207, ; 236
	i32 340, ; 237
	i32 31, ; 238
	i32 138, ; 239
	i32 92, ; 240
	i32 194, ; 241
	i32 93, ; 242
	i32 49, ; 243
	i32 141, ; 244
	i32 112, ; 245
	i32 140, ; 246
	i32 253, ; 247
	i32 115, ; 248
	i32 301, ; 249
	i32 157, ; 250
	i32 76, ; 251
	i32 79, ; 252
	i32 273, ; 253
	i32 37, ; 254
	i32 295, ; 255
	i32 200, ; 256
	i32 257, ; 257
	i32 250, ; 258
	i32 64, ; 259
	i32 138, ; 260
	i32 15, ; 261
	i32 193, ; 262
	i32 116, ; 263
	i32 289, ; 264
	i32 298, ; 265
	i32 245, ; 266
	i32 48, ; 267
	i32 70, ; 268
	i32 80, ; 269
	i32 174, ; 270
	i32 126, ; 271
	i32 94, ; 272
	i32 121, ; 273
	i32 305, ; 274
	i32 26, ; 275
	i32 224, ; 276
	i32 266, ; 277
	i32 97, ; 278
	i32 28, ; 279
	i32 241, ; 280
	i32 311, ; 281
	i32 149, ; 282
	i32 226, ; 283
	i32 169, ; 284
	i32 4, ; 285
	i32 98, ; 286
	i32 191, ; 287
	i32 33, ; 288
	i32 93, ; 289
	i32 288, ; 290
	i32 209, ; 291
	i32 21, ; 292
	i32 41, ; 293
	i32 170, ; 294
	i32 177, ; 295
	i32 327, ; 296
	i32 259, ; 297
	i32 319, ; 298
	i32 185, ; 299
	i32 273, ; 300
	i32 304, ; 301
	i32 298, ; 302
	i32 278, ; 303
	i32 2, ; 304
	i32 134, ; 305
	i32 111, ; 306
	i32 192, ; 307
	i32 210, ; 308
	i32 228, ; 309
	i32 336, ; 310
	i32 58, ; 311
	i32 95, ; 312
	i32 182, ; 313
	i32 318, ; 314
	i32 39, ; 315
	i32 239, ; 316
	i32 25, ; 317
	i32 94, ; 318
	i32 312, ; 319
	i32 89, ; 320
	i32 99, ; 321
	i32 10, ; 322
	i32 87, ; 323
	i32 323, ; 324
	i32 100, ; 325
	i32 285, ; 326
	i32 196, ; 327
	i32 305, ; 328
	i32 230, ; 329
	i32 315, ; 330
	i32 7, ; 331
	i32 270, ; 332
	i32 227, ; 333
	i32 88, ; 334
	i32 198, ; 335
	i32 265, ; 336
	i32 154, ; 337
	i32 314, ; 338
	i32 33, ; 339
	i32 206, ; 340
	i32 116, ; 341
	i32 82, ; 342
	i32 225, ; 343
	i32 20, ; 344
	i32 11, ; 345
	i32 162, ; 346
	i32 3, ; 347
	i32 218, ; 348
	i32 322, ; 349
	i32 212, ; 350
	i32 210, ; 351
	i32 189, ; 352
	i32 84, ; 353
	i32 309, ; 354
	i32 64, ; 355
	i32 324, ; 356
	i32 292, ; 357
	i32 143, ; 358
	i32 274, ; 359
	i32 157, ; 360
	i32 41, ; 361
	i32 117, ; 362
	i32 197, ; 363
	i32 229, ; 364
	i32 281, ; 365
	i32 131, ; 366
	i32 75, ; 367
	i32 66, ; 368
	i32 328, ; 369
	i32 172, ; 370
	i32 174, ; 371
	i32 233, ; 372
	i32 143, ; 373
	i32 106, ; 374
	i32 151, ; 375
	i32 70, ; 376
	i32 322, ; 377
	i32 156, ; 378
	i32 196, ; 379
	i32 121, ; 380
	i32 127, ; 381
	i32 323, ; 382
	i32 152, ; 383
	i32 256, ; 384
	i32 188, ; 385
	i32 141, ; 386
	i32 243, ; 387
	i32 320, ; 388
	i32 20, ; 389
	i32 14, ; 390
	i32 214, ; 391
	i32 135, ; 392
	i32 75, ; 393
	i32 59, ; 394
	i32 222, ; 395
	i32 246, ; 396
	i32 167, ; 397
	i32 168, ; 398
	i32 216, ; 399
	i32 15, ; 400
	i32 74, ; 401
	i32 6, ; 402
	i32 23, ; 403
	i32 326, ; 404
	i32 268, ; 405
	i32 227, ; 406
	i32 187, ; 407
	i32 91, ; 408
	i32 321, ; 409
	i32 1, ; 410
	i32 136, ; 411
	i32 325, ; 412
	i32 269, ; 413
	i32 291, ; 414
	i32 134, ; 415
	i32 69, ; 416
	i32 190, ; 417
	i32 146, ; 418
	i32 203, ; 419
	i32 330, ; 420
	i32 309, ; 421
	i32 260, ; 422
	i32 211, ; 423
	i32 88, ; 424
	i32 96, ; 425
	i32 250, ; 426
	i32 255, ; 427
	i32 325, ; 428
	i32 31, ; 429
	i32 45, ; 430
	i32 264, ; 431
	i32 192, ; 432
	i32 184, ; 433
	i32 229, ; 434
	i32 109, ; 435
	i32 158, ; 436
	i32 35, ; 437
	i32 22, ; 438
	i32 114, ; 439
	i32 193, ; 440
	i32 57, ; 441
	i32 289, ; 442
	i32 144, ; 443
	i32 118, ; 444
	i32 120, ; 445
	i32 110, ; 446
	i32 231, ; 447
	i32 139, ; 448
	i32 187, ; 449
	i32 237, ; 450
	i32 311, ; 451
	i32 54, ; 452
	i32 105, ; 453
	i32 331, ; 454
	i32 217, ; 455
	i32 218, ; 456
	i32 133, ; 457
	i32 303, ; 458
	i32 294, ; 459
	i32 282, ; 460
	i32 337, ; 461
	i32 260, ; 462
	i32 220, ; 463
	i32 159, ; 464
	i32 247, ; 465
	i32 163, ; 466
	i32 132, ; 467
	i32 282, ; 468
	i32 161, ; 469
	i32 195, ; 470
	i32 271, ; 471
	i32 140, ; 472
	i32 294, ; 473
	i32 290, ; 474
	i32 169, ; 475
	i32 219, ; 476
	i32 232, ; 477
	i32 299, ; 478
	i32 40, ; 479
	i32 258, ; 480
	i32 81, ; 481
	i32 180, ; 482
	i32 191, ; 483
	i32 56, ; 484
	i32 37, ; 485
	i32 97, ; 486
	i32 166, ; 487
	i32 172, ; 488
	i32 206, ; 489
	i32 295, ; 490
	i32 82, ; 491
	i32 234, ; 492
	i32 98, ; 493
	i32 30, ; 494
	i32 159, ; 495
	i32 18, ; 496
	i32 127, ; 497
	i32 119, ; 498
	i32 254, ; 499
	i32 285, ; 500
	i32 267, ; 501
	i32 287, ; 502
	i32 165, ; 503
	i32 262, ; 504
	i32 346, ; 505
	i32 317, ; 506
	i32 284, ; 507
	i32 275, ; 508
	i32 170, ; 509
	i32 16, ; 510
	i32 144, ; 511
	i32 125, ; 512
	i32 118, ; 513
	i32 38, ; 514
	i32 181, ; 515
	i32 115, ; 516
	i32 47, ; 517
	i32 142, ; 518
	i32 117, ; 519
	i32 34, ; 520
	i32 176, ; 521
	i32 95, ; 522
	i32 53, ; 523
	i32 276, ; 524
	i32 129, ; 525
	i32 153, ; 526
	i32 24, ; 527
	i32 161, ; 528
	i32 253, ; 529
	i32 148, ; 530
	i32 104, ; 531
	i32 89, ; 532
	i32 241, ; 533
	i32 60, ; 534
	i32 142, ; 535
	i32 100, ; 536
	i32 5, ; 537
	i32 13, ; 538
	i32 221, ; 539
	i32 122, ; 540
	i32 135, ; 541
	i32 28, ; 542
	i32 317, ; 543
	i32 72, ; 544
	i32 251, ; 545
	i32 24, ; 546
	i32 239, ; 547
	i32 280, ; 548
	i32 277, ; 549
	i32 334, ; 550
	i32 137, ; 551
	i32 223, ; 552
	i32 232, ; 553
	i32 248, ; 554
	i32 168, ; 555
	i32 281, ; 556
	i32 313, ; 557
	i32 101, ; 558
	i32 123, ; 559
	i32 252, ; 560
	i32 204, ; 561
	i32 198, ; 562
	i32 201, ; 563
	i32 163, ; 564
	i32 167, ; 565
	i32 255, ; 566
	i32 39, ; 567
	i32 215, ; 568
	i32 332, ; 569
	i32 190, ; 570
	i32 17, ; 571
	i32 171, ; 572
	i32 333, ; 573
	i32 137, ; 574
	i32 150, ; 575
	i32 244, ; 576
	i32 175, ; 577
	i32 214, ; 578
	i32 155, ; 579
	i32 130, ; 580
	i32 19, ; 581
	i32 65, ; 582
	i32 173, ; 583
	i32 179, ; 584
	i32 147, ; 585
	i32 47, ; 586
	i32 341, ; 587
	i32 343, ; 588
	i32 230, ; 589
	i32 79, ; 590
	i32 61, ; 591
	i32 106, ; 592
	i32 279, ; 593
	i32 234, ; 594
	i32 49, ; 595
	i32 265, ; 596
	i32 338, ; 597
	i32 276, ; 598
	i32 14, ; 599
	i32 175, ; 600
	i32 197, ; 601
	i32 68, ; 602
	i32 171, ; 603
	i32 240, ; 604
	i32 244, ; 605
	i32 78, ; 606
	i32 249, ; 607
	i32 108, ; 608
	i32 233, ; 609
	i32 200, ; 610
	i32 275, ; 611
	i32 67, ; 612
	i32 195, ; 613
	i32 63, ; 614
	i32 27, ; 615
	i32 160, ; 616
	i32 313, ; 617
	i32 225, ; 618
	i32 199, ; 619
	i32 242, ; 620
	i32 10, ; 621
	i32 215, ; 622
	i32 11, ; 623
	i32 78, ; 624
	i32 126, ; 625
	i32 83, ; 626
	i32 173, ; 627
	i32 202, ; 628
	i32 66, ; 629
	i32 107, ; 630
	i32 65, ; 631
	i32 180, ; 632
	i32 128, ; 633
	i32 122, ; 634
	i32 221, ; 635
	i32 77, ; 636
	i32 290, ; 637
	i32 280, ; 638
	i32 8, ; 639
	i32 248, ; 640
	i32 2, ; 641
	i32 329, ; 642
	i32 44, ; 643
	i32 293, ; 644
	i32 156, ; 645
	i32 128, ; 646
	i32 278, ; 647
	i32 23, ; 648
	i32 133, ; 649
	i32 236, ; 650
	i32 267, ; 651
	i32 29, ; 652
	i32 235, ; 653
	i32 226, ; 654
	i32 62, ; 655
	i32 182, ; 656
	i32 217, ; 657
	i32 90, ; 658
	i32 87, ; 659
	i32 148, ; 660
	i32 315, ; 661
	i32 219, ; 662
	i32 36, ; 663
	i32 86, ; 664
	i32 256, ; 665
	i32 339, ; 666
	i32 201, ; 667
	i32 50, ; 668
	i32 6, ; 669
	i32 90, ; 670
	i32 339, ; 671
	i32 21, ; 672
	i32 183, ; 673
	i32 162, ; 674
	i32 96, ; 675
	i32 50, ; 676
	i32 113, ; 677
	i32 272, ; 678
	i32 130, ; 679
	i32 76, ; 680
	i32 179, ; 681
	i32 27, ; 682
	i32 345, ; 683
	i32 0, ; 684
	i32 328, ; 685
	i32 249, ; 686
	i32 271, ; 687
	i32 7, ; 688
	i32 216, ; 689
	i32 110, ; 690
	i32 272, ; 691
	i32 205, ; 692
	i32 258 ; 693
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
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" }

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
!7 = !{i32 1, !"NumRegisterParameters", i32 0}
