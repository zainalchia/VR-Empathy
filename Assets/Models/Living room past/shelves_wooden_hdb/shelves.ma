//Maya ASCII 2025ff03 scene
//Name: shelves.ma
//Last modified: Mon, Nov 03, 2025 03:26:07 PM
//Codeset: 1252
requires maya "2025ff03";
requires -nodeType "aiOptions" -nodeType "aiAOVDriver" -nodeType "aiAOVFilter" -nodeType "aiImagerDenoiserOidn"
		 "mtoa" "5.4.5";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2025";
fileInfo "version" "2025";
fileInfo "cutIdentifier" "202409190603-cbdc5a7e54";
fileInfo "osv" "Windows 11 Education v2009 (Build: 22631)";
fileInfo "UUID" "EE4E8F04-4C65-67EE-CF33-BCB6563FE8CA";
createNode transform -s -n "persp";
	rename -uid "A26C1B7E-4FBA-1A87-2D8A-ABA06BDBE965";
	setAttr ".v" no;
	setAttr ".t" -type "double3" -14.320517923598139 59.751197363684575 169.91590886970911 ;
	setAttr ".r" -type "double3" -9.9383527148235551 -2880.9999999998868 -1.4911121105327697e-16 ;
createNode camera -s -n "perspShape" -p "persp";
	rename -uid "9F4F6908-4811-0F28-0673-B989BF0E9070";
	setAttr -k off ".v" no;
	setAttr ".fl" 34.999999999999993;
	setAttr ".coi" 194.24999038722973;
	setAttr ".imn" -type "string" "persp";
	setAttr ".den" -type "string" "persp_depth";
	setAttr ".man" -type "string" "persp_mask";
	setAttr ".tp" -type "double3" 20.87681790710964 5.9249778307980243 -4.850039319680393 ;
	setAttr ".hc" -type "string" "viewSet -p %camera";
createNode transform -s -n "top";
	rename -uid "FC04A31F-4D15-A774-E739-38944EAA6754";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 1000.1 0 ;
	setAttr ".r" -type "double3" -90 0 0 ;
createNode camera -s -n "topShape" -p "top";
	rename -uid "3ADCD0F9-438F-D10D-BEB4-66A9328C335F";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "top";
	setAttr ".den" -type "string" "top_depth";
	setAttr ".man" -type "string" "top_mask";
	setAttr ".hc" -type "string" "viewSet -t %camera";
	setAttr ".o" yes;
createNode transform -s -n "front";
	rename -uid "B1A81EDA-47DD-E6F2-C93A-4A981C5D1176";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 0 1000.1 ;
createNode camera -s -n "frontShape" -p "front";
	rename -uid "885B35A4-4BC5-CFBF-842B-F6B21BD1C222";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "front";
	setAttr ".den" -type "string" "front_depth";
	setAttr ".man" -type "string" "front_mask";
	setAttr ".hc" -type "string" "viewSet -f %camera";
	setAttr ".o" yes;
createNode transform -s -n "side";
	rename -uid "6D3121CD-408F-12E5-A95D-5C9130ED9A4E";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 1000.1 0 0 ;
	setAttr ".r" -type "double3" 0 90 0 ;
createNode camera -s -n "sideShape" -p "side";
	rename -uid "9415DDB9-49EF-B61F-1296-C29C1AE9FF2A";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "side";
	setAttr ".den" -type "string" "side_depth";
	setAttr ".man" -type "string" "side_mask";
	setAttr ".hc" -type "string" "viewSet -s %camera";
	setAttr ".o" yes;
createNode transform -n "pCube1";
	rename -uid "F6363721-4DC7-695B-6550-C1BEE7E35823";
	setAttr ".t" -type "double3" 3.9167210139687532 4.5464997311381889 0 ;
	setAttr ".s" -type "double3" 7.3784951273418562 5.3246217130140669 0.18871880998666779 ;
	setAttr ".hio" yes;
createNode transform -n "transform1" -p "pCube1";
	rename -uid "CF68B5AD-4C78-C2B0-707B-14B9EE0DCCA2";
	setAttr ".v" no;
	setAttr ".hio" yes;
createNode mesh -n "pCubeShape1" -p "transform1";
	rename -uid "FB6BD935-468F-FF6B-9A14-B783EA29C20B";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr -s 2 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5 0.5 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".hio" yes;
createNode transform -n "pCube2";
	rename -uid "B098A51D-4C72-2A6F-1C99-EB8CE56AE8A2";
	setAttr ".t" -type "double3" -3.5299141930208693 4.5464997311381889 0.0046340064537781483 ;
	setAttr ".r" -type "double3" 0 179.23750291950208 0 ;
	setAttr ".s" -type "double3" 7.3784951273418562 5.3246217130140669 0.18871880998666779 ;
	setAttr ".hio" yes;
createNode transform -n "transform3" -p "pCube2";
	rename -uid "CBB9DD67-4D78-AD78-8E6D-20B4AEE6AD4D";
	setAttr ".v" no;
	setAttr ".hio" yes;
createNode mesh -n "pCubeShape2" -p "transform3";
	rename -uid "7965ABA7-4A81-38F3-4AA2-D99A93C595BE";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".iog[0].og[0].gcl" -type "componentList" 1 "f[0:21]";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr -s 6 ".gtag";
	setAttr ".gtag[0].gtagnm" -type "string" "back";
	setAttr ".gtag[0].gtagcmp" -type "componentList" 2 "f[2]" "f[10:13]";
	setAttr ".gtag[1].gtagnm" -type "string" "bottom";
	setAttr ".gtag[1].gtagcmp" -type "componentList" 1 "f[3]";
	setAttr ".gtag[2].gtagnm" -type "string" "front";
	setAttr ".gtag[2].gtagcmp" -type "componentList" 2 "f[0]" "f[6:9]";
	setAttr ".gtag[3].gtagnm" -type "string" "left";
	setAttr ".gtag[3].gtagcmp" -type "componentList" 1 "f[5]";
	setAttr ".gtag[4].gtagnm" -type "string" "right";
	setAttr ".gtag[4].gtagcmp" -type "componentList" 2 "f[4]" "f[14:21]";
	setAttr ".gtag[5].gtagnm" -type "string" "top";
	setAttr ".gtag[5].gtagcmp" -type "componentList" 1 "f[1]";
	setAttr ".pv" -type "double2" 0.375 0.625 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 30 ".uvst[0].uvsp[0:29]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25 0.375 0 0.625 0 0.625 0.25 0.375 0.25 0.375 0.5 0.625
		 0.5 0.625 0.75 0.375 0.75 0.625 0 0.875 0 0.875 0.25 0.625 0.25 0.625 0 0.875 0 0.875
		 0.25 0.625 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 4 ".pt[24:27]" -type "float3"  -3.7252903e-09 1.6391277e-07 
		0 -3.7252903e-09 -1.6391277e-07 0 -1.8626451e-09 -1.4901161e-08 0 -1.8626451e-09 
		1.4901161e-08 0;
	setAttr -s 24 ".vt[0:23]"  -0.5 -0.5 0.5 0.5000003 -0.5 0.5 -0.5 0.50000006 0.5
		 0.5000003 0.50000006 0.5 -0.5 0.50000006 -0.5 0.5000003 0.50000006 -0.5 -0.5 -0.5 -0.5
		 0.5000003 -0.5 -0.5 -0.38370535 -0.38370538 0.38370538 0.38370544 -0.38370538 0.38370538
		 0.38370544 0.38370544 0.38370538 -0.38370535 0.38370544 0.38370538 -0.38370535 0.38370544 -0.38370538
		 0.38370544 0.38370544 -0.38370538 0.38370544 -0.38370538 -0.38370538 -0.38370535 -0.38370538 -0.38370538
		 0.5000003 -0.28691041 -0.5 0.5000003 -0.28691041 0.5 0.5000003 0.28691047 -0.5 0.5000003 0.28691047 0.5
		 0.53336024 -0.28691041 -0.5 0.53336024 -0.28691041 0.5 0.53336024 0.28691047 -0.5
		 0.53336024 0.28691047 0.5;
	setAttr -s 44 ".ed[0:43]"  0 1 1 2 3 1 4 5 1 6 7 1 0 2 1 1 3 1 2 4 1
		 3 5 1 4 6 1 5 7 1 6 0 1 7 1 1 0 8 1 1 9 1 8 9 1 3 10 1 9 10 1 2 11 1 11 10 1 8 11 1
		 4 12 1 5 13 1 12 13 1 7 14 1 13 14 1 6 15 1 15 14 1 12 15 1 7 16 0 1 17 0 16 17 1
		 5 18 0 18 16 1 3 19 0 19 18 1 17 19 1 16 20 1 17 21 1 20 21 1 18 22 1 22 20 1 19 23 1
		 23 22 1 21 23 1;
	setAttr -s 22 -ch 88 ".fc[0:21]" -type "polyFaces" 
		f 4 14 16 -19 -20
		mu 0 4 14 15 16 17
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 22 24 -27 -28
		mu 0 4 18 19 20 21
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -39 -41 -43 -44
		mu 0 4 26 27 28 29
		f 4 10 4 6 8
		mu 0 4 12 0 2 13
		f 4 0 13 -15 -13
		mu 0 4 0 1 15 14
		f 4 5 15 -17 -14
		mu 0 4 1 3 16 15
		f 4 -2 17 18 -16
		mu 0 4 3 2 17 16
		f 4 -5 12 19 -18
		mu 0 4 2 0 14 17
		f 4 2 21 -23 -21
		mu 0 4 4 5 19 18
		f 4 9 23 -25 -22
		mu 0 4 5 7 20 19
		f 4 -4 25 26 -24
		mu 0 4 7 6 21 20
		f 4 -9 20 27 -26
		mu 0 4 6 4 18 21
		f 4 -12 28 30 -30
		mu 0 4 1 10 23 22
		f 4 -10 31 32 -29
		mu 0 4 10 11 24 23
		f 4 -8 33 34 -32
		mu 0 4 11 3 25 24
		f 4 -6 29 35 -34
		mu 0 4 3 1 22 25
		f 4 -31 36 38 -38
		mu 0 4 22 23 27 26
		f 4 -33 39 40 -37
		mu 0 4 23 24 28 27
		f 4 -35 41 42 -40
		mu 0 4 24 25 29 28
		f 4 -36 37 43 -42
		mu 0 4 25 22 26 29;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".hio" yes;
createNode transform -n "pCube3";
	rename -uid "9332B7A1-45F2-BE80-3A2E-C7870BB4393C";
	setAttr ".t" -type "double3" -0.13137910003225739 4.4945620299557358 0.17323303641438376 ;
	setAttr ".s" -type "double3" 0.37905439840996591 3.656738211353916 0.34252385522283951 ;
	setAttr ".hio" yes;
createNode transform -n "transform4" -p "pCube3";
	rename -uid "9A3CA057-4096-3F99-B099-75AF9F8D9844";
	setAttr ".v" no;
	setAttr ".hio" yes;
createNode mesh -n "pCubeShape3" -p "transform4";
	rename -uid "488E3E6B-46CE-E95C-FCE0-EB83B8828BFC";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr -s 2 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5 0.625 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".hio" yes;
createNode transform -n "pCube4";
	rename -uid "76D02A54-4906-37DA-79FE-5AA40FDBFAAC";
	setAttr ".t" -type "double3" 0.46643431261324075 4.4945620299557358 0.17323303641438376 ;
	setAttr ".s" -type "double3" 0.37905439840996591 3.656738211353916 0.34252385522283951 ;
	setAttr ".hio" yes;
createNode transform -n "transform2" -p "pCube4";
	rename -uid "587DADFB-4DA3-BCF6-4DD8-3780CC6E2884";
	setAttr ".v" no;
	setAttr ".hio" yes;
createNode mesh -n "pCubeShape4" -p "transform2";
	rename -uid "BFF1C9CD-4697-0421-AD78-51A7018B6110";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".iog[0].og[0].gcl" -type "componentList" 1 "f[0:4]";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr -s 6 ".gtag";
	setAttr ".gtag[0].gtagnm" -type "string" "back";
	setAttr ".gtag[0].gtagcmp" -type "componentList" 0;
	setAttr ".gtag[1].gtagnm" -type "string" "bottom";
	setAttr ".gtag[1].gtagcmp" -type "componentList" 1 "f[2]";
	setAttr ".gtag[2].gtagnm" -type "string" "front";
	setAttr ".gtag[2].gtagcmp" -type "componentList" 1 "f[0]";
	setAttr ".gtag[3].gtagnm" -type "string" "left";
	setAttr ".gtag[3].gtagcmp" -type "componentList" 1 "f[4]";
	setAttr ".gtag[4].gtagnm" -type "string" "right";
	setAttr ".gtag[4].gtagcmp" -type "componentList" 1 "f[3]";
	setAttr ".gtag[5].gtagnm" -type "string" "top";
	setAttr ".gtag[5].gtagcmp" -type "componentList" 1 "f[1]";
	setAttr ".pv" -type "double2" 0.5 0.625 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 14 ".uvst[0].uvsp[0:13]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".vt[0:7]"  -0.5 -0.5 0.5 0.5 -0.5 0.5 -0.5 0.5 0.5 0.5 0.5 0.5
		 -0.5 0.5 -0.5 0.5 0.5 -0.5 -0.5 -0.5 -0.5 0.5 -0.5 -0.5;
	setAttr -s 12 ".ed[0:11]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0;
	setAttr -s 5 -ch 20 ".fc[0:4]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 0 1 3 2
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".hio" yes;
createNode transform -n "shelf_1";
	rename -uid "DC6F8DB1-4FE8-DAFA-5013-4E8B66B2C160";
	setAttr ".t" -type "double3" 20.87681790710964 0 0 ;
	setAttr ".rp" -type "double3" 0 6.2026259035697731 -4.6247485004317834 ;
	setAttr ".sp" -type "double3" 0 6.2026259035697731 -4.6247485004317834 ;
createNode transform -n "shelf_base" -p "shelf_1";
	rename -uid "211982CA-4618-2FC4-76C3-9BB6F6C40C09";
	setAttr ".t" -type "double3" 0 1.6512034452749658 -4.8500368722748162 ;
	setAttr ".s" -type "double3" 16.171219704102587 0.41927889493470766 6.3170233860695353 ;
createNode mesh -n "shelf_baseShape" -p "shelf_base";
	rename -uid "59FC6126-4DF6-DCE3-B39D-2982CB577EFA";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 2.0227699875831604 1.0053485184907913 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".qsp" 0;
createNode transform -n "shelf_door" -p "shelf_1";
	rename -uid "66007900-4725-8729-99D3-77BF9E8DF176";
	setAttr ".t" -type "double3" 0.0048707406593795355 0 -1.5854429978804507 ;
	setAttr ".s" -type "double3" 1.0297675682307301 1 1 ;
	setAttr ".rp" -type "double3" 7.7818003563038172 4.5464998898242817 0.12506777951623479 ;
	setAttr ".sp" -type "double3" 7.7818003563038172 4.5464998898242817 0.12506777951623479 ;
createNode mesh -n "shelf_doorShape" -p "shelf_door";
	rename -uid "B00C5592-4D53-59A6-80EA-819860683D95";
	setAttr -k off ".v";
	setAttr -s 2 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 2.5054151117801666 0.9968966907925072 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode transform -n "shelf_door1" -p "shelf_1";
	rename -uid "4ECBB584-4D78-6CD3-BA21-9DA6F9CB2B3B";
	setAttr ".t" -type "double3" -0.35760270539983807 0 -1.5854429978804507 ;
	setAttr ".s" -type "double3" 1.0298871924514503 1 1 ;
	setAttr ".rp" -type "double3" -7.4382189764310915 4.5464998898242817 0.10120344239085237 ;
	setAttr ".sp" -type "double3" -7.4382189764310915 4.5464998898242817 0.10120344239085237 ;
createNode mesh -n "shelf_door1Shape" -p "shelf_door1";
	rename -uid "38C866D3-4CBD-6476-130D-81B21513A56C";
	setAttr -k off ".v";
	setAttr -s 2 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.49931401486804694 0.500970708472388 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode transform -n "cloth" -p "shelf_1";
	rename -uid "B2AE90CE-4068-FF14-8057-2F922F955D38";
	setAttr ".t" -type "double3" -0.0047866702884533652 12.95969528807246 -2.4019967780919336 ;
	setAttr ".r" -type "double3" 1.9160494532507319 0 0 ;
	setAttr ".s" -type "double3" 4.4722347476786428 4.4722347476786428 4.4722347476786428 ;
createNode mesh -n "clothShape" -p "cloth";
	rename -uid "BE69AE16-412B-F485-DAE7-06B5EDAE070C";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 61 ".uvst[0].uvsp[0:60]" -type "float2" 0.066987306 0.24999997
		 0.93301272 0.25000006 0.49999991 1 0.5 0 0.93301266 0.75000012 0.066987246 0.74999994
		 0.49999997 0.5 0 0.49999994 0.25 0.066987276 0.5 0.25 0.28349364 0.625 0.28349364
		 0.37499997 0.75000006 0.066987306 1 0.50000006 0.7165063 0.62500006 0.71650636 0.37500003
		 0.74999988 0.93301272 0.24999994 0.93301266 0.49999997 0.75 0.17524043 0.6875 0.017037064
		 0.62940949 0.14174682 0.43749997 0.28349364 0.49999997 0.15849361 0.56249994 0.017037094
		 0.37059045 0.14644662 0.14644659 0.26674682 0.22099364 0.15012023 0.29799679 0.37059051
		 0.017037064 0.5 0.125 0.39174682 0.3125 0.38337344 0.17299682 0.5 0.375 0.39174682
		 0.5625 0.39174682 0.4375 0.62940955 0.017037064 0.73325318 0.2209937 0.60825318 0.3125
		 0.61662662 0.17299682 0.85355341 0.14644665 0.98296297 0.37059054 0.85825318 0.43750006
		 0.84987974 0.29799688 0.98296291 0.62940961 0.82475948 0.68750006 0.71650636 0.50000006
		 0.84150636 0.56250006 0.60825312 0.5625 0.60825318 0.43750003 0.85355335 0.85355347
		 0.62499994 0.84150636 0.60825312 0.6875 0.72487968 0.76450324 0.62940943 0.98296297
		 0.37059039 0.98296291 0.37499994 0.84150636 0.49999994 0.90400636 0.14644653 0.85355335
		 0.39174679 0.6875 0.2751202 0.76450312 0.49999997 0.625;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 61 ".vt[0:60]"  -0.86602539 0 0.50000006 0.86602545 0 0.49999991
		 -1.6292068e-07 0 -1 5.9604645e-08 0 1 0.86602533 0 -0.50000018 -0.86602551 0 -0.49999991
		 -3.4438681e-08 0 0 -1 0 1.0323827e-07 -0.49999997 0 0.86602545 1.2582982e-08 0 0.5
		 -0.43301275 0 -0.24999994 -0.43301272 0 0.25000006 0.50000012 0 0.86602539 1 0 -1.5485742e-07
		 0.43301263 0 -0.25000009 0.43301272 0 0.24999993 0.49999982 0 -0.86602551 -0.50000012 0 -0.86602533
		 -8.3115474e-08 0 -0.5 -0.64951915 0 -0.37499994 -0.96592587 0 -0.25881895 -0.71650636 0 0.12500007
		 -0.43301272 0 5.9604645e-08 -0.68301278 0 -0.12499993 -0.96592581 0 0.25881913 -0.70710677 0 0.70710683
		 -0.46650636 0 0.55801272 -0.69975954 0 0.40400642 -0.25881901 0 0.96592587 3.6093812e-08 0 0.75
		 -0.21650636 0 0.37500003 -0.23325315 0 0.65400636 -1.092785e-08 0 0.25 -0.21650639 0 -0.12499997
		 -0.21650638 0 0.12500003 0.25881913 0 0.96592587 0.46650639 0 0.5580126 0.21650636 0 0.37499997
		 0.23325321 0 0.65400636 0.70710683 0 0.70710671 0.96592587 0 0.25881892 0.71650636 0 0.12499989
		 0.69975954 0 0.40400624 0.96592581 0 -0.25881922 0.64951897 0 -0.37500012 0.43301266 0 -8.1956387e-08
		 0.68301266 0 -0.12500013 0.2165063 0 -0.12500004 0.21650633 0 0.12499996 0.70710671 0 -0.70710695
		 0.24999987 0 -0.68301272 0.21650627 0 -0.37500006 0.44975939 0 -0.52900642 0.25881886 0 -0.96592587
		 -0.25881919 0 -0.96592581 -0.25000009 0 -0.68301266 -1.3253758e-07 0 -0.80801272
		 -0.70710695 0 -0.70710671 -0.21650642 0 -0.37499997 -0.44975963 0 -0.5290063 -5.8031773e-08 0 -0.25;
	setAttr -s 108 ".ed[0:107]"  22 10 1 10 19 1 19 23 1 23 22 1 19 5 1 5 20 0
		 20 23 1 20 7 0 7 21 1 21 23 1 21 11 1 11 22 1 7 24 0 24 27 1 27 21 1 24 0 0 0 25 0
		 25 27 1 25 8 0 8 26 1 26 27 1 26 11 1 8 28 0 28 31 1 31 26 1 28 3 0 3 29 1 29 31 1
		 29 9 1 9 30 1 30 31 1 30 11 1 9 32 1 32 34 1 34 30 1 32 6 1 6 33 1 33 34 1 33 10 1
		 22 34 1 37 9 1 29 38 1 38 37 1 3 35 0 35 38 1 35 12 0 12 36 1 36 38 1 36 15 1 15 37 1
		 12 39 0 39 42 1 42 36 1 39 1 0 1 40 0 40 42 1 40 13 0 13 41 1 41 42 1 41 15 1 13 43 0
		 43 46 1 46 41 1 43 4 0 4 44 1 44 46 1 44 14 1 14 45 1 45 46 1 45 15 1 14 47 1 47 48 1
		 48 45 1 47 6 1 32 48 1 37 48 1 51 14 1 44 52 1 52 51 1 4 49 0 49 52 1 49 16 0 16 50 1
		 50 52 1 50 18 1 18 51 1 16 53 0 53 56 1 56 50 1 53 2 0 2 54 0 54 56 1 54 17 0 17 55 1
		 55 56 1 55 18 1 17 57 0 57 59 1 59 55 1 57 5 0 19 59 1 10 58 1 58 59 1 58 18 1 33 60 1
		 60 58 1 47 60 1 51 60 1;
	setAttr -s 48 -ch 192 ".fc[0:47]" -type "polyFaces" 
		f 4 0 1 2 3
		mu 0 4 22 10 19 23
		f 4 4 5 6 -3
		mu 0 4 19 5 20 23
		f 4 7 8 9 -7
		mu 0 4 20 7 21 23
		f 4 10 11 -4 -10
		mu 0 4 21 11 22 23
		f 4 -9 12 13 14
		mu 0 4 21 7 24 27
		f 4 15 16 17 -14
		mu 0 4 24 0 25 27
		f 4 18 19 20 -18
		mu 0 4 25 8 26 27
		f 4 21 -11 -15 -21
		mu 0 4 26 11 21 27
		f 4 -20 22 23 24
		mu 0 4 26 8 28 31
		f 4 25 26 27 -24
		mu 0 4 28 3 29 31
		f 4 28 29 30 -28
		mu 0 4 29 9 30 31
		f 4 31 -22 -25 -31
		mu 0 4 30 11 26 31
		f 4 -30 32 33 34
		mu 0 4 30 9 32 34
		f 4 35 36 37 -34
		mu 0 4 32 6 33 34
		f 4 38 -1 39 -38
		mu 0 4 33 10 22 34
		f 4 -12 -32 -35 -40
		mu 0 4 22 11 30 34
		f 4 40 -29 41 42
		mu 0 4 37 9 29 38
		f 4 -27 43 44 -42
		mu 0 4 29 3 35 38
		f 4 45 46 47 -45
		mu 0 4 35 12 36 38
		f 4 48 49 -43 -48
		mu 0 4 36 15 37 38
		f 4 -47 50 51 52
		mu 0 4 36 12 39 42
		f 4 53 54 55 -52
		mu 0 4 39 1 40 42
		f 4 56 57 58 -56
		mu 0 4 40 13 41 42
		f 4 59 -49 -53 -59
		mu 0 4 41 15 36 42
		f 4 -58 60 61 62
		mu 0 4 41 13 43 46
		f 4 63 64 65 -62
		mu 0 4 43 4 44 46
		f 4 66 67 68 -66
		mu 0 4 44 14 45 46
		f 4 69 -60 -63 -69
		mu 0 4 45 15 41 46
		f 4 -68 70 71 72
		mu 0 4 45 14 47 48
		f 4 73 -36 74 -72
		mu 0 4 47 6 32 48
		f 4 -33 -41 75 -75
		mu 0 4 32 9 37 48
		f 4 -50 -70 -73 -76
		mu 0 4 37 15 45 48
		f 4 76 -67 77 78
		mu 0 4 51 14 44 52
		f 4 -65 79 80 -78
		mu 0 4 44 4 49 52
		f 4 81 82 83 -81
		mu 0 4 49 16 50 52
		f 4 84 85 -79 -84
		mu 0 4 50 18 51 52
		f 4 -83 86 87 88
		mu 0 4 50 16 53 56
		f 4 89 90 91 -88
		mu 0 4 53 2 54 56
		f 4 92 93 94 -92
		mu 0 4 54 17 55 56
		f 4 95 -85 -89 -95
		mu 0 4 55 18 50 56
		f 4 -94 96 97 98
		mu 0 4 55 17 57 59
		f 4 99 -5 100 -98
		mu 0 4 57 5 19 59
		f 4 -2 101 102 -101
		mu 0 4 19 10 58 59
		f 4 103 -96 -99 -103
		mu 0 4 58 18 55 59
		f 4 -102 -39 104 105
		mu 0 4 58 10 33 60
		f 4 -37 -74 106 -105
		mu 0 4 33 6 47 60
		f 4 -71 -77 107 -107
		mu 0 4 47 14 51 60
		f 4 -86 -104 -106 -108
		mu 0 4 51 18 58 60;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
createNode mesh -n "outputCloth1" -p "cloth";
	rename -uid "B5EFD168-4920-0925-1C24-05A3243D0600";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 2.4885080732925884 2.488156114069243 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".qsp" 0;
createNode mesh -n "polySurfaceShape4" -p "cloth";
	rename -uid "D111C02A-4843-D0AF-D53A-9BB036FC5D71";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5 0.5 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 61 ".uvst[0].uvsp[0:60]" -type "float2" 0.066987306 0.24999997
		 0.93301272 0.25000006 0.49999991 1 0.5 0 0.93301266 0.75000012 0.066987246 0.74999994
		 0.49999997 0.5 0 0.49999994 0.25 0.066987276 0.5 0.25 0.28349364 0.625 0.28349364
		 0.37499997 0.75000006 0.066987306 1 0.50000006 0.7165063 0.62500006 0.71650636 0.37500003
		 0.74999988 0.93301272 0.24999994 0.93301266 0.49999997 0.75 0.17524043 0.6875 0.017037064
		 0.62940949 0.14174682 0.43749997 0.28349364 0.49999997 0.15849361 0.56249994 0.017037094
		 0.37059045 0.14644662 0.14644659 0.26674682 0.22099364 0.15012023 0.29799679 0.37059051
		 0.017037064 0.5 0.125 0.39174682 0.3125 0.38337344 0.17299682 0.5 0.375 0.39174682
		 0.5625 0.39174682 0.4375 0.62940955 0.017037064 0.73325318 0.2209937 0.60825318 0.3125
		 0.61662662 0.17299682 0.85355341 0.14644665 0.98296297 0.37059054 0.85825318 0.43750006
		 0.84987974 0.29799688 0.98296291 0.62940961 0.82475948 0.68750006 0.71650636 0.50000006
		 0.84150636 0.56250006 0.60825312 0.5625 0.60825318 0.43750003 0.85355335 0.85355347
		 0.62499994 0.84150636 0.60825312 0.6875 0.72487968 0.76450324 0.62940943 0.98296297
		 0.37059039 0.98296291 0.37499994 0.84150636 0.49999994 0.90400636 0.14644653 0.85355335
		 0.39174679 0.6875 0.2751202 0.76450312 0.49999997 0.625;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 61 ".vt[0:60]"  -0.86689651 -0.53779799 0.44145036 0.85859448 -0.55490202 0.44942656
		 0.0073227729 -0.23459771 -0.85434961 -0.010793956 -0.98841381 0.66032207 0.86425483 -0.1765791 -0.34720853
		 -0.86168826 -0.23459792 -0.35720676 -0.0015822694 -0.20282274 0.14513995 -0.99094141 -0.15232246 0.13229585
		 -0.50547415 -0.86073667 0.61427259 -0.0040354207 -0.50466639 0.5299418 -0.4312689 -0.22468872 -0.10938771
		 -0.43596026 -0.29367998 0.37240988 0.48786622 -0.87246805 0.61746693 0.9918831 -0.16147828 0.14926767
		 0.43063641 -0.17938155 -0.10416682 0.43181393 -0.30802742 0.36842296 0.50641799 -0.23459771 -0.7140342
		 -0.49423751 -0.23459771 -0.72392315 0.0027900722 -0.23459494 -0.35457575 -0.64654917 -0.23132144 -0.23281606
		 -0.95673764 -0.15333985 -0.12768851 -0.71442109 -0.22595474 0.24982706 -0.43068162 -0.20244317 0.13845648
		 -0.67314869 -0.16026492 0.011850145 -0.96695966 -0.32970127 0.3207846 -0.70839101 -0.72138262 0.53558338
		 -0.4718892 -0.56752282 0.51691997 -0.70399821 -0.43484837 0.43398663 -0.26625863 -0.95729202 0.63727278
		 -0.0077177072 -0.74389875 0.6056664 -0.21999635 -0.39978752 0.45460305 -0.23998237 -0.65060669 0.56930119
		 -0.0019669605 -0.3084603 0.37418225 -0.21653029 -0.21309553 0.015522355 -0.21737814 -0.23607613 0.26593289
		 0.24577703 -0.96349269 0.64053863 0.46127734 -0.5807386 0.51699895 0.21363273 -0.40834135 0.45078903
		 0.22720651 -0.65789193 0.56999767 0.69612908 -0.73678368 0.54188621 0.96132743 -0.34697014 0.3300316
		 0.71131581 -0.23903531 0.2563675 0.69637215 -0.45188117 0.43509993 0.95948374 -0.12906337 -0.1091299
		 0.64780682 -0.18027142 -0.22554275 0.42875817 -0.19634229 0.1451491 0.67486447 -0.14475594 0.025600875
		 0.21482603 -0.1953426 0.019716106 0.21405835 -0.2402638 0.26612553 0.71186304 -0.23459771 -0.55214274
		 0.25449654 -0.23459579 -0.53471082 0.21748178 -0.21781226 -0.22860642 0.4525834 -0.23459771 -0.37771395
		 0.26579931 -0.23459771 -0.81726092 -0.25185448 -0.23459771 -0.82244927 -0.24570538 -0.23459771 -0.54000044
		 0.0054227747 -0.23459792 -0.66254258 -0.70273662 -0.23459771 -0.56502849 -0.21436118 -0.23360102 -0.2326864
		 -0.44661644 -0.23459899 -0.38723463 0.00011045626 -0.21414149 -0.10537303;
	setAttr -s 108 ".ed[0:107]"  22 10 1 10 19 1 19 23 1 23 22 1 19 5 1 5 20 0
		 20 23 1 20 7 0 7 21 1 21 23 1 21 11 1 11 22 1 7 24 0 24 27 1 27 21 1 24 0 0 0 25 0
		 25 27 1 25 8 0 8 26 1 26 27 1 26 11 1 8 28 0 28 31 1 31 26 1 28 3 0 3 29 1 29 31 1
		 29 9 1 9 30 1 30 31 1 30 11 1 9 32 1 32 34 1 34 30 1 32 6 1 6 33 1 33 34 1 33 10 1
		 22 34 1 37 9 1 29 38 1 38 37 1 3 35 0 35 38 1 35 12 0 12 36 1 36 38 1 36 15 1 15 37 1
		 12 39 0 39 42 1 42 36 1 39 1 0 1 40 0 40 42 1 40 13 0 13 41 1 41 42 1 41 15 1 13 43 0
		 43 46 1 46 41 1 43 4 0 4 44 1 44 46 1 44 14 1 14 45 1 45 46 1 45 15 1 14 47 1 47 48 1
		 48 45 1 47 6 1 32 48 1 37 48 1 51 14 1 44 52 1 52 51 1 4 49 0 49 52 1 49 16 0 16 50 1
		 50 52 1 50 18 1 18 51 1 16 53 0 53 56 1 56 50 1 53 2 0 2 54 0 54 56 1 54 17 0 17 55 1
		 55 56 1 55 18 1 17 57 0 57 59 1 59 55 1 57 5 0 19 59 1 10 58 1 58 59 1 58 18 1 33 60 1
		 60 58 1 47 60 1 51 60 1;
	setAttr -s 48 -ch 192 ".fc[0:47]" -type "polyFaces" 
		f 4 0 1 2 3
		mu 0 4 22 10 19 23
		f 4 4 5 6 -3
		mu 0 4 19 5 20 23
		f 4 7 8 9 -7
		mu 0 4 20 7 21 23
		f 4 10 11 -4 -10
		mu 0 4 21 11 22 23
		f 4 -9 12 13 14
		mu 0 4 21 7 24 27
		f 4 15 16 17 -14
		mu 0 4 24 0 25 27
		f 4 18 19 20 -18
		mu 0 4 25 8 26 27
		f 4 21 -11 -15 -21
		mu 0 4 26 11 21 27
		f 4 -20 22 23 24
		mu 0 4 26 8 28 31
		f 4 25 26 27 -24
		mu 0 4 28 3 29 31
		f 4 28 29 30 -28
		mu 0 4 29 9 30 31
		f 4 31 -22 -25 -31
		mu 0 4 30 11 26 31
		f 4 -30 32 33 34
		mu 0 4 30 9 32 34
		f 4 35 36 37 -34
		mu 0 4 32 6 33 34
		f 4 38 -1 39 -38
		mu 0 4 33 10 22 34
		f 4 -12 -32 -35 -40
		mu 0 4 22 11 30 34
		f 4 40 -29 41 42
		mu 0 4 37 9 29 38
		f 4 -27 43 44 -42
		mu 0 4 29 3 35 38
		f 4 45 46 47 -45
		mu 0 4 35 12 36 38
		f 4 48 49 -43 -48
		mu 0 4 36 15 37 38
		f 4 -47 50 51 52
		mu 0 4 36 12 39 42
		f 4 53 54 55 -52
		mu 0 4 39 1 40 42
		f 4 56 57 58 -56
		mu 0 4 40 13 41 42
		f 4 59 -49 -53 -59
		mu 0 4 41 15 36 42
		f 4 -58 60 61 62
		mu 0 4 41 13 43 46
		f 4 63 64 65 -62
		mu 0 4 43 4 44 46
		f 4 66 67 68 -66
		mu 0 4 44 14 45 46
		f 4 69 -60 -63 -69
		mu 0 4 45 15 41 46
		f 4 -68 70 71 72
		mu 0 4 45 14 47 48
		f 4 73 -36 74 -72
		mu 0 4 47 6 32 48
		f 4 -33 -41 75 -75
		mu 0 4 32 9 37 48
		f 4 -50 -70 -73 -76
		mu 0 4 37 15 45 48
		f 4 76 -67 77 78
		mu 0 4 51 14 44 52
		f 4 -65 79 80 -78
		mu 0 4 44 4 49 52
		f 4 81 82 83 -81
		mu 0 4 49 16 50 52
		f 4 84 85 -79 -84
		mu 0 4 50 18 51 52
		f 4 -83 86 87 88
		mu 0 4 50 16 53 56
		f 4 89 90 91 -88
		mu 0 4 53 2 54 56
		f 4 92 93 94 -92
		mu 0 4 54 17 55 56
		f 4 95 -85 -89 -95
		mu 0 4 55 18 50 56
		f 4 -94 96 97 98
		mu 0 4 55 17 57 59
		f 4 99 -5 100 -98
		mu 0 4 57 5 19 59
		f 4 -2 101 102 -101
		mu 0 4 19 10 58 59
		f 4 103 -96 -99 -103
		mu 0 4 58 18 55 59
		f 4 -102 -39 104 105
		mu 0 4 58 10 33 60
		f 4 -37 -74 106 -105
		mu 0 4 33 6 47 60
		f 4 -71 -77 107 -107
		mu 0 4 47 14 51 60
		f 4 -86 -104 -106 -108
		mu 0 4 51 18 58 60;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".qsp" 0;
createNode transform -n "shelf_2";
	rename -uid "5C0E83A0-4C60-3B77-BD11-858248C255F8";
createNode transform -n "shelf2" -p "shelf_2";
	rename -uid "9F26F067-4464-859B-BC72-DA9D6C12F2DF";
	setAttr ".t" -type "double3" 0 1.9533067601044705 -4.7349194755441761 ;
	setAttr ".s" -type "double3" 21.783984280329417 1 9.2485939045477092 ;
createNode mesh -n "shelfShape2" -p "shelf2";
	rename -uid "757387C6-44FE-5354-90DC-09868B9C75FB";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 3.5075668932195461 1.503917169318628 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode transform -n "shelfdoor1" -p "shelf_2";
	rename -uid "495A8269-428D-5F2F-98FF-52ABB389A282";
	setAttr ".t" -type "double3" 4.6041324069896836 17.93573702162417 0.4992509045301281 ;
	setAttr ".r" -type "double3" 0 54.009669421475238 0 ;
	setAttr ".s" -type "double3" 9.2489248801951298 29.874130098051833 1 ;
	setAttr ".rp" -type "double3" 5.9088141222794182 0 0 ;
	setAttr ".rpt" -type "double3" -8.8817841970012523e-16 0 -8.8817841970012523e-16 ;
	setAttr ".sp" -type "double3" 0.63886497066616432 0 0 ;
	setAttr ".spt" -type "double3" 5.2699491516132531 0 0 ;
createNode mesh -n "shelfdoorShape1" -p "shelfdoor1";
	rename -uid "11D0573D-4D88-768D-0EB2-67BC4E3A6E9B";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.17978917062282562 0.5 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcol" yes;
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode mesh -n "shelfdoorShape1Orig" -p "shelfdoor1";
	rename -uid "F8D58A9E-4A48-4BBA-D8C4-19BB7D9C64CD";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode transform -n "shelfdoor" -p "shelf_2";
	rename -uid "2E69B18E-405C-0864-CFD9-F5A17B71F20D";
	setAttr ".t" -type "double3" -4.6452177177885776 17.93573702162417 0.60511540200649061 ;
	setAttr ".r" -type "double3" 0 -179.34424321964499 0 ;
	setAttr ".s" -type "double3" 9.2489248801951298 29.874130098051833 1 ;
	setAttr ".rp" -type "double3" 6.2626925501576265 0 1.5009694875889323e-15 ;
	setAttr ".rpt" -type "double3" -12.52497492769225 0 0.071675671048147357 ;
	setAttr ".sp" -type "double3" 0.67712654511531689 0 1.5009694875889323e-15 ;
	setAttr ".spt" -type "double3" 5.585566005042307 0 0 ;
createNode mesh -n "shelfdoorShape" -p "shelfdoor";
	rename -uid "99563372-4B5E-CF8F-EC0C-4F963E5E8E80";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5064459226903264 2.5036641658929293 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode mesh -n "polySurfaceShape3" -p "shelfdoor";
	rename -uid "0C221B5C-49CA-443A-26D1-89A7DEA2FE3A";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr -s 6 ".gtag";
	setAttr ".gtag[0].gtagnm" -type "string" "back";
	setAttr ".gtag[0].gtagcmp" -type "componentList" 4 "f[2]" "f[7]" "f[13]" "f[15]";
	setAttr ".gtag[1].gtagnm" -type "string" "bottom";
	setAttr ".gtag[1].gtagcmp" -type "componentList" 1 "f[3]";
	setAttr ".gtag[2].gtagnm" -type "string" "front";
	setAttr ".gtag[2].gtagcmp" -type "componentList" 4 "f[0]" "f[9]" "f[11]" "f[17]";
	setAttr ".gtag[3].gtagnm" -type "string" "left";
	setAttr ".gtag[3].gtagcmp" -type "componentList" 3 "f[5:6]" "f[10]" "f[14]";
	setAttr ".gtag[4].gtagnm" -type "string" "right";
	setAttr ".gtag[4].gtagcmp" -type "componentList" 5 "f[4]" "f[8]" "f[12]" "f[16]" "f[18:29]";
	setAttr ".gtag[5].gtagnm" -type "string" "top";
	setAttr ".gtag[5].gtagcmp" -type "componentList" 1 "f[1]";
	setAttr ".pv" -type "double2" 0.49999999266583472 0.5 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 44 ".uvst[0].uvsp[0:43]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25 0.375 0.125 0.125 0.125 0.375 0.625 0.625 0.625 0.875
		 0.125 0.625 0.125 0.125 0.1875 0.375 0.5625 0.375 0.1875 0.625 0.1875 0.625 0.5625
		 0.875 0.1875 0.375 0.0625 0.125 0.0625 0.375 0.6875 0.625 0.6875 0.875 0.0625 0.625
		 0.0625 0.875 0.125 0.875 0.1875 0.625 0.1875 0.625 0.125 0.625 0.0625 0.875 0.0625
		 0.875 0.125 0.875 0.1875 0.625 0.1875 0.625 0.125 0.625 0.0625 0.875 0.0625;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 32 ".vt[0:31]"  -0.50000012 -0.5 0.5 0.61743367 -0.5 0.5
		 -0.50000012 0.50000006 0.5 0.61743367 0.50000006 0.5 -0.50000012 0.50000006 -0.5
		 0.61743367 0.50000006 -0.5 -0.50000012 -0.5 -0.5 0.61743367 -0.5 -0.5 -0.50000012 0 0.5
		 -0.50000012 0 -0.5 0.61743367 0 -0.5 0.61743367 0 0.5 -0.50000012 0.25 -0.5 -0.50000012 0.25 0.5
		 0.61743367 0.25 0.5 0.61743367 0.25 -0.5 -0.50000012 -0.25 0.5 -0.50000012 -0.25 -0.5
		 0.61743367 -0.25 -0.5 0.61743367 -0.25 0.5 0.65242934 0 -0.30158865 0.65242934 0 0.30158854
		 0.65242934 0.25 -0.30158865 0.65242934 0.25 0.30158854 0.65242934 -0.25 -0.30158865
		 0.65242934 -0.25 0.30158854 0.68863422 0 -0.30158865 0.68863422 0 0.30158854 0.68863422 0.25 -0.30158865
		 0.68863422 0.25 0.30158854 0.68863422 -0.25 -0.30158865 0.68863422 -0.25 0.30158854;
	setAttr -s 60 ".ed[0:59]"  0 1 1 2 3 1 4 5 1 6 7 1 0 16 1 1 19 1 2 4 1
		 3 5 1 4 12 1 5 15 1 6 0 1 7 1 1 8 13 1 9 17 1 10 18 1 11 14 1 8 9 1 9 10 1 11 8 1
		 12 9 1 13 2 1 14 3 1 15 10 1 12 13 1 13 14 1 14 15 1 15 12 1 16 8 1 17 6 1 18 7 1
		 19 11 1 16 17 1 17 18 1 18 19 1 19 16 1 10 20 1 11 21 1 15 22 1 22 20 1 14 23 1 23 22 1
		 21 23 1 18 24 1 19 25 1 24 25 1 20 24 1 25 21 1 20 26 1 21 27 1 26 27 1 22 28 1 28 26 1
		 23 29 1 29 28 1 27 29 1 24 30 1 25 31 1 30 31 1 26 30 1 31 27 1;
	setAttr -s 30 -ch 120 ".fc[0:29]" -type "polyFaces" 
		f 4 0 5 34 -5
		mu 0 4 0 1 31 26
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 32 29 -4 -29
		mu 0 4 28 29 7 6
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -12 -30 33 -6
		mu 0 4 1 10 30 31
		f 4 10 4 31 28
		mu 0 4 12 0 26 27
		f 4 23 20 6 8
		mu 0 4 20 22 2 13
		f 4 2 9 26 -9
		mu 0 4 4 5 24 21
		f 4 25 -10 -8 -22
		mu 0 4 23 25 11 3
		f 4 24 21 -2 -21
		mu 0 4 22 23 3 2
		f 4 -17 12 -24 19
		mu 0 4 15 14 22 20
		f 4 -19 15 -25 -13
		mu 0 4 14 19 23 22
		f 4 -50 -52 -54 -55
		mu 0 4 41 38 39 40
		f 4 -27 22 -18 -20
		mu 0 4 21 24 17 16
		f 4 -32 27 16 13
		mu 0 4 27 26 14 15
		f 4 17 14 -33 -14
		mu 0 4 16 17 29 28
		f 4 -58 -59 49 -60
		mu 0 4 42 43 38 41
		f 4 -35 30 18 -28
		mu 0 4 26 31 19 14
		f 4 -23 37 38 -36
		mu 0 4 18 25 33 32
		f 4 -26 39 40 -38
		mu 0 4 25 23 34 33
		f 4 -16 36 41 -40
		mu 0 4 23 19 35 34
		f 4 -34 42 44 -44
		mu 0 4 31 30 37 36
		f 4 -15 35 45 -43
		mu 0 4 30 18 32 37
		f 4 -31 43 46 -37
		mu 0 4 19 31 36 35
		f 4 -39 50 51 -48
		mu 0 4 32 33 39 38
		f 4 -41 52 53 -51
		mu 0 4 33 34 40 39
		f 4 -42 48 54 -53
		mu 0 4 34 35 41 40
		f 4 -45 55 57 -57
		mu 0 4 36 37 43 42
		f 4 -46 47 58 -56
		mu 0 4 37 32 38 43
		f 4 -47 56 59 -49
		mu 0 4 35 36 42 41;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
createNode transform -n "shelf3";
	rename -uid "D9387AF1-4D30-52EB-BA76-A3862726A2A6";
	setAttr ".t" -type "double3" -43.651302639258333 4.1667430360800113 -4.8500368722748215 ;
	setAttr ".s" -type "double3" 18.546338765798428 1.6769562227072434 8.7387210802227422 ;
createNode mesh -n "shelf3Shape" -p "shelf3";
	rename -uid "8B16FADC-43B1-16FE-571C-E68C2555EFB0";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.49382263422012329 1.4955663424826229 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode mesh -n "polySurfaceShape1" -p "shelf3";
	rename -uid "D10875B3-4DD9-08AB-B3A2-989F5ACC60E8";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr -s 6 ".gtag";
	setAttr ".gtag[0].gtagnm" -type "string" "back";
	setAttr ".gtag[0].gtagcmp" -type "componentList" 4 "f[2]" "f[8]" "f[12]" "f[66]";
	setAttr ".gtag[1].gtagnm" -type "string" "bottom";
	setAttr ".gtag[1].gtagcmp" -type "componentList" 3 "f[3]" "f[9]" "f[13:21]";
	setAttr ".gtag[2].gtagnm" -type "string" "front";
	setAttr ".gtag[2].gtagcmp" -type "componentList" 3 "f[0]" "f[6]" "f[10]";
	setAttr ".gtag[3].gtagnm" -type "string" "left";
	setAttr ".gtag[3].gtagcmp" -type "componentList" 1 "f[5]";
	setAttr ".gtag[4].gtagnm" -type "string" "right";
	setAttr ".gtag[4].gtagcmp" -type "componentList" 1 "f[4]";
	setAttr ".gtag[5].gtagnm" -type "string" "top";
	setAttr ".gtag[5].gtagcmp" -type "componentList" 4 "f[1]" "f[7]" "f[11]" "f[22:69]";
	setAttr ".pv" -type "double2" 0.49946022033691406 0.375 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 72 ".uvst[0].uvsp[0:71]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25 0.38285673 0 0.38285673 1 0.38285673 0.25 0.38285673
		 0.5 0.38285673 0.75 0.61606371 0 0.61606371 1 0.61606371 0.25 0.61606371 0.5 0.61606371
		 0.75 0.375 0.75 0.38285673 0.75 0.38285673 1 0.375 1 0.61606371 1 0.61606371 0.75
		 0.625 0.75 0.625 1 0.375 0.25 0.38285673 0.25 0.38285673 0.5 0.375 0.5 0.61606371
		 0.5 0.61606371 0.25 0.625 0.25 0.625 0.5 0.375 0.25 0.38285673 0.25 0.38285673 0.5
		 0.375 0.5 0.61606371 0.5 0.61606371 0.25 0.625 0.25 0.625 0.5 0.375 0.25 0.38285673
		 0.25 0.38285673 0.5 0.375 0.5 0.61606371 0.5 0.61606371 0.25 0.625 0.25 0.625 0.5
		 0.375 0.25 0.38285673 0.25 0.38285673 0.5 0.375 0.5 0.61606371 0.5 0.61606371 0.25
		 0.625 0.25 0.625 0.5 0.38285673 0.48146749 0.38285673 0.48146749 0.61606371 0.48146749
		 0.61606371 0.48146749 0.38285673 0.48043025 0.38285673 0.48043025 0.61606371 0.48043025
		 0.61606371 0.48043025;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 64 ".vt[0:63]"  -0.49999949 -0.50000262 0.49999937 0.49999949 -0.50000262 0.49999937
		 -0.49999949 0.49999928 0.49999937 0.49999949 0.49999928 0.49999937 -0.49999949 0.49999928 -0.50000006
		 0.49999949 0.49999928 -0.50000006 -0.49999949 -0.50000262 -0.50000006 0.49999949 -0.50000262 -0.50000006
		 -0.46857283 -0.50000262 0.49999937 -0.46857283 0.49999928 0.49999937 -0.46857283 0.49999928 -0.50000006
		 -0.46857283 -0.50000262 -0.50000006 0.47041607 -0.50000262 0.49999937 0.47041607 0.49999928 0.49999937
		 0.47041607 0.49999928 -0.50000006 0.47041607 -0.50000262 -0.50000006 -0.49999949 -2.67275095 -0.50000006
		 -0.46857283 -2.67275095 -0.50000006 -0.46857283 -2.67275095 0.49999937 -0.49999949 -2.67275095 0.49999937
		 0.47041607 -2.67275095 -0.50000006 0.47041607 -2.67275095 0.49999937 0.49999949 -2.67275095 -0.50000006
		 0.49999949 -2.67275095 0.49999937 -0.49999949 13.44157219 0.49999937 -0.46857283 13.44157219 0.49999937
		 -0.46857283 13.44157219 -0.50000006 -0.49999949 13.44157219 -0.50000006 0.47041607 13.44157219 0.49999937
		 0.47041607 13.44157219 -0.50000006 0.49999949 13.44157219 0.49999937 0.49999949 13.44157219 -0.50000006
		 -0.49999949 14.68473434 0.49999937 -0.46857283 14.68473434 0.49999937 -0.46857283 14.68473434 -0.50000006
		 -0.49999949 14.68473434 -0.50000006 0.47041607 14.68473434 0.49999937 0.47041607 14.68473434 -0.50000006
		 0.49999949 14.68473434 0.49999937 0.49999949 14.68473434 -0.50000006 -0.49999949 23.05906105 0.49999937
		 -0.46857283 23.05906105 0.49999937 -0.46857283 23.05906105 -0.50000006 -0.49999949 23.05906105 -0.50000006
		 0.47041607 23.05906105 0.49999937 0.47041607 23.05906105 -0.50000006 0.49999949 23.05906105 0.49999937
		 0.49999949 23.05906105 -0.50000006 -0.49999949 24.38346672 0.49999937 -0.46857283 24.38346672 0.49999937
		 -0.46857283 24.38346672 -0.50000006 -0.49999949 24.38346672 -0.50000006 0.47041607 24.38346672 0.49999937
		 0.47041607 24.38346672 -0.50000006 0.49999949 24.38346672 0.49999937 0.49999949 24.38346672 -0.50000006
		 -0.4685728 0.49999928 -0.42587024 -0.4685728 13.44157219 -0.42587024 0.47041607 13.44157219 -0.42587024
		 0.47041607 0.49999928 -0.42587024 -0.46857283 14.68473434 -0.42172128 -0.46857283 23.05906105 -0.42172128
		 0.47041607 23.05906105 -0.42172128 0.47041607 14.68473434 -0.42172128;
	setAttr -s 140 ".ed[0:139]"  0 8 1 2 9 1 4 10 1 6 11 1 0 2 1 1 3 1 2 4 1
		 3 5 1 4 6 1 5 7 1 6 0 1 7 1 1 8 12 1 9 13 1 10 14 1 11 15 1 8 9 1 9 56 1 10 11 1
		 11 8 1 12 1 1 13 3 1 14 5 1 15 7 1 12 13 1 13 59 1 14 15 1 15 12 1 6 16 1 11 17 1
		 16 17 1 8 18 1 17 18 1 0 19 1 19 18 1 16 19 1 15 20 1 12 21 1 20 21 1 7 22 1 20 22 1
		 1 23 1 22 23 1 21 23 1 2 24 1 9 25 1 24 25 1 10 26 1 25 57 1 4 27 1 27 26 1 24 27 1
		 13 28 1 14 29 1 28 58 1 3 30 1 28 30 1 5 31 1 30 31 1 29 31 1 24 32 1 25 33 1 32 33 1
		 26 34 1 33 60 1 27 35 1 35 34 1 32 35 1 28 36 1 29 37 1 36 63 1 30 38 1 36 38 1 31 39 1
		 38 39 1 37 39 1 26 29 1 34 37 1 33 36 1 25 28 1 32 40 1 33 41 1 40 41 1 34 42 1 41 61 1
		 35 43 1 43 42 1 40 43 1 36 44 1 37 45 1 44 62 1 38 46 1 44 46 1 39 47 1 46 47 1 45 47 1
		 40 48 1 41 49 1 48 49 1 42 50 1 49 50 1 43 51 1 51 50 1 48 51 1 44 52 1 45 53 1 52 53 1
		 46 54 1 52 54 1 47 55 1 54 55 1 53 55 1 42 45 1 50 53 1 49 52 1 41 44 1 56 10 0 57 26 0
		 58 29 0 59 14 0 56 57 1 57 58 1 58 59 1 59 56 1 60 34 0 61 42 0 62 45 0 63 37 0 60 61 1
		 61 62 1 62 63 1 63 60 1 37 45 1 34 42 1 60 61 1 63 62 1 14 29 1 10 26 1 56 57 1 59 58 1;
	setAttr -s 70 -ch 280 ".fc[0:69]" -type "polyFaces" 
		f 4 0 16 -2 -5
		mu 0 4 0 14 16 2
		f 4 98 100 -103 -104
		mu 0 4 56 57 58 59
		f 4 2 18 -4 -9
		mu 0 4 4 17 18 6
		f 4 30 32 -35 -36
		mu 0 4 24 25 26 27
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13
		f 4 -17 12 24 -14
		mu 0 4 16 14 19 21
		f 4 123 -18 13 25
		mu 0 4 67 64 16 21
		f 4 -19 14 26 -16
		mu 0 4 18 17 22 23
		f 4 -20 15 27 -13
		mu 0 4 15 18 23 20
		f 4 -25 20 5 -22
		mu 0 4 21 19 1 3
		f 4 -107 108 110 -112
		mu 0 4 60 61 62 63
		f 4 -27 22 9 -24
		mu 0 4 23 22 5 7
		f 4 -39 40 42 -44
		mu 0 4 28 29 30 31
		f 4 3 29 -31 -29
		mu 0 4 6 18 25 24
		f 4 19 31 -33 -30
		mu 0 4 18 15 26 25
		f 4 -1 33 34 -32
		mu 0 4 15 8 27 26
		f 4 -11 28 35 -34
		mu 0 4 8 6 24 27
		f 4 -28 36 38 -38
		mu 0 4 20 23 29 28
		f 4 23 39 -41 -37
		mu 0 4 23 7 30 29
		f 4 11 41 -43 -40
		mu 0 4 7 9 31 30
		f 4 -21 37 43 -42
		mu 0 4 9 20 28 31
		f 4 1 45 -47 -45
		mu 0 4 2 16 33 32
		f 4 17 120 -49 -46
		mu 0 4 16 64 65 33
		f 4 -3 49 50 -48
		mu 0 4 17 4 35 34
		f 4 -7 44 51 -50
		mu 0 4 4 2 32 35
		f 4 122 -26 52 54
		mu 0 4 66 67 21 37
		f 4 21 55 -57 -53
		mu 0 4 21 3 38 37
		f 4 7 57 -59 -56
		mu 0 4 3 5 39 38
		f 4 -23 53 59 -58
		mu 0 4 5 22 36 39
		f 4 46 61 -63 -61
		mu 0 4 32 33 41 40
		f 4 -51 65 66 -64
		mu 0 4 34 35 43 42
		f 4 -52 60 67 -66
		mu 0 4 35 32 40 43
		f 4 56 71 -73 -69
		mu 0 4 37 38 46 45
		f 4 58 73 -75 -72
		mu 0 4 38 39 47 46
		f 4 -60 69 75 -74
		mu 0 4 39 36 44 47
		f 4 63 77 -70 -77
		mu 0 4 34 42 44 36
		f 4 131 -65 78 70
		mu 0 4 71 68 41 45
		f 4 -62 79 68 -79
		mu 0 4 41 33 37 45
		f 4 48 121 -55 -80
		mu 0 4 33 65 66 37
		f 4 62 81 -83 -81
		mu 0 4 40 41 49 48
		f 4 64 128 -85 -82
		mu 0 4 41 68 69 49
		f 4 -67 85 86 -84
		mu 0 4 42 43 51 50
		f 4 -68 80 87 -86
		mu 0 4 43 40 48 51
		f 4 130 -71 88 90
		mu 0 4 70 71 45 53
		f 4 72 91 -93 -89
		mu 0 4 45 46 54 53
		f 4 74 93 -95 -92
		mu 0 4 46 47 55 54
		f 4 -76 89 95 -94
		mu 0 4 47 44 52 55
		f 4 82 97 -99 -97
		mu 0 4 48 49 57 56
		f 4 -87 101 102 -100
		mu 0 4 50 51 59 58
		f 4 -88 96 103 -102
		mu 0 4 51 48 56 59
		f 4 92 107 -109 -105
		mu 0 4 53 54 62 61
		f 4 94 109 -111 -108
		mu 0 4 54 55 63 62
		f 4 -96 105 111 -110
		mu 0 4 55 52 60 63
		f 4 99 113 -106 -113
		mu 0 4 50 58 60 52
		f 4 -101 114 106 -114
		mu 0 4 58 57 61 60
		f 4 -98 115 104 -115
		mu 0 4 57 49 53 61
		f 4 84 129 -91 -116
		mu 0 4 49 69 70 53
		f 4 -121 116 47 -118
		mu 0 4 65 64 17 34
		f 4 -120 -123 118 -54
		mu 0 4 22 67 66 36
		f 4 -129 124 83 -126
		mu 0 4 69 68 42 50
		f 4 -128 -131 126 -90
		mu 0 4 44 71 70 52
		f 4 -78 133 112 -133
		mu 0 4 44 42 50 52
		f 4 -125 134 125 -134
		mu 0 4 42 68 69 50
		f 4 -132 135 -130 -135
		mu 0 4 68 71 70 69
		f 4 127 132 -127 -136
		mu 0 4 71 44 52 70
		f 4 -15 137 76 -137
		mu 0 4 22 17 34 36
		f 4 -117 138 117 -138
		mu 0 4 17 64 65 34
		f 4 -124 139 -122 -139
		mu 0 4 64 67 66 65
		f 4 119 136 -119 -140
		mu 0 4 67 22 36 66;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
createNode transform -n "vase";
	rename -uid "C77D04DC-4BBD-42FF-84DF-FD9A868EE518";
	setAttr ".t" -type "double3" -26.107629796476711 23.208824761137276 -4.6076247308320593 ;
	setAttr ".s" -type "double3" 2.5993814782064346 2.5993814782064346 2.5993814782064346 ;
createNode mesh -n "vaseShape" -p "vase";
	rename -uid "DB4F3FE5-48D4-EB95-26A6-FD9D6F644834";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 1.5229773115652028 1.5145874574051177 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode transform -n "shelf4";
	rename -uid "6016D5D7-47AB-26CB-0E4F-C39CEE5581E4";
	setAttr ".t" -type "double3" -22.133370339040415 2.3183390047443941 -4.8500368722748215 ;
	setAttr ".s" -type "double3" 16.171219704102587 0.75120721960833869 4.3169060170636264 ;
createNode mesh -n "shelf4Shape" -p "shelf4";
	rename -uid "222A412A-4C05-20D0-DF05-1DA29D9115C7";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 1.4958678781986237 1.4932580590248108 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode mesh -n "polySurfaceShape2" -p "shelf4";
	rename -uid "8B686F6E-4CF1-3446-A8EC-FBB582995BA1";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr -s 6 ".gtag";
	setAttr ".gtag[0].gtagnm" -type "string" "back";
	setAttr ".gtag[0].gtagcmp" -type "componentList" 4 "f[2]" "f[8]" "f[12]" "f[66]";
	setAttr ".gtag[1].gtagnm" -type "string" "bottom";
	setAttr ".gtag[1].gtagcmp" -type "componentList" 3 "f[3]" "f[9]" "f[13:21]";
	setAttr ".gtag[2].gtagnm" -type "string" "front";
	setAttr ".gtag[2].gtagcmp" -type "componentList" 3 "f[0]" "f[6]" "f[10]";
	setAttr ".gtag[3].gtagnm" -type "string" "left";
	setAttr ".gtag[3].gtagcmp" -type "componentList" 1 "f[5]";
	setAttr ".gtag[4].gtagnm" -type "string" "right";
	setAttr ".gtag[4].gtagcmp" -type "componentList" 1 "f[4]";
	setAttr ".gtag[5].gtagnm" -type "string" "top";
	setAttr ".gtag[5].gtagcmp" -type "componentList" 4 "f[1]" "f[7]" "f[11]" "f[22:69]";
	setAttr ".pv" -type "double2" 0.5 0.5 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 72 ".uvst[0].uvsp[0:71]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25 0.38285673 0 0.38285673 1 0.38285673 0.25 0.38285673
		 0.5 0.38285673 0.75 0.61606371 0 0.61606371 1 0.61606371 0.25 0.61606371 0.5 0.61606371
		 0.75 0.375 0.75 0.38285673 0.75 0.38285673 1 0.375 1 0.61606371 1 0.61606371 0.75
		 0.625 0.75 0.625 1 0.375 0.25 0.38285673 0.25 0.38285673 0.5 0.375 0.5 0.61606371
		 0.5 0.61606371 0.25 0.625 0.25 0.625 0.5 0.375 0.25 0.38285673 0.25 0.38285673 0.5
		 0.375 0.5 0.61606371 0.5 0.61606371 0.25 0.625 0.25 0.625 0.5 0.375 0.25 0.38285673
		 0.25 0.38285673 0.5 0.375 0.5 0.61606371 0.5 0.61606371 0.25 0.625 0.25 0.625 0.5
		 0.375 0.25 0.38285673 0.25 0.38285673 0.5 0.375 0.5 0.61606371 0.5 0.61606371 0.25
		 0.625 0.25 0.625 0.5 0.38285673 0.48146749 0.38285673 0.48146749 0.61606371 0.48146749
		 0.61606371 0.48146749 0.38285673 0.48043025 0.38285673 0.48043025 0.61606371 0.48043025
		 0.61606371 0.48043025;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 64 ".vt[0:63]"  -0.49999949 -0.50000262 0.49999937 0.49999949 -0.50000262 0.49999937
		 -0.49999949 0.49999928 0.49999937 0.49999949 0.49999928 0.49999937 -0.49999949 0.49999928 -0.50000006
		 0.49999949 0.49999928 -0.50000006 -0.49999949 -0.50000262 -0.50000006 0.49999949 -0.50000262 -0.50000006
		 -0.46857283 -0.50000262 0.49999937 -0.46857283 0.49999928 0.49999937 -0.46857283 0.49999928 -0.50000006
		 -0.46857283 -0.50000262 -0.50000006 0.47041607 -0.50000262 0.49999937 0.47041607 0.49999928 0.49999937
		 0.47041607 0.49999928 -0.50000006 0.47041607 -0.50000262 -0.50000006 -0.49999949 -2.67275095 -0.50000006
		 -0.46857283 -2.67275095 -0.50000006 -0.46857283 -2.67275095 0.49999937 -0.49999949 -2.67275095 0.49999937
		 0.47041607 -2.67275095 -0.50000006 0.47041607 -2.67275095 0.49999937 0.49999949 -2.67275095 -0.50000006
		 0.49999949 -2.67275095 0.49999937 -0.49999949 13.44157219 0.49999937 -0.46857283 13.44157219 0.49999937
		 -0.46857283 13.44157219 -0.50000006 -0.49999949 13.44157219 -0.50000006 0.47041607 13.44157219 0.49999937
		 0.47041607 13.44157219 -0.50000006 0.49999949 13.44157219 0.49999937 0.49999949 13.44157219 -0.50000006
		 -0.49999949 14.68473434 0.49999937 -0.46857283 14.68473434 0.49999937 -0.46857283 14.68473434 -0.50000006
		 -0.49999949 14.68473434 -0.50000006 0.47041607 14.68473434 0.49999937 0.47041607 14.68473434 -0.50000006
		 0.49999949 14.68473434 0.49999937 0.49999949 14.68473434 -0.50000006 -0.49999949 23.05906105 0.49999937
		 -0.46857283 23.05906105 0.49999937 -0.46857283 23.05906105 -0.50000006 -0.49999949 23.05906105 -0.50000006
		 0.47041607 23.05906105 0.49999937 0.47041607 23.05906105 -0.50000006 0.49999949 23.05906105 0.49999937
		 0.49999949 23.05906105 -0.50000006 -0.49999949 24.38346672 0.49999937 -0.46857283 24.38346672 0.49999937
		 -0.46857283 24.38346672 -0.50000006 -0.49999949 24.38346672 -0.50000006 0.47041607 24.38346672 0.49999937
		 0.47041607 24.38346672 -0.50000006 0.49999949 24.38346672 0.49999937 0.49999949 24.38346672 -0.50000006
		 -0.4685728 0.49999928 -0.42587024 -0.4685728 13.44157219 -0.42587024 0.47041607 13.44157219 -0.42587024
		 0.47041607 0.49999928 -0.42587024 -0.46857283 14.68473434 -0.42172128 -0.46857283 23.05906105 -0.42172128
		 0.47041607 23.05906105 -0.42172128 0.47041607 14.68473434 -0.42172128;
	setAttr -s 140 ".ed[0:139]"  0 8 1 2 9 1 4 10 1 6 11 1 0 2 1 1 3 1 2 4 1
		 3 5 1 4 6 1 5 7 1 6 0 1 7 1 1 8 12 1 9 13 1 10 14 1 11 15 1 8 9 1 9 56 1 10 11 1
		 11 8 1 12 1 1 13 3 1 14 5 1 15 7 1 12 13 1 13 59 1 14 15 1 15 12 1 6 16 1 11 17 1
		 16 17 1 8 18 1 17 18 1 0 19 1 19 18 1 16 19 1 15 20 1 12 21 1 20 21 1 7 22 1 20 22 1
		 1 23 1 22 23 1 21 23 1 2 24 1 9 25 1 24 25 1 10 26 1 25 57 1 4 27 1 27 26 1 24 27 1
		 13 28 1 14 29 1 28 58 1 3 30 1 28 30 1 5 31 1 30 31 1 29 31 1 24 32 1 25 33 1 32 33 1
		 26 34 1 33 60 1 27 35 1 35 34 1 32 35 1 28 36 1 29 37 1 36 63 1 30 38 1 36 38 1 31 39 1
		 38 39 1 37 39 1 26 29 1 34 37 1 33 36 1 25 28 1 32 40 1 33 41 1 40 41 1 34 42 1 41 61 1
		 35 43 1 43 42 1 40 43 1 36 44 1 37 45 1 44 62 1 38 46 1 44 46 1 39 47 1 46 47 1 45 47 1
		 40 48 1 41 49 1 48 49 1 42 50 1 49 50 1 43 51 1 51 50 1 48 51 1 44 52 1 45 53 1 52 53 1
		 46 54 1 52 54 1 47 55 1 54 55 1 53 55 1 42 45 1 50 53 1 49 52 1 41 44 1 56 10 0 57 26 0
		 58 29 0 59 14 0 56 57 1 57 58 1 58 59 1 59 56 1 60 34 0 61 42 0 62 45 0 63 37 0 60 61 1
		 61 62 1 62 63 1 63 60 1 37 45 1 34 42 1 60 61 1 63 62 1 14 29 1 10 26 1 56 57 1 59 58 1;
	setAttr -s 70 -ch 280 ".fc[0:69]" -type "polyFaces" 
		f 4 0 16 -2 -5
		mu 0 4 0 14 16 2
		f 4 98 100 -103 -104
		mu 0 4 56 57 58 59
		f 4 2 18 -4 -9
		mu 0 4 4 17 18 6
		f 4 30 32 -35 -36
		mu 0 4 24 25 26 27
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13
		f 4 -17 12 24 -14
		mu 0 4 16 14 19 21
		f 4 123 -18 13 25
		mu 0 4 67 64 16 21
		f 4 -19 14 26 -16
		mu 0 4 18 17 22 23
		f 4 -20 15 27 -13
		mu 0 4 15 18 23 20
		f 4 -25 20 5 -22
		mu 0 4 21 19 1 3
		f 4 -107 108 110 -112
		mu 0 4 60 61 62 63
		f 4 -27 22 9 -24
		mu 0 4 23 22 5 7
		f 4 -39 40 42 -44
		mu 0 4 28 29 30 31
		f 4 3 29 -31 -29
		mu 0 4 6 18 25 24
		f 4 19 31 -33 -30
		mu 0 4 18 15 26 25
		f 4 -1 33 34 -32
		mu 0 4 15 8 27 26
		f 4 -11 28 35 -34
		mu 0 4 8 6 24 27
		f 4 -28 36 38 -38
		mu 0 4 20 23 29 28
		f 4 23 39 -41 -37
		mu 0 4 23 7 30 29
		f 4 11 41 -43 -40
		mu 0 4 7 9 31 30
		f 4 -21 37 43 -42
		mu 0 4 9 20 28 31
		f 4 1 45 -47 -45
		mu 0 4 2 16 33 32
		f 4 17 120 -49 -46
		mu 0 4 16 64 65 33
		f 4 -3 49 50 -48
		mu 0 4 17 4 35 34
		f 4 -7 44 51 -50
		mu 0 4 4 2 32 35
		f 4 122 -26 52 54
		mu 0 4 66 67 21 37
		f 4 21 55 -57 -53
		mu 0 4 21 3 38 37
		f 4 7 57 -59 -56
		mu 0 4 3 5 39 38
		f 4 -23 53 59 -58
		mu 0 4 5 22 36 39
		f 4 46 61 -63 -61
		mu 0 4 32 33 41 40
		f 4 -51 65 66 -64
		mu 0 4 34 35 43 42
		f 4 -52 60 67 -66
		mu 0 4 35 32 40 43
		f 4 56 71 -73 -69
		mu 0 4 37 38 46 45
		f 4 58 73 -75 -72
		mu 0 4 38 39 47 46
		f 4 -60 69 75 -74
		mu 0 4 39 36 44 47
		f 4 63 77 -70 -77
		mu 0 4 34 42 44 36
		f 4 131 -65 78 70
		mu 0 4 71 68 41 45
		f 4 -62 79 68 -79
		mu 0 4 41 33 37 45
		f 4 48 121 -55 -80
		mu 0 4 33 65 66 37
		f 4 62 81 -83 -81
		mu 0 4 40 41 49 48
		f 4 64 128 -85 -82
		mu 0 4 41 68 69 49
		f 4 -67 85 86 -84
		mu 0 4 42 43 51 50
		f 4 -68 80 87 -86
		mu 0 4 43 40 48 51
		f 4 130 -71 88 90
		mu 0 4 70 71 45 53
		f 4 72 91 -93 -89
		mu 0 4 45 46 54 53
		f 4 74 93 -95 -92
		mu 0 4 46 47 55 54
		f 4 -76 89 95 -94
		mu 0 4 47 44 52 55
		f 4 82 97 -99 -97
		mu 0 4 48 49 57 56
		f 4 -87 101 102 -100
		mu 0 4 50 51 59 58
		f 4 -88 96 103 -102
		mu 0 4 51 48 56 59
		f 4 92 107 -109 -105
		mu 0 4 53 54 62 61
		f 4 94 109 -111 -108
		mu 0 4 54 55 63 62
		f 4 -96 105 111 -110
		mu 0 4 55 52 60 63
		f 4 99 113 -106 -113
		mu 0 4 50 58 60 52
		f 4 -101 114 106 -114
		mu 0 4 58 57 61 60
		f 4 -98 115 104 -115
		mu 0 4 57 49 53 61
		f 4 84 129 -91 -116
		mu 0 4 49 69 70 53
		f 4 -121 116 47 -118
		mu 0 4 65 64 17 34
		f 4 -120 -123 118 -54
		mu 0 4 22 67 66 36
		f 4 -129 124 83 -126
		mu 0 4 69 68 42 50
		f 4 -128 -131 126 -90
		mu 0 4 44 71 70 52
		f 4 -78 133 112 -133
		mu 0 4 44 42 50 52
		f 4 -125 134 125 -134
		mu 0 4 42 68 69 50
		f 4 -132 135 -130 -135
		mu 0 4 68 71 70 69
		f 4 127 132 -127 -136
		mu 0 4 71 44 52 70
		f 4 -15 137 76 -137
		mu 0 4 22 17 34 36
		f 4 -117 138 117 -138
		mu 0 4 17 64 65 34
		f 4 -124 139 -122 -139
		mu 0 4 64 67 66 65
		f 4 119 136 -119 -140
		mu 0 4 67 22 36 66;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
createNode transform -n "bottom";
	rename -uid "FD2D7F2A-405D-BE2A-A626-B4A009531287";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 -1000.1 0 ;
	setAttr ".r" -type "double3" 90 0 0 ;
createNode camera -n "bottomShape" -p "bottom";
	rename -uid "141EF644-4461-26A6-4E83-088C76EBC886";
	setAttr -k off ".v";
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "bottom1";
	setAttr ".den" -type "string" "bottom1_depth";
	setAttr ".man" -type "string" "bottom1_mask";
	setAttr ".hc" -type "string" "viewSet -bo %camera";
	setAttr ".o" yes;
createNode lightLinker -s -n "lightLinker1";
	rename -uid "4E48F810-43B5-DF59-04A7-80AC49D51E3F";
	setAttr -s 2 ".lnk";
	setAttr -s 2 ".slnk";
createNode shapeEditorManager -n "shapeEditorManager";
	rename -uid "41DD297A-40FA-5CB6-1A38-99A978841A65";
createNode poseInterpolatorManager -n "poseInterpolatorManager";
	rename -uid "4779D443-4653-98FA-4367-93B3ED4B45F5";
createNode displayLayerManager -n "layerManager";
	rename -uid "25ABAEDE-43B0-878A-6423-79AE7A551C11";
createNode displayLayer -n "defaultLayer";
	rename -uid "581C116A-46AC-2CF4-01E4-E0BC9B1F4004";
	setAttr ".ufem" -type "stringArray" 0  ;
createNode renderLayerManager -n "renderLayerManager";
	rename -uid "E048AAFF-4567-B4F7-6A3E-2D98AB9FA7E2";
createNode renderLayer -n "defaultRenderLayer";
	rename -uid "A48A3E1D-4422-75F9-3343-6A8935773374";
	setAttr ".g" yes;
createNode script -n "uiConfigurationScriptNode";
	rename -uid "E6638011-419C-BF53-82DA-96930897A450";
	setAttr ".b" -type "string" (
		"// Maya Mel UI Configuration File.\n//\n//  This script is machine generated.  Edit at your own risk.\n//\n//\n\nglobal string $gMainPane;\nif (`paneLayout -exists $gMainPane`) {\n\n\tglobal int $gUseScenePanelConfig;\n\tint    $useSceneConfig = $gUseScenePanelConfig;\n\tint    $nodeEditorPanelVisible = stringArrayContains(\"nodeEditorPanel1\", `getPanel -vis`);\n\tint    $nodeEditorWorkspaceControlOpen = (`workspaceControl -exists nodeEditorPanel1Window` && `workspaceControl -q -visible nodeEditorPanel1Window`);\n\tint    $menusOkayInPanels = `optionVar -q allowMenusInPanels`;\n\tint    $nVisPanes = `paneLayout -q -nvp $gMainPane`;\n\tint    $nPanes = 0;\n\tstring $editorName;\n\tstring $panelName;\n\tstring $itemFilterName;\n\tstring $panelConfig;\n\n\t//\n\t//  get current state of the UI\n\t//\n\tsceneUIReplacement -update $gMainPane;\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Top View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Top View\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"|top\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n"
		+ "            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n"
		+ "            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -bluePencil 1\n            -greasePencils 0\n            -excludeObjectPreset \"All\" \n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Side View\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Side View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"|side\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n"
		+ "            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n"
		+ "            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -bluePencil 1\n            -greasePencils 0\n            -excludeObjectPreset \"All\" \n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n            -sceneRenderFilter 0\n"
		+ "            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Front View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Front View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"|front\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n"
		+ "            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n"
		+ "            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n"
		+ "            -bluePencil 1\n            -greasePencils 0\n            -excludeObjectPreset \"All\" \n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Persp View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Persp View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"|persp\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 1\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n"
		+ "            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n"
		+ "            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n"
		+ "            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -bluePencil 1\n            -greasePencils 0\n            -excludeObjectPreset \"All\" \n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1492\n            -height 1043\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"ToggledOutliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"ToggledOutliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -docTag \"isolOutln_fromSeln\" \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n"
		+ "            -showReferenceNodes 1\n            -showReferenceMembers 1\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n"
		+ "            -alwaysToggleSelect 0\n            -directSelect 0\n            -isSet 0\n            -isSetMember 0\n            -showUfeItems 1\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -selectCommand \"print(\\\"\\\")\" \n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            -renderFilterIndex 0\n            -selectionOrder \"chronological\" \n            -expandAttribute 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n"
		+ "\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"Outliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"Outliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 0\n            -showReferenceMembers 0\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n"
		+ "            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -showUfeItems 1\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n"
		+ "            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"graphEditor\" (localizedPanelLabel(\"Graph Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Graph Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n"
		+ "                -autoExpand 1\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showParentContainers 0\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 0\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 1\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 1\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -showUfeItems 1\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n"
		+ "                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 1\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"GraphEd\");\n            animCurveEditor -e \n                -displayValues 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -showPlayRangeShades \"on\" \n                -lockPlayRangeShades \"off\" \n                -smoothness \"fine\" \n                -resultSamples 1\n                -resultScreenSamples 0\n                -resultUpdate \"delayed\" \n"
		+ "                -showUpstreamCurves 1\n                -tangentScale 1\n                -tangentLineThickness 1\n                -keyMinScale 1\n                -stackedCurvesMin -1\n                -stackedCurvesMax 1\n                -stackedCurvesSpace 0.2\n                -preSelectionHighlight 0\n                -limitToSelectedCurves 0\n                -constrainDrag 0\n                -valueLinesToggle 0\n                -highlightAffectedCurves 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dopeSheetPanel\" (localizedPanelLabel(\"Dope Sheet\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dope Sheet\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n"
		+ "                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 1\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showParentContainers 0\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 0\n                -showCompounds 0\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 1\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"0\" \n"
		+ "                -showSetMembers 1\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -showUfeItems 1\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"DopeSheetEd\");\n            dopeSheetEditor -e \n                -displayValues 0\n"
		+ "                -snapTime \"none\" \n                -snapValue \"none\" \n                -outliner \"dopeSheetPanel1OutlineEd\" \n                -hierarchyBelow 0\n                -selectionWindow 0 0 0 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"timeEditorPanel\" (localizedPanelLabel(\"Time Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Time Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"clipEditorPanel\" (localizedPanelLabel(\"Trax Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Trax Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = clipEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayValues 0\n"
		+ "                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"sequenceEditorPanel\" (localizedPanelLabel(\"Camera Sequencer\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Camera Sequencer\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = sequenceEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayValues 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 1 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperGraphPanel\" (localizedPanelLabel(\"Hypergraph Hierarchy\")) `;\n\tif (\"\" != $panelName) {\n"
		+ "\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypergraph Hierarchy\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"HyperGraphEd\");\n            hyperGraph -e \n                -graphLayoutStyle \"hierarchicalLayout\" \n                -orientation \"horiz\" \n                -mergeConnections 0\n                -zoom 1\n                -animateTransition 0\n                -showRelationships 1\n                -showShapes 0\n                -showDeformers 0\n                -showExpressions 0\n                -showConstraints 0\n                -showConnectionFromSelected 0\n                -showConnectionToSelected 0\n                -showConstraintLabels 0\n                -showUnderworld 0\n                -showInvisible 0\n                -transitionFrames 1\n                -opaqueContainers 0\n                -freeform 0\n                -imagePosition 0 0 \n                -imageScale 1\n                -imageEnabled 0\n                -graphType \"DAG\" \n                -heatMapDisplay 0\n"
		+ "                -updateSelection 1\n                -updateNodeAdded 1\n                -useDrawOverrideColor 0\n                -limitGraphTraversal -1\n                -range 0 0 \n                -iconSize \"smallIcons\" \n                -showCachedConnections 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperShadePanel\" (localizedPanelLabel(\"Hypershade\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypershade\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"visorPanel\" (localizedPanelLabel(\"Visor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Visor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n"
		+ "\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"nodeEditorPanel\" (localizedPanelLabel(\"Node Editor\")) `;\n\tif ($nodeEditorPanelVisible || $nodeEditorWorkspaceControlOpen) {\n\t\tif (\"\" == $panelName) {\n\t\t\tif ($useSceneConfig) {\n\t\t\t\t$panelName = `scriptedPanel -unParent  -type \"nodeEditorPanel\" -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -connectNodeOnCreation 0\n                -connectOnDrop 0\n                -copyConnectionsOnPaste 0\n                -connectionStyle \"bezier\" \n                -defaultPinnedState 0\n                -additiveGraphingMode 0\n                -connectedGraphingMode 1\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n"
		+ "                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -crosshairOnEdgeDragging 0\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n                -extendToShapes 1\n                -showUnitConversions 0\n                -editorMode \"default\" \n                -hasWatchpoint 0\n                $editorName;\n\t\t\t}\n\t\t} else {\n\t\t\t$label = `panel -q -label $panelName`;\n\t\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n"
		+ "                -connectNodeOnCreation 0\n                -connectOnDrop 0\n                -copyConnectionsOnPaste 0\n                -connectionStyle \"bezier\" \n                -defaultPinnedState 0\n                -additiveGraphingMode 0\n                -connectedGraphingMode 1\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -crosshairOnEdgeDragging 0\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n                -extendToShapes 1\n                -showUnitConversions 0\n                -editorMode \"default\" \n                -hasWatchpoint 0\n                $editorName;\n\t\t\tif (!$useSceneConfig) {\n"
		+ "\t\t\t\tpanel -e -l $label $panelName;\n\t\t\t}\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"createNodePanel\" (localizedPanelLabel(\"Create Node\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Create Node\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"polyTexturePlacementPanel\" (localizedPanelLabel(\"UV Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"UV Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"renderWindowPanel\" (localizedPanelLabel(\"Render View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Render View\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"shapePanel\" (localizedPanelLabel(\"Shape Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tshapePanel -edit -l (localizedPanelLabel(\"Shape Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"posePanel\" (localizedPanelLabel(\"Pose Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tposePanel -edit -l (localizedPanelLabel(\"Pose Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynRelEdPanel\" (localizedPanelLabel(\"Dynamic Relationships\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dynamic Relationships\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"relationshipPanel\" (localizedPanelLabel(\"Relationship Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Relationship Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"referenceEditorPanel\" (localizedPanelLabel(\"Reference Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Reference Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynPaintScriptedPanelType\" (localizedPanelLabel(\"Paint Effects\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Paint Effects\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"scriptEditorPanel\" (localizedPanelLabel(\"Script Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Script Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"profilerPanel\" (localizedPanelLabel(\"Profiler Tool\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Profiler Tool\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"contentBrowserPanel\" (localizedPanelLabel(\"Content Browser\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Content Browser\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\tif ($useSceneConfig) {\n        string $configName = `getPanel -cwl (localizedPanelLabel(\"Current Layout\"))`;\n        if (\"\" != $configName) {\n\t\t\tpanelConfiguration -edit -label (localizedPanelLabel(\"Current Layout\")) \n\t\t\t\t-userCreated false\n\t\t\t\t-defaultImage \"vacantCell.xP:/\"\n\t\t\t\t-image \"\"\n\t\t\t\t-sc false\n\t\t\t\t-configString \"global string $gMainPane; paneLayout -e -cn \\\"single\\\" -ps 1 100 100 $gMainPane;\"\n\t\t\t\t-removeAllPanels\n\t\t\t\t-ap false\n\t\t\t\t\t(localizedPanelLabel(\"Persp View\")) \n\t\t\t\t\t\"modelPanel\"\n"
		+ "\t\t\t\t\t\"$panelName = `modelPanel -unParent -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 1\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 32768\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -bluePencil 1\\n    -greasePencils 0\\n    -excludeObjectPreset \\\"All\\\" \\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 1492\\n    -height 1043\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 1\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 32768\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -bluePencil 1\\n    -greasePencils 0\\n    -excludeObjectPreset \\\"All\\\" \\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 1492\\n    -height 1043\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName\"\n"
		+ "\t\t\t\t$configName;\n\n            setNamedPanelLayout (localizedPanelLabel(\"Current Layout\"));\n        }\n\n        panelHistory -e -clear mainPanelHistory;\n        sceneUIReplacement -clear;\n\t}\n\n\ngrid -spacing 5 -size 12 -divisions 5 -displayAxes yes -displayGridLines yes -displayDivisionLines yes -displayPerspectiveLabels no -displayOrthographicLabels no -displayAxesBold yes -perspectiveLabelPosition axis -orthographicLabelPosition edge;\nviewManip -drawCompass 0 -compassAngle 0 -frontParameters \"\" -homeParameters \"\" -selectionLockParameters \"\";\n}\n");
	setAttr ".st" 3;
createNode script -n "sceneConfigurationScriptNode";
	rename -uid "B45A4BEA-4CE3-55F6-93F2-21A1B5CAD84E";
	setAttr ".b" -type "string" "playbackOptions -min 0 -max 42 -ast 0 -aet 101 ";
	setAttr ".st" 6;
createNode polyCube -n "polyCube1";
	rename -uid "1E8CABBF-4E93-DBFF-A425-358F50A2ED68";
	setAttr ".cuv" 4;
createNode polySplit -n "polySplit1";
	rename -uid "C2E53520-455A-DF95-5BEC-BBACBAEE426A";
	setAttr -s 5 ".e[0:4]"  0.031426899 0.031426899 0.031426899 0.031426899
		 0.031426899;
	setAttr -s 5 ".d[0:4]"  -2147483648 -2147483647 -2147483646 -2147483645 -2147483648;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit2";
	rename -uid "98CAE3C1-449D-8B72-CC6E-B7A298B2B438";
	setAttr -s 5 ".e[0:4]"  0.96309501 0.96309501 0.96309501 0.96309501
		 0.96309501;
	setAttr -s 5 ".d[0:4]"  -2147483636 -2147483635 -2147483634 -2147483633 -2147483636;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyExtrudeFace -n "polyExtrudeFace1";
	rename -uid "968F05C0-4146-7E92-041E-099170084BBA";
	setAttr ".ics" -type "componentList" 2 "f[3]" "f[13]";
	setAttr ".ix" -type "matrix" 16.171219704102587 0 0 0 0 0.41927889493470766 0 0 0 0 6.3170233860695353 0
		 0 1.6512034452749658 -4.8500368722748162 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 1.441564 -4.8500371 ;
	setAttr ".rs" 54238;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -8.0856098520512933 1.441563997807612 -8.0085485653095834 ;
	setAttr ".cbx" -type "double3" 8.0856098520512933 1.441563997807612 -1.6915251792400485 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak1";
	rename -uid "AF0D23D9-4A21-6320-3AE4-8580F39E82EA";
	setAttr ".uopa" yes;
	setAttr -s 4 ".tk[12:15]" -type "float3"  0.0061614979 0 0 0.0061614979
		 0 0 0.0061614979 0 0 0.0061614979 0 0;
createNode polyExtrudeFace -n "polyExtrudeFace2";
	rename -uid "66C32F39-4EC5-5111-6331-4AA1B4DB2814";
	setAttr ".ics" -type "componentList" 2 "f[1]" "f[11]";
	setAttr ".ix" -type "matrix" 16.171219704102587 0 0 0 0 0.41927889493470766 0 0 0 0 6.3170233860695353 0
		 0 1.6512034452749658 -4.8500368722748162 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 1.8608428 -4.8500371 ;
	setAttr ".rs" 65016;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -8.0856093701113902 1.8608427927784412 -8.008548941833519 ;
	setAttr ".cbx" -type "double3" 8.0856093701113902 1.8608427927784412 -1.6915255557639837 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak2";
	rename -uid "7FB5F515-411F-223B-B580-B7B90D7D7AF4";
	setAttr ".uopa" yes;
	setAttr -s 8 ".tk[16:23]" -type "float3"  0 -2.17275047 0 0 -2.17275047
		 0 0 -2.17275047 0 0 -2.17275047 0 0 -2.17275047 0 0 -2.17275047 0 0 -2.17275047 0
		 0 -2.17275047 0;
createNode polyExtrudeFace -n "polyExtrudeFace3";
	rename -uid "7561C4B6-49EE-F191-E431-D78559CFB8A5";
	setAttr ".ics" -type "componentList" 2 "f[1]" "f[11]";
	setAttr ".ix" -type "matrix" 16.171219704102587 0 0 0 0 0.41927889493470766 0 0 0 0 6.3170233860695353 0
		 0 1.6512034452749658 -4.8500368722748162 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 7.2869716 -4.8500376 ;
	setAttr ".rs" 53915;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -8.0856084062315841 7.2869713788583033 -8.008548941833519 ;
	setAttr ".cbx" -type "double3" 8.0856084062315841 7.2869713788583033 -1.6915261205498862 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak3";
	rename -uid "8652891E-4969-A13E-78AF-FD8C7FDB1998";
	setAttr ".uopa" yes;
	setAttr -s 8 ".tk[24:31]" -type "float3"  0 12.9415741 0 0 12.9415741
		 0 0 12.9415741 0 0 12.9415741 0 0 12.9415741 0 0 12.9415741 0 0 12.9415741 0 0 12.9415741
		 0;
createNode polyTweak -n "polyTweak4";
	rename -uid "6A3E6B6F-4BA8-E1A7-EA5F-46BE529D1C00";
	setAttr ".uopa" yes;
	setAttr -s 8 ".tk[32:39]" -type "float3"  0 1.24316168 0 0 1.24316168
		 0 0 1.24316168 0 0 1.24316168 0 0 1.24316168 0 0 1.24316168 0 0 1.24316168 0 0 1.24316168
		 0;
createNode deleteComponent -n "deleteComponent1";
	rename -uid "D7484B0F-463C-3A99-1EC7-59828B19E979";
	setAttr ".dc" -type "componentList" 2 "f[31]" "f[34]";
createNode polyBridgeEdge -n "polyBridgeEdge1";
	rename -uid "9320B383-4EFD-0F47-6A8C-D5A8646A2C63";
	setAttr ".ics" -type "componentList" 5 "e[48]" "e[54]" "e[61]" "e[63:64]" "e[68:70]";
	setAttr ".ix" -type "matrix" 16.171219704102587 0 0 0 0 0.41927889493470766 0 0 0 0 6.3170233860695353 0
		 0 1.6512034452749658 -4.8500368722748162 1;
	setAttr ".c[0]"  0 1 1;
	setAttr ".dv" 0;
	setAttr ".sv1" 26;
	setAttr ".sv2" 29;
	setAttr ".sma" 59.999999999999993;
	setAttr ".d" 1;
createNode polyExtrudeFace -n "polyExtrudeFace4";
	rename -uid "B2FF0149-4B20-6090-C39C-939DE823569A";
	setAttr ".ics" -type "componentList" 2 "f[1]" "f[11]";
	setAttr ".ix" -type "matrix" 16.171219704102587 0 0 0 0 0.41927889493470766 0 0 0 0 6.3170233860695353 0
		 0 1.6512034452749658 -4.8500368722748162 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 7.8082027 -4.8500381 ;
	setAttr ".rs" 39394;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -8.0856064784719717 7.8082026336393042 -8.008548941833519 ;
	setAttr ".cbx" -type "double3" 8.0856064784719717 7.8082026336393042 -1.6915270618597233 ;
	setAttr ".raf" no;
createNode polyExtrudeFace -n "polyExtrudeFace5";
	rename -uid "2A10D425-4098-BBD7-DCC8-4FB047BF9818";
	setAttr ".ics" -type "componentList" 2 "f[1]" "f[11]";
	setAttr ".ix" -type "matrix" 16.171219704102587 0 0 0 0 0.41927889493470766 0 0 0 0 6.3170233860695353 0
		 0 1.6512034452749658 -4.8500368722748162 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 11.319386 -4.8500381 ;
	setAttr ".rs" 62694;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -8.0856055145921655 11.319385079280078 -8.008548941833519 ;
	setAttr ".cbx" -type "double3" 8.0856055145921655 11.319385079280078 -1.6915274383836585 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak5";
	rename -uid "B7E49D3A-4A2E-CFC9-C302-C7BB1C15AA9B";
	setAttr ".uopa" yes;
	setAttr -s 8 ".tk[40:47]" -type "float3"  0 8.3743372 0 0 8.3743372
		 0 0 8.3743372 0 0 8.3743372 0 0 8.3743372 0 0 8.3743372 0 0 8.3743372 0 0 8.3743372
		 0;
createNode polyTweak -n "polyTweak6";
	rename -uid "6E893B38-4305-FEA3-98C3-108168839A21";
	setAttr ".uopa" yes;
	setAttr -s 8 ".tk[48:55]" -type "float3"  0 1.32440436 0 0 1.32440436
		 0 0 1.32440436 0 0 1.32440436 0 0 1.32440436 0 0 1.32440436 0 0 1.32440436 0 0 1.32440436
		 0;
createNode deleteComponent -n "deleteComponent2";
	rename -uid "FC909F42-43FB-9DF6-8A82-30B800242734";
	setAttr ".dc" -type "componentList" 2 "f[49]" "f[52]";
createNode polyBridgeEdge -n "polyBridgeEdge2";
	rename -uid "0F4F89EE-45E5-842C-0304-AD8FEEB0575E";
	setAttr ".ics" -type "componentList" 5 "e[84]" "e[90]" "e[97]" "e[99:100]" "e[104:106]";
	setAttr ".ix" -type "matrix" 16.171219704102587 0 0 0 0 0.41927889493470766 0 0 0 0 6.3170233860695353 0
		 0 1.6512034452749658 -4.8500368722748162 1;
	setAttr ".c[0]"  0 1 1;
	setAttr ".dv" 0;
	setAttr ".sv1" 42;
	setAttr ".sv2" 45;
	setAttr ".sma" 59.999999999999993;
	setAttr ".d" 1;
createNode polySplit -n "polySplit3";
	rename -uid "24BF4C19-4790-4429-7F6B-61A9711BC8D3";
	setAttr -s 5 ".e[0:4]"  0.92587 0.92587 0.92587 0.92587 0.92587;
	setAttr -s 5 ".d[0:4]"  -2147483631 -2147483600 -2147483594 -2147483623 -2147483631;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit4";
	rename -uid "8E0293E4-4D81-6B8C-C9CE-8EA3C1360980";
	setAttr -s 5 ".e[0:4]"  0.92172098 0.92172098 0.92172098 0.92172098
		 0.92172098;
	setAttr -s 5 ".d[0:4]"  -2147483584 -2147483564 -2147483558 -2147483578 -2147483584;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode deleteComponent -n "deleteComponent3";
	rename -uid "00DBC29B-43CC-6456-9E3B-5DA9A0A2CC41";
	setAttr ".dc" -type "componentList" 2 "f[63]" "f[65]";
createNode polyBridgeEdge -n "polyBridgeEdge3";
	rename -uid "D95F25F0-42D1-4D67-3D77-0983B06FC4DC";
	setAttr ".ics" -type "componentList" 5 "e[77]" "e[112]" "e[124:127]" "e[129]" "e[131]";
	setAttr ".ix" -type "matrix" 16.171219704102587 0 0 0 0 0.41927889493470766 0 0 0 0 6.3170233860695353 0
		 0 1.6512034452749658 -4.8500368722748162 1;
	setAttr ".c[0]"  0 1 1;
	setAttr ".dv" 0;
	setAttr ".sv1" 37;
	setAttr ".sv2" 45;
	setAttr ".sma" 59.999999999999993;
	setAttr ".d" 1;
createNode deleteComponent -n "deleteComponent4";
	rename -uid "B3804D77-4844-852E-82AE-228206E6A16D";
	setAttr ".dc" -type "componentList" 2 "f[59]" "f[61]";
createNode polyBridgeEdge -n "polyBridgeEdge4";
	rename -uid "5C8A3E7D-497F-5CA8-74A7-8894526D605F";
	setAttr ".ics" -type "componentList" 5 "e[14]" "e[76]" "e[116:119]" "e[121]" "e[123]";
	setAttr ".ix" -type "matrix" 16.171219704102587 0 0 0 0 0.41927889493470766 0 0 0 0 6.3170233860695353 0
		 0 1.6512034452749658 -4.8500368722748162 1;
	setAttr ".c[0]"  0 1 1;
	setAttr ".dv" 0;
	setAttr ".sv1" 14;
	setAttr ".sv2" 29;
	setAttr ".sma" 59.999999999999993;
	setAttr ".d" 1;
createNode polySoftEdge -n "polySoftEdge1";
	rename -uid "5E70B639-4305-6ACD-29BB-778C2143F66D";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[*]";
	setAttr ".ix" -type "matrix" 16.171219704102587 0 0 0 0 0.41927889493470766 0 0 0 0 6.3170233860695353 0
		 0 1.6512034452749658 -4.8500368722748162 1;
	setAttr ".a" 180;
createNode polyCube -n "polyCube2";
	rename -uid "C08635E4-46D8-8D5B-52E3-6991C8734319";
	setAttr ".cuv" 4;
createNode polyExtrudeFace -n "polyExtrudeFace6";
	rename -uid "81A54FBF-49FF-8623-EB68-56973B2A65AB";
	setAttr ".ics" -type "componentList" 2 "f[0]" "f[2]";
	setAttr ".ix" -type "matrix" 7.3784951273418562 0 0 0 0 5.3246217130140669 0 0 0 0 0.18871880998666779 0
		 3.9167210139687532 4.5464997311381889 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 3.9167211 4.5464997 0 ;
	setAttr ".rs" 51073;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 0.22747345029782506 1.8841888746311555 -0.094359404993333895 ;
	setAttr ".cbx" -type "double3" 7.6059685776396808 7.2088105876452229 0.094359404993333895 ;
	setAttr ".raf" no;
createNode polySoftEdge -n "polySoftEdge2";
	rename -uid "8F6D2755-4DF6-8A43-CA1B-2E9A07329502";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[*]";
	setAttr ".ix" -type "matrix" 7.3784951273418562 0 0 0 0 5.3246217130140669 0 0 0 0 0.18871880998666779 0
		 3.9167210139687532 4.5464997311381889 0 1;
	setAttr ".a" 180;
createNode polyTweak -n "polyTweak7";
	rename -uid "3C9036F4-4E1B-CD4C-95CB-DFA53BFAFDA6";
	setAttr ".uopa" yes;
	setAttr -s 8 ".tk[8:15]" -type "float3"  0.11629462 0.11629462 -0.11629462
		 -0.11629463 0.11629462 -0.11629462 -0.11629463 -0.11629463 -0.11629462 0.11629462
		 -0.11629463 -0.11629462 0.11629462 -0.11629463 0.11629462 -0.11629463 -0.11629463
		 0.11629462 -0.11629463 0.11629462 0.11629462 0.11629462 0.11629462 0.11629462;
createNode polyExtrudeFace -n "polyExtrudeFace7";
	rename -uid "EF642CAD-48BA-3C62-CEC3-888307EF103D";
	setAttr ".ics" -type "componentList" 1 "f[4]";
	setAttr ".ix" -type "matrix" 7.3784951273418562 0 0 0 0 5.3246217130140669 0 0 0 0 0.18871880998666779 0
		 3.9167210139687532 4.5464997311381889 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 7.605969 4.5464997 0 ;
	setAttr ".rs" 35907;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 7.6059690174322618 1.8841888746311555 -0.094359404993333895 ;
	setAttr ".cbx" -type "double3" 7.6059690174322618 7.2088109050174083 0.094359404993333895 ;
	setAttr ".raf" no;
createNode polyExtrudeFace -n "polyExtrudeFace8";
	rename -uid "85F8F5C8-43C4-6A58-B718-5CB0AE61DC89";
	setAttr ".ics" -type "componentList" 1 "f[4]";
	setAttr ".ix" -type "matrix" 7.3784951273418562 0 0 0 0 5.3246217130140669 0 0 0 0 0.18871880998666779 0
		 3.9167210139687532 4.5464997311381889 0 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 7.6059699 4.5464997 0 ;
	setAttr ".rs" 36984;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 7.6059698970174239 3.0188103073593826 -0.094359404993333895 ;
	setAttr ".cbx" -type "double3" 7.6059698970174239 6.0741894722891807 0.094359404993333895 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak8";
	rename -uid "A2121848-42E3-2496-6957-54A22D64B143";
	setAttr ".uopa" yes;
	setAttr -s 4 ".tk[16:19]" -type "float3"  1.8626451e-09 0.21308957 0
		 1.8626451e-09 0.21308957 0 1.8626451e-09 -0.21308957 0 1.8626451e-09 -0.21308957
		 0;
createNode polySoftEdge -n "polySoftEdge3";
	rename -uid "A5D322D4-46AF-61E2-1BA8-88997762FAC3";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[*]";
	setAttr ".ix" -type "matrix" 7.3784951273418562 0 0 0 0 5.3246217130140669 0 0 0 0 0.18871880998666779 0
		 3.9167210139687532 4.5464997311381889 0 1;
	setAttr ".a" 180;
createNode polyTweak -n "polyTweak9";
	rename -uid "6B5DB1FE-407B-E89C-B448-6BB87B707619";
	setAttr ".uopa" yes;
	setAttr -s 4 ".tk[20:23]" -type "float3"  0.033359971 0 0 0.033359971
		 0 0 0.033359971 0 0 0.033359971 0 0;
createNode polyCube -n "polyCube3";
	rename -uid "4AC256F6-4122-5221-9766-A3A884516474";
	setAttr ".cuv" 4;
createNode deleteComponent -n "deleteComponent5";
	rename -uid "9BB2F8EC-4BB5-7F02-935C-C5BFA87780AD";
	setAttr ".dc" -type "componentList" 1 "f[2]";
createNode polyUnite -n "polyUnite1";
	rename -uid "7FA8FD22-4F5B-36C9-7D5F-E0978E216C8D";
	setAttr -s 2 ".ip";
	setAttr -s 2 ".im";
createNode groupId -n "groupId1";
	rename -uid "824D2DAE-41B8-F4BC-92BF-0F84CACFD3F2";
	setAttr ".ihi" 0;
createNode groupId -n "groupId2";
	rename -uid "E9DDB5A0-4F0D-6B65-1A7A-A28B26A4A1E4";
	setAttr ".ihi" 0;
createNode groupId -n "groupId3";
	rename -uid "ACB00610-498C-92F9-EED7-D2ADBB8AEA28";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts1";
	rename -uid "D33D7DD9-4F3A-AE3B-6B86-74BA4D13040F";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 1 "f[0:21]";
createNode groupId -n "groupId4";
	rename -uid "EF607A74-41C7-6A9C-716E-A5BCF6B39479";
	setAttr ".ihi" 0;
createNode groupId -n "groupId5";
	rename -uid "8BDA68A0-4688-F739-A11A-D795434EDC27";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts2";
	rename -uid "6185640E-4062-4948-534C-44895DAC1E06";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 1 "f[0:26]";
createNode groupId -n "groupId6";
	rename -uid "890506B4-4D9E-50D0-C894-E195E1B55D4D";
	setAttr ".ihi" 0;
createNode polyUnite -n "polyUnite2";
	rename -uid "D6585362-4D77-82C6-77D4-0BADA58EB70E";
	setAttr -s 2 ".ip";
	setAttr -s 2 ".im";
createNode groupId -n "groupId7";
	rename -uid "93C45E98-4860-7AA1-EED3-C899B32ECEA7";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts3";
	rename -uid "3F7C2C07-4335-C6B0-3F29-279B8D96E9A2";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 1 "f[0:4]";
createNode groupId -n "groupId8";
	rename -uid "A800606E-45D5-2B28-F0F6-F49877647FFC";
	setAttr ".ihi" 0;
createNode groupId -n "groupId9";
	rename -uid "FF28E787-435A-4F33-C5FE-F98FC207475D";
	setAttr ".ihi" 0;
createNode groupId -n "groupId10";
	rename -uid "552277FE-4ABC-97D7-8617-EEBBDF4581AA";
	setAttr ".ihi" 0;
createNode groupId -n "groupId11";
	rename -uid "F50C636F-495A-7F8D-F8F0-FBB535C2465D";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts4";
	rename -uid "87997B60-4A69-32A7-D0BD-858E77F3FD3E";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 1 "f[0:26]";
createNode groupId -n "groupId12";
	rename -uid "6BDDAD05-4BA6-84EA-5C7A-959190ADA539";
	setAttr ".ihi" 0;
createNode polySoftEdge -n "polySoftEdge4";
	rename -uid "EB4FABC6-4708-4F16-5099-558BA9B3BB4D";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[*]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".a" 180;
createNode polySoftEdge -n "polySoftEdge5";
	rename -uid "26C57891-4943-1C20-0E95-17B2DB2D4BD8";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[*]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".a" 180;
createNode polyCube -n "polyCube4";
	rename -uid "2682D743-49D2-857D-CE81-3CA668081E24";
	setAttr ".cuv" 4;
createNode polyExtrudeFace -n "polyExtrudeFace9";
	rename -uid "65307A2F-4691-91BD-2F87-D697638EE682";
	setAttr ".ics" -type "componentList" 1 "f[1]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 2.4533067 -4.7349195 ;
	setAttr ".rs" 41927;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -10.45945116725518 2.4533067601044705 -9.1755771195060767 ;
	setAttr ".cbx" -type "double3" 10.45945116725518 2.4533067601044705 -0.29426183158227648 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak10";
	rename -uid "51A69338-4A2E-3B86-A1B8-EA964623CE5C";
	setAttr ".uopa" yes;
	setAttr -s 4 ".tk[2:5]" -type "float3"  0.019855915 0 -0.019855915
		 -0.019855915 0 -0.019855915 0.019855915 0 0.019855915 -0.019855915 0 0.019855915;
createNode polyExtrudeFace -n "polyExtrudeFace10";
	rename -uid "8DFB2C45-4C65-55BA-C3A6-12BF3FFDD408";
	setAttr ".ics" -type "componentList" 1 "f[1]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 2.7067757 -4.73492 ;
	setAttr ".rs" 48707;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -10.459451816468503 2.7067756312211086 -9.1755776707652288 ;
	setAttr ".cbx" -type "double3" 10.459451816468503 2.7067756312211086 -0.29426210721185342 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak11";
	rename -uid "D5703830-442E-79CA-28C7-08BFBC63B344";
	setAttr ".uopa" yes;
	setAttr -s 4 ".tk[8:11]" -type "float3"  0 0.25346899 0 0 0.25346899
		 0 0 0.25346899 0 0 0.25346899 0;
createNode polyExtrudeFace -n "polyExtrudeFace11";
	rename -uid "9591F439-4791-3C42-70F7-6CAFA78A04DF";
	setAttr ".ics" -type "componentList" 1 "f[1]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 2.9239755 -4.7349205 ;
	setAttr ".rs" 47227;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -11.024787426837205 2.9239754336197903 -9.4155970090885788 ;
	setAttr ".cbx" -type "double3" 11.024787426837205 2.9239754336197903 -0.054244147036391688 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak12";
	rename -uid "F9180230-4DF3-8464-05B2-9EABE8C9811D";
	setAttr ".uopa" yes;
	setAttr -s 4 ".tk[12:15]" -type "float3"  -0.025951849 0.21719977 0.025951851
		 0.025951849 0.21719977 0.025951851 0.025951849 0.21719977 -0.025951851 -0.025951849
		 0.21719977 -0.025951851;
createNode polyExtrudeFace -n "polyExtrudeFace12";
	rename -uid "51A784E1-48A0-06A8-930B-14B235C032B3";
	setAttr ".ics" -type "componentList" 1 "f[1]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 4.5869288 -4.734921 ;
	setAttr ".rs" 35560;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -11.024787426837205 4.5869289295990994 -9.4155981116068865 ;
	setAttr ".cbx" -type "double3" 11.024787426837205 4.5869289295990994 -0.054244147036391688 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak13";
	rename -uid "F932B67F-4606-848B-9350-51B46A68071B";
	setAttr ".uopa" yes;
	setAttr -s 4 ".tk[16:19]" -type "float3"  0 1.66295362 0 0 1.66295362
		 0 0 1.66295362 0 0 1.66295362 0;
createNode polySplit -n "polySplit5";
	rename -uid "23BA1A65-4732-6966-1739-ADAA85DFD00D";
	setAttr -s 13 ".e[0:12]"  0.92556602 0.92556602 0.92556602 0.92556602
		 0.92556602 0.92556602 0.92556602 0.92556602 0.92556602 0.92556602 0.92556602 0.92556602
		 0.92556602;
	setAttr -s 13 ".d[0:12]"  -2147483648 -2147483647 -2147483634 -2147483626 -2147483618 -2147483610 
		-2147483606 -2147483614 -2147483622 -2147483630 -2147483646 -2147483645 -2147483648;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyTweak -n "polyTweak14";
	rename -uid "EB4D3312-4FF3-83B4-DAA0-CABF2FB043B1";
	setAttr ".uopa" yes;
	setAttr -s 4 ".tk[20:23]" -type "float3"  0.0015232689 0.28869745 -0.0015232691
		 -0.0015232689 0.28869745 -0.0015232691 -0.0015232689 0.28869745 0.0015232691 0.0015232689
		 0.28869745 0.0015232691;
createNode polySplit -n "polySplit6";
	rename -uid "A745A861-4674-3E4E-973C-60B0A6AC8D4B";
	setAttr -s 13 ".e[0:12]"  0.10294 0.10294 0.10294 0.10294 0.10294 0.10294
		 0.10294 0.10294 0.10294 0.10294 0.10294 0.10294 0.10294;
	setAttr -s 13 ".d[0:12]"  -2147483648 -2147483647 -2147483634 -2147483626 -2147483618 -2147483610 
		-2147483606 -2147483614 -2147483622 -2147483630 -2147483646 -2147483645 -2147483648;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit7";
	rename -uid "23DBFEC7-4A3E-C46B-488F-389D34639E82";
	setAttr -s 17 ".e[0:16]"  0.928581 0.071419202 0.071419202 0.071419202
		 0.071419202 0.928581 0.928581 0.928581 0.928581 0.928581 0.928581 0.928581 0.928581
		 0.928581 0.928581 0.928581 0.928581;
	setAttr -s 17 ".d[0:16]"  -2147483642 -2147483638 -2147483557 -2147483581 -2147483637 -2147483641 
		-2147483632 -2147483624 -2147483616 -2147483608 -2147483587 -2147483563 -2147483605 -2147483613 -2147483621 -2147483629 -2147483642;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyExtrudeFace -n "polyExtrudeFace13";
	rename -uid "CA0E901E-441E-9363-996A-B18EDED00A8C";
	setAttr ".ics" -type "componentList" 3 "f[1]" "f[27]" "f[55:57]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 4.8756266 -4.734921 ;
	setAttr ".rs" 57527;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -10.991604835502141 4.8756264107544949 -9.401510132658256 ;
	setAttr ".cbx" -type "double3" 10.991604835502141 4.8756264107544949 -0.068332125985022252 ;
	setAttr ".raf" no;
createNode polyExtrudeFace -n "polyExtrudeFace14";
	rename -uid "B44213DD-4D36-2FC0-EACA-9888904A4F2B";
	setAttr ".ics" -type "componentList" 3 "f[1]" "f[27]" "f[55:57]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 9.2654696 -4.7349219 ;
	setAttr ".rs" 43115;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -10.991604835502141 9.2654696362336217 -9.4015112351765637 ;
	setAttr ".cbx" -type "double3" 10.991604835502141 9.2654696362336217 -0.068332677244176132 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak15";
	rename -uid "30960BD6-4589-1AF3-B753-0082C3FDF730";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[64:75]" -type "float3"  0 4.38984299 0 0 4.38984299
		 0 0 4.38984299 0 0 4.38984299 0 0 4.38984299 0 0 4.38984299 0 0 4.38984299 0 0 4.38984299
		 0 0 4.38984299 0 0 4.38984299 0 0 4.38984299 0 0 4.38984299 0;
createNode polyExtrudeFace -n "polyExtrudeFace15";
	rename -uid "9E93E6F8-4D52-D61A-107A-058585B5F088";
	setAttr ".ics" -type "componentList" 3 "f[1]" "f[27]" "f[55:57]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 9.854001 -4.7349224 ;
	setAttr ".rs" 46112;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -10.991604835502141 9.8540011303742467 -9.4015123376948733 ;
	setAttr ".cbx" -type "double3" 10.991604835502141 9.8540011303742467 -0.068332677244176132 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak16";
	rename -uid "968A0B51-40DF-7E4B-8B88-9DBE753B5AF7";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[76:87]" -type "float3"  0 0.58853137 0 0 0.58853137
		 0 0 0.58853137 0 0 0.58853137 0 0 0.58853137 0 0 0.58853137 0 0 0.58853137 0 0 0.58853137
		 0 0 0.58853137 0 0 0.58853137 0 0 0.58853137 0 0 0.58853137 0;
createNode polyExtrudeFace -n "polyExtrudeFace16";
	rename -uid "1EA10214-40F5-2221-F483-9DBA235A98BC";
	setAttr ".ics" -type "componentList" 3 "f[1]" "f[27]" "f[55:57]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 14.462322 -4.7349224 ;
	setAttr ".rs" 44993;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -10.991604835502141 14.46232184341746 -9.4015123376948733 ;
	setAttr ".cbx" -type "double3" 10.991604835502141 14.46232184341746 -0.068332677244176132 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak17";
	rename -uid "19407795-425C-93E0-218A-4D8564F764DF";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[88:99]" -type "float3"  0 4.60832071 0 0 4.60832071
		 0 0 4.60832071 0 0 4.60832071 0 0 4.60832071 0 0 4.60832071 0 0 4.60832071 0 0 4.60832071
		 0 0 4.60832071 0 0 4.60832071 0 0 4.60832071 0 0 4.60832071 0;
createNode polyExtrudeFace -n "polyExtrudeFace17";
	rename -uid "7BD63D46-468C-1781-0E15-1A82A084A657";
	setAttr ".ics" -type "componentList" 3 "f[1]" "f[27]" "f[55:57]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 14.880103 -4.7349224 ;
	setAttr ".rs" 43764;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -10.991604835502141 14.880102719577128 -9.4015123376948733 ;
	setAttr ".cbx" -type "double3" 10.991604835502141 14.880102719577128 -0.068332677244176132 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak18";
	rename -uid "A193522F-470E-B942-4BE4-2A86CD9ACDE4";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[100:111]" -type "float3"  0 0.41778067 0 0 0.41778067
		 0 0 0.41778067 0 0 0.41778067 0 0 0.41778067 0 0 0.41778067 0 0 0.41778067 0 0 0.41778067
		 0 0 0.41778067 0 0 0.41778067 0 0 0.41778067 0 0 0.41778067 0;
createNode polyExtrudeFace -n "polyExtrudeFace18";
	rename -uid "8C8D6996-492B-AF2D-2D19-3EB28AD58F99";
	setAttr ".ics" -type "componentList" 3 "f[1]" "f[27]" "f[55:57]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 19.458956 -4.7349224 ;
	setAttr ".rs" 58095;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -10.991604835502141 19.458956326754862 -9.4015123376948733 ;
	setAttr ".cbx" -type "double3" 10.991604835502141 19.458956326754862 -0.068332677244176132 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak19";
	rename -uid "CC0958EB-4D79-EABC-8910-48B4056BE2D3";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[112:123]" -type "float3"  0 4.57885361 0 0 4.57885361
		 0 0 4.57885361 0 0 4.57885361 0 0 4.57885361 0 0 4.57885361 0 0 4.57885361 0 0 4.57885361
		 0 0 4.57885361 0 0 4.57885361 0 0 4.57885361 0 0 4.57885361 0;
createNode polyExtrudeFace -n "polyExtrudeFace19";
	rename -uid "442E8901-4FE1-A278-BD37-1B9A718F7ED3";
	setAttr ".ics" -type "componentList" 3 "f[1]" "f[27]" "f[55:57]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 20.071569 -4.7349224 ;
	setAttr ".rs" 58845;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -10.991604835502141 20.071570004733378 -9.4015123376948733 ;
	setAttr ".cbx" -type "double3" 10.991604835502141 20.071570004733378 -0.068332677244176132 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak20";
	rename -uid "96F1A020-4442-F4F4-1CEC-648FA48F2656";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[124:135]" -type "float3"  0 0.61261433 0 0 0.61261433
		 0 0 0.61261433 0 0 0.61261433 0 0 0.61261433 0 0 0.61261433 0 0 0.61261433 0 0 0.61261433
		 0 0 0.61261433 0 0 0.61261433 0 0 0.61261433 0 0 0.61261433 0;
createNode polyExtrudeFace -n "polyExtrudeFace20";
	rename -uid "B181686A-4329-32A6-30A3-7093464846C6";
	setAttr ".ics" -type "componentList" 3 "f[1]" "f[27]" "f[55:57]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 24.351631 -4.7349224 ;
	setAttr ".rs" 61588;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -10.991604835502141 24.351631726535135 -9.4015123376948733 ;
	setAttr ".cbx" -type "double3" 10.991604835502141 24.351631726535135 -0.068332677244176132 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak21";
	rename -uid "A1D791C9-4A43-A9B9-02C7-75ABCAE5C893";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[136:147]" -type "float3"  0 4.28006124 0 0 4.28006124
		 0 0 4.28006124 0 0 4.28006124 0 0 4.28006124 0 0 4.28006124 0 0 4.28006124 0 0 4.28006124
		 0 0 4.28006124 0 0 4.28006124 0 0 4.28006124 0 0 4.28006124 0;
createNode polyExtrudeFace -n "polyExtrudeFace21";
	rename -uid "64491DD9-48BB-942A-CE44-2799434185FE";
	setAttr ".ics" -type "componentList" 3 "f[1]" "f[27]" "f[55:57]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 24.894209 -4.7349224 ;
	setAttr ".rs" 49037;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -10.991604835502141 24.894209470065409 -9.4015123376948733 ;
	setAttr ".cbx" -type "double3" 10.991604835502141 24.894209470065409 -0.068332677244176132 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak22";
	rename -uid "C8BFDF27-48A9-831C-581F-7E8DD34BE211";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[148:159]" -type "float3"  0 0.54257685 0 0 0.54257685
		 0 0 0.54257685 0 0 0.54257685 0 0 0.54257685 0 0 0.54257685 0 0 0.54257685 0 0 0.54257685
		 0 0 0.54257685 0 0 0.54257685 0 0 0.54257685 0 0 0.54257685 0;
createNode polyExtrudeFace -n "polyExtrudeFace22";
	rename -uid "C64C1970-48D9-B996-7852-29B6B7F412EE";
	setAttr ".ics" -type "componentList" 3 "f[1]" "f[27]" "f[55:57]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 28.279394 -4.7349224 ;
	setAttr ".rs" 43427;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -10.991604835502141 28.279394711764628 -9.4015123376948733 ;
	setAttr ".cbx" -type "double3" 10.991604835502141 28.279394711764628 -0.068332677244176132 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak23";
	rename -uid "EAC6AC5D-447B-3513-118C-9A8C41BC0305";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[160:171]" -type "float3"  0 3.38518476 0 0 3.38518476
		 0 0 3.38518476 0 0 3.38518476 0 0 3.38518476 0 0 3.38518476 0 0 3.38518476 0 0 3.38518476
		 0 0 3.38518476 0 0 3.38518476 0 0 3.38518476 0 0 3.38518476 0;
createNode polyExtrudeFace -n "polyExtrudeFace23";
	rename -uid "7B89689B-4E31-D07D-0861-F3BB3C1E6A28";
	setAttr ".ics" -type "componentList" 3 "f[1]" "f[27]" "f[55:57]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 28.820421 -4.7349224 ;
	setAttr ".rs" 46789;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -10.991604835502141 28.820421780856424 -9.4015123376948733 ;
	setAttr ".cbx" -type "double3" 10.991604835502141 28.820421780856424 -0.068332677244176132 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak24";
	rename -uid "BE71DCC3-4A90-BEC6-26B5-1F9C592CDC88";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[172:183]" -type "float3"  0 0.54102641 0 0 0.54102641
		 0 0 0.54102641 0 0 0.54102641 0 0 0.54102641 0 0 0.54102641 0 0 0.54102641 0 0 0.54102641
		 0 0 0.54102641 0 0 0.54102641 0 0 0.54102641 0 0 0.54102641 0;
createNode polyExtrudeFace -n "polyExtrudeFace24";
	rename -uid "79D5848A-4E1E-FCD2-BA6E-148E960D1FA2";
	setAttr ".ics" -type "componentList" 3 "f[1]" "f[27]" "f[55:57]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 31.859209 -4.7349224 ;
	setAttr ".rs" 57769;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -10.991604835502141 31.859209622653299 -9.4015123376948733 ;
	setAttr ".cbx" -type "double3" 10.991604835502141 31.859209622653299 -0.068332677244176132 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak25";
	rename -uid "A3685BB4-4B6A-BCC3-CF3A-0D89DA51BAC2";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[184:195]" -type "float3"  0 3.038787127 0 0 3.038787127
		 0 0 3.038787127 0 0 3.038787127 0 0 3.038787127 0 0 3.038787127 0 0 3.038787127 0
		 0 3.038787127 0 0 3.038787127 0 0 3.038787127 0 0 3.038787127 0 0 3.038787127 0;
createNode polyTweak -n "polyTweak26";
	rename -uid "BECE9DE5-464F-7FFA-C824-C9BF834BF9C2";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[196:207]" -type "float3"  0 0.87710381 0 0 0.87710381
		 0 0 0.87710381 0 0 0.87710381 0 0 0.87710381 0 0 0.87710381 0 0 0.87710381 0 0 0.87710381
		 0 0 0.87710381 0 0 0.87710381 0 0 0.87710381 0 0 0.87710381 0;
createNode deleteComponent -n "deleteComponent6";
	rename -uid "6215E960-418A-D647-4A94-CCA339DFB9DA";
	setAttr ".dc" -type "componentList" 2 "f[195]" "f[197]";
createNode polyBridgeEdge -n "polyBridgeEdge5";
	rename -uid "33E6B1CB-4789-5BE3-B94E-AE8DA41CF704";
	setAttr ".ics" -type "componentList" 6 "e[364]" "e[370]" "e[385]" "e[387:388]" "e[393]" "e[395:396]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".c[0]"  0 1 1;
	setAttr ".dv" 0;
	setAttr ".sv1" 186;
	setAttr ".sv2" 189;
	setAttr ".sma" 59.999999999999993;
	setAttr ".d" 1;
createNode polyExtrudeFace -n "polyExtrudeFace25";
	rename -uid "C6F1D243-4805-1BE6-090E-40A6E521D6C9";
	setAttr ".ics" -type "componentList" 4 "f[1]" "f[27]" "f[55:57]" "f[205]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 32.736313 -4.7349224 ;
	setAttr ".rs" 45688;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -10.991604835502141 32.736313428195288 -9.4015123376948733 ;
	setAttr ".cbx" -type "double3" 10.991604835502141 32.736313428195288 -0.068332677244176132 ;
	setAttr ".raf" no;
createNode polyExtrudeFace -n "polyExtrudeFace26";
	rename -uid "67E61A40-4B40-BE9A-A898-2AA8FF702D12";
	setAttr ".ics" -type "componentList" 4 "f[1]" "f[27]" "f[55:57]" "f[205]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 33.050087 -4.7349224 ;
	setAttr ".rs" 56350;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -10.991604835502141 33.050085629733374 -9.4015123376948733 ;
	setAttr ".cbx" -type "double3" 10.991604835502141 33.050085629733374 -0.068332677244176132 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak27";
	rename -uid "9669F16C-406B-CD79-BF39-5A97F74C8268";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[208:219]" -type "float3"  0 0.31377149 0 0 0.31377149
		 0 0 0.31377149 0 0 0.31377149 0 0 0.31377149 0 0 0.31377149 0 0 0.31377149 0 0 0.31377149
		 0 0 0.31377149 0 0 0.31377149 0 0 0.31377149 0 0 0.31377149 0;
createNode polyExtrudeFace -n "polyExtrudeFace27";
	rename -uid "2AE4695F-4196-1A56-4937-83914FC4658F";
	setAttr ".ics" -type "componentList" 4 "f[1]" "f[27]" "f[55:57]" "f[205]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 33.409321 -4.7349224 ;
	setAttr ".rs" 48558;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -10.172935150102239 33.409321393283179 -9.0539382039137131 ;
	setAttr ".cbx" -type "double3" 10.172935150102239 33.409321393283179 -0.41590681102533722 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak28";
	rename -uid "7E86074A-4C46-9666-8B8D-48963100B11D";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[220:231]" -type "float3"  0.03758128 0.35923401 -0.037581284
		 0.030419964 0.35923401 -0.037581284 0.030419964 0.35923401 0.032213256 0.03758128
		 0.35923401 0.032213256 -0.03758128 0.35923401 0.032213256 -0.031986628 0.35923401
		 0.032213256 -0.031986628 0.35923401 -0.037581284 -0.03758128 0.35923401 -0.037581284
		 -0.031986628 0.35923401 0.037581284 -0.03758128 0.35923401 0.037581284 0.030419964
		 0.35923401 0.037581284 0.03758128 0.35923401 0.037581284;
createNode polyExtrudeFace -n "polyExtrudeFace28";
	rename -uid "DF79624C-430D-452B-8BA4-D5870B97AA99";
	setAttr ".ics" -type "componentList" 4 "f[1]" "f[27]" "f[55:57]" "f[205]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 33.680958 -4.7349229 ;
	setAttr ".rs" 53631;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -10.172935150102239 33.680958356173804 -9.0539384795432909 ;
	setAttr ".cbx" -type "double3" 10.172935150102239 33.680958356173804 -0.41590708665491416 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak29";
	rename -uid "FB6161AB-4358-E258-476A-05AA5DC54182";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[232:243]" -type "float3"  0 0.27163655 0 0 0.27163655
		 0 0 0.27163655 0 0 0.27163655 0 0 0.27163655 0 0 0.27163655 0 0 0.27163655 0 0 0.27163655
		 0 0 0.27163655 0 0 0.27163655 0 0 0.27163655 0 0 0.27163655 0;
createNode polyExtrudeFace -n "polyExtrudeFace29";
	rename -uid "F0474EA9-4357-40C8-2C64-ABB24435DC4F";
	setAttr ".ics" -type "componentList" 4 "f[1]" "f[27]" "f[55:57]" "f[205]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 34.257343 -4.7349234 ;
	setAttr ".rs" 35003;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -11.851703419858371 34.257341946872046 -9.7666763242026882 ;
	setAttr ".cbx" -type "double3" 11.851703419858371 34.257341946872046 0.29682965548617446 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak30";
	rename -uid "9105D383-4190-1150-675B-42B622648733";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[244:255]" -type "float3"  -0.077064335 0.57638431 0.07706435
		 -0.062379271 0.57638431 0.07706435 -0.062379271 0.57638431 -0.066056639 -0.077064335
		 0.57638431 -0.066056639 0.077064335 0.57638431 -0.066056639 0.065591902 0.57638431
		 -0.066056639 0.065591902 0.57638431 0.07706435 0.077064335 0.57638431 0.07706435
		 0.065591902 0.57638431 -0.07706435 0.077064335 0.57638431 -0.07706435 -0.062379271
		 0.57638431 -0.07706435 -0.077064335 0.57638431 -0.07706435;
createNode polyExtrudeFace -n "polyExtrudeFace30";
	rename -uid "A1B2FA2B-43B3-A3DC-7630-DE8181D3B0C1";
	setAttr ".ics" -type "componentList" 4 "f[1]" "f[27]" "f[55:57]" "f[205]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 35.825855 -4.7349234 ;
	setAttr ".rs" 52838;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -11.851703419858371 35.825853909762671 -9.7666763242026882 ;
	setAttr ".cbx" -type "double3" 11.851703419858371 35.825853909762671 0.29682965548617446 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak31";
	rename -uid "89CA78D9-4E8E-A72B-A597-C99AEC31D485";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[256:267]" -type "float3"  0 1.56851256 0 0 1.56851256
		 0 0 1.56851256 0 0 1.56851256 0 0 1.56851256 0 0 1.56851256 0 0 1.56851256 0 0 1.56851256
		 0 0 1.56851256 0 0 1.56851256 0 0 1.56851256 0 0 1.56851256 0;
createNode polySoftEdge -n "polySoftEdge6";
	rename -uid "965BC5C3-44DD-5A0B-93B1-D4BC359C7C37";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[*]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".a" 180;
createNode polyTweak -n "polyTweak32";
	rename -uid "33006F41-449E-1BA9-F4E6-2DA0A7DC698C";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[268:279]" -type "float3"  0.030750273 0.73177266 -0.030750282
		 0.024890641 0.73177266 -0.030750282 0.024890641 0.73177266 0.026357984 0.030750273
		 0.73177266 0.026357984 -0.030750273 0.73177266 0.026357984 -0.026172545 0.73177266
		 0.026357984 -0.026172545 0.73177266 -0.030750282 -0.030750273 0.73177266 -0.030750282
		 -0.026172545 0.73177266 0.030750282 -0.030750273 0.73177266 0.030750282 0.024890641
		 0.73177266 0.030750282 0.030750273 0.73177266 0.030750282;
createNode deleteComponent -n "deleteComponent7";
	rename -uid "5D5C3B0A-4ABF-F4D3-A8CC-948475993528";
	setAttr ".dc" -type "componentList" 2 "f[171]" "f[173]";
createNode polyBridgeEdge -n "polyBridgeEdge6";
	rename -uid "86F9B450-4E08-ED1C-7D16-79B715687CA7";
	setAttr ".ics" -type "componentList" 5 "e[316]" "e[322]" "e[337]" "e[339:340]" "e[344:346]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".c[0]"  0 1 1;
	setAttr ".dv" 0;
	setAttr ".sv1" 162;
	setAttr ".sv2" 165;
	setAttr ".sma" 59.999999999999993;
	setAttr ".d" 1;
createNode deleteComponent -n "deleteComponent8";
	rename -uid "29632664-4CC8-2530-C7FF-459F3F52726B";
	setAttr ".dc" -type "componentList" 2 "f[147]" "f[149]";
createNode polyBridgeEdge -n "polyBridgeEdge7";
	rename -uid "1B14775D-41AA-C348-52E2-D081B7213743";
	setAttr ".ics" -type "componentList" 5 "e[268]" "e[274]" "e[289]" "e[291:292]" "e[296:298]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".c[0]"  0 1 1;
	setAttr ".dv" 0;
	setAttr ".sv1" 138;
	setAttr ".sv2" 141;
	setAttr ".sma" 59.999999999999993;
	setAttr ".d" 1;
createNode deleteComponent -n "deleteComponent9";
	rename -uid "CE3258AB-4E14-E100-ED14-4190A8D24138";
	setAttr ".dc" -type "componentList" 2 "f[123]" "f[125]";
createNode polyBridgeEdge -n "polyBridgeEdge8";
	rename -uid "4E9240EC-4A2F-1483-C32B-7C89E02A7AD9";
	setAttr ".ics" -type "componentList" 5 "e[220]" "e[226]" "e[241]" "e[243:244]" "e[248:250]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".c[0]"  0 1 1;
	setAttr ".dv" 0;
	setAttr ".sv1" 114;
	setAttr ".sv2" 117;
	setAttr ".sma" 59.999999999999993;
	setAttr ".d" 1;
createNode deleteComponent -n "deleteComponent10";
	rename -uid "DE90625F-42FF-7003-9E62-B3B3E848918E";
	setAttr ".dc" -type "componentList" 2 "f[99]" "f[101]";
createNode polyBridgeEdge -n "polyBridgeEdge9";
	rename -uid "3693F1E3-48E8-32BF-0709-BA852FA551CE";
	setAttr ".ics" -type "componentList" 5 "e[172]" "e[178]" "e[193]" "e[195:196]" "e[200:202]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".c[0]"  0 1 1;
	setAttr ".dv" 0;
	setAttr ".sv1" 90;
	setAttr ".sv2" 93;
	setAttr ".sma" 59.999999999999993;
	setAttr ".d" 1;
createNode deleteComponent -n "deleteComponent11";
	rename -uid "C964C01F-4026-EAB2-18FF-5CB96311DEC3";
	setAttr ".dc" -type "componentList" 2 "f[75]" "f[77]";
createNode polyBridgeEdge -n "polyBridgeEdge10";
	rename -uid "5CBDD05F-4925-2147-BF44-89A02A43D3F7";
	setAttr ".ics" -type "componentList" 5 "e[124]" "e[130]" "e[145]" "e[147:148]" "e[152:154]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".c[0]"  0 1 1;
	setAttr ".dv" 0;
	setAttr ".sv1" 66;
	setAttr ".sv2" 69;
	setAttr ".sma" 59.999999999999993;
	setAttr ".d" 1;
createNode polySoftEdge -n "polySoftEdge7";
	rename -uid "93B37A0C-4248-5965-9A44-D2AE3447883B";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[*]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".a" 180;
createNode polySoftEdge -n "polySoftEdge8";
	rename -uid "81EE5F87-4D81-8170-1157-789026B3F868";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[*]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
createNode polySoftEdge -n "polySoftEdge9";
	rename -uid "53C0A317-4345-5CEE-87D5-A6B884E519FF";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[*]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".a" 180;
createNode polyCube -n "polyCube5";
	rename -uid "5DF1F49E-4728-092D-9D45-60AC65E649BA";
	setAttr ".cuv" 4;
createNode polySplit -n "polySplit8";
	rename -uid "B68AD818-49A1-2D10-C9C8-1EB57FF8A39B";
	setAttr -s 5 ".e[0:4]"  0.5 0.5 0.5 0.5 0.5;
	setAttr -s 5 ".d[0:4]"  -2147483644 -2147483640 -2147483639 -2147483643 -2147483644;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyTweak -n "polyTweak33";
	rename -uid "7DE24A62-4CF6-CFDB-FF65-0EA3834C7A8F";
	setAttr ".uopa" yes;
	setAttr -s 4 ".tk";
	setAttr ".tk[1]" -type "float3" 0.11743373 0 0 ;
	setAttr ".tk[3]" -type "float3" 0.11743373 0 0 ;
	setAttr ".tk[5]" -type "float3" 0.11743373 0 0 ;
	setAttr ".tk[7]" -type "float3" 0.11743373 0 0 ;
createNode polySplit -n "polySplit9";
	rename -uid "2E9A6465-41A5-742B-0EEC-889AE711F1A9";
	setAttr -s 5 ".e[0:4]"  0.5 0.5 0.5 0.5 0.5;
	setAttr -s 5 ".d[0:4]"  -2147483640 -2147483636 -2147483633 -2147483639 -2147483640;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit10";
	rename -uid "9AF47164-489F-393B-F801-3A86F070E562";
	setAttr -s 5 ".e[0:4]"  0.5 0.5 0.5 0.5 0.5;
	setAttr -s 5 ".d[0:4]"  -2147483644 -2147483635 -2147483634 -2147483643 -2147483644;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyExtrudeFace -n "polyExtrudeFace31";
	rename -uid "D621D8A2-43CA-DD57-E253-ECACBE5D6FB3";
	setAttr ".ics" -type "componentList" 2 "f[12]" "f[16]";
	setAttr ".ix" -type "matrix" 9.2489248801951298 0 0 0 0 29.874130098051833 0 0 0 0 1 0
		 4.6041324069896836 17.93573702162417 1.0027408375285827 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 10.314731 17.935738 1.0027409 ;
	setAttr ".rs" 57844;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 10.314730564546815 10.467204497111211 0.50274083752858267 ;
	setAttr ".cbx" -type "double3" 10.314730564546815 25.40426954613713 1.5027408375285827 ;
	setAttr ".raf" no;
createNode polyExtrudeFace -n "polyExtrudeFace32";
	rename -uid "7ACEBF4F-4DF5-5D99-7756-C1845DB34BED";
	setAttr ".ics" -type "componentList" 2 "f[12]" "f[16]";
	setAttr ".ix" -type "matrix" 9.2489248801951298 0 0 0 0 29.874130098051833 0 0 0 0 1 0
		 4.6041324069896836 17.93573702162417 1.0027408375285827 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 10.638403 17.935738 1.0027409 ;
	setAttr ".rs" 63992;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" 10.638402934557964 10.467204497111211 0.70115221281277762 ;
	setAttr ".cbx" -type "double3" 10.638402934557964 25.40426954613713 1.3043294324420653 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak34";
	rename -uid "8209FAF8-4BEB-C1AD-4371-AABECB4B54E6";
	setAttr ".uopa" yes;
	setAttr -s 6 ".tk[20:25]" -type "float3"  0.034995716 0 0.19841138 0.034995716
		 0 -0.19841141 0.034995716 0 0.19841138 0.034995716 0 -0.19841141 0.034995716 0 0.19841138
		 0.034995716 0 -0.19841141;
createNode polySoftEdge -n "polySoftEdge10";
	rename -uid "D4CD56F2-4783-0E09-75C2-8299384C8924";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[*]";
	setAttr ".ix" -type "matrix" 9.2489248801951298 0 0 0 0 29.874130098051833 0 0 0 0 1 0
		 4.6041324069896836 17.93573702162417 0.4992509045301281 1;
	setAttr ".a" 180;
createNode polyTweak -n "polyTweak35";
	rename -uid "71B492FB-48DA-5DC4-581C-31896A8E05C9";
	setAttr ".uopa" yes;
	setAttr -s 6 ".tk[26:31]" -type "float3"  0.036204871 0 0 0.036204871
		 0 0 0.036204871 0 0 0.036204871 0 0 0.036204871 0 0 0.036204871 0 0;
createNode polyCylinder -n "polyCylinder1";
	rename -uid "2B5F5769-4E0F-0B04-BE6F-4EB16701D037";
	setAttr ".sa" 11;
	setAttr ".sc" 1;
	setAttr ".cuv" 3;
createNode polyExtrudeFace -n "polyExtrudeFace33";
	rename -uid "A4D7FDF2-4DBA-9488-3120-60909073A114";
	setAttr ".ics" -type "componentList" 1 "f[22:32]";
	setAttr ".ix" -type "matrix" 4.8682659656529106 0 0 0 0 4.8682659656529106 0 0 0 0 4.8682659656529106 0
		 0 5.7373604581058171 11.877381640567668 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0.098599322 10.605626 11.877381 ;
	setAttr ".rs" 51902;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -6.9267362665709111 10.605626423758729 4.7798070425788293 ;
	setAttr ".cbx" -type "double3" 7.1239349162552168 10.605626423758729 18.974956238556508 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak36";
	rename -uid "EC986FE3-4DBA-9A06-16CA-0FA21FFA71E1";
	setAttr ".uopa" yes;
	setAttr -s 11 ".tk[11:21]" -type "float3"  0.38826665 0 -0.25567946 0.18687963
		 0 -0.43018243 -0.076881625 0 -0.46810523 -0.3192744 0 -0.35740846 -0.4633413 0 -0.13323683
		 -0.46334133 0 0.13323665 -0.31927446 0 0.35740843 -0.076881744 0 0.46810523 0.18687952
		 0 0.43018246 0.38826662 0 0.25567952 0.46334133 0 2.1001829e-16;
createNode polyExtrudeFace -n "polyExtrudeFace34";
	rename -uid "7E0A0846-45F5-BC8B-09D1-61B84A13EBDA";
	setAttr ".ics" -type "componentList" 1 "f[22:32]";
	setAttr ".ix" -type "matrix" 4.8682659656529106 0 0 0 0 4.8682659656529106 0 0 0 0 4.8682659656529106 0
		 0 5.7373604581058171 11.877381640567668 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0.098599322 14.304314 11.877381 ;
	setAttr ".rs" 65153;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -5.395378315491083 14.304313585964218 6.3269120077892529 ;
	setAttr ".cbx" -type "double3" 5.5925769651753887 14.304313585964218 17.427851273346082 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak37";
	rename -uid "BFCF71EB-4F88-340B-C6A0-A8B660522B8A";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[23:34]" -type "float3"  -0.26359183 0.7597543 0.1735791
		 -0.12687141 0.7597543 0.29204828 0.0044147824 0.7597543 -1.4859548e-15 0.052194428
		 0.7597543 0.31779397 0.21675339 0.7597543 0.24264237 0.31455934 0.7597543 0.090453647
		 0.31455937 0.7597543 -0.09045355 0.21675344 0.7597543 -0.24264234 0.052194528 0.7597543
		 -0.31779397 -0.12687127 0.7597543 -0.29204828 -0.2635918 0.7597543 -0.17357929 -0.31455937
		 0.7597543 -1.4859548e-15;
createNode polyExtrudeFace -n "polyExtrudeFace35";
	rename -uid "52B21D79-4273-F4F8-04E7-B79A9671BCCB";
	setAttr ".ics" -type "componentList" 1 "f[22:32]";
	setAttr ".ix" -type "matrix" 4.8682659656529106 0 0 0 0 4.8682659656529106 0 0 0 0 4.8682659656529106 0
		 0 5.7373604581058171 11.877381640567668 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0.098599032 17.069071 11.877381 ;
	setAttr ".rs" 52896;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -3.7413934080904419 17.069070608197723 7.9979035627755817 ;
	setAttr ".cbx" -type "double3" 3.9385914774322202 17.069070608197723 15.7568585576747 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak38";
	rename -uid "A07F3425-4409-EE5D-E118-5989CF09DA50";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[34:45]" -type "float3"  -0.28469947 0.56791407 0.18747884
		 -0.13703088 0.56791407 0.31543443 0.0047682892 0.56791407 -3.5888469e-08 0.056373987
		 0.56791407 0.34324175 0.23411033 0.56791407 0.26207247 0.33974823 0.56791407 0.097696871
		 0.33974841 0.56791407 -0.097696759 0.23411039 0.56791407 -0.26207253 0.05637408 0.56791407
		 -0.34324175 -0.13703078 0.56791407 -0.31543443 -0.28469947 0.56791407 -0.18747889
		 -0.33974841 0.56791407 -3.5888469e-08;
createNode polyExtrudeFace -n "polyExtrudeFace36";
	rename -uid "1AEBFF68-48BC-630C-18DA-799D2C85DD6D";
	setAttr ".ics" -type "componentList" 1 "f[22:32]";
	setAttr ".ix" -type "matrix" 4.8682659656529106 0 0 0 0 4.8682659656529106 0 0 0 0 4.8682659656529106 0
		 0 5.7373604581058171 11.877381640567668 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0.098599032 18.729235 11.87738 ;
	setAttr ".rs" 35910;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -3.0516278778366974 18.729234422484502 8.69476116888187 ;
	setAttr ".cbx" -type "double3" 3.2488259471784757 18.729234422484502 15.060000371225884 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak39";
	rename -uid "5E7554D2-4CF4-E95E-9D02-029B377321CD";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[45:56]" -type "float3"  -0.11872903 0.34101728 0.078184783
		 -0.057146356 0.34101728 0.13154645 0.0019885264 0.34101728 -3.2119782e-08 0.023509774
		 0.34101728 0.14314304 0.097631626 0.34101728 0.10929277 0.14168608 0.34101728 0.0407428
		 0.14168611 0.34101728 -0.040742736 0.0976317 0.34101728 -0.10929278 0.023509821 0.34101728
		 -0.14314304 -0.057146326 0.34101728 -0.1315465 -0.11872903 0.34101728 -0.078184798
		 -0.14168611 0.34101728 -3.2119782e-08;
createNode polyExtrudeFace -n "polyExtrudeFace37";
	rename -uid "05AD7A5C-48A2-4B23-FBF7-68A2DC0A018A";
	setAttr ".ics" -type "componentList" 1 "f[22:32]";
	setAttr ".ix" -type "matrix" 4.8682659656529106 0 0 0 0 4.8682659656529106 0 0 0 0 4.8682659656529106 0
		 0 5.7373604581058171 11.877381640567668 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0.098599181 22.774826 11.877381 ;
	setAttr ".rs" 61119;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -1.7683947938801081 22.774825392667523 9.9911896459629848 ;
	setAttr ".cbx" -type "double3" 1.9655931533931501 22.774825392667523 13.763572474487296 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak40";
	rename -uid "E6EC0A76-4467-B6C8-1CBC-AE968F69FDBE";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[56:67]" -type "float3"  -0.22088216 0.83101255 0.14545418
		 -0.1063145 0.83101255 0.24472769 0.0036994577 0.83101255 -4.855946e-08 0.043737389
		 0.83101255 0.2663019 0.18163292 0.83101255 0.20332713 0.26359138 0.83101255 0.075797483
		 0.26359141 0.83101255 -0.075797305 0.18163306 0.83101255 -0.20332713 0.043737438
		 0.83101255 -0.2663019 -0.10631444 0.83101255 -0.24472766 -0.22088216 0.83101255 -0.14545418
		 -0.26359141 0.83101255 -4.855946e-08;
createNode polyExtrudeFace -n "polyExtrudeFace38";
	rename -uid "8BB99633-4A44-FF6A-B282-45A2500D8F6D";
	setAttr ".ics" -type "componentList" 1 "f[22:32]";
	setAttr ".ix" -type "matrix" 4.8682659656529106 0 0 0 0 4.8682659656529106 0 0 0 0 4.8682659656529106 0
		 0 5.7373604581058171 11.877381640567668 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0.098599181 25.475946 11.877381 ;
	setAttr ".rs" 65065;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -1.7683949389657398 25.475947276460921 9.9911895008773541 ;
	setAttr ".cbx" -type "double3" 1.9655932984787818 25.475947276460921 13.763572619572928 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak41";
	rename -uid "8B455C4A-4A44-5748-7AAB-659A78EBA96B";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[67:78]" -type "float3"  0 0.55484229 -1.7763568e-15
		 0 0.55484229 -1.7763568e-15 0 0.55484229 -1.7763568e-15 0 0.55484229 -1.7763568e-15
		 0 0.55484229 -1.7763568e-15 0 0.55484229 -1.7763568e-15 0 0.55484229 -1.7763568e-15
		 0 0.55484229 -1.7763568e-15 0 0.55484229 -1.7763568e-15 0 0.55484229 -1.7763568e-15
		 0 0.55484229 -1.7763568e-15 0 0.55484229 -1.7763568e-15;
createNode polyExtrudeFace -n "polyExtrudeFace39";
	rename -uid "6D563531-43AF-C70D-FDC1-4D9BE8B4C5DF";
	setAttr ".ics" -type "componentList" 1 "f[22:32]";
	setAttr ".ix" -type "matrix" 4.8682659656529106 0 0 0 0 4.8682659656529106 0 0 0 0 4.8682659656529106 0
		 0 5.7373604581058171 11.877381640567668 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0.098599255 25.837536 11.877381 ;
	setAttr ".rs" 51741;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -2.3279617839474702 25.837535491401908 9.4258688499105929 ;
	setAttr ".cbx" -type "double3" 2.5251602885461439 25.837535491401908 14.328893270539687 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak42";
	rename -uid "F4D9BEFD-4F9D-2FD2-D6A8-9C9492E6D21C";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[78:89]" -type "float3"  0.096317895 0.074274622 -0.063426763
		 0.046359517 0.074274622 -0.10671615 -0.0016131897 0.074274622 3.5728863e-08 -0.019072127
		 0.074274622 -0.11612364 -0.079202913 0.074274622 -0.088662915 -0.1149417 0.074274622
		 -0.03305224 -0.11494172 0.074274622 0.033052161 -0.079202935 0.074274622 0.088662915
		 -0.019072164 0.074274622 0.11612364 0.046359465 0.074274622 0.10671601 0.096317895
		 0.074274622 0.063426763 0.11494172 0.074274622 3.5728863e-08;
createNode polyExtrudeFace -n "polyExtrudeFace40";
	rename -uid "01918AE0-4AED-5F9F-62E9-76925AC3FA2E";
	setAttr ".ics" -type "componentList" 1 "f[22:32]";
	setAttr ".ix" -type "matrix" 4.8682659656529106 0 0 0 0 4.8682659656529106 0 0 0 0 4.8682659656529106 0
		 0 5.7373604581058171 11.877381640567668 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0.098599322 26.403992 11.87738 ;
	setAttr ".rs" 34094;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -3.370220255971708 26.403991582522963 8.3728939178663797 ;
	setAttr ".cbx" -type "double3" 3.5674189056560137 26.403991582522963 15.381867622241375 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak43";
	rename -uid "FEB0263B-4C97-1CB3-6B1D-2C8FD7E83379";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[89:100]" -type "float3"  0.17940329 0.1163562 -0.1181398
		 0.086350009 0.1163562 -0.19877124 -0.0030047458 0.1163562 7.6804284e-08 -0.035524048
		 0.1163562 -0.21629371 -0.14752464 0.1163562 -0.16514494 -0.21409233 0.1163562 -0.061563592
		 -0.21409234 0.1163562 0.061563514 -0.14752464 0.1163562 0.16514495 -0.035524115 0.1163562
		 0.21629371 0.086349882 0.1163562 0.1987711 0.17940329 0.1163562 0.11813976 0.21409239
		 0.1163562 7.6804284e-08;
createNode polyBevel3 -n "polyBevel1";
	rename -uid "B8D72B73-464F-3AE2-9EA2-C39E49AD7131";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[0:10]";
	setAttr ".ix" -type "matrix" 4.8682659656529106 0 0 0 0 4.8682659656529106 0 0 0 0 4.8682659656529106 0
		 0 5.7373604581058171 11.877381640567668 1;
	setAttr ".ws" yes;
	setAttr ".oaf" yes;
	setAttr ".at" 180;
	setAttr ".sn" yes;
	setAttr ".mv" yes;
	setAttr ".mvt" 0.0001;
	setAttr ".sa" 30;
createNode polyTweak -n "polyTweak44";
	rename -uid "147AC26D-429A-5B62-0789-75BD12845AA0";
	setAttr ".uopa" yes;
	setAttr -s 12 ".tk[100:111]" -type "float3"  -0.044744853 0.12639263 0.029465182
		 -0.021536497 0.12639263 0.049575411 0.00074941391 0.12639263 -1.3400093e-08 0.008860033
		 0.12639263 0.053945683 0.036794029 0.12639263 0.041188695 0.053396627 0.12639263
		 0.015354528 0.053396635 0.12639263 -0.01535452 0.036794037 0.12639263 -0.041188698
		 0.0088600498 0.12639263 -0.053945683 -0.021536469 0.12639263 -0.049575359 -0.044744853
		 0.12639263 -0.029465156 -0.053396635 0.12639263 -1.3400093e-08;
createNode polySoftEdge -n "polySoftEdge11";
	rename -uid "3B796307-4A4B-CAF1-2A09-619428D7EB5F";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[*]";
	setAttr ".ix" -type "matrix" 4.8682659656529106 0 0 0 0 4.8682659656529106 0 0 0 0 4.8682659656529106 0
		 0 5.7373604581058171 11.877381640567668 1;
	setAttr ".a" 180;
createNode aiOptions -s -n "defaultArnoldRenderOptions";
	rename -uid "2B7FDE72-45A2-66B0-BB3C-3E817EB088F5";
	setAttr ".version" -type "string" "5.4.5";
createNode aiAOVFilter -s -n "defaultArnoldFilter";
	rename -uid "E0C98889-410C-D396-BB51-F99BDCA913F5";
createNode aiAOVDriver -s -n "defaultArnoldDriver";
	rename -uid "4ED77AC4-47FF-66F9-0823-538296B5471E";
createNode aiAOVDriver -s -n "defaultArnoldDisplayDriver";
	rename -uid "3CEFEA21-489E-9E28-6AC1-52B33507DAF6";
	setAttr ".ai_translator" -type "string" "maya";
	setAttr ".output_mode" 0;
createNode aiImagerDenoiserOidn -s -n "defaultArnoldDenoiser";
	rename -uid "BA028204-4684-6EB5-3DCD-139378359AAF";
createNode polyAutoProj -n "polyAutoProj1";
	rename -uid "BE6875AA-4C12-BB2E-C4B3-0F90B34C19A0";
	setAttr ".cch" yes;
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "f[0:69]";
	setAttr ".ix" -type "matrix" 18.546338765798428 0 0 0 0 1.6769562227072434 0 0 0 0 8.7387210802227422 0
		 -43.651302639258333 4.1667430360800113 -4.8500368722748215 1;
	setAttr ".s" -type "double3" 45.372092585367163 45.372092585367163 45.372092585367163 ;
	setAttr ".o" 0;
	setAttr ".ps" 0.20000000298023224;
	setAttr ".dl" yes;
createNode polyTweakUV -n "polyTweakUV1";
	rename -uid "36FFCABB-4F8D-4436-1E71-AF9C7B4137A4";
	setAttr ".uopa" yes;
	setAttr -s 131 ".uvtk";
	setAttr ".uvtk[1]" -type "float2" 0.14925772 0.013479829 ;
	setAttr ".uvtk[2]" -type "float2" 0.14602381 0.013320565 ;
	setAttr ".uvtk[3]" -type "float2" -0.0026171133 -0.0022409409 ;
	setAttr ".uvtk[5]" -type "float2" 0.15489563 0.013543401 ;
	setAttr ".uvtk[6]" -type "float2" 0.10205822 -0.0026504993 ;
	setAttr ".uvtk[7]" -type "float2" -0.045832168 -0.020798028 ;
	setAttr ".uvtk[8]" -type "float2" 0.097364418 -0.004006803 ;
	setAttr ".uvtk[9]" -type "float2" -0.050274976 -0.022989035 ;
	setAttr ".uvtk[10]" -type "float2" 0.065323673 -0.015874326 ;
	setAttr ".uvtk[11]" -type "float2" -0.082067095 -0.035688698 ;
	setAttr ".uvtk[12]" -type "float2" 0.06021329 -0.01781261 ;
	setAttr ".uvtk[13]" -type "float2" -0.087163262 -0.037670851 ;
	setAttr ".uvtk[15]" -type "float2" 0.14925633 0.013481282 ;
	setAttr ".uvtk[16]" -type "float2" 0.1460263 0.013319805 ;
	setAttr ".uvtk[17]" -type "float2" -0.0026178509 -0.0022404939 ;
	setAttr ".uvtk[19]" -type "float2" 0.15489621 0.01354279 ;
	setAttr ".uvtk[20]" -type "float2" 0.10205732 -0.0026505589 ;
	setAttr ".uvtk[21]" -type "float2" -0.045831285 -0.020798624 ;
	setAttr ".uvtk[22]" -type "float2" 0.097365305 -0.0040069818 ;
	setAttr ".uvtk[23]" -type "float2" -0.050275721 -0.022988915 ;
	setAttr ".uvtk[24]" -type "float2" 0.065323219 -0.015873969 ;
	setAttr ".uvtk[25]" -type "float2" -0.082066655 -0.035688698 ;
	setAttr ".uvtk[26]" -type "float2" 0.06021297 -0.01781249 ;
	setAttr ".uvtk[27]" -type "float2" -0.087162942 -0.037670791 ;
	setAttr ".uvtk[30]" -type "float2" 0 0.064635985 ;
	setAttr ".uvtk[31]" -type "float2" 0 0.06463597 ;
	setAttr ".uvtk[34]" -type "float2" 0 0.064635918 ;
	setAttr ".uvtk[35]" -type "float2" 0 0.06463591 ;
	setAttr ".uvtk[38]" -type "float2" 1.1473894e-06 -0.38498953 ;
	setAttr ".uvtk[39]" -type "float2" 2.3543835e-06 -0.38499171 ;
	setAttr ".uvtk[40]" -type "float2" -3.4272671e-06 -8.0112368e-06 ;
	setAttr ".uvtk[41]" -type "float2" -3.4719706e-06 -0.38499296 ;
	setAttr ".uvtk[43]" -type "float2" -0.040108174 0.035278331 ;
	setAttr ".uvtk[44]" -type "float2" 0.090623498 0.018885933 ;
	setAttr ".uvtk[45]" -type "float2" 0.13133535 -0.015028328 ;
	setAttr ".uvtk[46]" -type "float2" -0.050515309 0.036693234 ;
	setAttr ".uvtk[50]" -type "float2" -8.9406967e-08 -0.24912326 ;
	setAttr ".uvtk[51]" -type "float2" 1.7881393e-07 -0.24912347 ;
	setAttr ".uvtk[52]" -type "float2" 2.9802322e-07 -1.461478e-06 ;
	setAttr ".uvtk[53]" -type "float2" 2.9802322e-08 -0.24912313 ;
	setAttr ".uvtk[55]" -type "float2" -0.035406113 0.048436236 ;
	setAttr ".uvtk[56]" -type "float2" 0.080509782 0.025939446 ;
	setAttr ".uvtk[57]" -type "float2" 0.11698189 -0.020578921 ;
	setAttr ".uvtk[58]" -type "float2" -0.045103669 0.050508395 ;
	setAttr ".uvtk[62]" -type "float2" 0.0060602427 -0.000295192 ;
	setAttr ".uvtk[63]" -type "float2" -0.0060602427 -0.000295192 ;
	setAttr ".uvtk[66]" -type "float2" 0.0060603023 -0.000295192 ;
	setAttr ".uvtk[67]" -type "float2" -0.0060603023 -0.000295192 ;
	setAttr ".uvtk[70]" -type "float2" 0.0057432652 -0.00017142296 ;
	setAttr ".uvtk[71]" -type "float2" -0.0057432652 -0.00017142296 ;
	setAttr ".uvtk[74]" -type "float2" 0.0057433248 -0.00017142296 ;
	setAttr ".uvtk[75]" -type "float2" -0.0057433248 -0.00017142296 ;
	setAttr ".uvtk[78]" -type "float2" -0.015793324 0.0037063621 ;
	setAttr ".uvtk[79]" -type "float2" -0.016054988 0.003934782 ;
	setAttr ".uvtk[80]" -type "float2" 0.0075835586 -0.0075198794 ;
	setAttr ".uvtk[81]" -type "float2" -0.0081394315 -0.0037026112 ;
	setAttr ".uvtk[82]" -type "float2" 0.007824719 -0.0077567641 ;
	setAttr ".uvtk[83]" -type "float2" -0.0078973174 -0.003938478 ;
	setAttr ".uvtk[86]" -type "float2" 0.00064778328 -4.3202192e-05 ;
	setAttr ".uvtk[87]" -type "float2" -0.00064778328 -4.3202192e-05 ;
	setAttr ".uvtk[90]" -type "float2" 0.018024087 0 ;
	setAttr ".uvtk[91]" -type "float2" 0.018024087 3.7252903e-09 ;
	setAttr ".uvtk[94]" -type "float2" 0.038794994 -9.3132257e-10 ;
	setAttr ".uvtk[95]" -type "float2" 0.038794935 0 ;
	setAttr ".uvtk[98]" -type "float2" 0.0012222528 2.3283064e-10 ;
	setAttr ".uvtk[99]" -type "float2" 0.0012222528 0 ;
	setAttr ".uvtk[102]" -type "float2" 0.017943323 1.1175871e-08 ;
	setAttr ".uvtk[103]" -type "float2" 0.017943323 -9.778887e-09 ;
	setAttr ".uvtk[106]" -type "float2" -5.9604645e-08 -0.038794808 ;
	setAttr ".uvtk[107]" -type "float2" 0 -0.038794808 ;
	setAttr ".uvtk[110]" -type "float2" -5.9604645e-08 -0.038795136 ;
	setAttr ".uvtk[111]" -type "float2" 5.9604645e-08 -0.038795128 ;
	setAttr ".uvtk[112]" -type "float2" -0.62457699 0.032872468 ;
	setAttr ".uvtk[113]" -type "float2" -0.61421543 0.033941403 ;
	setAttr ".uvtk[114]" -type "float2" -0.62176377 0.023778383 ;
	setAttr ".uvtk[115]" -type "float2" -0.6313588 0.020663748 ;
	setAttr ".uvtk[116]" -type "float2" -0.62457699 0.032872472 ;
	setAttr ".uvtk[117]" -type "float2" -0.61280775 0.033097319 ;
	setAttr ".uvtk[118]" -type "float2" -0.37658417 0.11288135 ;
	setAttr ".uvtk[119]" -type "float2" -0.38406423 0.10230874 ;
	setAttr ".uvtk[120]" -type "float2" -0.74201787 -0.046852272 ;
	setAttr ".uvtk[121]" -type "float2" -0.75176913 -0.049948495 ;
	setAttr ".uvtk[122]" -type "float2" -0.36953059 0.11465895 ;
	setAttr ".uvtk[123]" -type "float2" -0.37580389 0.10407586 ;
	setAttr ".uvtk[124]" -type "float2" -0.74749607 -0.05372135 ;
	setAttr ".uvtk[125]" -type "float2" -0.75820768 -0.054946642 ;
	setAttr ".uvtk[126]" -type "float2" -0.3660599 0.13977718 ;
	setAttr ".uvtk[127]" -type "float2" -0.35913828 0.14135388 ;
	setAttr ".uvtk[128]" -type "float2" -0.44404244 -0.00044254027 ;
	setAttr ".uvtk[129]" -type "float2" -0.4524138 -0.0021321569 ;
	setAttr ".uvtk[130]" -type "float2" -0.457728 -0.009124672 ;
	setAttr ".uvtk[131]" -type "float2" -0.77552748 -0.07389383 ;
	setAttr ".uvtk[132]" -type "float2" -0.7862395 -0.075001344 ;
	setAttr ".uvtk[133]" -type "float2" -0.44852191 -0.0084506031 ;
	setAttr ".uvtk[134]" -type "float2" -0.77822495 -0.079542801 ;
	setAttr ".uvtk[135]" -type "float2" -0.78851688 -0.080127403 ;
	setAttr ".uvtk[136]" -type "float2" -0.46346036 -0.052394252 ;
	setAttr ".uvtk[137]" -type "float2" -0.47273788 -0.052985888 ;
	setAttr ".uvtk[138]" -type "float2" -0.47538811 -0.058739167 ;
	setAttr ".uvtk[139]" -type "float2" -0.46584868 -0.058157008 ;
	setAttr ".uvtk[141]" -type "float2" 0.011629518 -1.1205673e-05 ;
	setAttr ".uvtk[142]" -type "float2" 0.011599589 -5.8472157e-05 ;
	setAttr ".uvtk[143]" -type "float2" 0.00030780956 -0.00018417835 ;
	setAttr ".uvtk[145]" -type "float2" 0.01163505 4.4703484e-06 ;
	setAttr ".uvtk[146]" -type "float2" 0.35935542 2.682209e-05 ;
	setAttr ".uvtk[147]" -type "float2" 0.35936055 3.5047531e-05 ;
	setAttr ".uvtk[148]" -type "float2" 0.010471184 -0.0032837987 ;
	setAttr ".uvtk[149]" -type "float2" -0.00063188747 -0.0034472942 ;
	setAttr ".uvtk[150]" -type "float2" 5.6810677e-06 1.4156103e-05 ;
	setAttr ".uvtk[151]" -type "float2" 0.011640888 1.7106533e-05 ;
	setAttr ".uvtk[152]" -type "float2" 0.35922861 3.8951635e-05 ;
	setAttr ".uvtk[153]" -type "float2" 0.37031087 2.4855137e-05 ;
	setAttr ".uvtk[154]" -type "float2" 0.37029129 2.0861626e-05 ;
	setAttr ".uvtk[155]" -type "float2" 7.981807e-05 8.0764294e-05 ;
	setAttr ".uvtk[156]" -type "float2" 0.011712056 8.1270933e-05 ;
	setAttr ".uvtk[157]" -type "float2" 0.35922903 6.5356493e-05 ;
	setAttr ".uvtk[158]" -type "float2" 0.37018007 3.5583973e-05 ;
	setAttr ".uvtk[159]" -type "float2" 0.37043217 -0.00024205446 ;
	setAttr ".uvtk[160]" -type "float2" 0.35950029 -0.00022161007 ;
	setAttr ".uvtk[161]" -type "float2" 7.8763813e-05 0.00011742022 ;
	setAttr ".uvtk[162]" -type "float2" 0.011704717 9.0420246e-05 ;
	setAttr ".uvtk[163]" -type "float2" 0.359386 7.4073672e-05 ;
	setAttr ".uvtk[164]" -type "float2" 0.37017795 7.2777271e-05 ;
	setAttr ".uvtk[165]" -type "float2" 0.35939467 5.1146606e-05 ;
	setAttr ".uvtk[166]" -type "float2" 0.37034333 8.0414116e-05 ;
	setAttr ".uvtk[167]" -type "float2" 0.37035969 3.3673597e-05 ;
	setAttr ".uvtk[170]" -type "float2" 0 -0.28040767 ;
	setAttr ".uvtk[171]" -type "float2" 2.9802322e-08 -0.28040773 ;
	setAttr ".uvtk[174]" -type "float2" 0 -0.4333384 ;
	setAttr ".uvtk[175]" -type "float2" 0 -0.43333846 ;
createNode polyPlanarProj -n "polyPlanarProj1";
	rename -uid "68FDD766-43C0-A57F-02FC-46A6F8BF47A6";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "f[0:69]";
	setAttr ".ix" -type "matrix" 18.546338765798428 0 0 0 0 1.6769562227072434 0 0 0 0 8.7387210802227422 0
		 -43.651302639258333 4.1667430360800113 -4.8500368722748215 1;
	setAttr ".ws" yes;
	setAttr ".pc" -type "double3" -43.651298522949219 22.370702743530273 -4.8500399589538574 ;
	setAttr ".ro" -type "double3" -15.338353038478241 -7.8000007041605928 1.9099926193262859e-07 ;
	setAttr ".ps" -type "double2" 19.560706399786078 46.711930999988219 ;
	setAttr ".per" yes;
	setAttr ".cam" -type "matrix" 1.9264541864395142 0.061145391315221786 0.1308840811252594 0.13088145852088928
		 1.3492293518223919e-17 1.6425787210464478 -0.26452392339706421 -0.26451864838600159
		 0.26389139890670776 -0.44637224078178406 -0.95547705888748169 -0.95545798540115356
		 70.616714477539062 -38.170928955078125 61.634815216064453 61.833580017089844;
	setAttr ".prgt" 1031;
	setAttr ".ptop" 1177;
createNode polyMapCut -n "polyMapCut1";
	rename -uid "793C2187-4EF7-E624-563B-348DC903A51C";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 16 "e[0]" "e[4:5]" "e[12]" "e[20]" "e[33]" "e[41]" "e[44]" "e[55]" "e[60]" "e[71]" "e[80]" "e[91]" "e[96]" "e[98]" "e[107:108]" "e[114]";
createNode polyMapCut -n "polyMapCut2";
	rename -uid "9E39D830-4F22-CBB0-EEAA-B3A9FDBE7F2F";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 4 "e[31]" "e[34]" "e[37]" "e[43]";
createNode polyMapCut -n "polyMapCut3";
	rename -uid "B6C84D61-48AE-9208-4C0D-B69C2A36FA97";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 7 "e[13]" "e[45]" "e[52]" "e[78:79]" "e[81]" "e[88]" "e[115]";
createNode polyMapCut -n "polyMapCut4";
	rename -uid "68E760C4-4BCA-A9A6-3441-E2AAA504AA45";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 17 "e[3]" "e[8:9]" "e[15]" "e[23]" "e[28:30]" "e[36]" "e[39:40]" "e[49]" "e[57]" "e[65]" "e[73]" "e[85]" "e[93]" "e[101:102]" "e[109]" "e[111]" "e[113]";
createNode polyMapCut -n "polyMapCut5";
	rename -uid "9C8F1322-46DF-00B3-2132-08A64263BC17";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "e[103]" "e[110]";
createNode polyMapCut -n "polyMapCut6";
	rename -uid "7748F22C-4023-EAA5-61B5-69BC3A74F448";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[42]";
createNode polyMapCut -n "polyMapCut7";
	rename -uid "B4DB7640-49FA-A005-7C6F-8DAD7937F269";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[35]";
createNode polyMapCut -n "polyMapCut8";
	rename -uid "131EEEBB-46C3-EE29-C835-1A86FCAB83A4";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 7 "e[6]" "e[10]" "e[19]" "e[27]" "e[32]" "e[38]" "e[49]";
createNode polyTweakUV -n "polyTweakUV2";
	rename -uid "461DC010-4C17-5D53-597D-08B7D774BFE9";
	setAttr ".uopa" yes;
	setAttr -s 121 ".uvtk";
	setAttr ".uvtk[3]" -type "float2" -0.60365814 -1.1641532e-09 ;
	setAttr ".uvtk[4]" -type "float2" 0.038142338 0.55839276 ;
	setAttr ".uvtk[5]" -type "float2" -0.59414572 -0.010074594 ;
	setAttr ".uvtk[6]" -type "float2" -0.01095294 0.77113926 ;
	setAttr ".uvtk[7]" -type "float2" 0.55276036 0.45545143 ;
	setAttr ".uvtk[8]" -type "float2" 0.72692794 1.2420471 ;
	setAttr ".uvtk[9]" -type "float2" -0.0013659894 -0.0059870929 ;
	setAttr ".uvtk[10]" -type "float2" -0.050802916 0.62756544 ;
	setAttr ".uvtk[13]" -type "float2" -0.014193989 0.67565888 ;
	setAttr ".uvtk[14]" -type "float2" -0.00095731765 -0.00026165752 ;
	setAttr ".uvtk[15]" -type "float2" -0.047099445 0.073736869 ;
	setAttr ".uvtk[17]" -type "float2" 0.3817023 1.1876639 ;
	setAttr ".uvtk[18]" -type "float2" -0.31344438 -0.039084971 ;
	setAttr ".uvtk[19]" -type "float2" 0.34862214 1.2052056 ;
	setAttr ".uvtk[21]" -type "float2" -0.60335946 -0.0039386535 ;
	setAttr ".uvtk[22]" -type "float2" -0.30506742 -0.032367453 ;
	setAttr ".uvtk[24]" -type "float2" -0.30381948 -0.037971884 ;
	setAttr ".uvtk[26]" -type "float2" -0.32719141 -0.78136396 ;
	setAttr ".uvtk[27]" -type "float2" -0.05903329 0.58740354 ;
	setAttr ".uvtk[28]" -type "float2" 0.13617174 0.33194008 ;
	setAttr ".uvtk[29]" -type "float2" -0.33843997 -0.78113806 ;
	setAttr ".uvtk[31]" -type "float2" -0.0044321418 0.11789249 ;
	setAttr ".uvtk[32]" -type "float2" 0.40036023 1.2438316 ;
	setAttr ".uvtk[33]" -type "float2" -0.0005402863 -0.00062366575 ;
	setAttr ".uvtk[34]" -type "float2" 0.024807207 -0.35612547 ;
	setAttr ".uvtk[35]" -type "float2" -0.60357028 0.017795704 ;
	setAttr ".uvtk[36]" -type "float2" 0.012847617 -0.39118028 ;
	setAttr ".uvtk[37]" -type "float2" 0.62954479 0.85198033 ;
	setAttr ".uvtk[38]" -type "float2" 0.011504829 -0.39360452 ;
	setAttr ".uvtk[39]" -type "float2" -0.32464826 -0.40023369 ;
	setAttr ".uvtk[40]" -type "float2" -0.61136353 0.0053207418 ;
	setAttr ".uvtk[41]" -type "float2" 0.23402871 0.77685964 ;
	setAttr ".uvtk[42]" -type "float2" -0.33368206 -0.4038302 ;
	setAttr ".uvtk[43]" -type "float2" -0.32312971 -0.40308973 ;
	setAttr ".uvtk[44]" -type "float2" 0.047821548 -0.40310949 ;
	setAttr ".uvtk[45]" -type "float2" -0.6006695 0.016985796 ;
	setAttr ".uvtk[46]" -type "float2" 0.62053239 0.81035614 ;
	setAttr ".uvtk[47]" -type "float2" 0.016387604 -0.43567836 ;
	setAttr ".uvtk[48]" -type "float2" 0.22295913 0.73060453 ;
	setAttr ".uvtk[49]" -type "float2" -0.61169839 0.0066876551 ;
	setAttr ".uvtk[50]" -type "float2" -0.33545935 -0.44379157 ;
	setAttr ".uvtk[51]" -type "float2" -0.32500786 -0.44346184 ;
	setAttr ".uvtk[52]" -type "float2" -0.32715854 -0.44145069 ;
	setAttr ".uvtk[53]" -type "float2" 0.018698826 -0.43352187 ;
	setAttr ".uvtk[54]" -type "float2" 0.079742998 -0.75613391 ;
	setAttr ".uvtk[55]" -type "float2" -0.59726202 -0.0051678205 ;
	setAttr ".uvtk[56]" -type "float2" 0.044248935 -0.73761159 ;
	setAttr ".uvtk[57]" -type "float2" 0.56173301 0.50732648 ;
	setAttr ".uvtk[58]" -type "float2" 0.041696202 -0.73631668 ;
	setAttr ".uvtk[59]" -type "float2" -0.32913539 -0.73308527 ;
	setAttr ".uvtk[60]" -type "float2" -0.60435152 0.0066322228 ;
	setAttr ".uvtk[61]" -type "float2" 0.14807668 0.39069375 ;
	setAttr ".uvtk[62]" -type "float2" -0.33824772 -0.73181915 ;
	setAttr ".uvtk[63]" -type "float2" -0.32707506 -0.73190427 ;
	setAttr ".uvtk[64]" -type "float2" 0.03729783 0.56382328 ;
	setAttr ".uvtk[65]" -type "float2" -0.60534841 0.0035762924 ;
	setAttr ".uvtk[66]" -type "float2" -0.60490233 0.0038530964 ;
	setAttr ".uvtk[67]" -type "float2" -0.60425651 0.0064872643 ;
	setAttr ".uvtk[68]" -type "float2" -0.59312117 -0.010794797 ;
	setAttr ".uvtk[69]" -type "float2" 0.60074043 0.53871453 ;
	setAttr ".uvtk[70]" -type "float2" -0.61081618 0.0059808036 ;
	setAttr ".uvtk[71]" -type "float2" 0.65204126 0.89589608 ;
	setAttr ".uvtk[72]" -type "float2" -0.61232501 0.0050271889 ;
	setAttr ".uvtk[73]" -type "float2" 0.6600818 0.94427526 ;
	setAttr ".uvtk[74]" -type "float2" -0.60320711 -0.0046590427 ;
	setAttr ".uvtk[76]" -type "float2" -0.60042822 -0.0093308697 ;
	setAttr ".uvtk[77]" -type "float2" 0.35743099 1.2347485 ;
	setAttr ".uvtk[78]" -type "float2" -0.60349172 -0.0044399099 ;
	setAttr ".uvtk[80]" -type "float2" -0.60076994 -0.0092365975 ;
	setAttr ".uvtk[81]" -type "float2" -0.60388345 -0.004419283 ;
	setAttr ".uvtk[82]" -type "float2" 0.00069338083 0.00042431056 ;
	setAttr ".uvtk[83]" -type "float2" 0.37656015 1.2973889 ;
	setAttr ".uvtk[85]" -type "float2" 0.00098280609 -6.683822e-05 ;
	setAttr ".uvtk[86]" -type "float2" -0.015252933 0.68253076 ;
	setAttr ".uvtk[87]" -type "float2" 0.71124077 1.5420178 ;
	setAttr ".uvtk[88]" -type "float2" -0.59887564 -0.0038863802 ;
	setAttr ".uvtk[89]" -type "float2" -0.35757345 -0.74990499 ;
	setAttr ".uvtk[90]" -type "float2" -0.35383388 -0.41360351 ;
	setAttr ".uvtk[91]" -type "float2" -0.60117424 0.017700873 ;
	setAttr ".uvtk[92]" -type "float2" -0.60525864 0.018365048 ;
	setAttr ".uvtk[93]" -type "float2" -0.34837604 -0.35685235 ;
	setAttr ".uvtk[94]" -type "float2" -0.31494889 0.042311147 ;
	setAttr ".uvtk[95]" -type "float2" -0.60365814 -1.1641532e-09 ;
	setAttr ".uvtk[96]" -type "float2" 0.045774173 -0.78797811 ;
	setAttr ".uvtk[97]" -type "float2" -0.034987077 0.79118305 ;
	setAttr ".uvtk[98]" -type "float2" 0.16736813 0.40395537 ;
	setAttr ".uvtk[99]" -type "float2" 0.17880973 0.45353454 ;
	setAttr ".uvtk[100]" -type "float2" 0.058855694 -0.78814912 ;
	setAttr ".uvtk[101]" -type "float2" 0.054648541 -0.73652929 ;
	setAttr ".uvtk[102]" -type "float2" 0.2510677 0.74418187 ;
	setAttr ".uvtk[103]" -type "float2" 0.028395876 -0.43551326 ;
	setAttr ".uvtk[104]" -type "float2" 0.26178145 0.78424788 ;
	setAttr ".uvtk[105]" -type "float2" 0.02341684 -0.39289823 ;
	setAttr ".uvtk[106]" -type "float2" 0.37310857 1.1612628 ;
	setAttr ".uvtk[107]" -type "float2" 0.0093848854 -0.0047570169 ;
	setAttr ".uvtk[108]" -type "float2" -0.038010567 0.045136407 ;
	setAttr ".uvtk[109]" -type "float2" -0.0042953193 0.11784099 ;
	setAttr ".uvtk[110]" -type "float2" -0.31194931 -0.012165651 ;
	setAttr ".uvtk[112]" -type "float2" -0.30280739 -0.011079147 ;
	setAttr ".uvtk[113]" -type "float2" 0.2049526 1.562485 ;
	setAttr ".uvtk[114]" -type "float2" -0.0096136555 0.12434787 ;
	setAttr ".uvtk[115]" -type "float2" -0.0094458759 0.12429199 ;
	setAttr ".uvtk[116]" -type "float2" -0.0024845973 0.021793827 ;
	setAttr ".uvtk[118]" -type "float2" 0.0080486238 0.022980556 ;
	setAttr ".uvtk[119]" -type "float2" -0.020571724 0.03146401 ;
	setAttr ".uvtk[120]" -type "float2" -0.061340049 0.5880959 ;
	setAttr ".uvtk[121]" -type "float2" -0.035264984 0.79178375 ;
	setAttr ".uvtk[122]" -type "float2" 0.59312999 0.47667831 ;
	setAttr ".uvtk[123]" -type "float2" -0.0098958425 0.77048874 ;
	setAttr ".uvtk[124]" -type "float2" -0.015413523 -0.0022621453 ;
	setAttr ".uvtk[125]" -type "float2" -0.016719937 -0.0024896897 ;
	setAttr ".uvtk[126]" -type "float2" -0.045984626 0.066851497 ;
	setAttr ".uvtk[127]" -type "float2" 0.0096207187 0.00045824336 ;
	setAttr ".uvtk[130]" -type "float2" -0.037580997 0.051621899 ;
	setAttr ".uvtk[132]" -type "float2" -0.0095909163 0.00076892693 ;
	setAttr ".uvtk[134]" -type "float2" 0.15861467 1.5552137 ;
	setAttr ".uvtk[135]" -type "float2" 0.71124077 1.5420178 ;
	setAttr ".uvtk[136]" -type "float2" -0.050802909 0.62756544 ;
	setAttr ".uvtk[138]" -type "float2" -0.021105736 0.034807213 ;
	setAttr ".uvtk[139]" -type "float2" 0.7491231 1.3897231 ;
createNode polyLayoutUV -n "polyLayoutUV1";
	rename -uid "FDF4495D-4895-47C7-CD5C-788144509849";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "f[0:69]";
	setAttr ".l" 1;
	setAttr ".ps" 0.20000000298023224;
	setAttr ".dl" yes;
	setAttr ".rbf" 1;
	setAttr ".lm" 1;
createNode polyTweakUV -n "polyTweakUV3";
	rename -uid "3C739A96-452C-3F9B-E49C-55920B44DA25";
	setAttr ".uopa" yes;
	setAttr -s 109 ".uvtk";
	setAttr ".uvtk[9]" -type "float2" 2.3841858e-07 -1.1175871e-06 ;
	setAttr ".uvtk[18]" -type "float2" -2.8014183e-06 -4.0978193e-06 ;
	setAttr ".uvtk[22]" -type "float2" -2.0265579e-06 -2.2426248e-06 ;
	setAttr ".uvtk[24]" -type "float2" -1.4901161e-06 -1.9967556e-06 ;
	setAttr ".uvtk[26]" -type "float2" -1.1920929e-06 -2.3543835e-06 ;
	setAttr ".uvtk[29]" -type "float2" -1.2516975e-06 -2.4661422e-06 ;
	setAttr ".uvtk[34]" -type "float2" -2.5033951e-06 3.2261014e-06 ;
	setAttr ".uvtk[36]" -type "float2" -2.0265579e-06 -1.7359853e-06 ;
	setAttr ".uvtk[38]" -type "float2" -5.9604645e-08 -1.6987324e-06 ;
	setAttr ".uvtk[39]" -type "float2" 5.364418e-07 -1.8775463e-06 ;
	setAttr ".uvtk[42]" -type "float2" 8.3446503e-07 -1.937151e-06 ;
	setAttr ".uvtk[43]" -type "float2" 1.3113022e-06 -1.6987324e-06 ;
	setAttr ".uvtk[44]" -type "float2" 2.9802322e-06 2.3171306e-06 ;
	setAttr ".uvtk[47]" -type "float2" 1.2516975e-06 -2.078712e-06 ;
	setAttr ".uvtk[50]" -type "float2" 7.1525574e-07 1.013279e-06 ;
	setAttr ".uvtk[51]" -type "float2" -2.3841858e-06 -5.9604645e-07 ;
	setAttr ".uvtk[52]" -type "float2" -4.2915344e-06 -9.611249e-07 ;
	setAttr ".uvtk[53]" -type "float2" 2.8014183e-06 -2.3171306e-06 ;
	setAttr ".uvtk[54]" -type "float2" -2.1457672e-06 3.3974648e-06 ;
	setAttr ".uvtk[56]" -type "float2" -5.364418e-07 3.9488077e-06 ;
	setAttr ".uvtk[58]" -type "float2" 5.9604645e-08 3.3453107e-06 ;
	setAttr ".uvtk[59]" -type "float2" 1.7881393e-07 -1.4901161e-08 ;
	setAttr ".uvtk[62]" -type "float2" 1.7881393e-07 9.3132257e-07 ;
	setAttr ".uvtk[63]" -type "float2" 1.1920929e-07 2.0116568e-07 ;
	setAttr ".uvtk[89]" -type "float2" 4.0531158e-06 1.8328428e-06 ;
	setAttr ".uvtk[90]" -type "float2" -2.0265579e-06 6.0722232e-06 ;
	setAttr ".uvtk[93]" -type "float2" 3.0994415e-06 -1.7881393e-06 ;
	setAttr ".uvtk[94]" -type "float2" -4.4703484e-06 5.0030649e-06 ;
	setAttr ".uvtk[96]" -type "float2" 1.6689301e-06 -8.1211329e-07 ;
	setAttr ".uvtk[100]" -type "float2" -5.9604645e-08 -6.7278743e-06 ;
	setAttr ".uvtk[101]" -type "float2" 7.1525574e-07 3.1962991e-06 ;
	setAttr ".uvtk[103]" -type "float2" -6.5565109e-07 -1.4826655e-06 ;
	setAttr ".uvtk[105]" -type "float2" -1.7881393e-06 -2.1383166e-06 ;
	setAttr ".uvtk[107]" -type "float2" 7.1525574e-07 -1.6614795e-06 ;
	setAttr ".uvtk[110]" -type "float2" 1.4901161e-06 -4.8168004e-06 ;
	setAttr ".uvtk[112]" -type "float2" 9.4771385e-06 1.3519078e-05 ;
	setAttr ".uvtk[116]" -type "float2" -1.7881393e-07 -4.4554472e-06 ;
	setAttr ".uvtk[118]" -type "float2" -3.7550926e-06 -1.1220574e-05 ;
	setAttr ".uvtk[127]" -type "float2" 0.0052389503 0.0012048613 ;
	setAttr ".uvtk[132]" -type "float2" -0.0053673983 -0.00094198011 ;
createNode polyAutoProj -n "polyAutoProj2";
	rename -uid "014007E8-4C94-12CE-2D18-04B246D41E36";
	setAttr ".cch" yes;
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 15 "f[2]" "f[7:8]" "f[12]" "f[23:24]" "f[26]" "f[29]" "f[31]" "f[35:37]" "f[39]" "f[41:42]" "f[44]" "f[47]" "f[49]" "f[53:54]" "f[57:69]";
	setAttr ".ix" -type "matrix" 18.546338765798428 0 0 0 0 1.6769562227072434 0 0 0 0 8.7387210802227422 0
		 -43.651302639258333 4.1667430360800113 -4.8500368722748215 1;
	setAttr ".s" -type "double3" 41.728492156048645 41.728492156048645 41.728492156048645 ;
	setAttr ".o" 0;
	setAttr ".ps" 0.20000000298023224;
	setAttr ".dl" yes;
createNode polyLayoutUV -n "polyLayoutUV2";
	rename -uid "73402842-4F97-894A-05A9-D3A4A6FAC9E6";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "f[0:69]";
	setAttr ".l" 1;
	setAttr ".ps" 0.20000000298023224;
	setAttr ".dl" yes;
	setAttr ".rbf" 1;
	setAttr ".lm" 1;
createNode polyTweakUV -n "polyTweakUV4";
	rename -uid "F49BDEB3-42BC-078B-5EA8-50B2DA739D4B";
	setAttr ".uopa" yes;
	setAttr -s 188 ".uvtk[0:187]" -type "float2" -0.071675144 0.54387575 -0.24186274
		 0.48675478 0.67628503 0.11577724 0.053598024 0.74746412 0.67733318 0.099385798 0.05027137
		 0.74757397 -0.52938145 0.84087867 -0.51706463 0.43908602 -0.1480616 0.61629313 -0.25891089
		 0.43883353 -0.16653401 0.37107486 -0.11621513 0.62025446 -0.23844072 0.43950775 -0.10346281
		 0.53953373 -0.22027087 0.48481178 -0.10974429 0.38925293 -0.10349739 0.28700256 -0.16898751
		 0.53826314 0.66948092 0.11530299 -0.23509464 0.43883353 0.053246833 0.7541337 -0.55019629
		 0.17269927 -0.17740491 0.29408333 -0.23844072 0.48476261 -0.069110163 0.39965123
		 -0.22120094 0.43883353 0.67701948 0.10736921 -0.5237692 0.65683877 0.66955888 0.10736504
		 -0.34554768 0.22507507 0.67704642 0.1065053 -0.52440423 0.67775822 -0.36880183 0.21911806
		 0.66955757 0.10650003 0.67757541 0.10041833 -0.52869654 0.81860459 0.66936862 0.1003226
		 -0.52541846 0.17903697 0.053504713 0.74773657 0.66937745 0.099309742 0.66912532 0.099309862
		 0.66912603 0.1003288 0.67760241 0.099392772 -0.44104767 0.82128751 0.66931838 0.10650748
		 -0.43674734 0.68044549 0.66935587 0.10736364 -0.43609971 0.65953517 0.66927963 0.11530024
		 -0.17669353 0.29322618 0.66923511 0.11592022 -0.084804662 0.29179218 0.67623144 0.11641222
		 -0.25100365 0.48598862 0.66943812 0.11593498 0.67601109 0.11639276 -0.22807026 0.43889636
		 -0.044169866 0.30218798 -0.22817838 0.4841491 -0.24599007 0.43883353 -0.10671463
		 0.54387563 -0.17579323 0.40636039 0.67732102 0.10039902 0.67679471 0.10648564 0.67679256
		 0.10735092 0.67605543 0.11575893 0.050027765 0.75400627 -0.57513475 0.27015907 -0.5503704
		 0.27650186 -0.39374039 0.31657723 -0.37048754 0.3225354 -0.12845659 0.38447306 -0.1867815
		 0.62514317 -0.23152465 0.48526567 -0.22817838 0.43933743 -0.13021335 0.57197958 -0.26251227
		 0.48826438 -0.25460503 0.48884106 -0.25100365 0.43940967 -0.20778826 0.36400178 0.053239264
		 0.75433546 0.050020494 0.75420821 -0.44171727 0.84356695 0.050278999 0.74735296 -0.17320564
		 0.3704192 -0.18216249 0.29464573 -0.11387639 0.61577213 -0.17600077 0.29240504 -0.19358438
		 0.36724317 -0.168448 0.3698568 -0.20248255 0.54480976 -0.17391706 0.37405956 -0.18133157
		 0.29297072 -0.15328634 0.61859661 -0.20577198 0.55693597 -0.10023438 0.42140359 -0.13856074
		 0.53991437 -0.082088672 0.62011397 -0.1908972 0.28998476 -0.42938372 0.44178861 -0.041272826
		 0.59520727 0.060155965 0.59520727 0.060155965 0.58267736 -0.041272826 0.58267736
		 0.068276711 0.59520727 0.068276711 0.58267736 0.05589173 0.22298026 0.05589173 0.95490426
		 -0.098796852 0.95490426 -0.098796852 0.22298026 0.068276651 0.95490426 0.068276651
		 0.22298026 0.034134664 0.72549921 0.089834787 0.72549921 0.089834787 0.71739119 0.034134664
		 0.71739119 0.094565131 0.72549921 0.094565131 0.71739119 0.085332043 0.48463589 0.085332043
		 0.9582544 -0.0233896 0.9582544 -0.0233896 0.48463589 0.09456519 0.9582544 0.09456519
		 0.48463589 0.35117254 0.73363203 0.36232927 0.73363203 0.36232927 0.72552401 0.35117254
		 0.72552401 0.33532211 0.96638733 0.31966224 0.96638733 0.31966224 0.49276882 0.33532211
		 0.49276882 -0.2770623 0.066238105 -0.27905127 0.051157176 0.080629461 -0.31765553
		 0.082618378 -0.3025746 0.05362206 0.054571331 0.051346831 0.069652379 -0.30833378
		 -0.30598864 -0.30605856 -0.32106969 -0.47682136 0.67541093 -0.47025302 0.3913404
		 -0.31387049 0.39465585 -0.3204388 0.67872638 -0.31234527 0.74966019 -0.20443523 0.72265279
		 -0.17792451 0.92957914 -0.28583455 0.95658654 -0.33881611 0.92973834 -0.31218612
		 0.72249359 -0.20459443 0.74950093 -0.23122446 0.95674568 -0.36548591 0.92957908 -0.33897525
		 0.72265285 -0.23106514 0.74966019 -0.25757581 0.95658654 0.084855907 -0.60377818
		 0.083871983 -0.59835893 0.058268301 -0.6274991 0.059252195 -0.63291836 0.41620901
		 -0.22665778 0.41522509 -0.22123852 0.054473318 -0.43643397 0.028869607 -0.46557415
		 0.44803879 -0.19043159 0.44705489 -0.18501234 0.38582647 -0.059313565 0.053547114
		 -0.43133265 0.027943403 -0.4604727 0.66245311 0.053598136 0.6614691 0.05901739 0.41765618
		 -0.023087502 0.38490018 -0.054212123 0.69636279 0.092191637 0.6953789 0.097610891
		 0.63207054 0.22094235 0.41673002 -0.017985821 0.66598028 0.25953585 0.63114434 0.22604379
		 0.66505414 0.26463729 0.36232927 0.73363203 0.49616307 0.73363203 0.49616307 0.72552401
		 0.36232927 0.72552401 0.29361823 0.75031048 0.37582165 0.75031048 0.37582165 0.58370924
		 0.29361823 0.58370924;
createNode polyAutoProj -n "polyAutoProj3";
	rename -uid "9D56C35A-4E3C-7FD9-16EF-5C99634C2433";
	setAttr ".cch" yes;
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "f[0:69]";
	setAttr ".ix" -type "matrix" 16.171219704102587 0 0 0 0 0.75120721960833869 0 0 0 0 4.3169060170636264 0
		 -22.133370339040415 2.3183390047443941 -4.8500368722748215 1;
	setAttr ".s" -type "double3" 20.324826049329744 20.324826049329744 20.324826049329744 ;
	setAttr ".o" 0;
	setAttr ".ps" 0.20000000298023224;
	setAttr ".dl" yes;
createNode polyTweakUV -n "polyTweakUV5";
	rename -uid "5AC73521-4384-BEE7-E482-E8B6E72F59E9";
	setAttr ".uopa" yes;
	setAttr -s 176 ".uvtk[0:175]" -type "float2" 2.38640165 0.16794243 2.42660666
		 0.16590574 2.42674017 0.14289239 2.38670874 0.14408329 2.38309741 0.2179258 2.42581129
		 0.21582748 2.42713189 -0.16029304 2.38735843 -0.16033858 2.42698717 -0.18933952 2.3872869
		 -0.18972552 2.42576838 -0.38606089 2.38615298 -0.38683647 2.42555809 -0.41719884
		 2.38594699 -0.41799337 2.25321555 0.17085937 2.29358673 0.16835287 2.29380512 0.14537111
		 2.25360131 0.1470286 2.24972248 0.2207929 2.29260874 0.21820952 2.29524326 -0.15741342
		 2.25529146 -0.15699691 2.29519916 -0.18642056 2.25531864 -0.18634498 2.29465151 -0.38287467
		 2.25485349 -0.38319081 2.29454732 -0.41397041 2.25475311 -0.41430527 1.67166817 0.27910414
		 1.62558079 0.27910414 1.62558079 0.32774532 1.67166817 0.32774532 1.72542596 0.27910414
		 1.67933869 0.27910414 1.67933869 0.32774532 1.72542596 0.32774532 2.072428703 0.94543374
		 2.038853407 0.87236106 2.21658611 0.39717627 2.25016332 0.47026217 2.036158085 0.8665092
		 2.21390462 0.39133108 2.08278656 0.37355387 1.86362076 0.84618998 1.83023286 0.75573826
		 2.050274134 0.28281295 1.86636162 0.85339892 2.085352182 0.37491715 2.12980247 0.84954745
		 2.17590547 0.84954745 2.17590356 0.66780168 2.12979937 0.66779858 2.17982435 0.84954566
		 2.17982578 0.66779715 1.85997462 0.64066011 1.73253047 0.95155144 1.69570291 0.87023997
		 1.82435441 0.55884504 1.73576784 0.95837331 1.86266601 0.64209753 2.09990859 0.58935618
		 2.098476887 0.58935618 2.10191298 0.43600392 2.096472502 0.43600392 2.061486006 0.58935618
		 2.060054302 0.58935618 2.063490391 0.43600392 2.058049917 0.43600392 2.21250987 0.5893563
		 2.21115398 0.5893563 2.21441078 0.35254562 2.20925283 0.35254562 2.17408705 0.5893563
		 2.1727314 0.5893563 2.1759882 0.35254562 2.17083001 0.35254562 1.54456711 0.23067364
		 1.55002427 0.22877559 1.55010009 0.26430398 1.54298162 0.26412112 1.77168882 0.23025271
		 1.77121234 0.26620585 1.77868009 0.2303184 1.77819562 0.26627797 1.93750346 0.61166775
		 1.94050121 0.61166775 1.94616652 0.70638716 1.93183827 0.70638716 1.69932747 0.62522942
		 1.69932747 0.7916854 1.68049812 0.7916854 1.68049812 0.62522942 1.48465753 0.55307436
		 1.48465753 0.51470292 1.7145493 0.51470292 1.71454906 0.55307436 1.90408289 0.67865038
		 1.90408289 0.61845601 1.91374421 0.61845601 1.91374421 0.67865038 1.7328434 0.62522942
		 1.7328434 0.7916854 1.71409869 0.79168552 1.71409869 0.62522942 1.5488708 0.64793688
		 1.5818305 0.7084648 1.35187876 0.73876095 1.31891918 0.67823291 1.50922513 0.57513064
		 1.54203713 0.63538712 1.31208611 0.66568327 1.27927423 0.60542667 2.63026333 0.51457185
		 2.64160252 0.51048297 2.6416235 0.48868072 2.63371754 0.48932242 2.6096859 0.54895294
		 2.62322307 0.5432409 2.9068203 0.51232547 2.90670443 0.49026394 2.65013361 0.18578333
		 2.64219856 0.18622392 2.91481733 0.51323503 2.91361308 0.49078417 2.65083551 0.1572032
		 2.64272022 0.15756297 2.91006184 0.56153607 2.91800165 0.56247938 2.90223575 0.17492872
		 2.89533806 0.17444104 2.89598083 0.14581919 2.65546417 -0.036390722 2.6473403 -0.035989463
		 2.9031651 0.14543176 2.65658379 -0.066812426 2.64832044 -0.066309482 2.90805483 -0.054034054
		 2.90079618 -0.053642929 2.90191698 -0.084091216 2.90948606 -0.084789306 2.58204007
		 -0.43531507 2.59055805 -0.43531781 2.59055543 -0.45782882 2.58208275 -0.45784384
		 2.58204007 -0.14404893 2.59056163 -0.14404845 2.8451705 -0.43531424 2.84517002 -0.45781904
		 2.59045482 -0.50695711 2.5820055 -0.50698525 2.58204389 -0.11607105 2.59056449 -0.11606985
		 2.84514618 -0.14404011 2.85319257 -0.43531555 2.85319281 -0.4578293 2.582057 0.072410747
		 2.59057736 0.072413847 2.84514713 -0.11605984 2.85316634 -0.14404178 2.85324001 -0.50675827
		 2.84522581 -0.50674564 2.58205843 0.1022298 2.5905776 0.1022248 2.84515667 0.072417662
		 2.85316777 -0.11605877 2.8451581 0.10222515 2.85317826 0.072418377 2.8531754 0.1022149
		 1.67801642 0.37724897 1.90933084 0.37724897 1.90933084 0.17911851 1.67801642 0.17911851
		 1.8290745 0.040621534 2.032293797 0.040621534 2.032294035 -0.28355351 1.8290745 -0.28355411;
createNode polyAutoProj -n "polyAutoProj4";
	rename -uid "71F2C280-42AB-F254-EA25-E99C6D34D62B";
	setAttr ".cch" yes;
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "f[0:131]";
	setAttr ".ix" -type "matrix" 2.5993814782064346 0 0 0 0 2.5993814782064346 0 0 0 0 2.5993814782064346 0
		 -26.107629796476711 23.208824761137276 -4.6076247308320593 1;
	setAttr ".s" -type "double3" 13.962751177284076 13.962751177284076 13.962751177284076 ;
	setAttr ".o" 0;
	setAttr ".ps" 0.20000000298023224;
	setAttr ".dl" yes;
createNode polyTweakUV -n "polyTweakUV6";
	rename -uid "D633CE02-4016-7C28-2470-F09EDD89567A";
	setAttr ".uopa" yes;
	setAttr -s 203 ".uvtk[0:202]" -type "float2" 1.056931973 0.09766233 1.068689108
		 0.09766233 1.064328432 0.098197222 1.051135302 0.1100738 1.053604126 0.097182058
		 1.063178778 0.10348403 1.057689667 0.097021341 1.063851118 0.096871853 1.063219786
		 0.11213088 1.05079627 0.12430143 1.061575651 0.10361937 1.06600666 0.096226454 1.075649738
		 0.10576892 1.068953514 0.11040306 1.064786673 0.12071449 1.053574085 0.13077885 1.07034874
		 0.097681992 1.080900908 0.11899233 1.070808172 0.11887771 1.070921659 0.14053297
		 1.06366992 0.14495611 1.082155704 0.12497669 1.075298548 0.1390965 1.075609207 0.14991856
		 1.068976164 0.15209842 1.08267355 0.14068317 1.078362703 0.14840531 1.084927082 0.1475575
		 1.22493982 -0.18588012 1.03927803 -0.18737179 1.041304588 -0.36159497 1.18630815
		 -0.36862022 1.17632198 0.16658521 1.036481619 0.16072494 0.8580637 -0.18929726 0.89728689
		 -0.36997432 1.042244434 -0.5007773 1.14323807 -0.50699109 0.89711386 0.16277838 0.94143802
		 -0.50801545 1.042813301 -0.58166039 1.12468052 -0.58566833 0.96107364 -0.58643019
		 1.043574572 -0.77254236 1.091766357 -0.77361381 0.99533218 -0.77422392 1.044912815
		 -0.89661705 1.092758179 -0.89621222 0.9969973 -0.89730799 1.021174431 0.26984841
		 1.021174431 0.24939084 1.027606726 0.2504915 1.027763844 0.27216232 1.018042326 0.23237365
		 1.02609086 0.2315414 1.024391413 0.20445603 1.032478571 0.20461828 0.98950648 0.25128132
		 0.98950648 0.22794867 0.99774653 0.22794867 0.99846113 0.25150752 0.98993224 0.20608515
		 0.9981209 0.20548964 1.10362244 0.26571709 1.086621761 0.28044844 1.070296288 0.24413282
		 1.064355135 0.28364956 1.10996032 0.24413282 1.04389286 0.27430511 1.10362244 0.22254884
		 1.031730652 0.25538045 1.086621761 0.20781714 1.031730652 0.232885 1.064355135 0.20461559
		 1.04389286 0.21396077 1.17436981 0.23476321 1.16537762 0.22998321 1.1685307 0.2211566
		 1.18008542 0.23099947 1.15371704 0.22920305 1.1519599 0.2193011 1.17544866 0.2047323
		 1.19461536 0.22150201 1.174963 0.24489027 1.18424702 0.24557966 1.14291859 0.23379868
		 1.13658786 0.22629839 1.14890766 0.20110911 1.20195866 0.24588257 1.17079401 0.25578642
		 1.17904592 0.26142919 1.13662124 0.24238539 1.12753391 0.23956311 1.12442756 0.21248943
		 1.19424462 0.27154672 1.16214037 0.26369739 1.16628408 0.27249801 1.13662696 0.25270611
		 1.12748575 0.25536418 1.11023235 0.23445922 1.17370987 0.28915262 1.15173745 0.26588029
		 1.15047646 0.2752499 1.14237118 0.26162368 1.13608885 0.26874471 1.11021233 0.2603274
		 1.1477778 0.2929588 1.1242125 0.28217542 1.25315928 0.20298249 1.23623157 0.21933198
		 1.23719335 0.22100973 1.24202967 0.20148087 1.25909996 0.22320449 1.23600101 0.21853793
		 1.2393496 0.21798909 1.2393086 0.2220968 1.23382092 0.20497531 1.25052595 0.23046356
		 1.23588252 0.2166124 1.24191952 0.22163397 1.22956562 0.21050918 1.24174547 0.23194796
		 1.23709226 0.21454573 1.24377561 0.21952999 1.2284019 0.21618432 1.23518944 0.22963363
		 1.23953748 0.21355027 1.24391365 0.21666282 1.22902799 0.2210564 1.23112535 0.22551137
		 1.24224019 0.21430379 1.043992758 0.15153217 1.026172638 0.15153217 1.036229372 0.15458807
		 1.052166939 0.14347026 1.049312353 0.14742911 1.035672188 0.14075661 1.039265871
		 0.15126586 1.039311409 0.15497121 1.043762445 0.14550075 1.05672574 0.13460681 1.038477898
		 0.13964772 1.04011941 0.15059352 1.035643339 0.14487883 1.041158199 0.14606735 1.045486689
		 0.14046639 1.056374073 0.1322549 1.03626585 0.14421564 1.036025524 0.13639829 1.042781353
		 0.14096433 1.047770023 0.13082905 1.054448843 0.1277035 1.037996292 0.13371974 1.04586339
		 0.13118918 1.046158791 0.12876035 1.051940203 0.12774505 1.042801142 0.12871404 1.045921326
		 0.1290703 1.043718338 0.1287023 1.016194582 0.10435593 1.028907299 0.10435593 1.027657747
		 0.10872245 1.01651144 0.12046361 1.021802664 0.092077613 1.031639099 0.099877119
		 1.023013592 0.10545349 1.030560017 0.10927773 1.029962063 0.12382412 1.020718575
		 0.13488078 1.035381079 0.10163688 1.044010639 0.10726774 1.051367283 0.12151885 1.036752701
		 0.12441468 1.031892776 0.13193995 1.024290085 0.13965088 1.054565668 0.097299263
		 1.053693056 0.1364274 1.037727356 0.13273197 1.034456491 0.14828229 1.029896021 0.15061975
		 1.051679611 0.1420539 1.037926435 0.14907217 1.033184052 0.15395188 1.029743195 0.15382767
		 1.04619813 0.15286851 1.034756899 0.15487933 1.042001963 0.15656447 1.018118858 0.20461589
		 1.018118858 0.22299391 1.012732506 0.22128594 1.013421774 0.20140564 1.022215128
		 0.24100167 1.013694763 0.241081 1.015485764 0.26876527 1.0065629482 0.26763844 1.000062704086
		 0.26918441 1.000062704086 0.24706435 1.0069532394 0.24755085 1.008054018 0.27035469
		 0.99819672 0.231466 1.0052034855 0.22976243 1.0041055679 0.20373315 1.010788679 0.20309162;
createNode polyAutoProj -n "polyAutoProj5";
	rename -uid "9C1CFB25-4975-01CE-7730-B29271CCE54A";
	setAttr ".cch" yes;
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "f[0:289]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".s" -type "double3" 35.104320526123047 35.104320526123047 35.104320526123047 ;
	setAttr ".o" 0;
	setAttr ".ps" 0.20000000298023224;
	setAttr ".dl" yes;
createNode polyTweakUV -n "polyTweakUV7";
	rename -uid "678F5177-4A31-D49D-779D-798CDCA918D1";
	setAttr ".uopa" yes;
	setAttr -s 457 ".uvtk";
	setAttr ".uvtk[2]" -type "float2" -8.6203218e-06 -0.025026999 ;
	setAttr ".uvtk[3]" -type "float2" -1.2069941e-06 -0.025026821 ;
	setAttr ".uvtk[4]" -type "float2" 5.0738454e-06 -8.2145794e-05 ;
	setAttr ".uvtk[5]" -type "float2" -9.3132257e-07 -0.025018042 ;
	setAttr ".uvtk[6]" -type "float2" -1.0468066e-05 -0.031444397 ;
	setAttr ".uvtk[7]" -type "float2" 2.1606684e-07 -0.031439725 ;
	setAttr ".uvtk[8]" -type "float2" -3.3535063e-05 -0.031430282 ;
	setAttr ".uvtk[9]" -type "float2" -1.0892749e-05 -0.035749301 ;
	setAttr ".uvtk[10]" -type "float2" 3.7401915e-06 -0.035743251 ;
	setAttr ".uvtk[11]" -type "float2" -3.5241246e-05 -0.035769954 ;
	setAttr ".uvtk[12]" -type "float2" 8.3371997e-06 -0.077826835 ;
	setAttr ".uvtk[13]" -type "float2" 1.4796853e-05 -0.077831782 ;
	setAttr ".uvtk[14]" -type "float2" 2.0757318e-05 -0.077837773 ;
	setAttr ".uvtk[15]" -type "float2" 1.0587275e-05 -0.085125789 ;
	setAttr ".uvtk[16]" -type "float2" 1.4819205e-05 -0.085132286 ;
	setAttr ".uvtk[17]" -type "float2" 1.6592443e-05 -0.085120641 ;
	setAttr ".uvtk[18]" -type "float2" -1.0624528e-05 -0.1962024 ;
	setAttr ".uvtk[19]" -type "float2" 3.5762787e-06 -0.19621776 ;
	setAttr ".uvtk[20]" -type "float2" -1.5296042e-05 -0.19619504 ;
	setAttr ".uvtk[21]" -type "float2" -1.2367964e-05 -0.21109846 ;
	setAttr ".uvtk[22]" -type "float2" 3.2708049e-06 -0.21110995 ;
	setAttr ".uvtk[23]" -type "float2" -2.1375716e-05 -0.21109834 ;
	setAttr ".uvtk[24]" -type "float2" -1.3038516e-06 -0.32774144 ;
	setAttr ".uvtk[25]" -type "float2" 1.1086464e-05 -0.32772574 ;
	setAttr ".uvtk[26]" -type "float2" -6.146729e-06 -0.32774612 ;
	setAttr ".uvtk[27]" -type "float2" -3.1292439e-07 -0.33831456 ;
	setAttr ".uvtk[28]" -type "float2" 1.1973083e-05 -0.33829847 ;
	setAttr ".uvtk[29]" -type "float2" -1.2218952e-06 -0.33831754 ;
	setAttr ".uvtk[30]" -type "float2" -4.4256449e-06 -0.45418301 ;
	setAttr ".uvtk[31]" -type "float2" 1.6659498e-05 -0.45418075 ;
	setAttr ".uvtk[32]" -type "float2" -3.1888485e-06 -0.45418036 ;
	setAttr ".uvtk[33]" -type "float2" -7.4952841e-06 -0.46968663 ;
	setAttr ".uvtk[34]" -type "float2" 1.6838312e-05 -0.46968567 ;
	setAttr ".uvtk[35]" -type "float2" -1.2151897e-05 -0.46968096 ;
	setAttr ".uvtk[36]" -type "float2" -2.3707747e-05 -0.57802355 ;
	setAttr ".uvtk[37]" -type "float2" 1.3165176e-05 -0.57801265 ;
	setAttr ".uvtk[38]" -type "float2" -3.4764409e-05 -0.57802314 ;
	setAttr ".uvtk[39]" -type "float2" -2.1018088e-05 -0.59175676 ;
	setAttr ".uvtk[40]" -type "float2" 1.3247132e-05 -0.59174448 ;
	setAttr ".uvtk[41]" -type "float2" -2.5369227e-05 -0.59176272 ;
	setAttr ".uvtk[42]" -type "float2" 4.1425228e-06 -0.67742187 ;
	setAttr ".uvtk[43]" -type "float2" 1.8708408e-05 -0.67741758 ;
	setAttr ".uvtk[44]" -type "float2" 9.2089176e-06 -0.6774264 ;
	setAttr ".uvtk[45]" -type "float2" 3.4421682e-06 -0.69111097 ;
	setAttr ".uvtk[46]" -type "float2" 1.9714236e-05 -0.69111019 ;
	setAttr ".uvtk[47]" -type "float2" 7.4058771e-06 -0.6911031 ;
	setAttr ".uvtk[48]" -type "float2" -2.4266541e-05 -0.76801252 ;
	setAttr ".uvtk[49]" -type "float2" 2.5115907e-05 -0.76801896 ;
	setAttr ".uvtk[50]" -type "float2" -4.0449202e-05 -0.76800525 ;
	setAttr ".uvtk[51]" -type "float2" -2.1517277e-05 -0.79021513 ;
	setAttr ".uvtk[52]" -type "float2" 2.6874244e-05 -0.79021657 ;
	setAttr ".uvtk[53]" -type "float2" -5.5015087e-05 -0.79024923 ;
	setAttr ".uvtk[54]" -type "float2" -2.0667911e-05 -0.79815668 ;
	setAttr ".uvtk[55]" -type "float2" 2.7313828e-05 -0.7981565 ;
	setAttr ".uvtk[56]" -type "float2" -2.7194619e-05 -0.79820687 ;
	setAttr ".uvtk[57]" -type "float2" -8.1062317e-06 -0.80560386 ;
	setAttr ".uvtk[58]" -type "float2" 2.7038157e-05 -0.80560887 ;
	setAttr ".uvtk[59]" -type "float2" 1.6048551e-05 -0.80560797 ;
	setAttr ".uvtk[60]" -type "float2" -6.4000487e-06 -0.81248027 ;
	setAttr ".uvtk[61]" -type "float2" 2.8550625e-05 -0.81248462 ;
	setAttr ".uvtk[62]" -type "float2" 6.146729e-06 -0.81247234 ;
	setAttr ".uvtk[63]" -type "float2" -1.1667609e-05 -0.82339519 ;
	setAttr ".uvtk[64]" -type "float2" 3.3274293e-05 -0.82341069 ;
	setAttr ".uvtk[65]" -type "float2" -2.7880073e-05 -0.82337773 ;
	setAttr ".uvtk[66]" -type "float2" -7.160008e-06 -0.86311007 ;
	setAttr ".uvtk[67]" -type "float2" 3.3557415e-05 -0.86310905 ;
	setAttr ".uvtk[68]" -type "float2" -3.8191676e-05 -0.86312485 ;
	setAttr ".uvtk[69]" -type "float2" 4.4107437e-06 -0.88083643 ;
	setAttr ".uvtk[70]" -type "float2" 3.3192337e-05 -0.88083041 ;
	setAttr ".uvtk[71]" -type "float2" 2.2180378e-05 -0.88088721 ;
	setAttr ".uvtk[73]" -type "float2" -0.0015246421 -0.00077759929 ;
	setAttr ".uvtk[74]" -type "float2" 0.19961888 0.016565703 ;
	setAttr ".uvtk[75]" -type "float2" 0.1931199 0.016682167 ;
	setAttr ".uvtk[76]" -type "float2" -0.017121196 -0.0019555956 ;
	setAttr ".uvtk[77]" -type "float2" -0.014786579 -0.00092060491 ;
	setAttr ".uvtk[79]" -type "float2" 0.19260679 0.016205542 ;
	setAttr ".uvtk[80]" -type "float2" -0.015074864 -0.0012263954 ;
	setAttr ".uvtk[81]" -type "float2" -0.0059885532 0.0094060004 ;
	setAttr ".uvtk[82]" -type "float2" 0.19698882 0.026554003 ;
	setAttr ".uvtk[83]" -type "float2" -0.021587759 0.0081742071 ;
	setAttr ".uvtk[84]" -type "float2" -0.0092149526 0.0060337856 ;
	setAttr ".uvtk[85]" -type "float2" 0.19360933 0.023378104 ;
	setAttr ".uvtk[86]" -type "float2" -0.024753027 0.0047307014 ;
	setAttr ".uvtk[87]" -type "float2" -0.0095032305 0.0055197477 ;
	setAttr ".uvtk[88]" -type "float2" 0.19268419 0.022848591 ;
	setAttr ".uvtk[89]" -type "float2" -0.025003783 0.004192844 ;
	setAttr ".uvtk[90]" -type "float2" 0.18362625 0.014275149 ;
	setAttr ".uvtk[91]" -type "float2" -0.018284932 -0.003433153 ;
	setAttr ".uvtk[92]" -type "float2" -0.033789717 -0.0047682226 ;
	setAttr ".uvtk[93]" -type "float2" 0.18239377 0.013116077 ;
	setAttr ".uvtk[94]" -type "float2" -0.019472972 -0.0046468377 ;
	setAttr ".uvtk[95]" -type "float2" -0.034960754 -0.0060046315 ;
	setAttr ".uvtk[96]" -type "float2" 0.17271192 0.0038877726 ;
	setAttr ".uvtk[97]" -type "float2" -0.028923206 -0.014183104 ;
	setAttr ".uvtk[98]" -type "float2" -0.044405691 -0.015554458 ;
	setAttr ".uvtk[99]" -type "float2" 0.17182364 0.0030448139 ;
	setAttr ".uvtk[100]" -type "float2" -0.029788651 -0.015054047 ;
	setAttr ".uvtk[101]" -type "float2" -0.04526753 -0.016443253 ;
	setAttr ".uvtk[102]" -type "float2" 0.16208617 -0.0062682629 ;
	setAttr ".uvtk[103]" -type "float2" -0.039369896 -0.02459693 ;
	setAttr ".uvtk[104]" -type "float2" -0.05484229 -0.025997519 ;
	setAttr ".uvtk[105]" -type "float2" 0.16077386 -0.0075184703 ;
	setAttr ".uvtk[106]" -type "float2" -0.040662698 -0.02587831 ;
	setAttr ".uvtk[107]" -type "float2" -0.056136511 -0.027291298 ;
	setAttr ".uvtk[108]" -type "float2" 0.15157996 -0.016312122 ;
	setAttr ".uvtk[109]" -type "float2" -0.049771614 -0.034824848 ;
	setAttr ".uvtk[110]" -type "float2" -0.065246895 -0.036244214 ;
	setAttr ".uvtk[111]" -type "float2" 0.15041099 -0.017430604 ;
	setAttr ".uvtk[112]" -type "float2" -0.050928138 -0.035961688 ;
	setAttr ".uvtk[113]" -type "float2" -0.066404462 -0.03738302 ;
	setAttr ".uvtk[114]" -type "float2" 0.14310934 -0.024440289 ;
	setAttr ".uvtk[115]" -type "float2" -0.058166329 -0.043062091 ;
	setAttr ".uvtk[116]" -type "float2" -0.073631391 -0.044486463 ;
	setAttr ".uvtk[117]" -type "float2" 0.14194049 -0.025562465 ;
	setAttr ".uvtk[118]" -type "float2" -0.059331607 -0.04419899 ;
	setAttr ".uvtk[119]" -type "float2" -0.074794352 -0.045644224 ;
	setAttr ".uvtk[120]" -type "float2" 0.13536651 -0.031884253 ;
	setAttr ".uvtk[121]" -type "float2" -0.065897271 -0.050567329 ;
	setAttr ".uvtk[122]" -type "float2" -0.081373438 -0.052005947 ;
	setAttr ".uvtk[123]" -type "float2" 0.13346936 -0.033704042 ;
	setAttr ".uvtk[124]" -type "float2" -0.067793086 -0.052402318 ;
	setAttr ".uvtk[125]" -type "float2" -0.083258241 -0.053830266 ;
	setAttr ".uvtk[126]" -type "float2" 0.13278879 -0.034355402 ;
	setAttr ".uvtk[127]" -type "float2" -0.068472341 -0.05306083 ;
	setAttr ".uvtk[128]" -type "float2" -0.083929069 -0.054491758 ;
	setAttr ".uvtk[129]" -type "float2" 0.1227829 -0.021800399 ;
	setAttr ".uvtk[130]" -type "float2" -0.063490786 -0.039116144 ;
	setAttr ".uvtk[131]" -type "float2" -0.077816099 -0.040469646 ;
	setAttr ".uvtk[132]" -type "float2" 0.1221924 -0.022366107 ;
	setAttr ".uvtk[133]" -type "float2" -0.0640788 -0.039685249 ;
	setAttr ".uvtk[134]" -type "float2" -0.078416139 -0.041027248 ;
	setAttr ".uvtk[135]" -type "float2" 0.13490272 0.0094798207 ;
	setAttr ".uvtk[136]" -type "float2" -0.08209756 -0.010696769 ;
	setAttr ".uvtk[137]" -type "float2" -0.098792769 -0.012240708 ;
	setAttr ".uvtk[138]" -type "float2" 0.13151097 0.0062065125 ;
	setAttr ".uvtk[139]" -type "float2" -0.085477188 -0.013972163 ;
	setAttr ".uvtk[140]" -type "float2" -0.10215398 -0.015514791 ;
	setAttr ".uvtk[141]" -type "float2" 0.12276419 0.010906756 ;
	setAttr ".uvtk[142]" -type "float2" -0.081958942 -0.0081341267 ;
	setAttr ".uvtk[143]" -type "float2" -0.09768676 -0.0096116662 ;
	setAttr ".uvtk[146]" -type "float2" 0 -0.11108594 ;
	setAttr ".uvtk[147]" -type "float2" 0 -0.11108595 ;
	setAttr ".uvtk[150]" -type "float2" 0 -0.11108594 ;
	setAttr ".uvtk[151]" -type "float2" 0 -0.11108594 ;
	setAttr ".uvtk[154]" -type "float2" 0 -0.11661452 ;
	setAttr ".uvtk[155]" -type "float2" 0 -0.11661452 ;
	setAttr ".uvtk[158]" -type "float2" 0 -0.11661449 ;
	setAttr ".uvtk[159]" -type "float2" 0 -0.11661449 ;
	setAttr ".uvtk[162]" -type "float2" 0 -0.11586891 ;
	setAttr ".uvtk[163]" -type "float2" 0 -0.11586891 ;
	setAttr ".uvtk[166]" -type "float2" 0 -0.1158689 ;
	setAttr ".uvtk[167]" -type "float2" 0 -0.1158689 ;
	setAttr ".uvtk[170]" -type "float2" 0 -0.10830784 ;
	setAttr ".uvtk[171]" -type "float2" 0 -0.10830784 ;
	setAttr ".uvtk[174]" -type "float2" 2.9802322e-08 -0.10830782 ;
	setAttr ".uvtk[175]" -type "float2" 0 -0.10830783 ;
	setAttr ".uvtk[178]" -type "float2" 0 -0.085662752 ;
	setAttr ".uvtk[179]" -type "float2" 0 -0.085662752 ;
	setAttr ".uvtk[182]" -type "float2" 0 -0.085662752 ;
	setAttr ".uvtk[183]" -type "float2" 0 -0.08566276 ;
	setAttr ".uvtk[186]" -type "float2" 0 -0.076897211 ;
	setAttr ".uvtk[187]" -type "float2" 0 -0.076897211 ;
	setAttr ".uvtk[190]" -type "float2" 0 -0.076897211 ;
	setAttr ".uvtk[191]" -type "float2" 0 -0.076897211 ;
	setAttr ".uvtk[194]" -type "float2" -0.0032834411 -0.01245201 ;
	setAttr ".uvtk[195]" -type "float2" -0.0038397312 -0.013369067 ;
	setAttr ".uvtk[196]" -type "float2" 0.0071520209 0.0075271577 ;
	setAttr ".uvtk[197]" -type "float2" 0.0035429001 -0.004689971 ;
	setAttr ".uvtk[198]" -type "float2" -0.0035684705 -0.013406482 ;
	setAttr ".uvtk[199]" -type "float2" -0.0041580796 -0.01437789 ;
	setAttr ".uvtk[200]" -type "float2" 0.0041859746 -0.0039837863 ;
	setAttr ".uvtk[201]" -type "float2" 0.0077976584 0.008215948 ;
	setAttr ".uvtk[202]" -type "float2" 0.0032586455 -0.0056337398 ;
	setAttr ".uvtk[203]" -type "float2" 0.0039053559 -0.0048954878 ;
	setAttr ".uvtk[206]" -type "float2" -0.0015864372 -0.013591152 ;
	setAttr ".uvtk[207]" -type "float2" -0.001860559 -0.014038978 ;
	setAttr ".uvtk[208]" -type "float2" -3.5405159e-05 0.0010816322 ;
	setAttr ".uvtk[209]" -type "float2" 0.00012248755 0.0010457363 ;
	setAttr ".uvtk[210]" -type "float2" 0.0036432147 0.0036704745 ;
	setAttr ".uvtk[211]" -type "float2" 0.0018717647 -0.0098196659 ;
	setAttr ".uvtk[212]" -type "float2" 0.0037772059 0.0047041797 ;
	setAttr ".uvtk[213]" -type "float2" 0.0039692521 0.0040133861 ;
	setAttr ".uvtk[214]" -type "float2" 0.002188921 -0.0094771534 ;
	setAttr ".uvtk[215]" -type "float2" 0.0041168928 0.0050498531 ;
	setAttr ".uvtk[218]" -type "float2" 0 0.0152996 ;
	setAttr ".uvtk[219]" -type "float2" 0 0.0152996 ;
	setAttr ".uvtk[222]" -type "float2" 0.032221854 -1.3969839e-09 ;
	setAttr ".uvtk[223]" -type "float2" 0.032221854 -1.8626451e-09 ;
	setAttr ".uvtk[226]" -type "float2" 0.032221735 1.3969839e-09 ;
	setAttr ".uvtk[227]" -type "float2" 0.032221735 -1.8626451e-09 ;
	setAttr ".uvtk[230]" -type "float2" 0.032221794 2.7939677e-09 ;
	setAttr ".uvtk[231]" -type "float2" 0.032221794 -3.7252903e-09 ;
	setAttr ".uvtk[234]" -type "float2" 0.032221854 1.8626451e-09 ;
	setAttr ".uvtk[235]" -type "float2" 0.032221854 -3.7252903e-09 ;
	setAttr ".uvtk[238]" -type "float2" 0.032221854 -1.3969839e-09 ;
	setAttr ".uvtk[239]" -type "float2" 0.032221854 -1.8626451e-09 ;
	setAttr ".uvtk[242]" -type "float2" 0.032221735 1.3969839e-09 ;
	setAttr ".uvtk[243]" -type "float2" 0.032221735 -1.8626451e-09 ;
	setAttr ".uvtk[246]" -type "float2" 0.032221854 0 ;
	setAttr ".uvtk[247]" -type "float2" 0.032221854 0 ;
	setAttr ".uvtk[250]" -type "float2" 0.032221794 0 ;
	setAttr ".uvtk[251]" -type "float2" 0.032221794 0 ;
	setAttr ".uvtk[254]" -type "float2" 0.032221794 3.7252903e-09 ;
	setAttr ".uvtk[255]" -type "float2" 0.032221794 -7.4505806e-09 ;
	setAttr ".uvtk[258]" -type "float2" 0.032221854 0 ;
	setAttr ".uvtk[259]" -type "float2" 0.032221854 -3.7252903e-09 ;
	setAttr ".uvtk[262]" -type "float2" 0.032221794 3.7252903e-09 ;
	setAttr ".uvtk[263]" -type "float2" 0.032221794 -7.4505806e-09 ;
	setAttr ".uvtk[266]" -type "float2" 5.0455332e-05 -0.027310515 ;
	setAttr ".uvtk[267]" -type "float2" 0.00025575864 -0.027016949 ;
	setAttr ".uvtk[268]" -type "float2" -0.0039553083 -0.0026052662 ;
	setAttr ".uvtk[269]" -type "float2" -0.0037262607 -0.029823951 ;
	setAttr ".uvtk[270]" -type "float2" 8.2605518e-05 -0.034225304 ;
	setAttr ".uvtk[271]" -type "float2" 0.00034739939 -0.033901207 ;
	setAttr ".uvtk[272]" -type "float2" -0.0043385848 -0.0028352505 ;
	setAttr ".uvtk[273]" -type "float2" -0.0040911138 -0.030056244 ;
	setAttr ".uvtk[274]" -type "float2" -0.0036885906 -0.036740955 ;
	setAttr ".uvtk[275]" -type "float2" 0.00022170739 -0.039966837 ;
	setAttr ".uvtk[276]" -type "float2" 0.00053734891 -0.039577883 ;
	setAttr ".uvtk[277]" -type "float2" -0.0040577482 -0.036977403 ;
	setAttr ".uvtk[278]" -type "float2" -0.0037456732 -0.042623244 ;
	setAttr ".uvtk[279]" -type "float2" 0.00046415906 -0.085337482 ;
	setAttr ".uvtk[280]" -type "float2" 0.00094842142 -0.084951878 ;
	setAttr ".uvtk[281]" -type "float2" -0.0041583646 -0.042896904 ;
	setAttr ".uvtk[282]" -type "float2" -0.0034935083 -0.088004507 ;
	setAttr ".uvtk[283]" -type "float2" 0.00049972115 -0.093218394 ;
	setAttr ".uvtk[284]" -type "float2" 0.0010125716 -0.092854686 ;
	setAttr ".uvtk[285]" -type "float2" -0.0038843807 -0.088377781 ;
	setAttr ".uvtk[286]" -type "float2" -0.0034428537 -0.095875904 ;
	setAttr ".uvtk[287]" -type "float2" 0.0011686468 -0.21319626 ;
	setAttr ".uvtk[288]" -type "float2" 0.0017317613 -0.21291783 ;
	setAttr ".uvtk[289]" -type "float2" -0.0038087759 -0.096283704 ;
	setAttr ".uvtk[290]" -type "float2" 0.0012467746 -0.22923924 ;
	setAttr ".uvtk[291]" -type "float2" 0.0018016533 -0.22904885 ;
	setAttr ".uvtk[292]" -type "float2" -0.0025286209 -0.21614417 ;
	setAttr ".uvtk[293]" -type "float2" -0.0022081304 -0.2156602 ;
	setAttr ".uvtk[294]" -type "float2" -0.0021238644 -0.23169769 ;
	setAttr ".uvtk[295]" -type "float2" 0.0015717344 -0.35516545 ;
	setAttr ".uvtk[296]" -type "float2" 0.0020784196 -0.35509044 ;
	setAttr ".uvtk[297]" -type "float2" -0.0022951122 -0.23219483 ;
	setAttr ".uvtk[298]" -type "float2" 0.0016077589 -0.36652857 ;
	setAttr ".uvtk[299]" -type "float2" 0.0020630211 -0.36652845 ;
	setAttr ".uvtk[300]" -type "float2" -0.00075087696 -0.35726693 ;
	setAttr ".uvtk[301]" -type "float2" -0.00069820695 -0.356769 ;
	setAttr ".uvtk[302]" -type "float2" -0.00065837428 -0.36812693 ;
	setAttr ".uvtk[303]" -type "float2" 0.0015161932 -0.49132615 ;
	setAttr ".uvtk[304]" -type "float2" 0.0018798863 -0.49142691 ;
	setAttr ".uvtk[305]" -type "float2" -0.0005745329 -0.36855167 ;
	setAttr ".uvtk[306]" -type "float2" 0.0015247278 -0.50794965 ;
	setAttr ".uvtk[307]" -type "float2" 0.0018081032 -0.50813508 ;
	setAttr ".uvtk[308]" -type "float2" 0.00061226636 -0.49202433 ;
	setAttr ".uvtk[309]" -type "float2" 0.0004317034 -0.49167714 ;
	setAttr ".uvtk[310]" -type "float2" 0.00044787675 -0.50829035 ;
	setAttr ".uvtk[311]" -type "float2" 0.0010709926 -0.62427664 ;
	setAttr ".uvtk[312]" -type "float2" 0.0012917891 -0.62453866 ;
	setAttr ".uvtk[313]" -type "float2" 0.00074625015 -0.50845629 ;
	setAttr ".uvtk[314]" -type "float2" 0.0010376847 -0.63897592 ;
	setAttr ".uvtk[315]" -type "float2" 0.0011979984 -0.63929796 ;
	setAttr ".uvtk[316]" -type "float2" 0.0010663792 -0.62335593 ;
	setAttr ".uvtk[317]" -type "float2" 0.00074178725 -0.62328798 ;
	setAttr ".uvtk[318]" -type "float2" 0.00071532093 -0.63797754 ;
	setAttr ".uvtk[319]" -type "float2" 0.00045673968 -0.73080945 ;
	setAttr ".uvtk[320]" -type "float2" 0.00056676567 -0.73117507 ;
	setAttr ".uvtk[321]" -type "float2" 0.001050368 -0.6378879 ;
	setAttr ".uvtk[322]" -type "float2" 0.00039729895 -0.74545723 ;
	setAttr ".uvtk[323]" -type "float2" 0.00045152334 -0.74584514 ;
	setAttr ".uvtk[324]" -type "float2" 0.00074001774 -0.72879481 ;
	setAttr ".uvtk[325]" -type "float2" 0.00045799091 -0.72895145 ;
	setAttr ".uvtk[326]" -type "float2" 0.00040380284 -0.7435903 ;
	setAttr ".uvtk[327]" -type "float2" -0.00017911987 -0.82778347 ;
	setAttr ".uvtk[328]" -type "float2" -0.00014969055 -0.82815009 ;
	setAttr ".uvtk[329]" -type "float2" 0.00063736737 -0.74333864 ;
	setAttr ".uvtk[330]" -type "float2" -0.00029596407 -0.85152334 ;
	setAttr ".uvtk[331]" -type "float2" -0.000309814 -0.85187656 ;
	setAttr ".uvtk[332]" -type "float2" 0.00010039285 -0.82520878 ;
	setAttr ".uvtk[333]" -type "float2" -5.4508448e-05 -0.82545501 ;
	setAttr ".uvtk[334]" -type "float2" -0.00016593747 -0.84918606 ;
	setAttr ".uvtk[335]" -type "float2" -0.0003379886 -0.86001533 ;
	setAttr ".uvtk[336]" -type "float2" -0.0003640973 -0.86035925 ;
	setAttr ".uvtk[337]" -type "float2" -8.0108643e-05 -0.8489117 ;
	setAttr ".uvtk[338]" -type "float2" -0.00020650774 -0.85767651 ;
	setAttr ".uvtk[339]" -type "float2" -0.00039844634 -0.86946708 ;
	setAttr ".uvtk[340]" -type "float2" -0.00043019583 -0.8697446 ;
	setAttr ".uvtk[341]" -type "float2" -0.00014159828 -0.85739899 ;
	setAttr ".uvtk[342]" -type "float2" -0.00027750805 -0.86730158 ;
	setAttr ".uvtk[343]" -type "float2" -0.00043421471 -0.87681872 ;
	setAttr ".uvtk[344]" -type "float2" -0.00046435068 -0.87708396 ;
	setAttr ".uvtk[345]" -type "float2" -0.00026129931 -0.86708176 ;
	setAttr ".uvtk[346]" -type "float2" -0.00031242147 -0.87465256 ;
	setAttr ".uvtk[347]" -type "float2" -0.00056415144 -0.89214706 ;
	setAttr ".uvtk[348]" -type "float2" -0.00059668964 -0.89242506 ;
	setAttr ".uvtk[349]" -type "float2" -0.00029988959 -0.87443995 ;
	setAttr ".uvtk[350]" -type "float2" -0.00042041577 -0.88962054 ;
	setAttr ".uvtk[351]" -type "float2" -0.00076491758 -0.93459553 ;
	setAttr ".uvtk[352]" -type "float2" -0.0007848934 -0.93487024 ;
	setAttr ".uvtk[353]" -type "float2" -0.00042216852 -0.88938755 ;
	setAttr ".uvtk[354]" -type "float2" -0.00062293932 -0.93206984 ;
	setAttr ".uvtk[355]" -type "float2" -0.00086184684 -0.95426029 ;
	setAttr ".uvtk[356]" -type "float2" -0.00087496161 -0.95452315 ;
	setAttr ".uvtk[357]" -type "float2" -0.0006240122 -0.93184477 ;
	setAttr ".uvtk[358]" -type "float2" -0.00072787516 -0.95187712 ;
	setAttr ".uvtk[359]" -type "float2" -0.00072395429 -0.95167023 ;
	setAttr ".uvtk[361]" -type "float2" 0.039034076 -0.015534818 ;
	setAttr ".uvtk[362]" -type "float2" 0.040024459 -0.021067858 ;
	setAttr ".uvtk[363]" -type "float2" 7.0299953e-05 -0.0038924813 ;
	setAttr ".uvtk[364]" -type "float2" 0.037181899 -0.013400972 ;
	setAttr ".uvtk[366]" -type "float2" 0.36048359 -0.14297104 ;
	setAttr ".uvtk[367]" -type "float2" 0.37476331 -0.15391105 ;
	setAttr ".uvtk[368]" -type "float2" 0.35862288 -0.14079928 ;
	setAttr ".uvtk[369]" -type "float2" 0.02634339 -0.010358214 ;
	setAttr ".uvtk[370]" -type "float2" -0.012586173 0.0038571954 ;
	setAttr ".uvtk[371]" -type "float2" 0.38927555 -0.1543895 ;
	setAttr ".uvtk[372]" -type "float2" 0.404726 -0.16584498 ;
	setAttr ".uvtk[373]" -type "float2" 0.38742179 -0.1522159 ;
	setAttr ".uvtk[374]" -type "float2" 0.36515141 -0.14457661 ;
	setAttr ".uvtk[375]" -type "float2" 0.014246445 0.003841579 ;
	setAttr ".uvtk[376]" -type "float2" -0.024351727 0.018802106 ;
	setAttr ".uvtk[377]" -type "float2" 0.39551166 -0.15661186 ;
	setAttr ".uvtk[378]" -type "float2" 0.35294479 -0.13033432 ;
	setAttr ".uvtk[379]" -type "float2" 0.012637094 0.0061093569 ;
	setAttr ".uvtk[380]" -type "float2" -0.025866466 0.021158278 ;
	setAttr ".uvtk[381]" -type "float2" 0.38332063 -0.14237595 ;
	setAttr ".uvtk[382]" -type "float2" 0.35030025 -0.12766099 ;
	setAttr ".uvtk[383]" -type "float2" -0.058085587 0.059181213 ;
	setAttr ".uvtk[384]" -type "float2" -0.019465821 0.043828666 ;
	setAttr ".uvtk[385]" -type "float2" 0.38058513 -0.13966858 ;
	setAttr ".uvtk[386]" -type "float2" 0.31806371 -0.090051472 ;
	setAttr ".uvtk[387]" -type "float2" -0.062430166 0.064252734 ;
	setAttr ".uvtk[388]" -type "float2" -0.023777694 0.048886061 ;
	setAttr ".uvtk[389]" -type "float2" 0.34834176 -0.10206825 ;
	setAttr ".uvtk[390]" -type "float2" 0.31374055 -0.085006952 ;
	setAttr ".uvtk[391]" -type "float2" -0.096280307 0.10386074 ;
	setAttr ".uvtk[392]" -type "float2" -0.05758334 0.088478982 ;
	setAttr ".uvtk[393]" -type "float2" 0.34401059 -0.097025871 ;
	setAttr ".uvtk[394]" -type "float2" 0.27988306 -0.045493364 ;
	setAttr ".uvtk[395]" -type "float2" -0.099351272 0.10745627 ;
	setAttr ".uvtk[396]" -type "float2" -0.060649902 0.092067659 ;
	setAttr ".uvtk[397]" -type "float2" 0.31013906 -0.057517409 ;
	setAttr ".uvtk[398]" -type "float2" 0.27681422 -0.041907072 ;
	setAttr ".uvtk[399]" -type "float2" -0.13297215 0.14677465 ;
	setAttr ".uvtk[400]" -type "float2" -0.094259836 0.13140011 ;
	setAttr ".uvtk[401]" -type "float2" 0.30706736 -0.053933322 ;
	setAttr ".uvtk[402]" -type "float2" 0.24317375 -0.0026188791 ;
	setAttr ".uvtk[403]" -type "float2" -0.13746923 0.15203217 ;
	setAttr ".uvtk[404]" -type "float2" -0.09875726 0.13666192 ;
	setAttr ".uvtk[405]" -type "float2" 0.2734302 -0.014637679 ;
	setAttr ".uvtk[406]" -type "float2" 0.23867258 0.002638489 ;
	setAttr ".uvtk[407]" -type "float2" -0.16886947 0.18881369 ;
	setAttr ".uvtk[408]" -type "float2" -0.13018122 0.17342418 ;
	setAttr ".uvtk[409]" -type "float2" 0.26893026 -0.0093835592 ;
	setAttr ".uvtk[410]" -type "float2" 0.2072174 0.039373368 ;
	setAttr ".uvtk[411]" -type "float2" -0.17286015 0.19348103 ;
	setAttr ".uvtk[412]" -type "float2" -0.13416649 0.17808461 ;
	setAttr ".uvtk[413]" -type "float2" 0.23746619 0.027333021 ;
	setAttr ".uvtk[414]" -type "float2" 0.20322901 0.044031799 ;
	setAttr ".uvtk[415]" -type "float2" -0.19774613 0.22254953 ;
	setAttr ".uvtk[416]" -type "float2" -0.15903863 0.20716038 ;
	setAttr ".uvtk[417]" -type "float2" 0.23346943 0.031992167 ;
	setAttr ".uvtk[418]" -type "float2" 0.17834499 0.073100239 ;
	setAttr ".uvtk[419]" -type "float2" -0.20172429 0.22719203 ;
	setAttr ".uvtk[420]" -type "float2" -0.16301391 0.21180741 ;
	setAttr ".uvtk[421]" -type "float2" 0.20857808 0.061082304 ;
	setAttr ".uvtk[422]" -type "float2" 0.17436871 0.077745602 ;
	setAttr ".uvtk[423]" -type "float2" -0.22406158 0.25330019 ;
	setAttr ".uvtk[424]" -type "float2" -0.18534337 0.23791026 ;
	setAttr ".uvtk[425]" -type "float2" 0.20461103 0.065733209 ;
	setAttr ".uvtk[426]" -type "float2" 0.1520361 0.10383292 ;
	setAttr ".uvtk[427]" -type "float2" -0.23050836 0.26082644 ;
	setAttr ".uvtk[428]" -type "float2" -0.19178863 0.24544391 ;
	setAttr ".uvtk[429]" -type "float2" 0.18228745 0.09180747 ;
	setAttr ".uvtk[430]" -type "float2" 0.14559031 0.11136285 ;
	setAttr ".uvtk[431]" -type "float2" -0.23281175 0.26351827 ;
	setAttr ".uvtk[432]" -type "float2" -0.19409411 0.24813905 ;
	setAttr ".uvtk[433]" -type "float2" 0.17583218 0.099324338 ;
	setAttr ".uvtk[434]" -type "float2" 0.14328462 0.11405701 ;
	setAttr ".uvtk[435]" -type "float2" -0.2213442 0.25781038 ;
	setAttr ".uvtk[436]" -type "float2" -0.18551823 0.24357483 ;
	setAttr ".uvtk[437]" -type "float2" 0.17352346 0.10201836 ;
	setAttr ".uvtk[438]" -type "float2" 0.12673146 0.11947792 ;
	setAttr ".uvtk[439]" -type "float2" -0.2233389 0.26014704 ;
	setAttr ".uvtk[440]" -type "float2" -0.18751386 0.2459079 ;
	setAttr ".uvtk[441]" -type "float2" 0.15472424 0.10834753 ;
	setAttr ".uvtk[442]" -type "float2" 0.12473501 0.12181004 ;
	setAttr ".uvtk[443]" -type "float2" -0.26112297 0.27071589 ;
	setAttr ".uvtk[444]" -type "float2" -0.21936494 0.25410944 ;
	setAttr ".uvtk[445]" -type "float2" 0.1527302 0.11067947 ;
	setAttr ".uvtk[446]" -type "float2" 0.14440873 0.10953023 ;
	setAttr ".uvtk[447]" -type "float2" -0.27265245 0.2841762 ;
	setAttr ".uvtk[448]" -type "float2" -0.23088998 0.26757964 ;
	setAttr ".uvtk[449]" -type "float2" 0.1769973 0.09654595 ;
	setAttr ".uvtk[450]" -type "float2" 0.13288361 0.12300169 ;
	setAttr ".uvtk[451]" -type "float2" -0.26603049 0.28447628 ;
	setAttr ".uvtk[452]" -type "float2" -0.22663584 0.26882529 ;
	setAttr ".uvtk[453]" -type "float2" 0.16546218 0.11003879 ;
	setAttr ".uvtk[454]" -type "float2" 0.11657852 0.13241935 ;
	setAttr ".uvtk[455]" -type "float2" 0.14732984 0.12020096 ;
	setAttr ".uvtk[458]" -type "float2" -1.0877848e-05 -0.11885376 ;
	setAttr ".uvtk[459]" -type "float2" 1.0788441e-05 -0.11885373 ;
	setAttr ".uvtk[460]" -type "float2" -1.1727214e-05 -0.13478824 ;
	setAttr ".uvtk[461]" -type "float2" 1.1622906e-05 -0.1347882 ;
	setAttr ".uvtk[462]" -type "float2" -1.3396144e-05 -0.25955737 ;
	setAttr ".uvtk[463]" -type "float2" 1.335144e-05 -0.25955746 ;
	setAttr ".uvtk[464]" -type "float2" -1.3411045e-05 -0.27086818 ;
	setAttr ".uvtk[465]" -type "float2" 1.3202429e-05 -0.270868 ;
	setAttr ".uvtk[466]" -type "float2" -1.02669e-05 -0.39483282 ;
	setAttr ".uvtk[467]" -type "float2" 1.0237098e-05 -0.39483273 ;
	setAttr ".uvtk[468]" -type "float2" -9.5814466e-06 -0.41141766 ;
	setAttr ".uvtk[469]" -type "float2" 9.5069408e-06 -0.41141739 ;
	setAttr ".uvtk[470]" -type "float2" -4.1723251e-06 -0.52728289 ;
	setAttr ".uvtk[471]" -type "float2" 3.9488077e-06 -0.52728325 ;
	setAttr ".uvtk[472]" -type "float2" -3.7401915e-06 -0.54197127 ;
	setAttr ".uvtk[473]" -type "float2" 3.7848949e-06 -0.54197085 ;
	setAttr ".uvtk[474]" -type "float2" -4.157424e-06 -0.63360673 ;
	setAttr ".uvtk[475]" -type "float2" 3.7401915e-06 -0.63360685 ;
	setAttr ".uvtk[476]" -type "float2" -3.2782555e-06 -0.64825267 ;
	setAttr ".uvtk[477]" -type "float2" 3.8295984e-06 -0.64825237 ;
	setAttr ".uvtk[478]" -type "float2" -4.9620867e-06 -0.73051 ;
	setAttr ".uvtk[479]" -type "float2" 4.8875809e-06 -0.73051012 ;
	setAttr ".uvtk[480]" -type "float2" -5.2750111e-06 -0.75425291 ;
	setAttr ".uvtk[481]" -type "float2" 4.9471855e-06 -0.75425231 ;
	setAttr ".uvtk[482]" -type "float2" -5.8561563e-06 -0.76274604 ;
	setAttr ".uvtk[483]" -type "float2" 6.1243773e-06 -0.76274645 ;
	setAttr ".uvtk[484]" -type "float2" -5.5730343e-06 -0.77233064 ;
	setAttr ".uvtk[485]" -type "float2" 5.8859587e-06 -0.77233106 ;
	setAttr ".uvtk[486]" -type "float2" -5.7816505e-06 -0.77968448 ;
	setAttr ".uvtk[487]" -type "float2" 5.4091215e-06 -0.77968401 ;
	setAttr ".uvtk[488]" -type "float2" -7.4952841e-06 -0.79494399 ;
	setAttr ".uvtk[489]" -type "float2" 7.5697899e-06 -0.79494405 ;
	setAttr ".uvtk[490]" -type "float2" -8.508563e-06 -0.83740497 ;
	setAttr ".uvtk[491]" -type "float2" 8.4936619e-06 -0.83740509 ;
	setAttr ".uvtk[492]" -type "float2" -7.9721212e-06 -0.85716379 ;
	setAttr ".uvtk[493]" -type "float2" 8.0764294e-06 -0.85716373 ;
	setAttr ".uvtk[496]" -type "float2" 0.49408802 -2.6896596e-06 ;
	setAttr ".uvtk[497]" -type "float2" 0.49408498 -4.0531158e-06 ;
	setAttr ".uvtk[498]" -type "float2" 5.9604645e-08 -1.065433e-06 ;
	setAttr ".uvtk[499]" -type "float2" 0.49408862 -2.1085143e-06 ;
	setAttr ".uvtk[500]" -type "float2" 0.017937675 -0.0030504391 ;
	setAttr ".uvtk[501]" -type "float2" 0.47522572 -0.0030497909 ;
	setAttr ".uvtk[502]" -type "float2" 0.017937511 -0.0030523762 ;
	setAttr ".uvtk[503]" -type "float2" 0.47522536 -0.0030490831 ;
	setAttr ".uvtk[504]" -type "float2" -0.018849432 -0.010532491 ;
	setAttr ".uvtk[505]" -type "float2" 0.51390386 -0.01052314 ;
	setAttr ".uvtk[506]" -type "float2" -0.01884985 -0.010539495 ;
	setAttr ".uvtk[507]" -type "float2" 0.51390529 -0.010521587 ;
	setAttr ".uvtk[508]" -type "float2" -0.0041702092 -0.011662041 ;
	setAttr ".uvtk[509]" -type "float2" 0.49847552 -0.01164438 ;
	setAttr ".uvtk[512]" -type "float2" 0.0073197484 -0.00021696836 ;
	setAttr ".uvtk[513]" -type "float2" -0.0073197484 -0.00021696836 ;
	setAttr ".uvtk[516]" -type "float2" 0.0073406696 -0.0002182126 ;
	setAttr ".uvtk[517]" -type "float2" -0.0073406696 -0.0002182126 ;
	setAttr ".uvtk[520]" -type "float2" 0.0082871914 -0.0002781488 ;
	setAttr ".uvtk[521]" -type "float2" -0.0082871914 -0.0002781488 ;
	setAttr ".uvtk[524]" -type "float2" 0.0056533217 -0.00012939796 ;
	setAttr ".uvtk[525]" -type "float2" -0.0056533217 -0.00012939796 ;
	setAttr ".uvtk[528]" -type "float2" 0.0079618692 -0.00025672466 ;
	setAttr ".uvtk[529]" -type "float2" -0.0079618692 -0.00025672466 ;
createNode polyPlanarProj -n "polyPlanarProj2";
	rename -uid "2039B89D-4644-5721-2E22-6B9DEF50A7ED";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "f[0:289]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".ws" yes;
	setAttr ".pc" -type "double3" -0.16421890258789062 19.115663528442383 -4.4741473197937012 ;
	setAttr ".ro" -type "double3" -14.138352716854536 -32.199999110326175 -6.8691593411765622e-08 ;
	setAttr ".ps" -type "double2" 25.420264536283291 38.851225138819593 ;
	setAttr ".per" yes;
	setAttr ".cam" -type "matrix" 1.6453756093978882 0.22169908881187439 0.51674509048461914 0.516734778881073
		 8.1739749574957473e-19 1.6516538858413696 -0.24426905810832977 -0.24426417052745819
		 1.0361483097076416 -0.35205218195915222 -0.82057732343673706 -0.82056087255477905
		 -4.9418096542358398 -21.041034698486328 54.285945892333984 54.484859466552734;
	setAttr ".prgt" 1031;
	setAttr ".ptop" 1177;
createNode polyMapCut -n "polyMapCut9";
	rename -uid "02D596FE-4548-6560-B492-C2A690A7D91D";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 12 "e[436]" "e[439]" "e[444:445]" "e[448:449]" "e[452]" "e[454:456]" "e[460]" "e[463]" "e[468:469]" "e[472:473]" "e[476]" "e[478:480]";
createNode polyMapCut -n "polyMapCut10";
	rename -uid "67A2E154-4BB1-8350-B43A-5A94434A0FA5";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 12 "e[1:2]" "e[6:7]" "e[14]" "e[16]" "e[18:19]" "e[45:46]" "e[53:54]" "e[69:70]" "e[77:78]" "e[92]" "e[97:98]" "e[105]";
createNode polyMapCut -n "polyMapCut11";
	rename -uid "B3AD8B5F-4D70-6781-9411-26B194E80E97";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 86 "e[4:5]" "e[8:9]" "e[12:13]" "e[15]" "e[17]" "e[20:21]" "e[23]" "e[25]" "e[28:29]" "e[31]" "e[33]" "e[36:37]" "e[39]" "e[41]" "e[120]" "e[131]" "e[135]" "e[141]" "e[144]" "e[155]" "e[159]" "e[165]" "e[168]" "e[179]" "e[183]" "e[189]" "e[192]" "e[203]" "e[207]" "e[213]" "e[216]" "e[227]" "e[231]" "e[237]" "e[240]" "e[251]" "e[255]" "e[261]" "e[264]" "e[275]" "e[279]" "e[285]" "e[288]" "e[299]" "e[303]" "e[309]" "e[312]" "e[323]" "e[327]" "e[333]" "e[336]" "e[347]" "e[351]" "e[357]" "e[360]" "e[371]" "e[375]" "e[381]" "e[384]" "e[393]" "e[397]" "e[403]" "e[410]" "e[419]" "e[423]" "e[429]" "e[434]" "e[443]" "e[447]" "e[453]" "e[458]" "e[467]" "e[471]" "e[477]" "e[482]" "e[491]" "e[495]" "e[501]" "e[506]" "e[515]" "e[519]" "e[525]" "e[530]" "e[543]" "e[548]" "e[555]";
createNode polyMapCut -n "polyMapCut12";
	rename -uid "93635F41-4503-B567-B466-22A40C0F6314";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 6 "e[532]" "e[537]" "e[544:545]" "e[549:550]" "e[554]" "e[556:558]";
createNode polyMapCut -n "polyMapCut13";
	rename -uid "054775E5-4BBA-5EAA-384D-56B41FCB7C96";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 19 "e[73]" "e[121]" "e[129]" "e[169]" "e[177]" "e[217]" "e[225]" "e[265]" "e[273]" "e[313]" "e[321]" "e[361]" "e[369]" "e[409]" "e[562:563]" "e[566:567]" "e[570:571]" "e[574:575]" "e[578:579]";
createNode polyTweakUV -n "polyTweakUV8";
	rename -uid "52335C15-4641-DD9C-E818-8DAC6FA775DE";
	setAttr ".uopa" yes;
	setAttr -s 427 ".uvtk";
	setAttr ".uvtk[1]" -type "float2" -0.073982984 -0.06354294 ;
	setAttr ".uvtk[3]" -type "float2" 0.00065541267 -1.0142103e-05 ;
	setAttr ".uvtk[6]" -type "float2" 0.079929233 0.086510658 ;
	setAttr ".uvtk[7]" -type "float2" 0.12846033 0.093262196 ;
	setAttr ".uvtk[8]" -type "float2" -0.14611137 0.020026363 ;
	setAttr ".uvtk[9]" -type "float2" -0.25768578 -0.060578678 ;
	setAttr ".uvtk[10]" -type "float2" -0.22194457 -0.042844575 ;
	setAttr ".uvtk[11]" -type "float2" -0.15341187 0.017284401 ;
	setAttr ".uvtk[12]" -type "float2" -0.14183277 0.015272819 ;
	setAttr ".uvtk[13]" -type "float2" -0.21072313 -0.045051377 ;
	setAttr ".uvtk[14]" -type "float2" -0.68562782 -0.64252377 ;
	setAttr ".uvtk[15]" -type "float2" -0.79162371 -0.60117102 ;
	setAttr ".uvtk[17]" -type "float2" 0.00072264671 0.00025299191 ;
	setAttr ".uvtk[20]" -type "float2" 0.0082556754 0.002029717 ;
	setAttr ".uvtk[22]" -type "float2" 0.0050843954 0.0013185591 ;
	setAttr ".uvtk[24]" -type "float2" -0.0095530078 -0.0060320199 ;
	setAttr ".uvtk[26]" -type "float2" -0.0018872172 0.0042941049 ;
	setAttr ".uvtk[27]" -type "float2" 0.0075589269 0.0065679476 ;
	setAttr ".uvtk[28]" -type "float2" -0.002679646 0.0021255314 ;
	setAttr ".uvtk[29]" -type "float2" 0.0021312833 0.0056889206 ;
	setAttr ".uvtk[33]" -type "float2" -0.0083461255 -0.0011330768 ;
	setAttr ".uvtk[34]" -type "float2" 0.0014986992 0.00041700155 ;
	setAttr ".uvtk[35]" -type "float2" 0.0033558607 5.7160854e-05 ;
	setAttr ".uvtk[36]" -type "float2" -0.0074252486 0.0061727613 ;
	setAttr ".uvtk[37]" -type "float2" -0.02781 -0.056075461 ;
	setAttr ".uvtk[38]" -type "float2" -0.008646071 -0.0078535378 ;
	setAttr ".uvtk[39]" -type "float2" -0.00064997375 0.00020645559 ;
	setAttr ".uvtk[40]" -type "float2" -0.042322889 0.92905062 ;
	setAttr ".uvtk[41]" -type "float2" 0.00038583577 -0.00086546689 ;
	setAttr ".uvtk[42]" -type "float2" 0.0045926571 1.7955899e-05 ;
	setAttr ".uvtk[43]" -type "float2" -0.2480146 0.077815488 ;
	setAttr ".uvtk[44]" -type "float2" -0.032975823 -0.066372491 ;
	setAttr ".uvtk[45]" -type "float2" -0.011610724 -0.0070754588 ;
	setAttr ".uvtk[46]" -type "float2" -0.0015632585 0.0003169179 ;
	setAttr ".uvtk[48]" -type "float2" -0.64042795 -0.59626383 ;
	setAttr ".uvtk[50]" -type "float2" -0.0033536553 0.0042717308 ;
	setAttr ".uvtk[51]" -type "float2" -0.012720585 0.0045018792 ;
	setAttr ".uvtk[52]" -type "float2" -0.014248133 0.0043830723 ;
	setAttr ".uvtk[54]" -type "float2" -0.31367633 0.13501215 ;
	setAttr ".uvtk[55]" -type "float2" -0.42395359 0.086681247 ;
	setAttr ".uvtk[56]" -type "float2" -0.047962129 -0.052954257 ;
	setAttr ".uvtk[57]" -type "float2" 0.021931767 -0.0068889707 ;
	setAttr ".uvtk[58]" -type "float2" -0.13107949 -0.45669878 ;
	setAttr ".uvtk[59]" -type "float2" -0.13639826 -0.46503443 ;
	setAttr ".uvtk[60]" -type "float2" -0.14092159 -0.49982312 ;
	setAttr ".uvtk[61]" -type "float2" 0.011185884 -0.0067792684 ;
	setAttr ".uvtk[62]" -type "float2" -0.10082698 -0.40505916 ;
	setAttr ".uvtk[64]" -type "float2" -0.67541534 -0.093158983 ;
	setAttr ".uvtk[66]" -type "float2" -0.77351576 -0.54814112 ;
	setAttr ".uvtk[67]" -type "float2" -0.75718647 -0.55281782 ;
	setAttr ".uvtk[68]" -type "float2" -0.80063909 -0.59751618 ;
	setAttr ".uvtk[69]" -type "float2" -0.74804229 -0.55637205 ;
	setAttr ".uvtk[70]" -type "float2" -0.31571829 0.79191852 ;
	setAttr ".uvtk[71]" -type "float2" 0.028192595 0.86017197 ;
	setAttr ".uvtk[73]" -type "float2" 0.0063824654 -0.00078368187 ;
	setAttr ".uvtk[76]" -type "float2" -0.03648667 0.8222729 ;
	setAttr ".uvtk[77]" -type "float2" -0.015285656 -0.020338207 ;
	setAttr ".uvtk[78]" -type "float2" 0.034645915 0.76588881 ;
	setAttr ".uvtk[79]" -type "float2" -0.0081733242 0.0021720678 ;
	setAttr ".uvtk[80]" -type "float2" -0.037993312 0.0018981397 ;
	setAttr ".uvtk[81]" -type "float2" -0.3159247 0.71034521 ;
	setAttr ".uvtk[82]" -type "float2" -0.23619041 0.064774901 ;
	setAttr ".uvtk[83]" -type "float2" 0.019932091 -0.0042153299 ;
	setAttr ".uvtk[84]" -type "float2" -0.22121987 -0.63724458 ;
	setAttr ".uvtk[85]" -type "float2" -0.21628276 -0.60339558 ;
	setAttr ".uvtk[86]" -type "float2" -0.10625575 -0.2170459 ;
	setAttr ".uvtk[87]" -type "float2" -0.018789049 -0.0039406419 ;
	setAttr ".uvtk[88]" -type "float2" -0.0285604 -0.022264555 ;
	setAttr ".uvtk[89]" -type "float2" -0.017380014 -0.023304343 ;
	setAttr ".uvtk[90]" -type "float2" -0.0090648308 0.0022307634 ;
	setAttr ".uvtk[91]" -type "float2" -0.23461393 0.062826991 ;
	setAttr ".uvtk[92]" -type "float2" -0.4192605 0.73801029 ;
	setAttr ".uvtk[93]" -type "float2" 0.021975935 -0.0049315691 ;
	setAttr ".uvtk[94]" -type "float2" -0.23198411 -0.65587282 ;
	setAttr ".uvtk[95]" -type "float2" -0.22699614 -0.6221512 ;
	setAttr ".uvtk[96]" -type "float2" -0.31594872 0.69920009 ;
	setAttr ".uvtk[97]" -type "float2" 0.035527378 0.75296676 ;
	setAttr ".uvtk[98]" -type "float2" -0.11606609 -0.23752208 ;
	setAttr ".uvtk[99]" -type "float2" -0.019786932 -0.0037165582 ;
	setAttr ".uvtk[100]" -type "float2" -0.029253989 0.68949056 ;
	setAttr ".uvtk[101]" -type "float2" -0.033258244 -0.049627483 ;
	setAttr ".uvtk[102]" -type "float2" 0.042548828 0.64940304 ;
	setAttr ".uvtk[103]" -type "float2" -0.015742075 0.0008213222 ;
	setAttr ".uvtk[104]" -type "float2" -0.065678418 -0.0052837729 ;
	setAttr ".uvtk[105]" -type "float2" -0.31609148 0.6101917 ;
	setAttr ".uvtk[106]" -type "float2" -0.22203881 0.045731246 ;
	setAttr ".uvtk[107]" -type "float2" 0.037808895 -0.011893004 ;
	setAttr ".uvtk[108]" -type "float2" -0.31636068 -0.80341458 ;
	setAttr ".uvtk[109]" -type "float2" -0.31092203 -0.7707634 ;
	setAttr ".uvtk[110]" -type "float2" -0.1927647 -0.40020898 ;
	setAttr ".uvtk[111]" -type "float2" -0.026498582 -0.0041007698 ;
	setAttr ".uvtk[112]" -type "float2" -0.04733482 -0.048494071 ;
	setAttr ".uvtk[113]" -type "float2" -0.034689523 -0.052285761 ;
	setAttr ".uvtk[114]" -type "float2" -0.016344164 0.00050407648 ;
	setAttr ".uvtk[115]" -type "float2" -0.22090438 0.044016302 ;
	setAttr ".uvtk[116]" -type "float2" -0.42171943 0.62918735 ;
	setAttr ".uvtk[117]" -type "float2" 0.039246678 -0.012649953 ;
	setAttr ".uvtk[118]" -type "float2" -0.324009 -0.81695211 ;
	setAttr ".uvtk[119]" -type "float2" -0.31853396 -0.78439283 ;
	setAttr ".uvtk[120]" -type "float2" -0.31610298 0.60196215 ;
	setAttr ".uvtk[121]" -type "float2" 0.043196626 0.63979685 ;
	setAttr ".uvtk[122]" -type "float2" -0.19970638 -0.41516963 ;
	setAttr ".uvtk[123]" -type "float2" -0.027170591 -0.0043339133 ;
	setAttr ".uvtk[124]" -type "float2" -0.022046462 0.55482852 ;
	setAttr ".uvtk[125]" -type "float2" -0.049842112 -0.084737301 ;
	setAttr ".uvtk[126]" -type "float2" 0.050376192 0.53210974 ;
	setAttr ".uvtk[127]" -type "float2" -0.022657491 -0.0051673353 ;
	setAttr ".uvtk[128]" -type "float2" -0.091905087 -0.016669571 ;
	setAttr ".uvtk[129]" -type "float2" -0.31615365 0.51000631 ;
	setAttr ".uvtk[130]" -type "float2" -0.20830563 0.023217976 ;
	setAttr ".uvtk[131]" -type "float2" 0.054874837 -0.02241075 ;
	setAttr ".uvtk[132]" -type "float2" -0.40795377 -0.96694517 ;
	setAttr ".uvtk[133]" -type "float2" -0.40200257 -0.93553519 ;
	setAttr ".uvtk[134]" -type "float2" -0.27567202 -0.58155632 ;
	setAttr ".uvtk[135]" -type "float2" -0.033511955 -0.0089007914 ;
	setAttr ".uvtk[136]" -type "float2" -0.066081986 -0.082574308 ;
	setAttr ".uvtk[137]" -type "float2" -0.051846415 -0.089527071 ;
	setAttr ".uvtk[138]" -type "float2" -0.023485981 -0.0062528551 ;
	setAttr ".uvtk[139]" -type "float2" -0.2066277 0.020150781 ;
	setAttr ".uvtk[140]" -type "float2" -0.42423445 0.51153535 ;
	setAttr ".uvtk[141]" -type "float2" 0.056959689 -0.023936093 ;
	setAttr ".uvtk[142]" -type "float2" -0.41918701 -0.98726356 ;
	setAttr ".uvtk[143]" -type "float2" -0.41317585 -0.95600677 ;
	setAttr ".uvtk[144]" -type "float2" -0.31615323 0.49744248 ;
	setAttr ".uvtk[145]" -type "float2" 0.051351286 0.5173493 ;
	setAttr ".uvtk[146]" -type "float2" -0.28581694 -0.60416263 ;
	setAttr ".uvtk[147]" -type "float2" -0.034392826 -0.0098326802 ;
	setAttr ".uvtk[148]" -type "float2" -0.014785305 0.41587663 ;
	setAttr ".uvtk[149]" -type "float2" -0.065355912 -0.12624371 ;
	setAttr ".uvtk[150]" -type "float2" 0.05816637 0.4119162 ;
	setAttr ".uvtk[151]" -type "float2" -0.029011501 -0.016112864 ;
	setAttr ".uvtk[152]" -type "float2" -0.11738577 -0.031947911 ;
	setAttr ".uvtk[153]" -type "float2" -0.31597307 0.4079805 ;
	setAttr ".uvtk[154]" -type "float2" -0.19483355 -0.0033276677 ;
	setAttr ".uvtk[155]" -type "float2" 0.071401715 -0.036161721 ;
	setAttr ".uvtk[156]" -type "float2" -0.49775839 -1.1308241 ;
	setAttr ".uvtk[157]" -type "float2" -0.49128094 -1.1007332 ;
	setAttr ".uvtk[158]" -type "float2" -0.35656449 -0.7644847 ;
	setAttr ".uvtk[159]" -type "float2" -0.039944522 -0.018553257 ;
	setAttr ".uvtk[160]" -type "float2" -0.082872324 -0.12107044 ;
	setAttr ".uvtk[161]" -type "float2" -0.06703113 -0.13128892 ;
	setAttr ".uvtk[162]" -type "float2" -0.029686417 -0.017664373 ;
	setAttr ".uvtk[163]" -type "float2" -0.19334266 -0.0065650344 ;
	setAttr ".uvtk[164]" -type "float2" -0.42648429 0.39724654 ;
	setAttr ".uvtk[165]" -type "float2" 0.073230445 -0.037912667 ;
	setAttr ".uvtk[166]" -type "float2" -0.5077185 -1.1492448 ;
	setAttr ".uvtk[167]" -type "float2" -0.50118607 -1.1192964 ;
	setAttr ".uvtk[168]" -type "float2" -0.31594068 0.39640796 ;
	setAttr ".uvtk[169]" -type "float2" 0.059038267 0.39823437 ;
	setAttr ".uvtk[170]" -type "float2" -0.36551601 -0.78511333 ;
	setAttr ".uvtk[171]" -type "float2" -0.04064735 -0.019947588 ;
	setAttr ".uvtk[172]" -type "float2" -0.0088900924 0.29881668 ;
	setAttr ".uvtk[173]" -type "float2" -0.077116065 -0.1651212 ;
	setAttr ".uvtk[174]" -type "float2" 0.06431479 0.31136829 ;
	setAttr ".uvtk[175]" -type "float2" -0.033712141 -0.02896148 ;
	setAttr ".uvtk[176]" -type "float2" -0.13793504 -0.04739964 ;
	setAttr ".uvtk[177]" -type "float2" -0.31544414 0.32308608 ;
	setAttr ".uvtk[178]" -type "float2" -0.18402243 -0.028175175 ;
	setAttr ".uvtk[179]" -type "float2" 0.084584534 -0.049877703 ;
	setAttr ".uvtk[180]" -type "float2" -0.56993663 -1.2652085 ;
	setAttr ".uvtk[181]" -type "float2" -0.56300873 -1.2362454 ;
	setAttr ".uvtk[182]" -type "float2" -0.42127326 -0.91542971 ;
	setAttr ".uvtk[183]" -type "float2" -0.044690244 -0.030255318 ;
	setAttr ".uvtk[184]" -type "float2" -0.095956072 -0.15773863 ;
	setAttr ".uvtk[185]" -type "float2" -0.078690499 -0.17088842 ;
	setAttr ".uvtk[186]" -type "float2" -0.034328569 -0.031037927 ;
	setAttr ".uvtk[187]" -type "float2" -0.18253586 -0.031861663 ;
	setAttr ".uvtk[188]" -type "float2" -0.42796141 0.30023837 ;
	setAttr ".uvtk[189]" -type "float2" 0.086388886 -0.051970541 ;
	setAttr ".uvtk[190]" -type "float2" -0.57987815 -1.2839224 ;
	setAttr ".uvtk[191]" -type "float2" -0.57289189 -1.2551208 ;
	setAttr ".uvtk[192]" -type "float2" -0.31534311 0.31116074 ;
	setAttr ".uvtk[193]" -type "float2" 0.065151855 0.29720813 ;
	setAttr ".uvtk[194]" -type "float2" -0.4301675 -0.93652004 ;
	setAttr ".uvtk[195]" -type "float2" -0.045316994 -0.032159984 ;
	setAttr ".uvtk[196]" -type "float2" -0.0037402958 0.1877203 ;
	setAttr ".uvtk[197]" -type "float2" -0.087330163 -0.20532113 ;
	setAttr ".uvtk[198]" -type "float2" 0.069439426 0.21646583 ;
	setAttr ".uvtk[199]" -type "float2" -0.037638821 -0.044153273 ;
	setAttr ".uvtk[200]" -type "float2" -0.15693143 -0.064179242 ;
	setAttr ".uvtk[201]" -type "float2" -0.31422037 0.24322355 ;
	setAttr ".uvtk[202]" -type "float2" -0.17420045 -0.053817272 ;
	setAttr ".uvtk[203]" -type "float2" 0.096483171 -0.064687669 ;
	setAttr ".uvtk[204]" -type "float2" -0.63577348 -1.3899708 ;
	setAttr ".uvtk[205]" -type "float2" -0.62841886 -1.3621097 ;
	setAttr ".uvtk[206]" -type "float2" -0.48003456 -1.0563724 ;
	setAttr ".uvtk[207]" -type "float2" -0.04863875 -0.044327974 ;
	setAttr ".uvtk[208]" -type "float2" -0.1085524 -0.19951206 ;
	setAttr ".uvtk[209]" -type "float2" -0.089751333 -0.21589357 ;
	setAttr ".uvtk[210]" -type "float2" -0.038547158 -0.048410356 ;
	setAttr ".uvtk[211]" -type "float2" -0.17180374 -0.060555696 ;
	setAttr ".uvtk[212]" -type "float2" -0.16172278 -0.068721294 ;
	setAttr ".uvtk[213]" -type "float2" 0.099388123 -0.068670511 ;
	setAttr ".uvtk[214]" -type "float2" -0.65191972 -1.420887 ;
	setAttr ".uvtk[215]" -type "float2" -0.64444876 -1.3932996 ;
	setAttr ".uvtk[216]" -type "float2" -0.31383938 0.22324973 ;
	setAttr ".uvtk[217]" -type "float2" 0.070641764 0.19267899 ;
	setAttr ".uvtk[218]" -type "float2" -0.49439767 -1.0914168 ;
	setAttr ".uvtk[219]" -type "float2" -0.049572002 -0.048288226 ;
	setAttr ".uvtk[220]" -type "float2" -0.10952715 -0.20310056 ;
	setAttr ".uvtk[221]" -type "float2" -0.090609923 -0.21974862 ;
	setAttr ".uvtk[222]" -type "float2" -0.038864836 -0.049985111 ;
	setAttr ".uvtk[223]" -type "float2" -0.17094836 -0.063013673 ;
	setAttr ".uvtk[224]" -type "float2" -0.16343814 -0.070390165 ;
	setAttr ".uvtk[225]" -type "float2" 0.10042596 -0.070129752 ;
	setAttr ".uvtk[226]" -type "float2" -0.65770501 -1.4319804 ;
	setAttr ".uvtk[227]" -type "float2" -0.6501829 -1.4044917 ;
	setAttr ".uvtk[228]" -type "float2" -0.31369537 0.21606708 ;
	setAttr ".uvtk[229]" -type "float2" 0.071066976 0.18411994 ;
	setAttr ".uvtk[230]" -type "float2" -0.49953309 -1.1040039 ;
	setAttr ".uvtk[231]" -type "float2" -0.049896464 -0.049745739 ;
	setAttr ".uvtk[233]" -type "float2" 0.0074442774 -0.00070613623 ;
	setAttr ".uvtk[240]" -type "float2" -0.30454677 0.20596665 ;
	setAttr ".uvtk[241]" -type "float2" 0.052593097 0.17468613 ;
	setAttr ".uvtk[242]" -type "float2" -0.0037167743 0.0066004395 ;
	setAttr ".uvtk[243]" -type "float2" -0.012137379 0.0012164116 ;
	setAttr ".uvtk[244]" -type "float2" -0.016755432 0.018031061 ;
	setAttr ".uvtk[245]" -type "float2" -0.0069258809 0.018856585 ;
	setAttr ".uvtk[246]" -type "float2" -0.019645423 0.043732643 ;
	setAttr ".uvtk[247]" -type "float2" -0.014825761 0.058770955 ;
	setAttr ".uvtk[248]" -type "float2" -0.0077124834 6.0617924e-05 ;
	setAttr ".uvtk[249]" -type "float2" 0.025496662 0.098804355 ;
	setAttr ".uvtk[250]" -type "float2" 0.0063694417 0.13516128 ;
	setAttr ".uvtk[251]" -type "float2" 0.00077947974 0.13671315 ;
	setAttr ".uvtk[252]" -type "float2" -0.30437726 0.19964403 ;
	setAttr ".uvtk[253]" -type "float2" 0.05290208 0.16725194 ;
	setAttr ".uvtk[254]" -type "float2" -0.0030529574 0.14862823 ;
	setAttr ".uvtk[255]" -type "float2" -0.021299232 0.044310868 ;
	setAttr ".uvtk[256]" -type "float2" -0.012674108 0.018040776 ;
	setAttr ".uvtk[257]" -type "float2" 0.0023007691 0.017752945 ;
	setAttr ".uvtk[258]" -type "float2" 0.019952899 0.040628493 ;
	setAttr ".uvtk[259]" -type "float2" -0.055488646 0.028702378 ;
	setAttr ".uvtk[260]" -type "float2" -0.0087017417 0.0025032759 ;
	setAttr ".uvtk[261]" -type "float2" -0.0056327581 0.076516688 ;
	setAttr ".uvtk[262]" -type "float2" 0.019274354 0.10247242 ;
	setAttr ".uvtk[263]" -type "float2" 0.01180321 0.10420674 ;
	setAttr ".uvtk[264]" -type "float2" -0.32192212 0.19030452 ;
	setAttr ".uvtk[265]" -type "float2" 0.092329696 0.15053546 ;
	setAttr ".uvtk[266]" -type "float2" 0.0059296042 0.11605728 ;
	setAttr ".uvtk[267]" -type "float2" 0.017524013 0.041701138 ;
	setAttr ".uvtk[268]" -type "float2" -0.0039187223 0.0033445358 ;
	setAttr ".uvtk[269]" -type "float2" 0.011751644 0.001458168 ;
	setAttr ".uvtk[270]" -type "float2" 0.019146932 0.010294676 ;
	setAttr ".uvtk[271]" -type "float2" -0.060055196 -0.025331855 ;
	setAttr ".uvtk[272]" -type "float2" -0.0040771365 -0.001116097 ;
	setAttr ".uvtk[273]" -type "float2" -0.0091869235 0.027749538 ;
	setAttr ".uvtk[274]" -type "float2" 0.014805794 0.033381283 ;
	setAttr ".uvtk[275]" -type "float2" 0.0075336099 0.03454566 ;
	setAttr ".uvtk[276]" -type "float2" -0.32120258 0.15415055 ;
	setAttr ".uvtk[277]" -type "float2" 0.094619222 0.10672247 ;
	setAttr ".uvtk[278]" -type "float2" 0.0049401186 0.0386554 ;
	setAttr ".uvtk[279]" -type "float2" 0.017327894 0.012049913 ;
	setAttr ".uvtk[280]" -type "float2" 0.0011357516 -0.0022057891 ;
	setAttr ".uvtk[281]" -type "float2" 0.00053352118 -0.00072747469 ;
	setAttr ".uvtk[283]" -type "float2" -0.012184024 0.0007147789 ;
	setAttr ".uvtk[284]" -type "float2" -0.0038491338 -0.0066722035 ;
	setAttr ".uvtk[285]" -type "float2" -0.00060015917 -0.012039244 ;
	setAttr ".uvtk[286]" -type "float2" -0.0003041923 -0.011062384 ;
	setAttr ".uvtk[287]" -type "float2" 0.00058197975 -0.0097574592 ;
	setAttr ".uvtk[288]" -type "float2" 0.00058597326 -0.010669589 ;
	setAttr ".uvtk[289]" -type "float2" 0.0087103099 -0.0026892424 ;
	setAttr ".uvtk[290]" -type "float2" -0.11314543 -0.19739658 ;
	setAttr ".uvtk[291]" -type "float2" -0.16176122 -0.073094904 ;
	setAttr ".uvtk[292]" -type "float2" -0.057935543 -0.037773252 ;
	setAttr ".uvtk[293]" -type "float2" -0.06788259 -0.037425816 ;
	setAttr ".uvtk[294]" -type "float2" -0.5186348 -1.1321269 ;
	setAttr ".uvtk[295]" -type "float2" -0.65980458 -1.4084318 ;
	setAttr ".uvtk[296]" -type "float2" -0.66724563 -1.4336827 ;
	setAttr ".uvtk[297]" -type "float2" 0.1090976 -0.06328243 ;
	setAttr ".uvtk[298]" -type "float2" -0.14115709 -0.058075547 ;
	setAttr ".uvtk[299]" -type "float2" -0.096858069 -0.21284699 ;
	setAttr ".uvtk[300]" -type "float2" -0.0087332577 -0.009241879 ;
	setAttr ".uvtk[301]" -type "float2" 0.017676167 0.045647539 ;
	setAttr ".uvtk[302]" -type "float2" -0.0014601648 -0.0074815154 ;
	setAttr ".uvtk[303]" -type "float2" -0.73421943 -0.10076463 ;
	setAttr ".uvtk[304]" -type "float2" -0.79497313 -0.64443755 ;
	setAttr ".uvtk[305]" -type "float2" -0.81551975 -0.59091771 ;
	setAttr ".uvtk[306]" -type "float2" -0.13509694 0.017904021 ;
	setAttr ".uvtk[307]" -type "float2" 0.096146464 0.013209596 ;
	setAttr ".uvtk[309]" -type "float2" -0.67506683 -0.09379001 ;
	setAttr ".uvtk[311]" -type "float2" -0.095970482 -0.38524023 ;
	setAttr ".uvtk[312]" -type "float2" -0.0010406375 -0.00062167272 ;
	setAttr ".uvtk[313]" -type "float2" -0.0014154315 1.7091632e-05 ;
	setAttr ".uvtk[314]" -type "float2" -0.058895677 -0.11032629 ;
	setAttr ".uvtk[315]" -type "float2" -0.60371274 -0.61821425 ;
	setAttr ".uvtk[316]" -type "float2" -0.0009778738 -0.0039801002 ;
	setAttr ".uvtk[317]" -type "float2" -0.69313109 -0.68561882 ;
	setAttr ".uvtk[318]" -type "float2" -0.0004799068 0.00013365224 ;
	setAttr ".uvtk[319]" -type "float2" 0.011904523 -0.049917616 ;
	setAttr ".uvtk[320]" -type "float2" 0.016226517 0.037808895 ;
	setAttr ".uvtk[321]" -type "float2" -0.0077984929 0.031563699 ;
	setAttr ".uvtk[322]" -type "float2" 0.0054382086 -0.0028685927 ;
	setAttr ".uvtk[323]" -type "float2" 0.039252497 -0.018764019 ;
	setAttr ".uvtk[324]" -type "float2" 0.016660742 0.1163283 ;
	setAttr ".uvtk[325]" -type "float2" -0.0032689571 0.080132246 ;
	setAttr ".uvtk[326]" -type "float2" 0.0010797977 -0.00038450956 ;
	setAttr ".uvtk[327]" -type "float2" 0.040035926 0.020697832 ;
	setAttr ".uvtk[328]" -type "float2" 0.0038006902 -0.0067807436 ;
	setAttr ".uvtk[329]" -type "float2" 0.0048613586 0.14923579 ;
	setAttr ".uvtk[330]" -type "float2" 0.00040206313 -0.0049029589 ;
	setAttr ".uvtk[331]" -type "float2" 0.027672797 0.10170525 ;
	setAttr ".uvtk[332]" -type "float2" 0.0063360929 -0.0012832284 ;
	setAttr ".uvtk[333]" -type "float2" -0.00049006939 -0.002466321 ;
	setAttr ".uvtk[334]" -type "float2" 0.14543524 -0.017804325 ;
	setAttr ".uvtk[335]" -type "float2" -0.0081533939 0.031062722 ;
	setAttr ".uvtk[336]" -type "float2" -0.494124 -1.1011212 ;
	setAttr ".uvtk[337]" -type "float2" 0.0038596727 0.0067085028 ;
	setAttr ".uvtk[338]" -type "float2" 0.12737492 -0.063867986 ;
	setAttr ".uvtk[339]" -type "float2" 0.0016520619 0.0041863322 ;
	setAttr ".uvtk[340]" -type "float2" -0.15949786 -0.062686384 ;
	setAttr ".uvtk[341]" -type "float2" 0.0058503151 -0.0005171895 ;
	setAttr ".uvtk[342]" -type "float2" 0.061813697 -0.046845973 ;
	setAttr ".uvtk[343]" -type "float2" 0.14550896 -0.016014874 ;
	setAttr ".uvtk[344]" -type "float2" -0.47256911 -1.070269 ;
	setAttr ".uvtk[345]" -type "float2" 0.12016767 -0.070906699 ;
	setAttr ".uvtk[346]" -type "float2" -0.16055202 -0.059419274 ;
	setAttr ".uvtk[347]" -type "float2" 0.093483731 -0.05873704 ;
	setAttr ".uvtk[348]" -type "float2" -0.46752393 -1.0574862 ;
	setAttr ".uvtk[349]" -type "float2" 0.11911279 -0.069516242 ;
	setAttr ".uvtk[350]" -type "float2" -0.15881857 -0.057909131 ;
	setAttr ".uvtk[351]" -type "float2" 0.093804903 -0.055562019 ;
	setAttr ".uvtk[352]" -type "float2" -0.45341527 -1.0219109 ;
	setAttr ".uvtk[353]" -type "float2" 0.11617178 -0.065718234 ;
	setAttr ".uvtk[354]" -type "float2" -0.15400371 -0.053809822 ;
	setAttr ".uvtk[355]" -type "float2" 0.094715469 -0.046892881 ;
	setAttr ".uvtk[356]" -type "float2" -0.40445164 -0.90026051 ;
	setAttr ".uvtk[357]" -type "float2" 0.10598165 -0.053620219 ;
	setAttr ".uvtk[358]" -type "float2" -0.13758764 -0.040740967 ;
	setAttr ".uvtk[359]" -type "float2" 0.098003 -0.019150615 ;
	setAttr ".uvtk[360]" -type "float2" -0.39572182 -0.87886983 ;
	setAttr ".uvtk[361]" -type "float2" 0.10416049 -0.051647842 ;
	setAttr ".uvtk[362]" -type "float2" -0.13471183 -0.038634539 ;
	setAttr ".uvtk[363]" -type "float2" 0.098606169 -0.014574707 ;
	setAttr ".uvtk[364]" -type "float2" -0.34094483 -0.74669701 ;
	setAttr ".uvtk[365]" -type "float2" 0.092682183 -0.040348887 ;
	setAttr ".uvtk[366]" -type "float2" -0.11676538 -0.026476264 ;
	setAttr ".uvtk[367]" -type "float2" 0.10249422 0.011690557 ;
	setAttr ".uvtk[368]" -type "float2" -0.33214355 -0.72578979 ;
	setAttr ".uvtk[369]" -type "float2" 0.090811372 -0.038700342 ;
	setAttr ".uvtk[370]" -type "float2" -0.11392778 -0.024732351 ;
	setAttr ".uvtk[371]" -type "float2" 0.10312745 0.015530765 ;
	setAttr ".uvtk[372]" -type "float2" -0.26258078 -0.56330752 ;
	setAttr ".uvtk[373]" -type "float2" 0.076234758 -0.027234852 ;
	setAttr ".uvtk[374]" -type "float2" -0.091352999 -0.01258862 ;
	setAttr ".uvtk[375]" -type "float2" 0.10826498 0.042503268 ;
	setAttr ".uvtk[376]" -type "float2" -0.25260133 -0.54042161 ;
	setAttr ".uvtk[377]" -type "float2" 0.074099064 -0.025832146 ;
	setAttr ".uvtk[378]" -type "float2" -0.088137627 -0.011098802 ;
	setAttr ".uvtk[379]" -type "float2" 0.10899884 0.045891583 ;
	setAttr ".uvtk[380]" -type "float2" -0.1778437 -0.37194255 ;
	setAttr ".uvtk[381]" -type "float2" 0.058303177 -0.016847402 ;
	setAttr ".uvtk[382]" -type "float2" -0.063738763 -0.0018859208 ;
	setAttr ".uvtk[383]" -type "float2" 0.11461477 0.067838132 ;
	setAttr ".uvtk[384]" -type "float2" -0.17100751 -0.35680559 ;
	setAttr ".uvtk[385]" -type "float2" 0.05679965 -0.016145527 ;
	setAttr ".uvtk[386]" -type "float2" -0.06150645 -0.0012048781 ;
	setAttr ".uvtk[387]" -type "float2" 0.11511311 0.069544643 ;
	setAttr ".uvtk[388]" -type "float2" -0.095473006 -0.1922061 ;
	setAttr ".uvtk[389]" -type "float2" 0.040805101 -0.0098970532 ;
	setAttr ".uvtk[390]" -type "float2" -0.036571562 0.0041961968 ;
	setAttr ".uvtk[391]" -type "float2" 0.12070736 0.085498363 ;
	setAttr ".uvtk[392]" -type "float2" -0.085809745 -0.17151 ;
	setAttr ".uvtk[393]" -type "float2" 0.038711905 -0.0092889071 ;
	setAttr ".uvtk[394]" -type "float2" -0.033324003 0.004661113 ;
	setAttr ".uvtk[395]" -type "float2" 0.12138079 0.087152109 ;
	setAttr ".uvtk[396]" -type "float2" -0.013583511 -0.019169107 ;
	setAttr ".uvtk[397]" -type "float2" 0.023284435 -0.005961746 ;
	setAttr ".uvtk[398]" -type "float2" -0.0089973211 0.0060451478 ;
	setAttr ".uvtk[399]" -type "float2" 0.12644108 0.097194359 ;
	setAttr ".uvtk[400]" -type "float2" -0.0084177852 -0.0086252838 ;
	setAttr ".uvtk[401]" -type "float2" -0.13557813 -0.49164408 ;
	setAttr ".uvtk[402]" -type "float2" -0.24976233 0.078553841 ;
	setAttr ".uvtk[403]" -type "float2" 0.12779164 0.098035149 ;
	setAttr ".uvtk[404]" -type "float2" 0.019005857 0.048051618 ;
	setAttr ".uvtk[405]" -type "float2" -0.10518476 -0.44033691 ;
	setAttr ".uvtk[406]" -type "float2" -0.25410348 0.082779899 ;
	setAttr ".uvtk[407]" -type "float2" 0.12950021 0.10066375 ;
	setAttr ".uvtk[408]" -type "float2" 0.095992498 0.01457309 ;
	setAttr ".uvtk[409]" -type "float2" -0.017949611 -0.0086818784 ;
	setAttr ".uvtk[410]" -type "float2" -0.10033783 -0.41882819 ;
	setAttr ".uvtk[411]" -type "float2" -0.0015250444 -0.0071614236 ;
	setAttr ".uvtk[412]" -type "float2" -0.23922002 0.076580852 ;
	setAttr ".uvtk[413]" -type "float2" -0.00054419041 -0.00033196807 ;
	setAttr ".uvtk[414]" -type "float2" 0.096829087 0.075666428 ;
	setAttr ".uvtk[415]" -type "float2" 0.11322406 0.08552698 ;
	setAttr ".uvtk[416]" -type "float2" -0.19189042 -0.0031810775 ;
	setAttr ".uvtk[417]" -type "float2" -0.0093909651 -0.0063246563 ;
	setAttr ".uvtk[418]" -type "float2" -0.7338016 -0.10183248 ;
	setAttr ".uvtk[419]" -type "float2" -0.80362904 -0.64084494 ;
	setAttr ".uvtk[420]" -type "float2" 0.00058919191 0.0039885491 ;
	setAttr ".uvtk[421]" -type "float2" -0.64736414 -0.66241437 ;
	setAttr ".uvtk[423]" -type "float2" 0.096532717 0.076720014 ;
	setAttr ".uvtk[427]" -type "float2" 0.010389943 -0.001269877 ;
	setAttr ".uvtk[428]" -type "float2" 0.13739872 0.098343849 ;
	setAttr ".uvtk[429]" -type "float2" 0.085307382 0.09064734 ;
	setAttr ".uvtk[430]" -type "float2" -0.3057158 0.13788372 ;
	setAttr ".uvtk[432]" -type "float2" -0.33389014 0.14323246 ;
	setAttr ".uvtk[433]" -type "float2" -0.34132195 0.14027971 ;
	setAttr ".uvtk[434]" -type "float2" 0.0085054636 -0.0011349916 ;
	setAttr ".uvtk[435]" -type "float2" -0.45376846 0.09322077 ;
	setAttr ".uvtk[436]" -type "float2" 0.01373896 -0.0021461844 ;
	setAttr ".uvtk[437]" -type "float2" 0.016585805 -0.030484021 ;
	setAttr ".uvtk[438]" -type "float2" -0.02635859 -0.01955159 ;
	setAttr ".uvtk[439]" -type "float2" -0.41903031 0.75051904 ;
	setAttr ".uvtk[440]" -type "float2" -0.035702318 0.80753839 ;
	setAttr ".uvtk[441]" -type "float2" -0.041277587 0.0014218688 ;
	setAttr ".uvtk[442]" -type "float2" -0.045835629 -0.046036601 ;
	setAttr ".uvtk[443]" -type "float2" -0.42158514 0.63854659 ;
	setAttr ".uvtk[444]" -type "float2" -0.028750062 0.67834598 ;
	setAttr ".uvtk[445]" -type "float2" -0.067986131 -0.0059833527 ;
	setAttr ".uvtk[446]" -type "float2" -0.063977219 -0.078134596 ;
	setAttr ".uvtk[447]" -type "float2" -0.42407161 0.52601415 ;
	setAttr ".uvtk[448]" -type "float2" -0.021379396 0.53758514 ;
	setAttr ".uvtk[449]" -type "float2" -0.095257282 -0.01825431 ;
	setAttr ".uvtk[450]" -type "float2" -0.081081741 -0.11636904 ;
	setAttr ".uvtk[451]" -type "float2" -0.42641452 0.41082937 ;
	setAttr ".uvtk[452]" -type "float2" -0.01430814 0.39959395 ;
	setAttr ".uvtk[453]" -type "float2" -0.12034005 -0.033855379 ;
	setAttr ".uvtk[454]" -type "float2" -0.094224222 -0.15237349 ;
	setAttr ".uvtk[455]" -type "float2" -0.42819893 0.31461799 ;
	setAttr ".uvtk[456]" -type "float2" -0.0087669343 0.28163463 ;
	setAttr ".uvtk[457]" -type "float2" -0.14088121 -0.049743176 ;
	setAttr ".uvtk[458]" -type "float2" -0.10581313 -0.18967456 ;
	setAttr ".uvtk[459]" -type "float2" -0.429299 0.22386181 ;
	setAttr ".uvtk[460]" -type "float2" -0.41687334 0.84129035 ;
	setAttr ".uvtk[461]" -type "float2" -0.0094454139 -0.0022795051 ;
createNode polyLayoutUV -n "polyLayoutUV3";
	rename -uid "C9A26328-46F9-EC72-D8B0-B29049DB9DB2";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "f[0:289]";
	setAttr ".l" 1;
	setAttr ".ps" 0.20000000298023224;
	setAttr ".dl" yes;
	setAttr ".rbf" 1;
	setAttr ".lm" 1;
createNode polyTweakUV -n "polyTweakUV9";
	rename -uid "E2313411-4DAA-76E3-BA50-0AB8102D53AD";
	setAttr ".uopa" yes;
	setAttr -s 442 ".uvtk";
	setAttr ".uvtk[0]" -type "float2" -0.33492473 0.16733482 ;
	setAttr ".uvtk[1]" -type "float2" -0.35528591 0.18223906 ;
	setAttr ".uvtk[4]" -type "float2" 0 0.16394608 ;
	setAttr ".uvtk[5]" -type "float2" -0.10445054 0.26985475 ;
	setAttr ".uvtk[6]" -type "float2" 0 0.16394584 ;
	setAttr ".uvtk[7]" -type "float2" 0 0.16394684 ;
	setAttr ".uvtk[8]" -type "float2" -0.25913763 0.24844164 ;
	setAttr ".uvtk[9]" -type "float2" -0.28500649 0.28546286 ;
	setAttr ".uvtk[10]" -type "float2" -0.28887215 0.2729761 ;
	setAttr ".uvtk[11]" -type "float2" -0.26850984 0.2580682 ;
	setAttr ".uvtk[12]" -type "float2" -0.27325439 0.25158811 ;
	setAttr ".uvtk[13]" -type "float2" -0.29361457 0.26649767 ;
	setAttr ".uvtk[14]" -type "float2" -0.54864681 0.3237763 ;
	setAttr ".uvtk[15]" -type "float2" -0.48696917 0.408032 ;
	setAttr ".uvtk[19]" -type "float2" 0.29057065 0.52471364 ;
	setAttr ".uvtk[20]" -type "float2" 0.27394697 0.52796298 ;
	setAttr ".uvtk[21]" -type "float2" -0.45094463 0.58721083 ;
	setAttr ".uvtk[22]" -type "float2" 0.44806617 0.49364313 ;
	setAttr ".uvtk[26]" -type "float2" 0.28729236 0.5281601 ;
	setAttr ".uvtk[27]" -type "float2" 0.26975331 0.53158611 ;
	setAttr ".uvtk[28]" -type "float2" -0.45073569 0.59110337 ;
	setAttr ".uvtk[29]" -type "float2" 0.45327234 0.49540144 ;
	setAttr ".uvtk[30]" -type "float2" 0.36658466 0.43625075 ;
	setAttr ".uvtk[31]" -type "float2" -0.25124967 0.51677322 ;
	setAttr ".uvtk[32]" -type "float2" -0.25073102 0.51528752 ;
	setAttr ".uvtk[33]" -type "float2" 0.2900261 0.54201025 ;
	setAttr ".uvtk[34]" -type "float2" 0.27246219 0.5454725 ;
	setAttr ".uvtk[35]" -type "float2" -0.45235258 0.60217559 ;
	setAttr ".uvtk[36]" -type "float2" 0.45597792 0.50916755 ;
	setAttr ".uvtk[37]" -type "float2" 0.37294364 0.45230496 ;
	setAttr ".uvtk[38]" -type "float2" -0.25150028 0.52367282 ;
	setAttr ".uvtk[39]" -type "float2" -0.24853218 0.52335781 ;
	setAttr ".uvtk[40]" -type "float2" -5.9604645e-07 0.16394615 ;
	setAttr ".uvtk[41]" -type "float2" 0.27320853 0.5478363 ;
	setAttr ".uvtk[42]" -type "float2" -0.4527359 0.60414016 ;
	setAttr ".uvtk[43]" -type "float2" -0.51198149 0.59386283 ;
	setAttr ".uvtk[44]" -type "float2" 0.37378967 0.45519799 ;
	setAttr ".uvtk[45]" -type "float2" -0.2514942 0.52541387 ;
	setAttr ".uvtk[46]" -type "float2" -0.24812689 0.52479798 ;
	setAttr ".uvtk[48]" -type "float2" -0.53273737 0.31213582 ;
	setAttr ".uvtk[49]" -type "float2" 0.4351446 0.49618468 ;
	setAttr ".uvtk[50]" -type "float2" 0.43968123 0.49808705 ;
	setAttr ".uvtk[51]" -type "float2" 0.44242191 0.51191646 ;
	setAttr ".uvtk[52]" -type "float2" 0.44266522 0.51436758 ;
	setAttr ".uvtk[54]" -type "float2" 5.9604645e-08 0.16394596 ;
	setAttr ".uvtk[55]" -type "float2" 0 0.16394597 ;
	setAttr ".uvtk[57]" -type "float2" -0.44759062 0.60247946 ;
	setAttr ".uvtk[58]" -type "float2" 0.19596684 0.52224803 ;
	setAttr ".uvtk[59]" -type "float2" 0.19734311 0.52493477 ;
	setAttr ".uvtk[60]" -type "float2" 0.18152171 0.53117055 ;
	setAttr ".uvtk[61]" -type "float2" -0.44744247 0.59010881 ;
	setAttr ".uvtk[62]" -type "float2" 0.18961927 0.50617242 ;
	setAttr ".uvtk[63]" -type "float2" -0.45385727 0.58753759 ;
	setAttr ".uvtk[66]" -type "float2" -0.45540315 0.41020215 ;
	setAttr ".uvtk[67]" -type "float2" -0.46631446 0.40286881 ;
	setAttr ".uvtk[68]" -type "float2" -0.48222363 0.41450948 ;
	setAttr ".uvtk[69]" -type "float2" -0.47105774 0.39638767 ;
	setAttr ".uvtk[70]" -type "float2" 2.3841858e-07 0.16394611 ;
	setAttr ".uvtk[71]" -type "float2" 0 0.16394581 ;
	setAttr ".uvtk[72]" -type "float2" -0.39344451 0.3574197 ;
	setAttr ".uvtk[73]" -type "float2" -0.41840789 0.36829096 ;
	setAttr ".uvtk[74]" -type "float2" -0.11496542 0.23616475 ;
	setAttr ".uvtk[76]" -type "float2" 1.1920929e-07 0.16394576 ;
	setAttr ".uvtk[77]" -type "float2" 0.28046286 0.58461112 ;
	setAttr ".uvtk[78]" -type "float2" 0 0.16394612 ;
	setAttr ".uvtk[79]" -type "float2" -0.24309853 0.54742664 ;
	setAttr ".uvtk[80]" -type "float2" 0.45017505 0.55048096 ;
	setAttr ".uvtk[81]" -type "float2" 1.7881393e-07 0.16394588 ;
	setAttr ".uvtk[82]" -type "float2" -0.51750964 0.62404376 ;
	setAttr ".uvtk[83]" -type "float2" -0.45767343 0.63446695 ;
	setAttr ".uvtk[84]" -type "float2" 0.19826975 0.57363486 ;
	setAttr ".uvtk[85]" -type "float2" 0.21409956 0.56739336 ;
	setAttr ".uvtk[86]" -type "float2" 0.39059311 0.49758416 ;
	setAttr ".uvtk[87]" -type "float2" -0.24655865 0.54817951 ;
	setAttr ".uvtk[88]" -type "float2" 0.29900676 0.5860393 ;
	setAttr ".uvtk[89]" -type "float2" 0.2814334 0.58955455 ;
	setAttr ".uvtk[90]" -type "float2" -0.24242207 0.55048513 ;
	setAttr ".uvtk[91]" -type "float2" -0.51825875 0.62810951 ;
	setAttr ".uvtk[92]" -type "float2" 1.7881393e-07 0.16394632 ;
	setAttr ".uvtk[93]" -type "float2" -0.45834714 0.63855094 ;
	setAttr ".uvtk[94]" -type "float2" 0.2005128 0.57932943 ;
	setAttr ".uvtk[95]" -type "float2" 0.21634692 0.5730871 ;
	setAttr ".uvtk[96]" -type "float2" 1.7881393e-07 0.1639459 ;
	setAttr ".uvtk[97]" -type "float2" 0 0.16394614 ;
	setAttr ".uvtk[98]" -type "float2" 0.39284796 0.50326794 ;
	setAttr ".uvtk[99]" -type "float2" -0.24590226 0.55125624 ;
	setAttr ".uvtk[100]" -type "float2" 1.1920929e-07 0.16394618 ;
	setAttr ".uvtk[101]" -type "float2" 0.28917727 0.62827915 ;
	setAttr ".uvtk[102]" -type "float2" -1.1920929e-07 0.16394605 ;
	setAttr ".uvtk[103]" -type "float2" -0.23704989 0.57456201 ;
	setAttr ".uvtk[104]" -type "float2" 0.45930719 0.59323847 ;
	setAttr ".uvtk[105]" -type "float2" 0 0.16394623 ;
	setAttr ".uvtk[106]" -type "float2" -0.52405989 0.66009849 ;
	setAttr ".uvtk[107]" -type "float2" -0.46373063 0.67063987 ;
	setAttr ".uvtk[108]" -type "float2" 0.21810925 0.62393564 ;
	setAttr ".uvtk[109]" -type "float2" 0.23395219 0.61768782 ;
	setAttr ".uvtk[110]" -type "float2" 0.41052103 0.54778486 ;
	setAttr ".uvtk[111]" -type "float2" -0.24053769 0.57533985 ;
	setAttr ".uvtk[112]" -type "float2" 0.30750266 0.6282295 ;
	setAttr ".uvtk[113]" -type "float2" 0.28987953 0.63180107 ;
	setAttr ".uvtk[114]" -type "float2" -0.23656309 0.57675368 ;
	setAttr ".uvtk[115]" -type "float2" -0.52458972 0.66300887 ;
	setAttr ".uvtk[116]" -type "float2" 0 0.16394587 ;
	setAttr ".uvtk[117]" -type "float2" -0.46422118 0.67355996 ;
	setAttr ".uvtk[118]" -type "float2" 0.21970105 0.62798321 ;
	setAttr ".uvtk[119]" -type "float2" 0.23554909 0.62173265 ;
	setAttr ".uvtk[120]" -type "float2" 5.9604645e-08 0.16394626 ;
	setAttr ".uvtk[121]" -type "float2" -1.1920929e-07 0.16394608 ;
	setAttr ".uvtk[122]" -type "float2" 0.4121244 0.55182153 ;
	setAttr ".uvtk[123]" -type "float2" -0.24006732 0.57753474 ;
	setAttr ".uvtk[124]" -type "float2" 1.1920929e-07 0.16394624 ;
	setAttr ".uvtk[125]" -type "float2" 0.29770574 0.67038047 ;
	setAttr ".uvtk[126]" -type "float2" 1.1920929e-07 0.16394612 ;
	setAttr ".uvtk[127]" -type "float2" -0.23117907 0.60084641 ;
	setAttr ".uvtk[128]" -type "float2" 0.46834862 0.63441682 ;
	setAttr ".uvtk[129]" -type "float2" -1.1920929e-07 0.16394596 ;
	setAttr ".uvtk[130]" -type "float2" -0.53033948 0.69500923 ;
	setAttr ".uvtk[131]" -type "float2" -0.46967965 0.70564473 ;
	setAttr ".uvtk[132]" -type "float2" 0.23721039 0.67233771 ;
	setAttr ".uvtk[133]" -type "float2" 0.25306368 0.66607821 ;
	setAttr ".uvtk[134]" -type "float2" 0.42971486 0.5960803 ;
	setAttr ".uvtk[135]" -type "float2" -0.23468994 0.60163027 ;
	setAttr ".uvtk[136]" -type "float2" 0.31643644 0.67191315 ;
	setAttr ".uvtk[137]" -type "float2" 0.29875651 0.67555863 ;
	setAttr ".uvtk[138]" -type "float2" -0.23045824 0.60407919 ;
	setAttr ".uvtk[139]" -type "float2" -0.53111213 0.69930106 ;
	setAttr ".uvtk[140]" -type "float2" 1.1920929e-07 0.16394605 ;
	setAttr ".uvtk[141]" -type "float2" -0.47041541 0.70994687 ;
	setAttr ".uvtk[142]" -type "float2" 0.23955119 0.67827535 ;
	setAttr ".uvtk[143]" -type "float2" 0.255409 0.67201293 ;
	setAttr ".uvtk[144]" -type "float2" -1.1920929e-07 0.16394597 ;
	setAttr ".uvtk[145]" -type "float2" 1.7881393e-07 0.16394609 ;
	setAttr ".uvtk[146]" -type "float2" 0.43206996 0.60200375 ;
	setAttr ".uvtk[147]" -type "float2" -0.23398073 0.6048671 ;
	setAttr ".uvtk[148]" -type "float2" 0 0.163946 ;
	setAttr ".uvtk[149]" -type "float2" 0.30622107 0.71173912 ;
	setAttr ".uvtk[150]" -type "float2" 0 0.16394567 ;
	setAttr ".uvtk[151]" -type "float2" -0.22538815 0.62671292 ;
	setAttr ".uvtk[152]" -type "float2" 0.47746795 0.67499632 ;
	setAttr ".uvtk[153]" -type "float2" -5.9604645e-08 0.16394639 ;
	setAttr ".uvtk[154]" -type "float2" -0.53647459 0.72934061 ;
	setAttr ".uvtk[155]" -type "float2" -0.4756121 0.74003154 ;
	setAttr ".uvtk[156]" -type "float2" 0.25594896 0.71975791 ;
	setAttr ".uvtk[157]" -type "float2" 0.27180994 0.71348649 ;
	setAttr ".uvtk[158]" -type "float2" 0.4485321 0.64340401 ;
	setAttr ".uvtk[159]" -type "float2" -0.22891571 0.62750334 ;
	setAttr ".uvtk[160]" -type "float2" 0.32489759 0.71262056 ;
	setAttr ".uvtk[161]" -type "float2" 0.30717841 0.71634108 ;
	setAttr ".uvtk[162]" -type "float2" -0.2247436 0.6295867 ;
	setAttr ".uvtk[163]" -type "float2" -0.53715485 0.73315412 ;
	setAttr ".uvtk[164]" -type "float2" 1.7881393e-07 0.16394635 ;
	setAttr ".uvtk[165]" -type "float2" -0.476273 0.74385035 ;
	setAttr ".uvtk[166]" -type "float2" 0.25802439 0.72502017 ;
	setAttr ".uvtk[167]" -type "float2" 0.27389061 0.7187447 ;
	setAttr ".uvtk[168]" -type "float2" 0 0.16394638 ;
	setAttr ".uvtk[169]" -type "float2" 5.9604645e-08 0.1639457 ;
	setAttr ".uvtk[170]" -type "float2" 0.45062006 0.64865398 ;
	setAttr ".uvtk[171]" -type "float2" -0.22827671 0.63038081 ;
	setAttr ".uvtk[172]" -type "float2" 1.1920929e-07 0.16394591 ;
	setAttr ".uvtk[173]" -type "float2" 0.31322524 0.74500501 ;
	setAttr ".uvtk[174]" -type "float2" -5.9604645e-08 0.16394633 ;
	setAttr ".uvtk[175]" -type "float2" -0.22070371 0.64753217 ;
	setAttr ".uvtk[176]" -type "float2" 0.48489457 0.70779788 ;
	setAttr ".uvtk[177]" -type "float2" -2.9802322e-07 0.16394581 ;
	setAttr ".uvtk[178]" -type "float2" -0.5413819 0.75696933 ;
	setAttr ".uvtk[179]" -type "float2" -0.48042583 0.76770294 ;
	setAttr ".uvtk[180]" -type "float2" 0.2710188 0.75784028 ;
	setAttr ".uvtk[181]" -type "float2" 0.28688338 0.75155228 ;
	setAttr ".uvtk[182]" -type "float2" 0.46365118 0.68141913 ;
	setAttr ".uvtk[183]" -type "float2" -0.22423862 0.6483295 ;
	setAttr ".uvtk[184]" -type "float2" 0.33193573 0.74581158 ;
	setAttr ".uvtk[185]" -type "float2" 0.31419986 0.74959189 ;
	setAttr ".uvtk[186]" -type "float2" -0.22005625 0.65040153 ;
	setAttr ".uvtk[187]" -type "float2" -0.54205656 0.76077729 ;
	setAttr ".uvtk[188]" -type "float2" 0 0.16394603 ;
	setAttr ".uvtk[189]" -type "float2" -0.48109329 0.77151495 ;
	setAttr ".uvtk[190]" -type "float2" 0.2730943 0.76308471 ;
	setAttr ".uvtk[191]" -type "float2" 0.28896111 0.75679576 ;
	setAttr ".uvtk[192]" -type "float2" -3.5762787e-07 0.16394579 ;
	setAttr ".uvtk[193]" -type "float2" -5.9604645e-08 0.16394633 ;
	setAttr ".uvtk[194]" -type "float2" 0.46573383 0.68665671 ;
	setAttr ".uvtk[195]" -type "float2" -0.22359246 0.65120173 ;
	setAttr ".uvtk[196]" -type "float2" 2.3841858e-07 0.16394626 ;
	setAttr ".uvtk[197]" -type "float2" 0.31969807 0.77533996 ;
	setAttr ".uvtk[198]" -type "float2" 1.1920929e-07 0.16394605 ;
	setAttr ".uvtk[199]" -type "float2" -0.21640985 0.66652054 ;
	setAttr ".uvtk[200]" -type "float2" 0.49166638 0.73788238 ;
	setAttr ".uvtk[201]" -type "float2" 0 0.16394594 ;
	setAttr ".uvtk[202]" -type "float2" -0.54583699 0.78216815 ;
	setAttr ".uvtk[203]" -type "float2" -0.48485452 0.79292375 ;
	setAttr ".uvtk[204]" -type "float2" 0.28477424 0.79254895 ;
	setAttr ".uvtk[205]" -type "float2" 0.30063841 0.78624821 ;
	setAttr ".uvtk[206]" -type "float2" 0.47743106 0.71608102 ;
	setAttr ".uvtk[207]" -type "float2" -0.21994688 0.66732121 ;
	setAttr ".uvtk[208]" -type "float2" 0.33904359 0.77895057 ;
	setAttr ".uvtk[209]" -type "float2" 0.32130009 0.78277582 ;
	setAttr ".uvtk[210]" -type "float2" -0.21535473 0.67117345 ;
	setAttr ".uvtk[211]" -type "float2" -0.54692733 0.78834307 ;
	setAttr ".uvtk[212]" -type "float2" 0.49328667 0.7452907 ;
	setAttr ".uvtk[213]" -type "float2" -0.48594224 0.79910189 ;
	setAttr ".uvtk[214]" -type "float2" 0.28814942 0.80105668 ;
	setAttr ".uvtk[215]" -type "float2" 0.30401111 0.79474771 ;
	setAttr ".uvtk[216]" -type "float2" -1.7881393e-07 0.16394614 ;
	setAttr ".uvtk[217]" -type "float2" -1.7881393e-07 0.16394614 ;
	setAttr ".uvtk[218]" -type "float2" 0.48080653 0.7245757 ;
	setAttr ".uvtk[219]" -type "float2" -0.21889564 0.67197877 ;
	setAttr ".uvtk[220]" -type "float2" 0.33962128 0.78160304 ;
	setAttr ".uvtk[221]" -type "float2" 0.32187429 0.78543568 ;
	setAttr ".uvtk[222]" -type "float2" -0.21497646 0.67283791 ;
	setAttr ".uvtk[223]" -type "float2" -0.54731721 0.79055095 ;
	setAttr ".uvtk[224]" -type "float2" 0.49386656 0.74794167 ;
	setAttr ".uvtk[225]" -type "float2" -0.48633188 0.80131197 ;
	setAttr ".uvtk[226]" -type "float2" 0.28936046 0.80410236 ;
	setAttr ".uvtk[227]" -type "float2" 0.30521771 0.79778808 ;
	setAttr ".uvtk[228]" -type "float2" 5.9604645e-08 0.16394611 ;
	setAttr ".uvtk[229]" -type "float2" 1.7881393e-07 0.16394621 ;
	setAttr ".uvtk[230]" -type "float2" 0.48201406 0.72761524 ;
	setAttr ".uvtk[231]" -type "float2" -0.21851748 0.67364699 ;
	setAttr ".uvtk[240]" -type "float2" 1.7881393e-07 0.16394611 ;
	setAttr ".uvtk[241]" -type "float2" 5.9604645e-08 0.16394624 ;
	setAttr ".uvtk[244]" -type "float2" -0.093329147 0.32206756 ;
	setAttr ".uvtk[245]" -type "float2" -0.065784886 0.30863139 ;
	setAttr ".uvtk[248]" -type "float2" -0.33362117 0.43955857 ;
	setAttr ".uvtk[250]" -type "float2" -0.42463341 0.31265879 ;
	setAttr ".uvtk[251]" -type "float2" -0.40192094 0.30276349 ;
	setAttr ".uvtk[252]" -type "float2" -1.1920929e-07 0.16394612 ;
	setAttr ".uvtk[253]" -type "float2" -3.5762787e-07 0.1639462 ;
	setAttr ".uvtk[254]" -type "float2" -0.14857072 0.19245145 ;
	setAttr ".uvtk[256]" -type "float2" -0.080371872 0.29958206 ;
	setAttr ".uvtk[257]" -type "float2" -0.048181899 0.28400761 ;
	setAttr ".uvtk[260]" -type "float2" -0.36032918 0.43645993 ;
	setAttr ".uvtk[262]" -type "float2" -0.44382623 0.33736813 ;
	setAttr ".uvtk[263]" -type "float2" -0.41736323 0.32584164 ;
	setAttr ".uvtk[264]" -type "float2" -5.9604645e-08 0.16394597 ;
	setAttr ".uvtk[265]" -type "float2" -1.1920929e-07 0.16394615 ;
	setAttr ".uvtk[266]" -type "float2" -0.12220338 0.19732714 ;
	setAttr ".uvtk[268]" -type "float2" -0.091272548 0.27726024 ;
	setAttr ".uvtk[269]" -type "float2" -0.059046037 0.26164442 ;
	setAttr ".uvtk[272]" -type "float2" -0.37127665 0.41409549 ;
	setAttr ".uvtk[274]" -type "float2" -0.433584 0.36088783 ;
	setAttr ".uvtk[275]" -type "float2" -0.40712187 0.34936807 ;
	setAttr ".uvtk[276]" -type "float2" -1.7881393e-07 0.1639459 ;
	setAttr ".uvtk[277]" -type "float2" -1.7881393e-07 0.16394593 ;
	setAttr ".uvtk[278]" -type "float2" -0.11196147 0.2208485 ;
	setAttr ".uvtk[290]" -type "float2" 0.34614289 0.78460658 ;
	setAttr ".uvtk[291]" -type "float2" 0.48890054 0.75345129 ;
	setAttr ".uvtk[292]" -type "float2" -0.21231914 0.6772185 ;
	setAttr ".uvtk[293]" -type "float2" -0.21558794 0.6779719 ;
	setAttr ".uvtk[294]" -type "float2" 0.47751713 0.73500478 ;
	setAttr ".uvtk[295]" -type "float2" 0.31388918 0.79995114 ;
	setAttr ".uvtk[296]" -type "float2" 0.29922134 0.80578595 ;
	setAttr ".uvtk[297]" -type "float2" -0.48953944 0.80723584 ;
	setAttr ".uvtk[298]" -type "float2" -0.54598188 0.79727513 ;
	setAttr ".uvtk[299]" -type "float2" 0.32973093 0.78817475 ;
	setAttr ".uvtk[300]" -type "float2" -0.25052002 0.51203817 ;
	setAttr ".uvtk[301]" -type "float2" 0.38017094 0.42724848 ;
	setAttr ".uvtk[304]" -type "float2" -0.49878785 0.41431004 ;
	setAttr ".uvtk[305]" -type "float2" -0.47067514 0.4213807 ;
	setAttr ".uvtk[306]" -type "float2" -0.26369485 0.24222246 ;
	setAttr ".uvtk[310]" -type "float2" 0.36091775 0.43487352 ;
	setAttr ".uvtk[311]" -type "float2" 0.19303405 0.50120604 ;
	setAttr ".uvtk[314]" -type "float2" -0.36602211 0.17477784 ;
	setAttr ".uvtk[315]" -type "float2" -0.53642732 0.29951808 ;
	setAttr ".uvtk[317]" -type "float2" -0.55801785 0.3334001 ;
	setAttr ".uvtk[319]" -type "float2" -0.34647137 0.16046569 ;
	setAttr ".uvtk[320]" -type "float2" -0.078087941 0.20610239 ;
	setAttr ".uvtk[322]" -type "float2" -0.39658666 0.42646575 ;
	setAttr ".uvtk[324]" -type "float2" -0.088333726 0.18257543 ;
	setAttr ".uvtk[326]" -type "float2" -0.38559151 0.44906572 ;
	setAttr ".uvtk[329]" -type "float2" -0.1194952 0.17979258 ;
	setAttr ".uvtk[333]" -type "float2" -0.35502338 0.4501805 ;
	setAttr ".uvtk[336]" -type "float2" 0.49631119 0.72754604 ;
	setAttr ".uvtk[338]" -type "float2" -0.48519403 0.80801439 ;
	setAttr ".uvtk[340]" -type "float2" 0.50171459 0.75063205 ;
	setAttr ".uvtk[342]" -type "float2" -0.1698111 0.6675508 ;
	setAttr ".uvtk[344]" -type "float2" 0.50232381 0.71954381 ;
	setAttr ".uvtk[345]" -type "float2" -0.48163283 0.8021419 ;
	setAttr ".uvtk[346]" -type "float2" 0.50769496 0.74485707 ;
	setAttr ".uvtk[347]" -type "float2" -0.16904669 0.66239327 ;
	setAttr ".uvtk[348]" -type "float2" 0.50111264 0.71650249 ;
	setAttr ".uvtk[349]" -type "float2" -0.4812451 0.7999301 ;
	setAttr ".uvtk[350]" -type "float2" 0.50710213 0.74220252 ;
	setAttr ".uvtk[351]" -type "float2" -0.16942503 0.66072953 ;
	setAttr ".uvtk[352]" -type "float2" 0.49772638 0.7080071 ;
	setAttr ".uvtk[353]" -type "float2" -0.4801597 0.7937507 ;
	setAttr ".uvtk[354]" -type "float2" 0.50543606 0.73478758 ;
	setAttr ".uvtk[355]" -type "float2" -0.17048277 0.65607876 ;
	setAttr ".uvtk[356]" -type "float2" 0.4860149 0.67858052 ;
	setAttr ".uvtk[357]" -type "float2" -0.47639668 0.77234179 ;
	setAttr ".uvtk[358]" -type "float2" 0.49962682 0.70923263 ;
	setAttr ".uvtk[359]" -type "float2" -0.17415196 0.63996488 ;
	setAttr ".uvtk[360]" -type "float2" 0.48393029 0.67334759 ;
	setAttr ".uvtk[361]" -type "float2" -0.47572696 0.76852477 ;
	setAttr ".uvtk[362]" -type "float2" 0.49857801 0.70469058 ;
	setAttr ".uvtk[363]" -type "float2" -0.17480668 0.63709599 ;
	setAttr ".uvtk[364]" -type "float2" 0.47088844 0.64058596 ;
	setAttr ".uvtk[365]" -type "float2" -0.47157741 0.74466312 ;
	setAttr ".uvtk[366]" -type "float2" 0.49209428 0.67643833 ;
	setAttr ".uvtk[367]" -type "float2" -0.17891091 0.61915463 ;
	setAttr ".uvtk[368]" -type "float2" 0.46879542 0.63533872 ;
	setAttr ".uvtk[369]" -type "float2" -0.47092539 0.74084002 ;
	setAttr ".uvtk[370]" -type "float2" 0.49104804 0.67192566 ;
	setAttr ".uvtk[371]" -type "float2" -0.17957164 0.61628085 ;
	setAttr ".uvtk[372]" -type "float2" 0.45232219 0.59394258 ;
	setAttr ".uvtk[373]" -type "float2" -0.46573028 0.71075624 ;
	setAttr ".uvtk[374]" -type "float2" 0.4829849 0.63648582 ;
	setAttr ".uvtk[375]" -type "float2" -0.18479207 0.59364617 ;
	setAttr ".uvtk[376]" -type "float2" 0.44996178 0.58802587 ;
	setAttr ".uvtk[377]" -type "float2" -0.46500397 0.70644313 ;
	setAttr ".uvtk[378]" -type "float2" 0.48183864 0.63143593 ;
	setAttr ".uvtk[379]" -type "float2" -0.18554558 0.59041196 ;
	setAttr ".uvtk[380]" -type "float2" 0.43236071 0.54377568 ;
	setAttr ".uvtk[381]" -type "float2" -0.45955434 0.67434597 ;
	setAttr ".uvtk[382]" -type "float2" 0.47350204 0.59376687 ;
	setAttr ".uvtk[383]" -type "float2" -0.19117856 0.56630826 ;
	setAttr ".uvtk[384]" -type "float2" 0.4307543 0.53974158 ;
	setAttr ".uvtk[385]" -type "float2" -0.45908505 0.67142236 ;
	setAttr ".uvtk[386]" -type "float2" 0.47275293 0.5903427 ;
	setAttr ".uvtk[387]" -type "float2" -0.19169889 0.56411523 ;
	setAttr ".uvtk[388]" -type "float2" 0.41307425 0.49523658 ;
	setAttr ".uvtk[389]" -type "float2" -0.45371133 0.63932514 ;
	setAttr ".uvtk[390]" -type "float2" 0.46462983 0.55251366 ;
	setAttr ".uvtk[391]" -type "float2" -0.19743013 0.54002362 ;
	setAttr ".uvtk[392]" -type "float2" 0.41081625 0.48955983 ;
	setAttr ".uvtk[393]" -type "float2" -0.45304656 0.63522816 ;
	setAttr ".uvtk[394]" -type "float2" 0.46362722 0.54768831 ;
	setAttr ".uvtk[395]" -type "float2" -0.19817413 0.53696048 ;
	setAttr ".uvtk[396]" -type "float2" 0.39400935 0.44718021 ;
	setAttr ".uvtk[397]" -type "float2" -0.44805658 0.60480046 ;
	setAttr ".uvtk[398]" -type "float2" 0.45617199 0.51159549 ;
	setAttr ".uvtk[399]" -type "float2" -0.20371011 0.51424819 ;
	setAttr ".uvtk[400]" -type "float2" 0.39322716 0.44426644 ;
	setAttr ".uvtk[401]" -type "float2" 0.18010059 0.52850151 ;
	setAttr ".uvtk[402]" -type "float2" -0.51170623 0.5918597 ;
	setAttr ".uvtk[403]" -type "float2" -0.20401187 0.51273465 ;
	setAttr ".uvtk[404]" -type "float2" 0.3868677 0.42821205 ;
	setAttr ".uvtk[405]" -type "float2" 0.17376259 0.51242441 ;
	setAttr ".uvtk[406]" -type "float2" -0.50958318 0.58052725 ;
	setAttr ".uvtk[407]" -type "float2" -0.20615718 0.50419688 ;
	setAttr ".uvtk[409]" -type "float2" -0.2530117 0.51435053 ;
	setAttr ".uvtk[410]" -type "float2" 0.17799366 0.50714093 ;
	setAttr ".uvtk[412]" -type "float2" -0.50717616 0.57670206 ;
	setAttr ".uvtk[415]" -type "float2" -0.20817079 0.50139636 ;
	setAttr ".uvtk[416]" -type "float2" -0.26544902 0.2711522 ;
	setAttr ".uvtk[419]" -type "float2" -0.49423051 0.42053989 ;
	setAttr ".uvtk[421]" -type "float2" -0.55170667 0.31069514 ;
	setAttr ".uvtk[422]" -type "float2" -0.32291901 0.16131368 ;
	setAttr ".uvtk[424]" -type "float2" 0 0.16394609 ;
	setAttr ".uvtk[425]" -type "float2" -0.36862928 0.39893556 ;
	setAttr ".uvtk[427]" -type "float2" -0.083008125 0.22224821 ;
	setAttr ".uvtk[428]" -type "float2" -2.9802322e-07 0.16394585 ;
	setAttr ".uvtk[429]" -type "float2" 4.1723251e-07 0.16394565 ;
	setAttr ".uvtk[430]" -type "float2" 6.5565109e-07 0.16394603 ;
	setAttr ".uvtk[432]" -type "float2" 5.9604645e-08 0.1639463 ;
	setAttr ".uvtk[433]" -type "float2" 0 0.16394638 ;
	setAttr ".uvtk[434]" -type "float2" -0.39251441 0.41050166 ;
	setAttr ".uvtk[435]" -type "float2" -1.7881393e-07 0.16394627 ;
	setAttr ".uvtk[436]" -type "float2" -0.074040189 0.25504974 ;
	setAttr ".uvtk[438]" -type "float2" 0.29801789 0.58113062 ;
	setAttr ".uvtk[439]" -type "float2" 1.1920929e-07 0.16394581 ;
	setAttr ".uvtk[440]" -type "float2" -2.9802322e-07 0.1639462 ;
	setAttr ".uvtk[441]" -type "float2" 0.45116758 0.55538177 ;
	setAttr ".uvtk[442]" -type "float2" 0.30678207 0.62473696 ;
	setAttr ".uvtk[443]" -type "float2" -2.3841858e-07 0.16394597 ;
	setAttr ".uvtk[444]" -type "float2" 4.1723251e-07 0.16394627 ;
	setAttr ".uvtk[445]" -type "float2" 0.46003062 0.59672552 ;
	setAttr ".uvtk[446]" -type "float2" 0.31535232 0.6667757 ;
	setAttr ".uvtk[447]" -type "float2" -4.1723251e-07 0.16394636 ;
	setAttr ".uvtk[448]" -type "float2" 2.9802322e-07 0.16394588 ;
	setAttr ".uvtk[449]" -type "float2" 0.46943784 0.63954598 ;
	setAttr ".uvtk[450]" -type "float2" 0.3239173 0.70805478 ;
	setAttr ".uvtk[451]" -type "float2" 0 0.16394663 ;
	setAttr ".uvtk[452]" -type "float2" -1.1920929e-07 0.1639462 ;
	setAttr ".uvtk[453]" -type "float2" 0.47845334 0.67955613 ;
	setAttr ".uvtk[454]" -type "float2" 0.33094609 0.74124718 ;
	setAttr ".uvtk[455]" -type "float2" 5.9604645e-08 0.16394567 ;
	setAttr ".uvtk[456]" -type "float2" -5.9604645e-08 0.1639457 ;
	setAttr ".uvtk[457]" -type "float2" 0.48588842 0.71235776 ;
	setAttr ".uvtk[458]" -type "float2" 0.33743045 0.77153605 ;
	setAttr ".uvtk[459]" -type "float2" 1.7881393e-07 0.16394582 ;
	setAttr ".uvtk[460]" -type "float2" -2.3841858e-07 0.16394632 ;
	setAttr ".uvtk[461]" -type "float2" 0.29072574 0.54437256 ;
createNode polyAutoProj -n "polyAutoProj6";
	rename -uid "5D656C73-4DE3-EAB5-413E-9090790BFA01";
	setAttr ".cch" yes;
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 47 "f[1]" "f[27]" "f[39]" "f[55:57]" "f[63]" "f[65]" "f[70]" "f[80]" "f[85]" "f[87]" "f[92]" "f[102]" "f[107]" "f[109]" "f[114]" "f[124]" "f[129]" "f[131]" "f[136]" "f[146]" "f[151]" "f[153]" "f[158]" "f[168]" "f[173]" "f[175]" "f[180]" "f[190]" "f[194:195]" "f[197]" "f[204]" "f[209]" "f[216]" "f[221]" "f[228]" "f[233]" "f[240]" "f[245]" "f[252]" "f[257]" "f[264]" "f[269:271]" "f[273:275]" "f[277:279]" "f[281:283]" "f[285:287]" "f[289]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".s" -type "double3" 31.68200063705444 31.68200063705444 31.68200063705444 ;
	setAttr ".o" 0;
	setAttr ".ps" 0.20000000298023224;
	setAttr ".dl" yes;
createNode polyTweakUV -n "polyTweakUV10";
	rename -uid "F4B900A1-4A91-2196-9D2C-BAABABFACD63";
	setAttr ".uopa" yes;
	setAttr -s 539 ".uvtk";
	setAttr ".uvtk[390]" -type "float2" 0 -0.40641671 ;
	setAttr ".uvtk[391]" -type "float2" 0 -0.40641671 ;
	setAttr ".uvtk[392]" -type "float2" 1.4901161e-08 -0.52950215 ;
	setAttr ".uvtk[393]" -type "float2" -1.4901161e-08 -0.52950221 ;
	setAttr ".uvtk[394]" -type "float2" -0.0068747252 -0.39149469 ;
	setAttr ".uvtk[395]" -type "float2" -0.065794006 -0.39149469 ;
	setAttr ".uvtk[396]" -type "float2" -0.065794006 -0.54442418 ;
	setAttr ".uvtk[397]" -type "float2" -0.0068747252 -0.54442418 ;
	setAttr ".uvtk[398]" -type "float2" 0 -0.40641671 ;
	setAttr ".uvtk[399]" -type "float2" 0 -0.40641671 ;
	setAttr ".uvtk[400]" -type "float2" 7.4505806e-09 -0.53562808 ;
	setAttr ".uvtk[401]" -type "float2" 0 -0.53562808 ;
	setAttr ".uvtk[402]" -type "float2" -0.0068747103 -0.39075208 ;
	setAttr ".uvtk[403]" -type "float2" -0.065793991 -0.39075208 ;
	setAttr ".uvtk[404]" -type "float2" -0.065793991 -0.55129272 ;
	setAttr ".uvtk[405]" -type "float2" -0.0068747178 -0.55129272 ;
	setAttr ".uvtk[406]" -type "float2" -0.072701521 -0.40638396 ;
	setAttr ".uvtk[407]" -type "float2" -0.072635971 -0.40638396 ;
	setAttr ".uvtk[408]" -type "float2" -0.072635971 -0.53473449 ;
	setAttr ".uvtk[409]" -type "float2" -0.072701521 -0.53473449 ;
	setAttr ".uvtk[410]" -type "float2" -0.079510756 -0.39078483 ;
	setAttr ".uvtk[411]" -type "float2" -0.13849559 -0.39078483 ;
	setAttr ".uvtk[412]" -type "float2" -0.13849559 -0.55033362 ;
	setAttr ".uvtk[413]" -type "float2" -0.079510756 -0.55033362 ;
	setAttr ".uvtk[414]" -type "float2" -0.043084204 -0.39161962 ;
	setAttr ".uvtk[415]" -type "float2" -0.10225335 -0.39161962 ;
	setAttr ".uvtk[416]" -type "float2" -0.10225335 -0.54084802 ;
	setAttr ".uvtk[417]" -type "float2" -0.043084204 -0.54084802 ;
	setAttr ".uvtk[418]" -type "float2" -0.079418644 -0.39161959 ;
	setAttr ".uvtk[419]" -type "float2" -0.13858773 -0.39161959 ;
	setAttr ".uvtk[420]" -type "float2" -0.13858773 -0.54084802 ;
	setAttr ".uvtk[421]" -type "float2" -0.079418644 -0.54084802 ;
	setAttr ".uvtk[422]" -type "float2" 0 -0.40641671 ;
	setAttr ".uvtk[423]" -type "float2" 0 -0.40641671 ;
	setAttr ".uvtk[424]" -type "float2" 0 -0.50133288 ;
	setAttr ".uvtk[425]" -type "float2" 0 -0.50133288 ;
	setAttr ".uvtk[426]" -type "float2" -0.0068747699 -0.39490974 ;
	setAttr ".uvtk[427]" -type "float2" -0.065794051 -0.39490974 ;
	setAttr ".uvtk[428]" -type "float2" -0.065794051 -0.51283985 ;
	setAttr ".uvtk[429]" -type "float2" -0.0068747699 -0.51283985 ;
	setAttr ".uvtk[430]" -type "float2" 0 -0.40641671 ;
	setAttr ".uvtk[431]" -type "float2" 0 -0.40641671 ;
	setAttr ".uvtk[432]" -type "float2" 0 -0.49162033 ;
	setAttr ".uvtk[433]" -type "float2" 0 -0.49162033 ;
	setAttr ".uvtk[434]" -type "float2" -0.0068747103 -0.39608723 ;
	setAttr ".uvtk[435]" -type "float2" -0.065794051 -0.39608723 ;
	setAttr ".uvtk[436]" -type "float2" -0.065794051 -0.50194979 ;
	setAttr ".uvtk[437]" -type "float2" -0.0068747103 -0.50194979 ;
	setAttr ".uvtk[438]" -type "float2" 0 -0.40641671 ;
	setAttr ".uvtk[439]" -type "float2" 0 -0.40641671 ;
	setAttr ".uvtk[440]" -type "float2" -0.0036382675 -0.42021424 ;
	setAttr ".uvtk[441]" -type "float2" -0.0042543411 -0.42123127 ;
	setAttr ".uvtk[442]" -type "float2" 0.0079244971 -0.39807686 ;
	setAttr ".uvtk[443]" -type "float2" 0.0039254427 -0.41161332 ;
	setAttr ".uvtk[444]" -type "float2" -0.0039541721 -0.42127171 ;
	setAttr ".uvtk[445]" -type "float2" -0.0046073794 -0.42234817 ;
	setAttr ".uvtk[446]" -type "float2" 0.0046389103 -0.4108308 ;
	setAttr ".uvtk[447]" -type "float2" 0.0086403489 -0.39731398 ;
	setAttr ".uvtk[448]" -type "float2" 0.0036104321 -0.4126589 ;
	setAttr ".uvtk[449]" -type "float2" 0.004327476 -0.41184041 ;
	setAttr ".uvtk[450]" -type "float2" 0 -0.40641671 ;
	setAttr ".uvtk[451]" -type "float2" 0 -0.40641671 ;
	setAttr ".uvtk[452]" -type "float2" 0 -0.38946444 ;
	setAttr ".uvtk[453]" -type "float2" 0 -0.38946444 ;
	setAttr ".uvtk[454]" -type "float2" -0.0063596964 -0.41892406 ;
	setAttr ".uvtk[455]" -type "float2" -0.0063596964 -0.37695703 ;
	setAttr ".uvtk[456]" -type "float2" -0.059042275 -0.37695703 ;
	setAttr ".uvtk[457]" -type "float2" -0.059042275 -0.41892406 ;
	setAttr ".uvtk[458]" -type "float2" -0.065401912 -0.40641671 ;
	setAttr ".uvtk[459]" -type "float2" -0.065401912 -0.38946444 ;
	setAttr ".uvtk[460]" -type "float2" -0.065401971 -0.38946444 ;
	setAttr ".uvtk[461]" -type "float2" -0.065401971 -0.40641671 ;
	setAttr ".uvtk[462]" -type "float2" -0.071761668 -0.41892406 ;
	setAttr ".uvtk[463]" -type "float2" -0.071761668 -0.37695703 ;
	setAttr ".uvtk[464]" -type "float2" -0.12444413 -0.37695703 ;
	setAttr ".uvtk[465]" -type "float2" -0.12444413 -0.41892406 ;
	setAttr ".uvtk[466]" -type "float2" -0.13080382 -0.40641671 ;
	setAttr ".uvtk[467]" -type "float2" -0.13080382 -0.38946444 ;
	setAttr ".uvtk[468]" -type "float2" -0.13080388 -0.38946444 ;
	setAttr ".uvtk[469]" -type "float2" -0.13080388 -0.40641671 ;
	setAttr ".uvtk[470]" -type "float2" -0.13716352 -0.41892406 ;
	setAttr ".uvtk[471]" -type "float2" -0.13716352 -0.37695703 ;
	setAttr ".uvtk[472]" -type "float2" -0.1898461 -0.37695703 ;
	setAttr ".uvtk[473]" -type "float2" -0.1898461 -0.41892406 ;
	setAttr ".uvtk[474]" -type "float2" -0.19620574 -0.40641671 ;
	setAttr ".uvtk[475]" -type "float2" -0.19620574 -0.38946444 ;
	setAttr ".uvtk[476]" -type "float2" -0.19620579 -0.38946444 ;
	setAttr ".uvtk[477]" -type "float2" -0.19620579 -0.40641671 ;
	setAttr ".uvtk[478]" -type "float2" -0.20256549 -0.41892406 ;
	setAttr ".uvtk[479]" -type "float2" -0.20256549 -0.37695703 ;
	setAttr ".uvtk[480]" -type "float2" -0.25524801 -0.37695703 ;
	setAttr ".uvtk[481]" -type "float2" -0.25524801 -0.41892406 ;
	setAttr ".uvtk[482]" -type "float2" -0.26160771 -0.40641671 ;
	setAttr ".uvtk[483]" -type "float2" -0.26160771 -0.38946444 ;
	setAttr ".uvtk[484]" -type "float2" -0.26160771 -0.38946444 ;
	setAttr ".uvtk[485]" -type "float2" -0.26160771 -0.40641671 ;
	setAttr ".uvtk[486]" -type "float2" -0.2679674 -0.41892406 ;
	setAttr ".uvtk[487]" -type "float2" -0.2679674 -0.37695703 ;
	setAttr ".uvtk[488]" -type "float2" -0.32064992 -0.37695703 ;
	setAttr ".uvtk[489]" -type "float2" -0.32064992 -0.41892406 ;
	setAttr ".uvtk[490]" -type "float2" -0.32700968 -0.40641671 ;
	setAttr ".uvtk[491]" -type "float2" -0.32700968 -0.38946444 ;
	setAttr ".uvtk[492]" -type "float2" -0.32700968 -0.38946444 ;
	setAttr ".uvtk[493]" -type "float2" -0.32700968 -0.40641671 ;
	setAttr ".uvtk[494]" -type "float2" -0.33237493 -0.41892406 ;
	setAttr ".uvtk[495]" -type "float2" -0.33237493 -0.37695703 ;
	setAttr ".uvtk[496]" -type "float2" -0.38505745 -0.37695703 ;
	setAttr ".uvtk[497]" -type "float2" -0.38505745 -0.41892406 ;
	setAttr ".uvtk[498]" -type "float2" 0 -0.40641671 ;
	setAttr ".uvtk[499]" -type "float2" 0 -0.40641671 ;
	setAttr ".uvtk[500]" -type "float2" 4.1909516e-07 -0.53808004 ;
	setAttr ".uvtk[501]" -type "float2" -2.9383227e-07 -0.53808022 ;
	setAttr ".uvtk[502]" -type "float2" -5.5879354e-09 -0.55573183 ;
	setAttr ".uvtk[503]" -type "float2" 1.4412217e-07 -0.55573201 ;
	setAttr ".uvtk[504]" -type "float2" -6.06291e-06 -0.69395101 ;
	setAttr ".uvtk[505]" -type "float2" 6.131595e-06 -0.69395113 ;
	setAttr ".uvtk[506]" -type "float2" -6.4689666e-06 -0.70648193 ;
	setAttr ".uvtk[507]" -type "float2" 6.4938795e-06 -0.70648223 ;
	setAttr ".uvtk[508]" -type "float2" -8.1714243e-06 -0.84382403 ;
	setAttr ".uvtk[509]" -type "float2" 8.2233455e-06 -0.84382403 ;
	setAttr ".uvtk[510]" -type "float2" -8.9164823e-06 -0.86219937 ;
	setAttr ".uvtk[511]" -type "float2" 8.9826062e-06 -0.86219978 ;
	setAttr ".uvtk[512]" -type "float2" -1.492165e-05 -0.99058408 ;
	setAttr ".uvtk[513]" -type "float2" 1.4142366e-05 -0.99058402 ;
	setAttr ".uvtk[514]" -type "float2" -1.5536323e-05 -1.0068597 ;
	setAttr ".uvtk[515]" -type "float2" 1.4760066e-05 -1.0068607 ;
	setAttr ".uvtk[516]" -type "float2" -1.2369826e-05 -1.1084032 ;
	setAttr ".uvtk[517]" -type "float2" 1.4782418e-05 -1.108402 ;
	setAttr ".uvtk[518]" -type "float2" -1.2688339e-05 -1.1246316 ;
	setAttr ".uvtk[519]" -type "float2" 1.4387304e-05 -1.124631 ;
	setAttr ".uvtk[520]" -type "float2" -1.8944964e-05 -1.2157767 ;
	setAttr ".uvtk[521]" -type "float2" 1.0400545e-05 -1.2157792 ;
	setAttr ".uvtk[522]" -type "float2" -1.7417595e-05 -1.2420924 ;
	setAttr ".uvtk[523]" -type "float2" 1.1934433e-05 -1.2420909 ;
	setAttr ".uvtk[524]" -type "float2" -1.5148893e-05 -1.2515059 ;
	setAttr ".uvtk[525]" -type "float2" 1.2908829e-05 -1.2515051 ;
	setAttr ".uvtk[526]" -type "float2" -9.5404685e-06 -1.2621279 ;
	setAttr ".uvtk[527]" -type "float2" 1.4489517e-05 -1.2621291 ;
	setAttr ".uvtk[528]" -type "float2" -8.2161278e-06 -1.270277 ;
	setAttr ".uvtk[529]" -type "float2" 1.5171012e-05 -1.2702781 ;
	setAttr ".uvtk[530]" -type "float2" -9.7919255e-06 -1.2871883 ;
	setAttr ".uvtk[531]" -type "float2" 1.6692327e-05 -1.2871872 ;
	setAttr ".uvtk[532]" -type "float2" -1.5571713e-05 -1.334233 ;
	setAttr ".uvtk[533]" -type "float2" 1.3681478e-05 -1.3342315 ;
	setAttr ".uvtk[534]" -type "float2" -1.7113984e-05 -1.3561232 ;
	setAttr ".uvtk[535]" -type "float2" 1.2974255e-05 -1.3561237 ;
	setAttr ".uvtk[536]" -type "float2" 0 0.10234584 ;
	setAttr ".uvtk[537]" -type "float2" 0 0.10234583 ;
	setAttr ".uvtk[538]" -type "float2" 0.5475136 0.10235608 ;
	setAttr ".uvtk[539]" -type "float2" 0.54751152 0.10235836 ;
	setAttr ".uvtk[540]" -type "float2" 2.3841858e-07 0.1023478 ;
	setAttr ".uvtk[541]" -type "float2" 0.54751331 0.10235492 ;
	setAttr ".uvtk[542]" -type "float2" 0.019879073 0.098972633 ;
	setAttr ".uvtk[543]" -type "float2" 0.52661085 0.098973647 ;
	setAttr ".uvtk[544]" -type "float2" 0.019880097 0.098975576 ;
	setAttr ".uvtk[545]" -type "float2" 0.52661014 0.098971076 ;
	setAttr ".uvtk[546]" -type "float2" -0.02087811 0.090698548 ;
	setAttr ".uvtk[547]" -type "float2" 0.56946915 0.09067703 ;
	setAttr ".uvtk[548]" -type "float2" -0.020880325 0.090705425 ;
	setAttr ".uvtk[549]" -type "float2" 0.56946248 0.090666413 ;
	setAttr ".uvtk[550]" -type "float2" -0.004616946 0.089463487 ;
	setAttr ".uvtk[551]" -type "float2" 0.55235684 0.089420632 ;
	setAttr ".uvtk[552]" -type "float2" 0 -0.40641671 ;
	setAttr ".uvtk[553]" -type "float2" 0 -0.40641671 ;
	setAttr ".uvtk[554]" -type "float2" 0.0081104636 -0.4066571 ;
	setAttr ".uvtk[555]" -type "float2" -0.0081104636 -0.4066571 ;
	setAttr ".uvtk[556]" -type "float2" 0.022744477 -0.40642819 ;
	setAttr ".uvtk[557]" -type "float2" 0.022760093 -0.40642819 ;
	setAttr ".uvtk[558]" -type "float2" 0.030886352 -0.40664563 ;
	setAttr ".uvtk[559]" -type "float2" 0.014618218 -0.40664563 ;
	setAttr ".uvtk[560]" -type "float2" 0 -0.40641671 ;
	setAttr ".uvtk[561]" -type "float2" 0 -0.40641671 ;
	setAttr ".uvtk[562]" -type "float2" 0.0091823339 -0.4067249 ;
	setAttr ".uvtk[563]" -type "float2" -0.0091823339 -0.4067249 ;
	setAttr ".uvtk[564]" -type "float2" 0 -0.40641671 ;
	setAttr ".uvtk[565]" -type "float2" 0 -0.40641671 ;
	setAttr ".uvtk[566]" -type "float2" 0.0062639713 -0.40656009 ;
	setAttr ".uvtk[567]" -type "float2" -0.0062639713 -0.40656009 ;
	setAttr ".uvtk[568]" -type "float2" 0 -0.40641671 ;
	setAttr ".uvtk[569]" -type "float2" 0 -0.40641671 ;
	setAttr ".uvtk[570]" -type "float2" 0.0088218451 -0.40670115 ;
	setAttr ".uvtk[571]" -type "float2" -0.0088218451 -0.40670115 ;
createNode polyMapDel -n "polyMapDel1";
	rename -uid "0D481950-414F-4BA7-DAF1-4C92CFD9B497";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 7 "f[194]" "f[209]" "f[221]" "f[233]" "f[245]" "f[257]" "f[269]";
createNode polyTweakUV -n "polyTweakUV11";
	rename -uid "AE9C5445-4AC8-805C-A56A-19B623108A77";
	setAttr ".uopa" yes;
	setAttr -s 167 ".uvtk";
	setAttr ".uvtk[390]" -type "float2" -0.011125557 0.49401465 ;
	setAttr ".uvtk[391]" -type "float2" 0.076389581 0.49401465 ;
	setAttr ".uvtk[392]" -type "float2" 0.076389611 0.53834319 ;
	setAttr ".uvtk[393]" -type "float2" -0.011125602 0.53834295 ;
	setAttr ".uvtk[394]" -type "float2" 0.076389581 0.53834319 ;
	setAttr ".uvtk[395]" -type "float2" -0.011125498 0.53834319 ;
	setAttr ".uvtk[396]" -type "float2" -0.011125498 0.49401465 ;
	setAttr ".uvtk[397]" -type "float2" 0.076389581 0.49401465 ;
	setAttr ".uvtk[398]" -type "float2" 0.13133942 0.4173024 ;
	setAttr ".uvtk[399]" -type "float2" 0.21871275 0.4173024 ;
	setAttr ".uvtk[400]" -type "float2" 0.21871287 0.46376154 ;
	setAttr ".uvtk[401]" -type "float2" 0.13133942 0.46376154 ;
	setAttr ".uvtk[402]" -type "float2" 0.21871285 0.46376154 ;
	setAttr ".uvtk[403]" -type "float2" 0.13133942 0.46376154 ;
	setAttr ".uvtk[404]" -type "float2" 0.13133942 0.4173024 ;
	setAttr ".uvtk[405]" -type "float2" 0.21871275 0.4173024 ;
	setAttr ".uvtk[406]" -type "float2" 0.13124235 0.41739956 ;
	setAttr ".uvtk[407]" -type "float2" 0.21880996 0.41739956 ;
	setAttr ".uvtk[408]" -type "float2" 0.21880996 0.46366444 ;
	setAttr ".uvtk[409]" -type "float2" 0.13124235 0.46366444 ;
	setAttr ".uvtk[410]" -type "float2" 0.21880996 0.46366432 ;
	setAttr ".uvtk[411]" -type "float2" 0.13124231 0.46366432 ;
	setAttr ".uvtk[412]" -type "float2" 0.13124231 0.41739956 ;
	setAttr ".uvtk[413]" -type "float2" 0.21880996 0.41739956 ;
	setAttr ".uvtk[414]" -type "float2" 0.07676059 0.53797215 ;
	setAttr ".uvtk[415]" -type "float2" -0.011496596 0.53797215 ;
	setAttr ".uvtk[416]" -type "float2" -0.011496596 0.49438584 ;
	setAttr ".uvtk[417]" -type "float2" 0.07676059 0.49438584 ;
	setAttr ".uvtk[418]" -type "float2" 0.07676062 0.53797215 ;
	setAttr ".uvtk[419]" -type "float2" -0.011496551 0.53797215 ;
	setAttr ".uvtk[420]" -type "float2" -0.011496551 0.49438572 ;
	setAttr ".uvtk[421]" -type "float2" 0.07676062 0.49438572 ;
	setAttr ".uvtk[422]" -type "float2" -0.15435648 0.56699085 ;
	setAttr ".uvtk[423]" -type "float2" -0.065167852 0.56699085 ;
	setAttr ".uvtk[424]" -type "float2" -0.065167852 0.60182798 ;
	setAttr ".uvtk[425]" -type "float2" -0.15435648 0.60182798 ;
	setAttr ".uvtk[426]" -type "float2" -0.065167852 0.60182798 ;
	setAttr ".uvtk[427]" -type "float2" -0.15435648 0.60182798 ;
	setAttr ".uvtk[428]" -type "float2" -0.15435648 0.56699085 ;
	setAttr ".uvtk[429]" -type "float2" -0.065167852 0.56699085 ;
	setAttr ".uvtk[430]" -type "float2" -0.22570427 0.62263834 ;
	setAttr ".uvtk[431]" -type "float2" -0.13918082 0.62263834 ;
	setAttr ".uvtk[432]" -type "float2" -0.13918082 0.6529761 ;
	setAttr ".uvtk[433]" -type "float2" -0.22570427 0.6529761 ;
	setAttr ".uvtk[434]" -type "float2" -0.13918082 0.65297604 ;
	setAttr ".uvtk[435]" -type "float2" -0.22570415 0.65297604 ;
	setAttr ".uvtk[436]" -type "float2" -0.22570415 0.62263834 ;
	setAttr ".uvtk[437]" -type "float2" -0.13918082 0.62263834 ;
	setAttr ".uvtk[438]" -type "float2" -0.13576043 0.56209671 ;
	setAttr ".uvtk[439]" -type "float2" -0.11643809 0.55749035 ;
	setAttr ".uvtk[440]" -type "float2" -0.11507446 0.66455865 ;
	setAttr ".uvtk[441]" -type "float2" -0.13979137 0.66369712 ;
	setAttr ".uvtk[442]" -type "float2" 0.11423038 0.55788296 ;
	setAttr ".uvtk[443]" -type "float2" 0.11371796 0.66713232 ;
	setAttr ".uvtk[444]" -type "float2" -0.11519068 0.67287064 ;
	setAttr ".uvtk[445]" -type "float2" -0.14023003 0.67169142 ;
	setAttr ".uvtk[446]" -type "float2" 0.13446799 0.66738212 ;
	setAttr ".uvtk[447]" -type "float2" 0.13496581 0.55800587 ;
	setAttr ".uvtk[448]" -type "float2" 0.11362533 0.6755178 ;
	setAttr ".uvtk[449]" -type "float2" 0.13445154 0.67598832 ;
	setAttr ".uvtk[450]" -type "float2" 0.38935339 0.54783952 ;
	setAttr ".uvtk[451]" -type "float2" 0.40963417 0.88642538 ;
	setAttr ".uvtk[452]" -type "float2" 0.24886665 0.89605516 ;
	setAttr ".uvtk[453]" -type "float2" 0.22858572 0.55746931 ;
	setAttr ".uvtk[454]" -type "float2" 0.22858602 0.55746943 ;
	setAttr ".uvtk[455]" -type "float2" 0.38935322 0.54783964 ;
	setAttr ".uvtk[456]" -type "float2" 0.40963417 0.88642538 ;
	setAttr ".uvtk[457]" -type "float2" 0.24886701 0.89605516 ;
	setAttr ".uvtk[458]" -type "float2" 0.40963417 0.88642538 ;
	setAttr ".uvtk[459]" -type "float2" 0.24886665 0.89605516 ;
	setAttr ".uvtk[460]" -type "float2" 0.22858572 0.55746931 ;
	setAttr ".uvtk[461]" -type "float2" 0.38935339 0.54783952 ;
	setAttr ".uvtk[462]" -type "float2" 0.22858536 0.55746931 ;
	setAttr ".uvtk[463]" -type "float2" 0.38935339 0.54783952 ;
	setAttr ".uvtk[464]" -type "float2" 0.40963411 0.88642538 ;
	setAttr ".uvtk[465]" -type "float2" 0.24886623 0.89605516 ;
	setAttr ".uvtk[466]" -type "float2" 0.40963417 0.88642538 ;
	setAttr ".uvtk[467]" -type "float2" 0.24886665 0.89605516 ;
	setAttr ".uvtk[468]" -type "float2" 0.22858572 0.55746931 ;
	setAttr ".uvtk[469]" -type "float2" 0.38935339 0.54783952 ;
	setAttr ".uvtk[470]" -type "float2" 0.22858602 0.55746943 ;
	setAttr ".uvtk[471]" -type "float2" 0.38935322 0.54783964 ;
	setAttr ".uvtk[472]" -type "float2" 0.40963417 0.88642538 ;
	setAttr ".uvtk[473]" -type "float2" 0.24886701 0.89605516 ;
	setAttr ".uvtk[474]" -type "float2" 0.40963417 0.88642538 ;
	setAttr ".uvtk[475]" -type "float2" 0.24886665 0.89605516 ;
	setAttr ".uvtk[476]" -type "float2" 0.22858572 0.55746931 ;
	setAttr ".uvtk[477]" -type "float2" 0.38935339 0.54783952 ;
	setAttr ".uvtk[478]" -type "float2" 0.22858572 0.55746931 ;
	setAttr ".uvtk[479]" -type "float2" 0.38935339 0.54783952 ;
	setAttr ".uvtk[480]" -type "float2" 0.40963417 0.88642538 ;
	setAttr ".uvtk[481]" -type "float2" 0.24886665 0.89605516 ;
	setAttr ".uvtk[482]" -type "float2" 0.40963417 0.88642538 ;
	setAttr ".uvtk[483]" -type "float2" 0.24886665 0.89605516 ;
	setAttr ".uvtk[484]" -type "float2" 0.22858572 0.55746931 ;
	setAttr ".uvtk[485]" -type "float2" 0.38935339 0.54783952 ;
	setAttr ".uvtk[486]" -type "float2" 0.22858572 0.55746931 ;
	setAttr ".uvtk[487]" -type "float2" 0.38935339 0.54783952 ;
	setAttr ".uvtk[488]" -type "float2" 0.40963417 0.88642538 ;
	setAttr ".uvtk[489]" -type "float2" 0.24886665 0.89605516 ;
	setAttr ".uvtk[490]" -type "float2" 0.40963417 0.88642538 ;
	setAttr ".uvtk[491]" -type "float2" 0.24886665 0.89605516 ;
	setAttr ".uvtk[492]" -type "float2" 0.22858572 0.55746931 ;
	setAttr ".uvtk[493]" -type "float2" 0.38935339 0.54783952 ;
	setAttr ".uvtk[494]" -type "float2" 0.22858572 0.55746931 ;
	setAttr ".uvtk[495]" -type "float2" 0.38935339 0.54783952 ;
	setAttr ".uvtk[496]" -type "float2" 0.40963417 0.88642538 ;
	setAttr ".uvtk[497]" -type "float2" 0.24886665 0.89605516 ;
	setAttr ".uvtk[498]" -type "float2" 0.022615481 0.41380161 ;
	setAttr ".uvtk[499]" -type "float2" 0.16101819 0.41380161 ;
	setAttr ".uvtk[500]" -type "float2" 0.16102038 0.44713509 ;
	setAttr ".uvtk[501]" -type "float2" 0.022613935 0.4471342 ;
	setAttr ".uvtk[502]" -type "float2" 0.16101818 0.45160347 ;
	setAttr ".uvtk[503]" -type "float2" 0.022616232 0.45160252 ;
	setAttr ".uvtk[504]" -type "float2" 0.16098635 0.48657984 ;
	setAttr ".uvtk[505]" -type "float2" 0.022647697 0.48657924 ;
	setAttr ".uvtk[506]" -type "float2" 0.16098422 0.48974937 ;
	setAttr ".uvtk[507]" -type "float2" 0.022649601 0.48974788 ;
	setAttr ".uvtk[508]" -type "float2" 0.16097528 0.52446675 ;
	setAttr ".uvtk[509]" -type "float2" 0.022658681 0.52446675 ;
	setAttr ".uvtk[510]" -type "float2" 0.16097136 0.52911067 ;
	setAttr ".uvtk[511]" -type "float2" 0.022662677 0.52910858 ;
	setAttr ".uvtk[512]" -type "float2" 0.16093981 0.56153691 ;
	setAttr ".uvtk[513]" -type "float2" 0.022689786 0.56153727 ;
	setAttr ".uvtk[514]" -type "float2" 0.16093656 0.56564575 ;
	setAttr ".uvtk[515]" -type "float2" 0.022693027 0.56564009 ;
	setAttr ".uvtk[516]" -type "float2" 0.16095321 0.59128445 ;
	setAttr ".uvtk[517]" -type "float2" 0.022693139 0.59129077 ;
	setAttr ".uvtk[518]" -type "float2" 0.16095152 0.59538466 ;
	setAttr ".uvtk[519]" -type "float2" 0.022691075 0.59538776 ;
	setAttr ".uvtk[520]" -type "float2" 0.16091865 0.61844057 ;
	setAttr ".uvtk[521]" -type "float2" 0.022670124 0.6184274 ;
	setAttr ".uvtk[522]" -type "float2" 0.1609267 0.62505323 ;
	setAttr ".uvtk[523]" -type "float2" 0.022678187 0.62506074 ;
	setAttr ".uvtk[524]" -type "float2" 0.16093861 0.62742281 ;
	setAttr ".uvtk[525]" -type "float2" 0.0226833 0.62742651 ;
	setAttr ".uvtk[526]" -type "float2" 0.15568434 0.63095099 ;
	setAttr ".uvtk[527]" -type "float2" 0.027716452 0.63094473 ;
	setAttr ".uvtk[528]" -type "float2" 0.15569128 0.63300329 ;
	setAttr ".uvtk[529]" -type "float2" 0.027720032 0.63299763 ;
	setAttr ".uvtk[530]" -type "float2" 0.1665175 0.63935572 ;
	setAttr ".uvtk[531]" -type "float2" 0.01742412 0.63936132 ;
	setAttr ".uvtk[532]" -type "float2" 0.16648713 0.65126163 ;
	setAttr ".uvtk[533]" -type "float2" 0.017408296 0.65126985 ;
	setAttr ".uvtk[534]" -type "float2" 0.16215603 0.65712124 ;
	setAttr ".uvtk[535]" -type "float2" 0.0215161 0.65711874 ;
	setAttr ".uvtk[536]" -type "float2" -0.41863456 0.47708541 ;
	setAttr ".uvtk[537]" -type "float2" -0.41863456 0.47708541 ;
	setAttr ".uvtk[538]" -type "float2" -0.41863456 0.47708541 ;
	setAttr ".uvtk[539]" -type "float2" -0.41863456 0.47708541 ;
	setAttr ".uvtk[540]" -type "float2" -0.41863456 0.47708541 ;
	setAttr ".uvtk[541]" -type "float2" -0.41863456 0.47708541 ;
	setAttr ".uvtk[542]" -type "float2" -0.41863456 0.47708541 ;
	setAttr ".uvtk[543]" -type "float2" -0.41863456 0.47708541 ;
	setAttr ".uvtk[544]" -type "float2" -0.41863456 0.47708541 ;
	setAttr ".uvtk[545]" -type "float2" -0.41863456 0.47708541 ;
	setAttr ".uvtk[546]" -type "float2" -0.41863456 0.47708541 ;
	setAttr ".uvtk[547]" -type "float2" -0.41863456 0.47708541 ;
	setAttr ".uvtk[548]" -type "float2" -0.41863456 0.47708541 ;
	setAttr ".uvtk[549]" -type "float2" -0.41863456 0.47708541 ;
	setAttr ".uvtk[550]" -type "float2" -0.41863456 0.47708541 ;
	setAttr ".uvtk[551]" -type "float2" -0.41863456 0.47708541 ;
	setAttr ".uvtk[552]" -type "float2" -0.41863456 0.47708541 ;
	setAttr ".uvtk[553]" -type "float2" -0.41863456 0.47708541 ;
	setAttr ".uvtk[554]" -type "float2" -0.41863456 0.47708541 ;
	setAttr ".uvtk[555]" -type "float2" -0.41863456 0.47708541 ;
createNode polyAutoProj -n "polyAutoProj7";
	rename -uid "91CA452C-4F02-5188-5E6C-DBB3BF93E243";
	setAttr ".cch" yes;
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 18 "f[6:9]" "f[23]" "f[31]" "f[35]" "f[43]" "f[51]" "f[61]" "f[222:227]" "f[229:232]" "f[235]" "f[237:238]" "f[243]" "f[247]" "f[249:250]" "f[255]" "f[259]" "f[261:262]" "f[267]";
	setAttr ".ix" -type "matrix" 21.783984280329417 0 0 0 0 1 0 0 0 0 9.2485939045477092 0
		 0 1.9533067601044705 -4.7349194755441761 1;
	setAttr ".s" -type "double3" 34.104320645332336 34.104320645332336 34.104320645332336 ;
	setAttr ".o" 0;
	setAttr ".ps" 0.20000000298023224;
	setAttr ".dl" yes;
createNode polyTweakUV -n "polyTweakUV12";
	rename -uid "C812489B-4079-7707-851A-D7A63A0B9448";
	setAttr ".uopa" yes;
	setAttr -s 550 ".uvtk";
	setAttr ".uvtk[0:249]" -type "float2" 3.017492056 0.03311789 3.018758297
		 0.033126563 3.00068736076 0.028987408 3.016866446 0.027583182 3.019016027 0.026866078
		 3.018798113 0.027484566 3.017531872 0.027475715 3.017529011 0.027879 3.018795252
		 0.027887523 3.030781746 0.033211142 3.030818224 0.027971983 3.00083661079 0.024103284
		 3.0021727085 0.024098516 3.020554304 0.021356344 2.98817325 0.024169385 3.0011417866
		 0.023884833 3.0025515556 0.023880064 3.020488024 0.02104944 2.98779607 0.023955464
		 3.0050325394 0.024690092 3.031600952 0.024367332 3.031516314 0.024508119 3.0011358261
		 0.02277118 3.0025479794 0.022764027 3.020474672 0.020148396 2.98779106 0.022849023
		 3.0050418377 0.023523748 3.031772614 0.023667216 3.031462669 0.023636758 3.0025253296
		 0.022569835 3.020480156 0.019987464 3.025321245 0.020046234 3.0050623417 0.023321271
		 3.031808853 0.023489416 3.031451702 0.023481131 3.029792309 0.03320393 2.98921204
		 0.024164498 2.98888898 0.023949683 2.98888206 0.022837877 2.98889971 0.022644162
		 3.020092249 0.020185292 3.017895937 0.023639202 3.017877817 0.023435891 3.019026518
		 0.023446918 3.020238876 0.021170855 3.01788497 0.02480644 3.020781755 0.021292567
		 3.029611588 0.026940048 3.029831648 0.027561903 3.030820847 0.027569145 3.029828787
		 0.02796489 3.013893366 0.031195164 3.01511097 0.031197429 3.00031304359 0.031163841
		 3.0025100708 0.019612968 3.03141737 0.021062195 2.98885441 0.019734681 3.025374413
		 0.017575979 3.020484447 0.017513454 3.01905632 0.020363808 3.017907143 0.020352662
		 3.0050866604 0.020241261 3.031786919 0.021058798 3.0010945797 0.019226432 3.0025081635
		 0.019215524 3.03141284 0.020735502 3.025382042 0.017243326 3.02048564 0.017180145
		 3.019060612 0.019950449 3.017910957 0.019939303 3.0050899982 0.019828439 3.031785011
		 0.020729899 3.0024838448 0.016100347 3.031373978 0.018161118 2.98878264 0.016286314
		 3.025433779 0.014625967 3.020502806 0.014560103 3.019091845 0.016711354 3.017941236
		 0.016700208 3.0051138401 0.016592622 3.031746864 0.018155515 3.0010633469 0.015831709
		 3.002481699 0.015817165 3.03137064 0.017926872 3.025438547 0.014387846 3.020504475
		 0.014321744 3.019094706 0.016417563 3.017944098 0.016406476 3.0051159859 0.016299486
		 3.031745195 0.01792109 3.0024490356 0.012711763 3.031330824 0.015350819 2.98869419
		 0.012961686 3.025485992 0.011770487 3.020527601 0.011701465 3.019124985 0.013196766
		 3.017973661 0.013185918 3.0051388741 0.013082445 3.031706095 0.015344977 3.0010206699
		 0.012314737 3.0024445057 0.012295067 3.031325579 0.015005231 3.025492668 0.011419415
		 3.020531178 0.011349976 3.019129276 0.012765586 3.017977476 0.012755036 3.0051417351
		 0.01265204 3.03170228 0.014999151 3.0024039745 0.0093809962 3.031286955 0.012584925
		 2.98859119 0.0096824169 3.02553463 0.0089627504 3.020559311 0.0088918209 3.019155979
		 0.009752512 3.018003941 0.0097424984 3.0051622391 0.0096424222 3.031664133 0.012578964
		 3.0009701252 0.0090352893 3.0023980141 0.0090103745 3.031282187 0.012277722 3.025539637
		 0.0086508989 3.020562887 0.0085796714 3.019159555 0.009370327 3.018007278 0.0093604922
		 3.0051648617 0.0092606544 3.031659842 0.012271345 3.002355814 0.0066998601 3.031249285
		 0.010358393 2.98850298 0.0070309639 3.025570869 0.0067036152 3.020587683 0.0066305399
		 3.019179583 0.0069862008 3.018026829 0.0069769025 3.0051808357 0.0068787932 3.031627417
		 0.010351717 3.00091814995 0.0063592792 3.0023481846 0.0063299537 3.031243801 0.01005131
		 3.025575638 0.0063920021 3.020591974 0.0063189268 3.019182682 0.0066051483 3.018029928
		 0.0065960288 3.0051836967 0.006498158 3.031622171 0.010044575 3.0023050308 0.0042535663
		 3.031212568 0.0083270669 2.98842549 0.0045995116 3.025602341 0.0046435595 3.020617247
		 0.0045687556 3.019199848 0.0044642091 3.018046618 0.0044557452 3.0051984787 0.0043593645
		 3.031591177 0.0083202124 3.00085997581 0.00368613 3.002291441 0.0036534667 3.031203508
		 0.0078293085 3.02560997 0.0041384101 2.98841023 0.0040014386 3.020624399 0.0040636659
		 3.019204378 0.0038458705 3.018051386 0.0038381219 3.0052030087 0.0037418008 3.031582355
		 0.0078219175 3.00085473061 0.0034721494 3.0022866726 0.0034390688 3.031200171 0.007651031
		 3.025612831 0.0039580464 2.98840451 0.0037873387 3.020626783 0.0038830638 3.019206047
		 0.0036244988 3.018053055 0.0036171079 3.0052046776 0.003520906 3.031579018 0.0076434016
		 3.0013244152 0.026680291 2.99995089 0.026645362 3.013311863 0.026974201 3.01436758
		 0.033587813 3.013259888 0.033585459 3.00090479851 0.033557415 3.00034379959 0.027306855
		 2.99874163 0.027261257 3.014310122 0.027649224 3.015596867 0.032920182 3.014306307
		 0.032917738 2.99991274 0.03288433 3.00031638145 0.02842018 2.99871159 0.028375268
		 3.01428318 0.028765142 3.015599489 0.031773239 3.014309168 0.03177014 2.99991536
		 0.031737089 3.00039410591 0.0031424165 2.98887134 0.00343436 3.031021357 0.0071471334
		 3.031371355 0.0071395636 3.0056736469 0.0031725764 3.01756525 0.0032619238 3.018631458
		 0.0032687783 3.020806074 0.0033711791 3.025420666 0.0034407377 3.0017185211 0.0031101108
		 3.031425953 0.024835825 3.00395298 0.024908543 3.031481981 0.028073072 3.030561209
		 0.026946843 3.016863823 0.027970046 3.0053520203 0.024920285 3.017545223 0.025030851
		 3.01896739 0.033748329 3.029563427 0.033822626 3.031446934 0.033103913 3.017751694
		 0.033739865 2.9982636 0.031733364 3.015545845 0.028796256 2.99826121 0.032880723
		 3.015575647 0.027669996 2.99948716 0.0335536 3.014382601 0.026993871 3.0043075085
		 0.0031623244 3.020451069 0.003364861 2.9878366 0.0034623742 3.026472807 0.0072345734
		 3.0037283897 0.0035104156 3.020242929 0.0038774014 2.98728752 0.0038209558 3.02628541
		 0.007745564 3.0037269592 0.003731668 3.020240307 0.0040579438 2.98729396 0.0040354133
		 3.026288748 0.0079235435 3.0037231445 0.0043492913 3.020233154 0.0045631528 2.98731279
		 0.004634738 3.026298285 0.0084212422 3.0037093163 0.0064888597 3.02020812 0.006313324
		 2.98738313 0.0067007542 3.026331902 0.010145605 3.0037064552 0.0068692565 3.02020359
		 0.0066255331 2.98739672 0.0070682168 3.0263381 0.010452449 3.0036914349 0.0092512369
		 3.020179272 0.0085754395 2.98747921 0.0093531609 3.026377201 0.012372792 3.0036888123
		 0.009632647 3.020176411 0.0088875294 2.98749328 0.0097183585 3.026384115 0.012680531;
	setAttr ".uvtk[250:499]" 3.0036695004 0.012642264 3.020148277 0.011345744 2.98759103
		 0.012583911 3.026438236 0.015103936 3.0036668777 0.013072431 3.020145893 0.011697888
		 2.98760486 0.012992263 3.026446581 0.015450478 3.0036449432 0.016289294 3.020123482
		 0.014319003 2.98769093 0.016034365 3.026511669 0.018032968 3.0036430359 0.016582787
		 3.02012372 0.01455754 2.98769784 0.016310871 3.026518345 0.01826787 3.0036199093
		 0.019817352 3.020107269 0.01717788 2.98776507 0.019362569 3.026593685 0.020851016
		 3.0036170483 0.020230293 3.020106792 0.017512143 2.98777103 0.019751072 3.026604891
		 0.021180391 3.003592968 0.023309648 3.02009964 0.019994795 2.98781204 0.02265805
		 3.026689529 0.023618162 3.0035684109 0.023512125 3.019047737 0.023650348 3.02532506
		 0.020208895 3.026688337 0.023779273 3.0035586357 0.02467823 3.019036293 0.024817944
		 3.025301456 0.02113694 3.026726723 0.024697185 3.031729698 0.024652064 3.018637419
		 0.025041044 3.025159121 0.021471798 3.026873112 0.025025725 3.017800093 0.026857257
		 3.031484604 0.027685434 3.030513287 0.033829629 3.016828537 0.033001035 3.013864517
		 0.029313505 2.9987545 0.031160444 3.015053749 0.029347152 2.99917173 0.028947443
		 3.001098156 0.01962167 2.98885059 0.019340217 3.0010674 0.016113102 2.98877835 0.016005516
		 3.0010285378 0.01272881 2.98868608 0.012548268 3.00097823143 0.0094034076 2.98858261
		 0.009314537 3.00092697144 0.0067275167 2.98849392 0.006662786 3.00087475777 0.0042845607
		 3.0011167526 0.022577822 3.023097515 0.044388682 3.017683268 0.044388682 3.017683268
		 0.041646302 3.023097515 0.041646123 3.017683268 0.041646302 3.023097515 0.041646302
		 3.023097515 0.044388682 3.017683268 0.044388682 3.023230314 0.04793933 3.017822742
		 0.04793933 3.017822742 0.045063883 3.023230314 0.045063883 3.017822742 0.045063883
		 3.023230314 0.045063883 3.023230314 0.04793933 3.017822742 0.04793933 3.023236036
		 0.047933429 3.017816782 0.047933429 3.017816782 0.045070022 3.023236036 0.045070022
		 3.017816782 0.045070022 3.023236275 0.045070022 3.023236275 0.047933429 3.017816782
		 0.047933429 3.017660141 0.041669011 3.023120403 0.041669011 3.023120403 0.044365525
		 3.017660141 0.044365525 3.017660141 0.041669011 3.023120403 0.041669011 3.023120403
		 0.044365883 3.017660141 0.044365883 3.023000002 0.041010916 3.017508268 0.041010916
		 3.017508268 0.038865924 3.023000002 0.038865924 3.017508268 0.038865924 3.023000002
		 0.038865924 3.023000002 0.041010916 3.017508268 0.041010916 3.022938728 0.03843528
		 3.017570496 0.03843528 3.017570496 0.036552936 3.022938728 0.036552936 3.017570496
		 0.036552966 3.022938728 0.036552966 3.022938728 0.03843528 3.017570496 0.03843528
		 3.015412331 0.041237533 3.014375448 0.041450679 3.014480829 0.035746485 3.015795469
		 0.035833448 3.0020918846 0.04104656 3.0023009777 0.035229325 3.014500856 0.03530398
		 3.015832424 0.035408407 3.0011959076 0.035181433 3.00098776817 0.041005373 3.0023195744
		 0.034782857 3.001210928 0.034723252 2.98812199 0.0405339 2.98840261 0.024862409 2.99584413
		 0.024995327 2.99556303 0.040667295 2.99556327 0.040666938 2.98812199 0.040534019
		 2.98840261 0.024862409 2.99584365 0.024995327 2.98840261 0.024862409 2.99584413 0.024995327
		 2.99556303 0.040667295 2.98812199 0.0405339 2.99556327 0.040667295 2.98812199 0.0405339
		 2.98840261 0.024862409 2.99584389 0.024995327 2.98840261 0.024862409 2.99584413 0.024995327
		 2.99556303 0.040667295 2.98812199 0.0405339 2.99556327 0.040666938 2.98812199 0.040534019
		 2.98840261 0.024862409 2.99584365 0.024995327 2.98840261 0.024862409 2.99584413 0.024995327
		 2.99556303 0.040667295 2.98812199 0.0405339 2.99556303 0.040667295 2.98812199 0.0405339
		 2.98840261 0.024862409 2.99584413 0.024995327 2.98840261 0.024862409 2.99584413 0.024995327
		 2.99556303 0.040667295 2.98812199 0.0405339 2.99556303 0.040667295 2.98812199 0.0405339
		 2.98840261 0.024862409 2.99584413 0.024995327 2.98840261 0.024862409 2.99584413 0.024995327
		 2.99556303 0.040667295 2.98812199 0.0405339 2.99556303 0.040667295 2.98812199 0.0405339
		 2.98840261 0.024862409 2.99584413 0.024995327 3.031419992 0.048101187 3.023794651
		 0.048101187 3.023794651 0.046264887 3.031419992 0.046264768 3.023794651 0.046018779
		 3.031419992 0.046019077 3.023796558 0.04409194 3.031418324 0.044091702 3.023796558
		 0.043917149 3.031418085 0.043917149 3.023797035 0.042004377 3.031417608 0.042004377
		 3.023797274 0.041748166 3.03141737 0.041748762 3.023798943 0.039962292 3.031415939
		 0.039961994 3.023799181 0.039735615 3.031415701 0.039736152 3.023798227 0.038323402
		 3.031415701 0.038322568 3.023798466 0.038097024 3.031415701 0.038097143 3.023800135
		 0.036826849 3.031416893 0.036827624 3.023799658 0.036462605 3.031416416 0.036462247
		 3.023799181 0.03633225 3.031416178 0.036331654 3.024088621 0.03613764 3.031138897
		 0.036137819 3.024088144 0.03602469 3.031138659 0.036024868 3.023491621 0.035674691
		 3.031705856 0.035673976 3.023493528 0.035018623 3.03170681 0.035018146 3.023731947
		 0.034695804 3.031480551 0.034695923 3.010400772 0.042417318 3.01118803 0.042417318
		 3.010812521 0.043647408 3.010776043 0.043647408 3.010399818 0.042417824 3.011188745
		 0.042417824 3.010812521 0.04364714 3.010776043 0.04364714 3.012506962 0.042417318
		 3.013398409 0.042417318 3.012973309 0.043650836 3.012931824 0.043650836 3.013663054
		 0.042417318 3.014271021 0.042417318 3.013981104 0.043643147 3.013952971 0.043643147
		 3.014535666 0.042417318 3.015392065 0.042417318 3.014983654 0.043649733 3.014944077
		 0.043649733 3.095496416 -0.16779083 3.095496416 0.068640538 3.052284479 0.068640538
		 3.052284479 -0.16779083 3.095496416 0.086825706 3.052284479 0.086825706 2.8622086
		 -0.16995528 2.96594262 -0.16995528 2.96594262 0.1105666 2.8622086 0.1105666 2.96594262
		 -0.19153029 2.8622086 -0.19153029 3.4963572 0.086826175 3.34850287 0.086826175 3.34850287
		 0.014803469 3.4963572 0.014803469 3.3353653 -0.13802114 3.50761867 -0.13802114 3.50772882
		 0.086826175 3.50772882 0.014803469 3.3353653 -0.55390459 3.50761867 -0.55390459 3.52086711
		 -0.13802114 3.34060717 -0.74793106;
	setAttr ".uvtk[500:549]" 3.50312495 -0.74793106 3.52086711 -0.55390459 3.51562452
		 -0.74793106 3.31848407 0.086826175 3.17063022 0.086826175 3.17063022 0.014803469
		 3.31848407 0.014803469 3.15925789 0.086826175 3.15925789 0.014803469 3.15936899 -0.13802114
		 3.3316226 -0.13802114 3.14612031 -0.13802114 3.15936899 -0.55390459 3.3316226 -0.55390459
		 3.14612031 -0.55390459 3.16386175 -0.74793106 3.32638001 -0.74793106 3.15136194 -0.74793106
		 3.14249182 -0.16779023 3.14249182 -0.14353064 3.099279881 -0.14353064 3.099279881
		 -0.16779023 3.14249182 0.067873582 3.099279881 0.067873582 3.14249182 0.086825706
		 3.099279881 0.086825706 2.98267746 -0.14353052 2.93946576 -0.14353052 2.93946576
		 -0.16778895 2.98267746 -0.16778895 2.98267746 0.06787464 2.93946576 0.06787464 2.93946576
		 0.086825117 2.98267746 0.086825117 2.98138523 -0.41908103 2.98138523 -0.39548653
		 2.93507671 -0.39548653 2.93507671 -0.41908103 2.98138523 -0.18987212 2.93507671 -0.18987212
		 2.98138523 -0.17144009 2.93507671 -0.17144009 3.019950628 -0.17144009 3.019950628
		 -0.18987212 3.066258907 -0.18987212 3.066258907 -0.17144009 3.019950628 -0.39548653
		 3.066258907 -0.39548653 3.019950628 -0.41908103 3.066258907 -0.41908103;
createNode polyAutoProj -n "polyAutoProj8";
	rename -uid "B95BD844-4C29-B0C5-0CA7-6C938B32E63A";
	setAttr ".cch" yes;
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "f[0:29]";
	setAttr ".ix" -type "matrix" 5.4351187894611153 0 -7.483454762603917 0 0 29.874130098051833 0 0
		 0.80911617939814362 0 0.58764871159235188 0 7.0406395232729064 17.93573702162417 5.2801680119226466 1;
	setAttr ".s" -type "double3" 29.87413187868875 29.87413187868875 29.87413187868875 ;
	setAttr ".o" 0;
	setAttr ".ps" 0.20000000298023224;
	setAttr ".dl" yes;
createNode polyAutoProj -n "polyAutoProj9";
	rename -uid "3B22FF61-46EA-4489-441C-68BCF90D02B6";
	setAttr ".cch" yes;
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "f[0:29]";
	setAttr ".ix" -type "matrix" -9.2483191254421282 0 0.10585269705523209 0 0 29.874130098051833 0 0
		 -0.011444865043924852 -0 -0.99993450538729123 0 -4.6452177177886602 17.93573702162417 0.60511540200649339 1;
	setAttr ".s" -type "double3" 29.87413187868875 29.87413187868875 29.87413187868875 ;
	setAttr ".o" 0;
	setAttr ".ps" 0.20000000298023224;
	setAttr ".dl" yes;
createNode polyTweakUV -n "polyTweakUV13";
	rename -uid "A75275B9-4103-7977-A33F-55B7DA3F555C";
	setAttr ".uopa" yes;
	setAttr -s 61 ".uvtk";
	setAttr ".uvtk[2]" -type "float2" 2.3384526 0 ;
	setAttr ".uvtk[3]" -type "float2" 2.3384526 0 ;
	setAttr ".uvtk[6]" -type "float2" 2.336987 2.2441149e-05 ;
	setAttr ".uvtk[7]" -type "float2" 2.3369875 4.5895576e-06 ;
	setAttr ".uvtk[8]" -type "float2" 4.6766315 -9.3787909e-05 ;
	setAttr ".uvtk[9]" -type "float2" 4.6766334 9.5844269e-05 ;
	setAttr ".uvtk[10]" -type "float2" 7.0167379 -5.9604645e-08 ;
	setAttr ".uvtk[11]" -type "float2" 7.0167375 -3.1232834e-05 ;
	setAttr ".uvtk[12]" -type "float2" 9.3530807 0.00014567375 ;
	setAttr ".uvtk[13]" -type "float2" 9.3530693 -0.00013452768 ;
	setAttr ".uvtk[16]" -type "float2" 2.3384521 -8.9406967e-08 ;
	setAttr ".uvtk[17]" -type "float2" 2.3384516 5.9604645e-08 ;
	setAttr ".uvtk[20]" -type "float2" 2.3384657 2.3841858e-07 ;
	setAttr ".uvtk[21]" -type "float2" 2.3384657 -2.3841858e-07 ;
	setAttr ".uvtk[22]" -type "float2" -2.3384657 2.9802322e-07 ;
	setAttr ".uvtk[23]" -type "float2" -2.3384657 -2.9802322e-07 ;
	setAttr ".uvtk[25]" -type "float2" -7.1525574e-07 1.1834536 ;
	setAttr ".uvtk[26]" -type "float2" 7.1525574e-07 1.1834536 ;
	setAttr ".uvtk[28]" -type "float2" 7.1525574e-07 -1.1834538 ;
	setAttr ".uvtk[29]" -type "float2" -7.1525574e-07 -1.1834538 ;
	setAttr ".uvtk[32]" -type "float2" -0.060099915 0.00076210499 ;
	setAttr ".uvtk[33]" -type "float2" -0.060196742 4.8875809e-06 ;
	setAttr ".uvtk[34]" -type "float2" 0.029953107 -0.0022900105 ;
	setAttr ".uvtk[35]" -type "float2" -0.030108005 -0.00076705217 ;
	setAttr ".uvtk[38]" -type "float2" -0.28892532 8.4983185e-09 ;
	setAttr ".uvtk[39]" -type "float2" -0.28892532 0 ;
	setAttr ".uvtk[42]" -type "float2" -0.28892577 -2.9802322e-08 ;
	setAttr ".uvtk[43]" -type "float2" -0.28892577 0 ;
	setAttr ".uvtk[46]" -type "float2" 0.093517289 5.9604645e-07 ;
	setAttr ".uvtk[47]" -type "float2" 0.093517661 -5.364418e-07 ;
	setAttr ".uvtk[48]" -type "float2" 0.19026569 6.5565109e-07 ;
	setAttr ".uvtk[49]" -type "float2" 0.19026554 -6.5565109e-07 ;
	setAttr ".uvtk[52]" -type "float2" 0.093517579 8.9406967e-08 ;
	setAttr ".uvtk[53]" -type "float2" 0.093517564 1.7881393e-07 ;
	setAttr ".uvtk[54]" -type "float2" 0.19026594 2.0861626e-07 ;
	setAttr ".uvtk[55]" -type "float2" 0.19026594 5.9604645e-08 ;
	setAttr ".uvtk[58]" -type "float2" 0.18060175 -1.4592661e-06 ;
	setAttr ".uvtk[59]" -type "float2" 0.1806047 1.758337e-06 ;
	setAttr ".uvtk[60]" -type "float2" 0.36120954 2.1244632e-06 ;
	setAttr ".uvtk[61]" -type "float2" 0.36120579 -1.6093254e-06 ;
	setAttr ".uvtk[62]" -type "float2" 0.54181015 -2.4129404e-06 ;
	setAttr ".uvtk[63]" -type "float2" 0.54181409 1.847744e-06 ;
	setAttr ".uvtk[64]" -type "float2" 0.72241557 3.5867561e-07 ;
	setAttr ".uvtk[65]" -type "float2" 0.72241461 1.4901161e-07 ;
	setAttr ".uvtk[68]" -type "float2" 0.18060368 1.4354009e-07 ;
	setAttr ".uvtk[69]" -type "float2" 0.18060392 -2.9802322e-08 ;
	setAttr ".uvtk[70]" -type "float2" -0.18059671 2.1457672e-06 ;
	setAttr ".uvtk[71]" -type "float2" -0.18061191 -5.9077283e-06 ;
	setAttr ".uvtk[72]" -type "float2" -0.36121526 -2.7418137e-06 ;
	setAttr ".uvtk[73]" -type "float2" -0.36119556 8.4296335e-07 ;
	setAttr ".uvtk[74]" -type "float2" -0.54180926 8.3446503e-07 ;
	setAttr ".uvtk[75]" -type "float2" -0.54181415 2.0723091e-06 ;
	setAttr ".uvtk[77]" -type "float2" 0.004044801 -0.00018137693 ;
	setAttr ".uvtk[78]" -type "float2" -0.004044801 -0.00018137693 ;
	setAttr ".uvtk[80]" -type "float2" 0.004044801 0.00018137693 ;
	setAttr ".uvtk[81]" -type "float2" -0.004044801 0.00018137693 ;
	setAttr ".uvtk[84]" -type "float2" -0.0080916584 9.0539455e-05 ;
	setAttr ".uvtk[85]" -type "float2" -0.0081017911 4.7683716e-07 ;
	setAttr ".uvtk[86]" -type "float2" 0.0040356815 -0.00027197599 ;
	setAttr ".uvtk[87]" -type "float2" -0.0040518939 -9.1016293e-05 ;
createNode polyTweakUV -n "polyTweakUV14";
	rename -uid "13FAE2B6-436D-5C89-9C72-72855D2CCCCA";
	setAttr ".uopa" yes;
	setAttr -s 61 ".uvtk";
	setAttr ".uvtk[2]" -type "float2" 2.3384533 -5.9604645e-08 ;
	setAttr ".uvtk[3]" -type "float2" 2.3384531 5.9604645e-08 ;
	setAttr ".uvtk[6]" -type "float2" 2.3394532 3.1888485e-06 ;
	setAttr ".uvtk[7]" -type "float2" 2.3394513 3.5703182e-05 ;
	setAttr ".uvtk[8]" -type "float2" 4.6774163 5.5670738e-05 ;
	setAttr ".uvtk[9]" -type "float2" 4.6774187 -3.8862228e-05 ;
	setAttr ".uvtk[10]" -type "float2" 7.0149398 6.1392784e-06 ;
	setAttr ".uvtk[11]" -type "float2" 7.0149412 -2.4616718e-05 ;
	setAttr ".uvtk[12]" -type "float2" 9.3538465 -2.7030706e-05 ;
	setAttr ".uvtk[13]" -type "float2" 9.3538437 3.4928322e-05 ;
	setAttr ".uvtk[16]" -type "float2" 2.3384521 -8.9406967e-08 ;
	setAttr ".uvtk[17]" -type "float2" 2.3384516 5.9604645e-08 ;
	setAttr ".uvtk[20]" -type "float2" 2.3384664 1.1920929e-07 ;
	setAttr ".uvtk[21]" -type "float2" 2.3384662 -1.7881393e-07 ;
	setAttr ".uvtk[22]" -type "float2" -2.3384662 1.7881393e-07 ;
	setAttr ".uvtk[23]" -type "float2" -2.3384662 -1.7881393e-07 ;
	setAttr ".uvtk[25]" -type "float2" -1.9967556e-06 1.1834536 ;
	setAttr ".uvtk[26]" -type "float2" 1.9967556e-06 1.183454 ;
	setAttr ".uvtk[28]" -type "float2" 2.0116568e-06 -1.1834538 ;
	setAttr ".uvtk[29]" -type "float2" -2.0116568e-06 -1.1834538 ;
	setAttr ".uvtk[32]" -type "float2" -0.06009993 0.00076210499 ;
	setAttr ".uvtk[33]" -type "float2" -0.060196728 4.8875809e-06 ;
	setAttr ".uvtk[34]" -type "float2" 0.029953107 -0.0022900105 ;
	setAttr ".uvtk[35]" -type "float2" -0.030108005 -0.00076705217 ;
	setAttr ".uvtk[38]" -type "float2" -0.28892523 -1.0128133e-08 ;
	setAttr ".uvtk[39]" -type "float2" -0.28892526 0 ;
	setAttr ".uvtk[42]" -type "float2" -0.28892577 0 ;
	setAttr ".uvtk[43]" -type "float2" -0.28892583 0 ;
	setAttr ".uvtk[46]" -type "float2" 0.093517393 5.6624413e-07 ;
	setAttr ".uvtk[47]" -type "float2" 0.093517497 -4.1723251e-07 ;
	setAttr ".uvtk[48]" -type "float2" 0.1902656 6.8545341e-07 ;
	setAttr ".uvtk[49]" -type "float2" 0.19026551 -7.1525574e-07 ;
	setAttr ".uvtk[52]" -type "float2" 0.093517579 2.0861626e-07 ;
	setAttr ".uvtk[53]" -type "float2" 0.093517594 1.1920929e-07 ;
	setAttr ".uvtk[54]" -type "float2" 0.19026594 1.1920929e-07 ;
	setAttr ".uvtk[55]" -type "float2" 0.19026591 1.7881393e-07 ;
	setAttr ".uvtk[58]" -type "float2" 0.18060386 -3.3256365e-06 ;
	setAttr ".uvtk[59]" -type "float2" 0.18060076 2.1755695e-06 ;
	setAttr ".uvtk[60]" -type "float2" 0.36120388 5.4697739e-06 ;
	setAttr ".uvtk[61]" -type "float2" 0.36120883 -4.9769878e-06 ;
	setAttr ".uvtk[62]" -type "float2" 0.54181391 -3.8061989e-06 ;
	setAttr ".uvtk[63]" -type "float2" 0.54180956 5.0663948e-06 ;
	setAttr ".uvtk[64]" -type "float2" 0.72241473 -2.6717316e-07 ;
	setAttr ".uvtk[65]" -type "float2" 0.72241497 -9.5367432e-07 ;
	setAttr ".uvtk[68]" -type "float2" 0.18060368 7.2759576e-08 ;
	setAttr ".uvtk[69]" -type "float2" 0.18060368 -2.9802322e-08 ;
	setAttr ".uvtk[70]" -type "float2" -0.18059593 -3.1888485e-06 ;
	setAttr ".uvtk[71]" -type "float2" -0.18061078 -5.3177355e-06 ;
	setAttr ".uvtk[72]" -type "float2" -0.36122245 5.6624413e-07 ;
	setAttr ".uvtk[73]" -type "float2" -0.36119357 2.5063055e-06 ;
	setAttr ".uvtk[74]" -type "float2" -0.5418061 1.4901161e-06 ;
	setAttr ".uvtk[75]" -type "float2" -0.54181653 3.0838419e-07 ;
	setAttr ".uvtk[77]" -type "float2" 0.004044801 -0.00018137693 ;
	setAttr ".uvtk[78]" -type "float2" -0.004044801 -0.00018137693 ;
	setAttr ".uvtk[80]" -type "float2" 0.004044801 0.00018137693 ;
	setAttr ".uvtk[81]" -type "float2" -0.004044801 0.00018137693 ;
	setAttr ".uvtk[84]" -type "float2" -0.0080916584 9.0539455e-05 ;
	setAttr ".uvtk[85]" -type "float2" -0.0081017911 4.7683716e-07 ;
	setAttr ".uvtk[86]" -type "float2" 0.0040356815 -0.00027197599 ;
	setAttr ".uvtk[87]" -type "float2" -0.0040518939 -9.1016293e-05 ;
createNode polyPlanarProj -n "polyPlanarProj3";
	rename -uid "15C9AA77-4DDF-70BA-8FA3-62BE35F6D072";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "f[0:29]";
	setAttr ".ix" -type "matrix" -9.2483191254421282 0 0.10585269705523209 0 0 29.874130098051833 0 0
		 -0.011444865043924852 -0 -0.99993450538729123 0 -4.6452177177886602 17.93573702162417 0.60511540200649339 1;
	setAttr ".ws" yes;
	setAttr ".pc" -type "double3" -5.4726386070251465 17.935739517211914 0.68753254413604736 ;
	setAttr ".ro" -type "double3" -6.3383526400554251 15.000000707709574 -7.1513884592106633e-08 ;
	setAttr ".ps" -type "double2" 10.849452686581106 30.081153842160845 ;
	setAttr ".per" yes;
	setAttr ".cam" -type "matrix" 1.8781890869140625 -0.048667784780263901 -0.2572421133518219 -0.25723695755004883
		 -1.4197789245225496e-17 1.6928359270095825 -0.11040183156728745 -0.11039962619543076
		 -0.50325924158096313 -0.18163064122200012 -0.96004056930541992 -0.96002137660980225
		 2.7412335872650146 -40.561328887939453 68.13238525390625 68.331016540527344;
	setAttr ".prgt" 1031;
	setAttr ".ptop" 1177;
createNode polyPlanarProj -n "polyPlanarProj4";
	rename -uid "E0C50683-4C34-AAE6-4ADD-AEAE6D322926";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "f[0:29]";
	setAttr ".ix" -type "matrix" 5.4351187894611153 0 -7.483454762603917 0 0 29.874130098051833 0 0
		 0.80911617939814362 0 0.58764871159235188 0 7.0406395232729064 17.93573702162417 5.2801680119226466 1;
	setAttr ".ws" yes;
	setAttr ".pc" -type "double3" 0.84456729888916016 17.935739517211914 3.7620620727539062 ;
	setAttr ".ro" -type "double3" -6.3383526400554251 15.000000707709574 -7.1513884592106633e-08 ;
	setAttr ".ps" -type "double2" 21.46186212440848 31.097885999283445 ;
	setAttr ".per" yes;
	setAttr ".cam" -type "matrix" 1.8781890869140625 -0.048667784780263901 -0.2572421133518219 -0.25723695755004883
		 -1.4197789245225496e-17 1.6928359270095825 -0.11040183156728745 -0.11039962619543076
		 -0.50325924158096313 -0.18163064122200012 -0.96004056930541992 -0.96002137660980225
		 2.7412335872650146 -40.561328887939453 68.13238525390625 68.331016540527344;
	setAttr ".prgt" 1031;
	setAttr ".ptop" 1177;
createNode polyPlanarProj -n "polyPlanarProj5";
	rename -uid "9E8B352A-403A-73EF-D2E5-05909989C48B";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "f[0:29]";
	setAttr ".ix" -type "matrix" -9.2483191254421282 0 0.10585269705523209 0 0 29.874130098051833 0 0
		 -0.011444865043924852 -0 -0.99993450538729123 0 -4.6452177177886602 17.93573702162417 0.60511540200649339 1;
	setAttr ".ws" yes;
	setAttr ".pc" -type "double3" 0.84456658363342285 17.935739517211914 3.7620618343353271 ;
	setAttr ".ro" -type "double3" -6.3383526400554251 15.000000707709574 -7.1513884592106633e-08 ;
	setAttr ".ps" -type "double2" 21.46186096753139 31.097885917472592 ;
	setAttr ".per" yes;
	setAttr ".cam" -type "matrix" 1.8781890869140625 -0.048667784780263901 -0.2572421133518219 -0.25723695755004883
		 -1.4197789245225496e-17 1.6928359270095825 -0.11040183156728745 -0.11039962619543076
		 -0.50325924158096313 -0.18163064122200012 -0.96004056930541992 -0.96002137660980225
		 2.7412335872650146 -40.561328887939453 68.13238525390625 68.331016540527344;
	setAttr ".prgt" 1031;
	setAttr ".ptop" 1177;
createNode polyMapCut -n "polyMapCut14";
	rename -uid "3935FE9D-4644-F4E1-C59A-FEA83D16E644";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 5 "e[14:15]" "e[22]" "e[25]" "e[30]" "e[33]";
createNode polyMapCut -n "polyMapCut15";
	rename -uid "B3B853FA-40F4-1B91-E5D6-BBBECAAB3AAB";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "e[6:7]" "e[10:11]";
createNode polyMapCut -n "polyMapCut16";
	rename -uid "DA28E824-443C-CDE4-9169-64AE02701161";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 3 "e[6]" "e[10:11]" "e[21]";
createNode polyMapCut -n "polyMapCut17";
	rename -uid "52F57771-47FF-31EE-A827-3190ED56CEB4";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "e[6:7]" "e[10:11]";
createNode polyMapCut -n "polyMapCut18";
	rename -uid "090A87FB-495F-DEFD-7BB0-2E8E6BF503BF";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 8 "e[0:1]" "e[3:5]" "e[12:15]" "e[17:22]" "e[24]" "e[26:30]" "e[32]" "e[34]";
createNode polyMapSew -n "polyMapSew1";
	rename -uid "B5F4EEE6-44C8-A1D4-5102-4DBDACD15782";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 5 "e[17:18]" "e[24]" "e[26]" "e[32]" "e[34]";
createNode polyMapCut -n "polyMapCut19";
	rename -uid "1B935217-46F3-9728-882D-79AF44EA3CDC";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "e[2]" "e[8:9]";
createNode polyMapSew -n "polyMapSew2";
	rename -uid "E81FABDF-46AC-5B12-E3AE-39AC86A314CA";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[7]";
createNode polyTweakUV -n "polyTweakUV15";
	rename -uid "814C3CF5-4222-5586-F16C-C8B3F34563EC";
	setAttr ".uopa" yes;
	setAttr -s 55 ".uvtk";
	setAttr ".uvtk[1]" -type "float2" 0.31353223 -0.36066025 ;
	setAttr ".uvtk[2]" -type "float2" 1.1372255 0.4262329 ;
	setAttr ".uvtk[3]" -type "float2" 0.36940059 0.48149416 ;
	setAttr ".uvtk[4]" -type "float2" -0.13275652 -0.25051016 ;
	setAttr ".uvtk[5]" -type "float2" 0.38336882 -0.96506345 ;
	setAttr ".uvtk[6]" -type "float2" 0.10746871 -0.08261317 ;
	setAttr ".uvtk[7]" -type "float2" 0.73944962 -0.037679061 ;
	setAttr ".uvtk[8]" -type "float2" 0.74416065 0.020032514 ;
	setAttr ".uvtk[9]" -type "float2" 1.0823159 0.43238503 ;
	setAttr ".uvtk[10]" -type "float2" 0.74152619 -0.0083411001 ;
	setAttr ".uvtk[11]" -type "float2" -0.02402398 0.013741081 ;
	setAttr ".uvtk[12]" -type "float2" 0.74184811 -0.011184085 ;
	setAttr ".uvtk[13]" -type "float2" 0.3714644 -0.47655919 ;
	setAttr ".uvtk[14]" -type "float2" 1.1016302 -0.44008625 ;
	setAttr ".uvtk[15]" -type "float2" 1.1266658 -0.44307905 ;
	setAttr ".uvtk[16]" -type "float2" -0.043586373 -0.046153784 ;
	setAttr ".uvtk[17]" -type "float2" -0.027533084 -0.04818958 ;
	setAttr ".uvtk[18]" -type "float2" 1.1324339 -0.034857318 ;
	setAttr ".uvtk[19]" -type "float2" 1.135915 -0.034125403 ;
	setAttr ".uvtk[20]" -type "float2" 1.1275376 -0.030357435 ;
	setAttr ".uvtk[21]" -type "float2" 1.1329607 -0.4386701 ;
	setAttr ".uvtk[22]" -type "float2" 1.1358109 -0.44038638 ;
	setAttr ".uvtk[23]" -type "float2" 1.0911576 -0.028413966 ;
	setAttr ".uvtk[24]" -type "float2" 1.1246898 0.41986552 ;
	setAttr ".uvtk[25]" -type "float2" 1.1180243 0.42552927 ;
	setAttr ".uvtk[26]" -type "float2" 1.1170645 -0.43925965 ;
	setAttr ".uvtk[27]" -type "float2" 1.1085643 -0.029918745 ;
	setAttr ".uvtk[28]" -type "float2" 1.1311247 -0.44105524 ;
	setAttr ".uvtk[29]" -type "float2" 1.1345931 -0.033806041 ;
	setAttr ".uvtk[30]" -type "float2" 1.1004086 0.42750341 ;
	setAttr ".uvtk[31]" -type "float2" 1.1221343 0.42177498 ;
	setAttr ".uvtk[32]" -type "float2" 0.74514389 -0.0059680417 ;
	setAttr ".uvtk[33]" -type "float2" 0.31416073 -0.82657278 ;
	setAttr ".uvtk[34]" -type "float2" 0.37332338 -0.01323236 ;
	setAttr ".uvtk[35]" -type "float2" 0.37830195 -0.48621401 ;
	setAttr ".uvtk[36]" -type "float2" 0.037997738 0.28894597 ;
	setAttr ".uvtk[37]" -type "float2" 0.74895436 -0.0096028922 ;
	setAttr ".uvtk[38]" -type "float2" 0.042065587 0.29504192 ;
	setAttr ".uvtk[39]" -type "float2" 0.11167723 -0.073162615 ;
	setAttr ".uvtk[40]" -type "float2" 0.36841774 0.45404026 ;
	setAttr ".uvtk[42]" -type "float2" -0.021188736 0.0084226578 ;
	setAttr ".uvtk[43]" -type "float2" 0.29432774 -0.81689572 ;
	setAttr ".uvtk[44]" -type "float2" 0.29354483 -0.34791139 ;
	setAttr ".uvtk[45]" -type "float2" 0.74462819 0.02606082 ;
	setAttr ".uvtk[46]" -type "float2" 0.37043902 0.0055174436 ;
	setAttr ".uvtk[47]" -type "float2" -0.073666662 -0.13467878 ;
	setAttr ".uvtk[48]" -type "float2" 0.37246785 -0.96502662 ;
	setAttr ".uvtk[49]" -type "float2" 0.74332762 0.0078195222 ;
	setAttr ".uvtk[50]" -type "float2" 0.36359197 0.91583276 ;
	setAttr ".uvtk[51]" -type "float2" 0.3683494 0.95155942 ;
	setAttr ".uvtk[52]" -type "float2" 0.75648826 -0.037565932 ;
	setAttr ".uvtk[53]" -type "float2" 0.75280392 -0.019887436 ;
	setAttr ".uvtk[54]" -type "float2" -0.14247805 -0.25953686 ;
	setAttr ".uvtk[55]" -type "float2" -0.0859842 -0.1384778 ;
createNode polyMapCut -n "polyMapCut20";
	rename -uid "23857B7E-48CA-AF28-F5D0-FD9D8DFD818D";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "e[16]" "e[31]";
createNode polyTweakUV -n "polyTweakUV16";
	rename -uid "80DFF464-4C31-3E5C-C888-42A115EF9115";
	setAttr ".uopa" yes;
	setAttr -s 60 ".uvtk[0:59]" -type "float2" 0.47618797 1.64738774 0.47643766
		 1.66959739 -0.4198195 1.011237144 -0.38948792 1.009198904 0.68760175 0.76125425 -0.36795372
		 1.056740761 0.7796011 0.7778365 -0.41418877 0.99357706 -0.41440907 1.041208744 -0.41528681
		 1.011455297 -0.39238194 1.057132483 0.47823092 1.64721513 -0.41431752 1.0094006062
		 -0.3897056 1.040792465 -0.41611895 1.037997723 -0.41864839 1.038014889 0.53864938
		 0.77972025 0.64238697 1.18732095 -0.41926685 1.026606798 -0.41799548 1.026583433
		 -0.4169226 1.026577234 -0.41702893 1.037834644 -0.41773906 1.03783989 -0.41564491
		 1.026584625 -0.41747496 1.011693478 -0.4165217 1.01168108 -0.41665056 1.037890196
		 -0.41632327 1.026575804 -0.41811469 1.037900686 -0.41859058 1.026591063 -0.41601029
		 1.011601686 -0.41797832 1.011611938 -0.39239612 1.041211128 0.47661629 1.68567538
		 -0.36773646 1.025146246 -0.36784491 1.040944576 0.84494269 0.78507257 -0.39241773
		 1.025314808 0.84591705 0.77630919 0.78043526 0.76895827 -0.36762753 1.0093493462
		 0.47615054 1.63127375 0.62344557 1.20106244 0.47876862 1.68565369 0.47859147 1.66957307
		 -0.41440943 1.057136774 -0.38959676 1.024996519 0.61562234 0.76045984 -0.38981396
		 1.056590557 -0.41438487 1.025288105 -0.36751884 0.99355203 -0.3893792 0.99340147
		 -0.39243734 0.99372143 -0.39243615 1.0094730854 0.687159 0.77047449 0.61624151 0.7705366
		 0.61893839 1.19979 0.47539738 1.63296866 0.53522223 0.77044696 0.643668 1.19011831;
createNode transferAttributes -n "transferAttributes1";
	rename -uid "FFF3650E-46CE-5E68-0FC1-E4BA99A2291D";
	setAttr ".uvs" 1;
	setAttr ".suv" -type "string" "map1";
	setAttr ".tuv" -type "string" "map1";
	setAttr ".col" 1;
	setAttr ".spa" 4;
	setAttr ".sus" -type "string" "map1";
	setAttr ".tus" -type "string" "map1";
createNode polyPlanarProj -n "polyPlanarProj6";
	rename -uid "962A1FA0-4B2F-7EB8-4B83-A3B1855A4870";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "f[0:69]";
	setAttr ".ix" -type "matrix" 16.171219704102587 0 0 0 0 0.41927889493470766 0 0 0 0 6.3170233860695353 0
		 20.87681790710964 1.6512034452749658 -4.8500368722748162 1;
	setAttr ".ws" yes;
	setAttr ".pc" -type "double3" 20.87681770324707 6.2026262283325195 -4.850039005279541 ;
	setAttr ".ro" -type "double3" -15.938353586806695 -2.1999999940899873 3.0764756149588566e-08 ;
	setAttr ".ps" -type "double2" 16.401780339406002 12.811868630959246 ;
	setAttr ".per" yes;
	setAttr ".cam" -type "matrix" 1.9430112838745117 0.017954621464014053 0.036912832409143448 0.036912094801664352
		 -3.3730733795559798e-18 1.6377706527709961 -0.27460843324661255 -0.27460291981697083
		 0.074642963707447052 -0.46737200021743774 -0.96086817979812622 -0.96084898710250854
		 -34.567291259765625 -14.126080513000488 17.749170303344727 17.948814392089844;
	setAttr ".prgt" 1031;
	setAttr ".ptop" 1177;
createNode polyMapCut -n "polyMapCut21";
	rename -uid "6A865025-4080-82F5-3FAF-7F9877DC45AB";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 18 "e[0]" "e[4:5]" "e[12]" "e[20]" "e[31]" "e[33:34]" "e[37]" "e[41]" "e[43:44]" "e[55]" "e[60]" "e[71]" "e[80]" "e[91]" "e[96]" "e[98]" "e[107:108]" "e[114]";
createNode polyMapCut -n "polyMapCut22";
	rename -uid "0B69607F-4034-D48D-622B-24ACC05872E7";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 4 "e[78]" "e[81]" "e[88]" "e[115]";
createNode polyMapCut -n "polyMapCut23";
	rename -uid "09523914-468A-F0AF-A522-898A923818C8";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 3 "e[45]" "e[52]" "e[79]";
createNode polyMapCut -n "polyMapCut24";
	rename -uid "0296E541-48E8-B627-5835-79AAF36B6ECF";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[13]";
createNode polyMapCut -n "polyMapCut25";
	rename -uid "B00BCA44-4F40-C5D8-DB10-138A66E8349E";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 12 "e[8:9]" "e[28]" "e[39]" "e[49]" "e[57]" "e[65]" "e[73]" "e[85]" "e[93]" "e[101:103]" "e[109:111]" "e[113]";
createNode polyMapCut -n "polyMapCut26";
	rename -uid "A5DACDA6-4727-D9FE-71F8-969E8E8A69EE";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 6 "e[3]" "e[15]" "e[23]" "e[29:30]" "e[36]" "e[40]";
createNode polyMapCut -n "polyMapCut27";
	rename -uid "8FE1F340-4B6E-E3A1-6577-38A61B7F70D8";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 2 "e[19]" "e[27]";
createNode polyTweakUV -n "polyTweakUV17";
	rename -uid "E611C770-48E0-94F5-0DE0-33BE285F63CA";
	setAttr ".uopa" yes;
	setAttr -s 118 ".uvtk";
	setAttr ".uvtk[0]" -type "float2" -0.36340851 -0.54448497 ;
	setAttr ".uvtk[3]" -type "float2" -0.78572929 0.36066261 ;
	setAttr ".uvtk[4]" -type "float2" -0.61312938 -1.0155023 ;
	setAttr ".uvtk[5]" -type "float2" -0.75521266 0.36855456 ;
	setAttr ".uvtk[6]" -type "float2" -0.48336795 -1.0528527 ;
	setAttr ".uvtk[7]" -type "float2" -0.086655103 -1.6082337 ;
	setAttr ".uvtk[8]" -type "float2" -0.12748459 -0.72282279 ;
	setAttr ".uvtk[9]" -type "float2" -0.0029367357 -0.0087480098 ;
	setAttr ".uvtk[10]" -type "float2" -0.15355304 -0.58151609 ;
	setAttr ".uvtk[12]" -type "float2" -0.13248584 -0.61200893 ;
	setAttr ".uvtk[13]" -type "float2" -0.15415746 -0.58915198 ;
	setAttr ".uvtk[14]" -type "float2" -0.0018701479 -0.00042423868 ;
	setAttr ".uvtk[15]" -type "float2" -0.36815649 -0.46028084 ;
	setAttr ".uvtk[17]" -type "float2" -0.71365756 -0.709409 ;
	setAttr ".uvtk[18]" -type "float2" -0.61490834 -0.04111132 ;
	setAttr ".uvtk[19]" -type "float2" -0.5791865 -0.60660839 ;
	setAttr ".uvtk[20]" -type "float2" -0.54972959 -0.4650442 ;
	setAttr ".uvtk[21]" -type "float2" -0.76144886 0.34356135 ;
	setAttr ".uvtk[22]" -type "float2" -0.60302138 -0.033295169 ;
	setAttr ".uvtk[24]" -type "float2" -0.59566897 -0.040033594 ;
	setAttr ".uvtk[26]" -type "float2" -0.65819788 -0.45893618 ;
	setAttr ".uvtk[27]" -type "float2" -1.5753067 -1.5726063 ;
	setAttr ".uvtk[28]" -type "float2" -0.67743433 -1.5955418 ;
	setAttr ".uvtk[29]" -type "float2" -0.67920637 -0.45906985 ;
	setAttr ".uvtk[30]" -type "float2" -0.54340577 -0.46420631 ;
	setAttr ".uvtk[31]" -type "float2" 0.0033394098 0.069681779 ;
	setAttr ".uvtk[32]" -type "float2" -0.70902455 -0.63529122 ;
	setAttr ".uvtk[33]" -type "float2" -0.00011587143 -0.0024868511 ;
	setAttr ".uvtk[34]" -type "float2" 0.024243742 -0.16586363 ;
	setAttr ".uvtk[35]" -type "float2" -0.76982689 0.38131142 ;
	setAttr ".uvtk[36]" -type "float2" 0.0026268512 -0.23469044 ;
	setAttr ".uvtk[37]" -type "float2" -0.10611621 -1.1904993 ;
	setAttr ".uvtk[38]" -type "float2" 0.0015412793 -0.23949374 ;
	setAttr ".uvtk[39]" -type "float2" -0.6376977 -0.24699488 ;
	setAttr ".uvtk[40]" -type "float2" -0.78751916 0.36780325 ;
	setAttr ".uvtk[41]" -type "float2" -0.62902379 -1.1226509 ;
	setAttr ".uvtk[42]" -type "float2" -0.65024465 -0.25394681 ;
	setAttr ".uvtk[43]" -type "float2" -0.62983316 -0.25294554 ;
	setAttr ".uvtk[44]" -type "float2" 0.062497545 -0.1882616 ;
	setAttr ".uvtk[45]" -type "float2" -0.76819348 0.38142216 ;
	setAttr ".uvtk[46]" -type "float2" -0.10396503 -1.236859 ;
	setAttr ".uvtk[47]" -type "float2" 0.0036754906 -0.26318723 ;
	setAttr ".uvtk[48]" -type "float2" -0.63421124 -1.1745416 ;
	setAttr ".uvtk[49]" -type "float2" -0.79203832 0.36865905 ;
	setAttr ".uvtk[50]" -type "float2" -0.65400797 -0.27610713 ;
	setAttr ".uvtk[51]" -type "float2" -0.63387561 -0.27551055 ;
	setAttr ".uvtk[52]" -type "float2" -0.64538932 -0.27144742 ;
	setAttr ".uvtk[53]" -type "float2" 0.008411184 -0.25977191 ;
	setAttr ".uvtk[54]" -type "float2" 0.079967067 -0.3937887 ;
	setAttr ".uvtk[55]" -type "float2" -0.75489521 0.37187454 ;
	setAttr ".uvtk[56]" -type "float2" 0.018511549 -0.42250019 ;
	setAttr ".uvtk[57]" -type "float2" -0.089086011 -1.5564592 ;
	setAttr ".uvtk[58]" -type "float2" 0.014014624 -0.42487529 ;
	setAttr ".uvtk[59]" -type "float2" -0.66564816 -0.4299171 ;
	setAttr ".uvtk[60]" -type "float2" -0.81486529 0.36589864 ;
	setAttr ".uvtk[61]" -type "float2" -0.6712243 -1.536257 ;
	setAttr ".uvtk[62]" -type "float2" -0.67585886 -0.4328655 ;
	setAttr ".uvtk[63]" -type "float2" -0.65493029 -0.43246341 ;
	setAttr ".uvtk[64]" -type "float2" -0.64124393 -1.0383449 ;
	setAttr ".uvtk[65]" -type "float2" -0.82037336 0.36335322 ;
	setAttr ".uvtk[66]" -type "float2" -0.82078362 0.36267623 ;
	setAttr ".uvtk[67]" -type "float2" -0.81566137 0.36449328 ;
	setAttr ".uvtk[68]" -type "float2" -0.75222558 0.36841825 ;
	setAttr ".uvtk[69]" -type "float2" -0.30540621 -1.5381944 ;
	setAttr ".uvtk[70]" -type "float2" -0.79140091 0.36695898 ;
	setAttr ".uvtk[71]" -type "float2" -0.32755113 -1.1661611 ;
	setAttr ".uvtk[72]" -type "float2" -0.7879054 0.3659268 ;
	setAttr ".uvtk[73]" -type "float2" -0.33067495 -1.1128566 ;
	setAttr ".uvtk[74]" -type "float2" -0.75994617 0.34147766 ;
	setAttr ".uvtk[75]" -type "float2" -0.36119509 -0.58360946 ;
	setAttr ".uvtk[76]" -type "float2" 0.0020704865 0.0012516435 ;
	setAttr ".uvtk[77]" -type "float2" -0.56800663 -0.48616806 ;
	setAttr ".uvtk[78]" -type "float2" -0.75741875 0.33860973 ;
	setAttr ".uvtk[79]" -type "float2" -0.57561815 -0.56840825 ;
	setAttr ".uvtk[80]" -type "float2" -0.75828278 0.34001389 ;
	setAttr ".uvtk[82]" -type "float2" 0.0012875609 -0.0014499836 ;
	setAttr ".uvtk[83]" -type "float2" -0.39625573 -0.43768248 ;
	setAttr ".uvtk[84]" -type "float2" -0.78704286 0.35781768 ;
	setAttr ".uvtk[86]" -type "float2" -0.78715408 0.35757115 ;
	setAttr ".uvtk[87]" -type "float2" 0.27634838 -1.0204356 ;
	setAttr ".uvtk[88]" -type "float2" -0.75789118 0.37222502 ;
	setAttr ".uvtk[89]" -type "float2" -0.83141959 -0.40253529 ;
	setAttr ".uvtk[90]" -type "float2" -0.79901981 -0.20350643 ;
	setAttr ".uvtk[91]" -type "float2" -0.76950002 0.38160163 ;
	setAttr ".uvtk[92]" -type "float2" -0.77173638 0.38154352 ;
	setAttr ".uvtk[93]" -type "float2" -0.78319162 -0.15709245 ;
	setAttr ".uvtk[94]" -type "float2" -0.78572929 0.36066261 ;
	setAttr ".uvtk[95]" -type "float2" -0.71452194 0.079802997 ;
	setAttr ".uvtk[96]" -type "float2" 0.015301734 -0.45197296 ;
	setAttr ".uvtk[97]" -type "float2" -1.174046 -1.5878029 ;
	setAttr ".uvtk[98]" -type "float2" -0.77296972 -1.60904 ;
	setAttr ".uvtk[99]" -type "float2" -1.1952857 -1.6046114 ;
	setAttr ".uvtk[100]" -type "float2" -1.6037947 -1.5894287 ;
	setAttr ".uvtk[101]" -type "float2" -0.76948667 -1.5585082 ;
	setAttr ".uvtk[102]" -type "float2" -0.30172646 -1.5992575 ;
	setAttr ".uvtk[103]" -type "float2" 0.038860224 -0.45192894 ;
	setAttr ".uvtk[104]" -type "float2" -0.45947924 -1.0345173 ;
	setAttr ".uvtk[105]" -type "float2" 0.037226669 -0.42503142 ;
	setAttr ".uvtk[106]" -type "float2" -0.74836427 -1.2463754 ;
	setAttr ".uvtk[107]" -type "float2" 0.025692374 -0.26322877 ;
	setAttr ".uvtk[108]" -type "float2" -0.74535841 -1.2010727 ;
	setAttr ".uvtk[109]" -type "float2" 0.023099445 -0.23878586 ;
	setAttr ".uvtk[110]" -type "float2" -0.71581304 -0.74373293 ;
	setAttr ".uvtk[111]" -type "float2" 0.017254777 -0.0076297075 ;
	setAttr ".uvtk[112]" -type "float2" -0.61200011 -0.025306121 ;
	setAttr ".uvtk[113]" -type "float2" -0.12907082 -0.68774664 ;
	setAttr ".uvtk[114]" -type "float2" -0.68989712 -0.61356735 ;
	setAttr ".uvtk[115]" -type "float2" 0.0035161376 0.069662586 ;
	setAttr ".uvtk[116]" -type "float2" -0.59322304 -0.023700118 ;
	setAttr ".uvtk[117]" -type "float2" -0.17783198 -0.71008909 ;
	setAttr ".uvtk[118]" -type "float2" -0.0027570054 0.071972042 ;
	setAttr ".uvtk[119]" -type "float2" -0.0025519207 0.071950868 ;
	setAttr ".uvtk[120]" -type "float2" -0.0032303929 0.0079137832 ;
	setAttr ".uvtk[123]" -type "float2" 0.017187193 0.0091539025 ;
	setAttr ".uvtk[124]" -type "float2" -0.69336092 -0.60627055 ;
	setAttr ".uvtk[125]" -type "float2" -0.51550591 -0.56004173 ;
	setAttr ".uvtk[126]" -type "float2" 0.42726424 -1.1778452 ;
	setAttr ".uvtk[127]" -type "float2" -0.39447024 -0.43850702 ;
createNode polyAutoProj -n "polyAutoProj10";
	rename -uid "22EDD51E-4728-FC98-0B92-9CA30917AB26";
	setAttr ".cch" yes;
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 15 "f[2]" "f[7:8]" "f[12]" "f[23:24]" "f[26]" "f[29]" "f[31]" "f[35:37]" "f[39]" "f[41:42]" "f[44]" "f[47]" "f[49]" "f[53:54]" "f[57:69]";
	setAttr ".ix" -type "matrix" 16.171219704102587 0 0 0 0 0.41927889493470766 0 0 0 0 6.3170233860695353 0
		 20.87681790710964 1.6512034452749658 -4.8500368722748162 1;
	setAttr ".s" -type "double3" 16.171200426506466 16.171200426506466 16.171200426506466 ;
	setAttr ".o" 0;
	setAttr ".ps" 0.20000000298023224;
	setAttr ".dl" yes;
createNode polyTweakUV -n "polyTweakUV18";
	rename -uid "C7424F1F-4A5D-21F8-FBEE-F68D50045A97";
	setAttr ".uopa" yes;
	setAttr -s 176 ".uvtk[0:175]" -type "float2" 5.087940216 0.81434101 4.89455032
		 0.17919953 5.17765713 0.14716572 5.070510864 0.82137835 5.48791552 -0.42875749 4.97501802
		 0.82947987 4.96037149 1.010894299 4.96638298 0.81859887 4.96803379 0.76580286 4.85223675
		 0.06217283 4.96718121 0.79305273 4.96748686 0.78329766 4.89403772 0.19721961 5.088487148
		 0.79684794 4.071630478 0.13286515 4.75063753 1.16056228 4.63221073 1.16987848 4.63158512
		 1.11884928 4.31659985 -0.35363901 4.21394062 0.082758635 5.066637039 1.054298162
		 4.6345067 1.35776365 4.63179398 1.13594282 4.21419907 0.067535877 4.75042725 1.1434691
		 4.074666977 0.15134239 5.35955238 -0.15054768 4.96312761 0.92279738 4.47062159 -0.66256988
		 4.63345337 1.27168632 5.37746096 -0.1796816 4.96281147 0.93280619 4.63357401 1.28146625
		 4.48754406 -0.69214857 5.49841022 -0.37933916 4.96070528 1.00023055077 4.59404612
		 -0.90064162 4.63437939 1.34734535 5.068665981 0.83093584 4.61243153 -0.93268842 4.58389091
		 -0.94843155 4.565732 -0.91532618 5.517313 -0.41141742 5.082009315 1.0040229559 4.45918131
		 -0.70672172 5.084118843 0.9365992 4.44339657 -0.67628026 5.084429264 0.92658919 4.28942871
		 -0.36733079 5.087688446 0.82239354 4.083965302 0.15001461 4.63190556 1.14492071 4.27728176
		 -0.34453446 4.63211298 1.16201138 4.30327368 -0.33059981 4.081970215 0.13309479 4.90420437
		 0.19792221 5.088790417 0.78708959 5.1641345 0.16977829 4.90619087 0.17945787 5.13673162
		 0.15338576 4.28617001 1.27757454 5.46946335 -0.39675575 5.34860134 -0.19710654 5.33158636
		 -0.16756183 5.15011215 0.13038212 4.97355843 1.053549528 4.75303078 1.35631502 4.97352028
		 1.060590148 5.06659174 1.061331987 4.75290394 1.34589624 5.081676483 1.014686823
		 4.97498989 0.82179993 4.75209761 1.2800169 4.75197887 1.27023745 4.75073242 1.1684283
		 4.96663475 0.81054872 4.75031757 1.13449371 4.20620537 0.067400098 4.1730957 1.025200367
		 4.85250711 0.046257526 4.84362841 0.046106756 4.84335804 0.062021881 4.20594597 0.082622826
		 4.7501111 1.11740112 4.27927971 1.022333622 4.17998552 1.28044081 5.089339256 0.76959372
		 4.78976631 0.88727605 4.75270653 0.74859083 4.88137627 0.23057711 4.91843176 0.36925995
		 4.74973774 0.73748863 4.87840033 0.21947134 4.12568998 0.30118001 3.94743228 0.8171283
		 3.90812302 0.62029386 4.090798378 0.10283625 3.95118761 0.83240926 4.12814522 0.30282366
		 4.44464588 0.24816141 4.40775204 0.11009739 4.49100876 -0.22510123 4.52790356 -0.087038994
		 4.40461874 0.098371603 4.48787546 -0.23682976 4.079043388 0.4605329 3.97897291 0.79361916
		 3.94110513 0.62101316 4.04527092 0.28666043 3.98327351 0.80742645 4.081208229 0.46264434
		 4.67693138 0.29548833 4.67561579 0.29548833 4.67561579 -0.026803851 4.67693138 -0.026803851
		 4.61458015 0.24945113 4.60962915 0.24945113 4.60962915 -0.098658323 4.61458015 -0.098658323
		 4.83185291 0.2634114 4.83060741 0.2634114 4.83060741 -0.23465478 4.83185291 -0.2346549
		 4.7802248 0.25762308 4.77553558 0.25762308 4.77553558 -0.28034079 4.7802248 -0.28034079
		 4.3579092 0.62066007 4.3579092 0.91447359 4.26732206 0.91447359 4.26732206 0.62066007
		 4.036490917 0.95376515 4.036490917 0.58617479 4.19992495 0.58617479 4.19992495 0.95376515
		 4.27084684 0.9118737 4.18296242 0.9118737 4.18296242 0.62507594 4.27084684 0.62507594
		 3.92915821 0.87661356 3.86137342 0.87661356 3.86137342 0.64121091 3.92915821 0.64121091
		 4.40127468 -0.33904892 4.40002012 -0.35736722 4.41513395 -0.39739448 4.41638756 -0.37907654
		 4.20568657 0.17896616 4.20442915 0.16064703 4.36243343 -0.90471274 4.37754726 -0.94474
		 4.18689823 0.22872484 4.18564034 0.21040666 4.16684389 -0.38669884 4.36124945 -0.921956
		 4.37636328 -0.96198457 4.060333252 0.56392717 4.059075356 0.54560852 4.14805508 -0.33693707
		 4.16566038 -0.40394425 4.040318012 0.61693919 4.039059639 0.59862077 4.021491528
		 -0.001736775 4.14686966 -0.35417879 4.0014753342 0.051275745 4.020305634 -0.018981237
		 4.00029087067 0.034030929 4.47413445 0.92869997 4.43654919 0.73083055 4.48230362
		 0.39562941 4.51988697 0.5934999 4.48390055 0.9547838 4.44631481 0.62338555 4.56473875
		 0.10537088 4.60232401 0.43676984;
createNode polyAutoProj -n "polyAutoProj11";
	rename -uid "175DB631-4F93-F055-3285-E59B160920EA";
	setAttr ".cch" yes;
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "f[0:47]";
	setAttr ".ix" -type "matrix" 4.4722347476786428 0 0 0 0 4.4697342740116612 0.14952978990724111 0
		 0 -0.14952978990724111 4.4697342740116612 0 20.872031236821186 12.95969528807246 -2.4019967780919336 1;
	setAttr ".s" -type "double3" 8.8676566470166058 8.8676566470166058 8.8676566470166058 ;
	setAttr ".o" 0;
	setAttr ".ps" 0.20000000298023224;
	setAttr ".dl" yes;
createNode polyTweakUV -n "polyTweakUV19";
	rename -uid "7A64DC71-4D6B-DF94-6C91-13B79C8C12F2";
	setAttr ".uopa" yes;
	setAttr -s 72 ".uvtk[0:71]" -type "float2" 2.041885614 1.016633511 2.024591208
		 1.016592264 2.015978575 1.0015704632 2.033051252 0.99971431 2.033307552 1.03157711
		 2.05078125 1.031517982 2.015987635 1.031728268 2.0052032471 1.015522003 2.007298708
		 0.98655838 2.023314238 0.97992605 2.049657106 0.9968341 2.05821085 1.016265392 2.024871349
		 1.04669404 2.063946009 1.031335354 2.058334351 1.046549082 2.042351961 1.046575785
		 2.0074822903 1.046881199 1.99454343 1.029541254 1.99279678 0.99765009 2.041455746
		 0.97753924 2.033600092 1.061676741 2.016272306 1.061861992 2.050794125 1.061623335
		 1.99491227 1.064445019 1.98599243 1.04706502 1.98170924 1.012198448 2.02495575 1.076735735
		 2.0058674812 1.078267097 2.042352676 1.076604605 1.98239923 1.082023859 1.97519636
		 1.065233707 1.97483397 1.029111862 2.016486168 1.091890097 1.99369586 1.096359968
		 2.034010649 1.093778133 2.063680172 1.061593533 2.057932615 1.076817989 1.97260821
		 1.047197342 2.0079960823 1.10699368 2.050113201 1.096321583 2.024609327 1.1136384
		 2.042639971 1.11589956 1.91820836 0.9968341 1.91307044 0.977539 1.92544746 0.97921246
		 1.93278456 0.99756163 1.93996859 0.98619503 1.9527787 0.9972555 1.94204259 1.013757944
		 1.92293406 1.016264915 1.96250272 1.011414766 1.93033814 1.031335115 1.94784021 1.029940605
		 1.96924078 1.028106928 1.95435011 1.046148062 1.9376564 1.046404839 1.97141206 1.045933247
		 1.93093491 1.061593533 1.94834852 1.06254077 1.92396522 1.046548843 1.91891456 1.031517982
		 1.96967328 1.063836575 1.91920662 1.061623335 1.94296479 1.078874111 1.92393517 1.076818228
		 1.96332145 1.080729246 1.91912103 1.096321583 1.93397307 1.095278502 1.95385373 1.095262051
		 1.92665267 1.11376691 1.91370893 1.11589956 1.94116211 1.10659862;
createNode polyAutoProj -n "polyAutoProj12";
	rename -uid "035E444F-4D2E-D973-5659-C3B5FA06719B";
	setAttr ".cch" yes;
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "f[0:26]";
	setAttr ".ix" -type "matrix" 1.0298871924514503 0 0 0 0 1 0 0 0 0 1 0 20.741522683754429 0 -1.5854429978804507 1;
	setAttr ".s" -type "double3" 15.683737980645931 15.683737980645931 15.683737980645931 ;
	setAttr ".o" 0;
	setAttr ".ps" 0.20000000298023224;
	setAttr ".dl" yes;
createNode polyAutoProj -n "polyAutoProj13";
	rename -uid "E3D6DBB2-49B8-BEB5-9A89-4BA27A8FD90D";
	setAttr ".cch" yes;
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "f[0:26]";
	setAttr ".ix" -type "matrix" 1.0297675682307301 0 0 0 0 1 0 0 0 0 1 0 20.650043374704826 0 -1.5854429978804507 1;
	setAttr ".s" -type "double3" 15.683737980645931 15.683737980645931 15.683737980645931 ;
	setAttr ".o" 0;
	setAttr ".ps" 0.20000000298023224;
	setAttr ".dl" yes;
createNode polyTweakUV -n "polyTweakUV20";
	rename -uid "20BDBFA0-4B4C-190C-6B76-9CAAB2DF9859";
	setAttr ".uopa" yes;
	setAttr -s 76 ".uvtk[0:75]" -type "float2" 0.87108761 0.5668447 0.87201059
		 0.5668447 0.87201059 0.57669771 0.87108761 0.57669771 0.90594614 0.5668447 0.90686899
		 0.5668447 0.90686899 0.57669771 0.90594614 0.57669771 0.89269382 0.56822324 0.89320225
		 0.56822324 0.89320225 0.57645559 0.89269382 0.57645559 0.93652767 1.18225574 0.93703616
		 1.18225574 0.93703616 1.19660306 0.93652767 1.19660306 0.88996643 0.7363624 0.89047486
		 0.7363624 0.89047486 0.73941964 0.88996643 0.73941964 0.89047486 0.75071007 0.89047486
		 0.74765259 0.88996643 0.75071007 0.88996643 0.74765259 0.8834492 0.57475781 0.8834492
		 0.57373643 0.88437223 0.57373643 0.88437223 0.57475781 0.9183079 0.57475781 0.9183079
		 0.57373643 0.91923082 0.57373643 0.91923082 0.57475781 1.58104587 1.17053342 1.58131051
		 1.19041348 1.5808022 1.19042015 1.58053756 1.17054009 1.54143393 1.1703229 1.55816627
		 1.19020271 1.55765784 1.19063044 1.54092538 1.17075086 0.93320149 0.61828107 0.93370992
		 0.61828786 0.93370122 0.6189509 0.93319267 0.61894423 0.95571041 0.61807054 0.9562189
		 0.6184985 0.95566058 0.61916178 0.95515209 0.61873358 0.8722077 0.5668447 0.87322903
		 0.5668447 0.87322903 0.57669771 0.8722077 0.57669771 1.041935325 1.16112375 1.041935325
		 1.17638016 1.030924916 1.17638016 1.030924916 1.16112375 1.043603778 1.15881109 1.043603778
		 1.17869091 1.029256463 1.17869091 1.029256463 1.15881109 0.58782935 1.16112232 0.58782935
		 1.17637825 0.57681894 1.17637825 0.57681894 1.16112232 0.58949792 1.15881109 0.58949792
		 1.17869091 0.57515049 1.17869091 0.57515049 1.15881109 0.89249665 0.56822324 0.89249665
		 0.57645559 0.89183354 0.57645559 0.89183354 0.56822324 0.91927147 0.56822276 0.91927147
		 0.57645571 0.91860819 0.57645571 0.91860819 0.56822276;
createNode polyTweakUV -n "polyTweakUV21";
	rename -uid "96560FB1-4D5B-E12B-2A23-6F9AF73B5CFD";
	setAttr ".uopa" yes;
	setAttr -s 76 ".uvtk[0:75]" -type "float2" 0.87139285 0.56431961 0.87220144
		 0.56431961 0.87220144 0.57295251 0.87139285 0.57295251 0.90636581 0.56431961 0.90717441
		 0.56431961 0.90717441 0.57295251 0.90636581 0.57295251 0.89317721 0.56569886 0.89362264
		 0.56569886 0.89362264 0.57291055 0.89317721 0.57291055 0.94822055 1.18224907 0.94866604
		 1.18224907 0.94866604 1.19481802 0.94822055 1.19481802 0.89003021 0.73457855 0.89047569
		 0.73457855 0.89047569 0.73725694 0.89003021 0.73725694 0.89047569 0.74714774 0.89047569
		 0.74446934 0.89003021 0.74714774 0.89003021 0.74446934 0.88421559 0.57210648 0.88421559
		 0.57121146 0.88502431 0.57121146 0.88502431 0.57210648 0.91918862 0.57210636 0.91918862
		 0.57121158 0.91999722 0.57121158 0.91999722 0.57210636 1.14061975 0.54931849 1.14911938
		 1.80909562 1.11689818 1.80931306 1.10839856 0.54953593 0.66117609 0.54931873 0.66967851
		 1.80909586 0.63745743 1.8093133 0.62895495 0.54953617 0.91825831 0.59503245 0.95047939
		 0.59524989 0.95019561 0.63727635 0.91797453 0.63705891 0.94028205 0.59503245 0.97250324
		 0.59524989 0.97221947 0.63727623 0.93999845 0.63705879 0.87239861 0.56431997 0.8732934
		 0.56431997 0.8732934 0.57295251 0.87239861 0.57295251 1.4469384 0.68409246 1.4469384
		 1.650877 0.74926734 1.650877 0.74926734 0.68409246 1.55266452 0.53758448 1.55266452
		 1.79738545 0.64354146 1.79738545 0.64354146 0.53758448 0.96730125 0.68409294 0.96730125
		 1.650877 0.26963031 1.650877 0.26963031 0.68409294 1.073027253 0.53758425 1.073027253
		 1.79738545 0.16390422 1.79738545 0.16390422 0.53758425 0.91370529 0.30846202 0.91370529
		 0.83014756 0.87167728 0.83014756 0.87167728 0.30846202 0.94056416 0.3084619 0.94056416
		 0.83014745 0.89853609 0.83014745 0.89853609 0.3084619;
createNode polyTweakUV -n "polyTweakUV22";
	rename -uid "BD7B444E-476A-8169-4286-AA8DBDA65806";
	setAttr ".uopa" yes;
	setAttr -s 60 ".uvtk[0:59]" -type "float2" 0 -1.6763806e-08 0 1.0244548e-07
		 0 -1.6763806e-08 0 -1.6763806e-08 0 -1.6763806e-08 0 -1.6763806e-08 0 -1.6763806e-08
		 0 -1.6763806e-08 0 -1.6763806e-08 0 1.0244548e-07 0 1.0244548e-07 0 1.0244548e-07
		 0 1.0244548e-07 0 1.0244548e-07 0 -1.6763806e-08 0 -1.6763806e-08 0 -1.6763806e-08
		 0 -1.6763806e-08 0 1.0244548e-07 0 -1.6763806e-08 0 -1.6763806e-08 0 -1.6763806e-08
		 0 1.0244548e-07 0 1.0244548e-07 0 -1.6763806e-08 0 1.0244548e-07 0 -1.6763806e-08
		 0 -1.6763806e-08 0 -1.6763806e-08 0 1.0244548e-07 0 1.0244548e-07 0 1.0244548e-07
		 0 1.0244548e-07 0 -1.6763806e-08 0 -1.6763806e-08 0 -1.6763806e-08 0 -1.6763806e-08
		 0 -1.6763806e-08 0 -1.6763806e-08 0 -1.6763806e-08 0 1.0244548e-07 0 -1.6763806e-08
		 0 -1.6763806e-08 0 1.0244548e-07 0 1.0244548e-07 0 -1.6763806e-08 0 1.0244548e-07
		 0 -1.6763806e-08 0 -1.6763806e-08 0 -1.6763806e-08 0 -1.6763806e-08 0 1.0244548e-07
		 0 -1.6763806e-08 0 -1.6763806e-08 0 -1.6763806e-08 0 -1.6763806e-08 0 -1.6763806e-08
		 0 -1.6763806e-08 0 1.0244548e-07 0 -1.6763806e-08;
select -ne :time1;
	setAttr ".o" 33;
	setAttr ".unw" 33;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
	setAttr ".fprt" yes;
	setAttr ".rtfm" 1;
select -ne :renderPartition;
	setAttr -s 2 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 5 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderingList1;
select -ne :standardSurface1;
	setAttr ".bc" -type "float3" 0.40000001 0.40000001 0.40000001 ;
	setAttr ".sr" 0.5;
select -ne :initialShadingGroup;
	setAttr -s 20 ".dsm";
	setAttr ".ro" yes;
	setAttr -s 10 ".gn";
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :initialMaterialInfo;
select -ne :defaultRenderGlobals;
	addAttr -ci true -h true -sn "dss" -ln "defaultSurfaceShader" -dt "string";
	setAttr ".dss" -type "string" "standardSurface1";
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :defaultColorMgtGlobals;
	setAttr ".cfe" yes;
	setAttr ".cfp" -type "string" "<MAYA_RESOURCES>/OCIO-configs/Maya2022-default/config.ocio";
	setAttr ".vtn" -type "string" "ACES 1.0 SDR-video (sRGB)";
	setAttr ".vn" -type "string" "ACES 1.0 SDR-video";
	setAttr ".dn" -type "string" "sRGB";
	setAttr ".wsn" -type "string" "ACEScg";
	setAttr ".otn" -type "string" "ACES 1.0 SDR-video (sRGB)";
	setAttr ".potn" -type "string" "ACES 1.0 SDR-video (sRGB)";
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
connectAttr "groupId3.id" "pCubeShape1.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "pCubeShape1.iog.og[0].gco";
connectAttr "groupParts1.og" "pCubeShape1.i";
connectAttr "groupId4.id" "pCubeShape1.ciog.cog[0].cgid";
connectAttr "groupId9.id" "pCubeShape2.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "pCubeShape2.iog.og[0].gco";
connectAttr "groupId10.id" "pCubeShape2.ciog.cog[0].cgid";
connectAttr "groupId7.id" "pCubeShape3.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "pCubeShape3.iog.og[0].gco";
connectAttr "groupParts3.og" "pCubeShape3.i";
connectAttr "groupId8.id" "pCubeShape3.ciog.cog[0].cgid";
connectAttr "groupId1.id" "pCubeShape4.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "pCubeShape4.iog.og[0].gco";
connectAttr "groupId2.id" "pCubeShape4.ciog.cog[0].cgid";
connectAttr "polyTweakUV18.out" "shelf_baseShape.i";
connectAttr "polyTweakUV18.uvtk[0]" "shelf_baseShape.uvst[0].uvtw";
connectAttr "polyTweakUV21.out" "shelf_doorShape.i";
connectAttr "groupId5.id" "shelf_doorShape.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "shelf_doorShape.iog.og[0].gco";
connectAttr "groupId6.id" "shelf_doorShape.ciog.cog[0].cgid";
connectAttr "polyTweakUV21.uvtk[0]" "shelf_doorShape.uvst[0].uvtw";
connectAttr "polyTweakUV20.out" "shelf_door1Shape.i";
connectAttr "groupId11.id" "shelf_door1Shape.iog.og[0].gid";
connectAttr ":initialShadingGroup.mwc" "shelf_door1Shape.iog.og[0].gco";
connectAttr "groupId12.id" "shelf_door1Shape.ciog.cog[0].cgid";
connectAttr "polyTweakUV20.uvtk[0]" "shelf_door1Shape.uvst[0].uvtw";
connectAttr "polyTweakUV19.out" "outputCloth1.i";
connectAttr "polyTweakUV19.uvtk[0]" "outputCloth1.uvst[0].uvtw";
connectAttr "polyTweakUV12.out" "shelfShape2.i";
connectAttr "polyTweakUV12.uvtk[0]" "shelfShape2.uvst[0].uvtw";
connectAttr "polyTweakUV22.out" "shelfdoorShape1.i";
connectAttr "polyTweakUV22.uvtk[0]" "shelfdoorShape1.uvst[0].uvtw";
connectAttr "polyTweakUV14.uvtk[0]" "shelfdoorShape1Orig.uvst[0].uvtw";
connectAttr "polyPlanarProj4.out" "shelfdoorShape1Orig.i";
connectAttr "polyTweakUV16.out" "shelfdoorShape.i";
connectAttr "polyTweakUV16.uvtk[0]" "shelfdoorShape.uvst[0].uvtw";
connectAttr "polyTweakUV4.out" "shelf3Shape.i";
connectAttr "polyTweakUV4.uvtk[0]" "shelf3Shape.uvst[0].uvtw";
connectAttr "polyTweakUV6.out" "vaseShape.i";
connectAttr "polyTweakUV6.uvtk[0]" "vaseShape.uvst[0].uvtw";
connectAttr "polyTweakUV5.out" "shelf4Shape.i";
connectAttr "polyTweakUV5.uvtk[0]" "shelf4Shape.uvst[0].uvtw";
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
connectAttr "layerManager.dli[0]" "defaultLayer.id";
connectAttr "renderLayerManager.rlmi[0]" "defaultRenderLayer.rlid";
connectAttr "polyCube1.out" "polySplit1.ip";
connectAttr "polySplit1.out" "polySplit2.ip";
connectAttr "polyTweak1.out" "polyExtrudeFace1.ip";
connectAttr "shelf_baseShape.wm" "polyExtrudeFace1.mp";
connectAttr "polySplit2.out" "polyTweak1.ip";
connectAttr "polyTweak2.out" "polyExtrudeFace2.ip";
connectAttr "shelf_baseShape.wm" "polyExtrudeFace2.mp";
connectAttr "polyExtrudeFace1.out" "polyTweak2.ip";
connectAttr "polyTweak3.out" "polyExtrudeFace3.ip";
connectAttr "shelf_baseShape.wm" "polyExtrudeFace3.mp";
connectAttr "polyExtrudeFace2.out" "polyTweak3.ip";
connectAttr "polyExtrudeFace3.out" "polyTweak4.ip";
connectAttr "polyTweak4.out" "deleteComponent1.ig";
connectAttr "deleteComponent1.og" "polyBridgeEdge1.ip";
connectAttr "shelf_baseShape.wm" "polyBridgeEdge1.mp";
connectAttr "polyBridgeEdge1.out" "polyExtrudeFace4.ip";
connectAttr "shelf_baseShape.wm" "polyExtrudeFace4.mp";
connectAttr "polyTweak5.out" "polyExtrudeFace5.ip";
connectAttr "shelf_baseShape.wm" "polyExtrudeFace5.mp";
connectAttr "polyExtrudeFace4.out" "polyTweak5.ip";
connectAttr "polyExtrudeFace5.out" "polyTweak6.ip";
connectAttr "polyTweak6.out" "deleteComponent2.ig";
connectAttr "deleteComponent2.og" "polyBridgeEdge2.ip";
connectAttr "shelf_baseShape.wm" "polyBridgeEdge2.mp";
connectAttr "polyBridgeEdge2.out" "polySplit3.ip";
connectAttr "polySplit3.out" "polySplit4.ip";
connectAttr "polySplit4.out" "deleteComponent3.ig";
connectAttr "deleteComponent3.og" "polyBridgeEdge3.ip";
connectAttr "shelf_baseShape.wm" "polyBridgeEdge3.mp";
connectAttr "polyBridgeEdge3.out" "deleteComponent4.ig";
connectAttr "deleteComponent4.og" "polyBridgeEdge4.ip";
connectAttr "shelf_baseShape.wm" "polyBridgeEdge4.mp";
connectAttr "polyBridgeEdge4.out" "polySoftEdge1.ip";
connectAttr "shelf_baseShape.wm" "polySoftEdge1.mp";
connectAttr "polyCube2.out" "polyExtrudeFace6.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace6.mp";
connectAttr "polyTweak7.out" "polySoftEdge2.ip";
connectAttr "pCubeShape1.wm" "polySoftEdge2.mp";
connectAttr "polyExtrudeFace6.out" "polyTweak7.ip";
connectAttr "polySoftEdge2.out" "polyExtrudeFace7.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace7.mp";
connectAttr "polyTweak8.out" "polyExtrudeFace8.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace8.mp";
connectAttr "polyExtrudeFace7.out" "polyTweak8.ip";
connectAttr "polyTweak9.out" "polySoftEdge3.ip";
connectAttr "pCubeShape1.wm" "polySoftEdge3.mp";
connectAttr "polyExtrudeFace8.out" "polyTweak9.ip";
connectAttr "polyCube3.out" "deleteComponent5.ig";
connectAttr "pCubeShape4.o" "polyUnite1.ip[0]";
connectAttr "pCubeShape1.o" "polyUnite1.ip[1]";
connectAttr "pCubeShape4.wm" "polyUnite1.im[0]";
connectAttr "pCubeShape1.wm" "polyUnite1.im[1]";
connectAttr "polySoftEdge3.out" "groupParts1.ig";
connectAttr "groupId3.id" "groupParts1.gi";
connectAttr "polyUnite1.out" "groupParts2.ig";
connectAttr "groupId5.id" "groupParts2.gi";
connectAttr "pCubeShape3.o" "polyUnite2.ip[0]";
connectAttr "pCubeShape2.o" "polyUnite2.ip[1]";
connectAttr "pCubeShape3.wm" "polyUnite2.im[0]";
connectAttr "pCubeShape2.wm" "polyUnite2.im[1]";
connectAttr "deleteComponent5.og" "groupParts3.ig";
connectAttr "groupId7.id" "groupParts3.gi";
connectAttr "polyUnite2.out" "groupParts4.ig";
connectAttr "groupId11.id" "groupParts4.gi";
connectAttr "groupParts2.og" "polySoftEdge4.ip";
connectAttr "shelf_doorShape.wm" "polySoftEdge4.mp";
connectAttr "groupParts4.og" "polySoftEdge5.ip";
connectAttr "shelf_door1Shape.wm" "polySoftEdge5.mp";
connectAttr "polyTweak10.out" "polyExtrudeFace9.ip";
connectAttr "shelfShape2.wm" "polyExtrudeFace9.mp";
connectAttr "polyCube4.out" "polyTweak10.ip";
connectAttr "polyTweak11.out" "polyExtrudeFace10.ip";
connectAttr "shelfShape2.wm" "polyExtrudeFace10.mp";
connectAttr "polyExtrudeFace9.out" "polyTweak11.ip";
connectAttr "polyTweak12.out" "polyExtrudeFace11.ip";
connectAttr "shelfShape2.wm" "polyExtrudeFace11.mp";
connectAttr "polyExtrudeFace10.out" "polyTweak12.ip";
connectAttr "polyTweak13.out" "polyExtrudeFace12.ip";
connectAttr "shelfShape2.wm" "polyExtrudeFace12.mp";
connectAttr "polyExtrudeFace11.out" "polyTweak13.ip";
connectAttr "polyTweak14.out" "polySplit5.ip";
connectAttr "polyExtrudeFace12.out" "polyTweak14.ip";
connectAttr "polySplit5.out" "polySplit6.ip";
connectAttr "polySplit6.out" "polySplit7.ip";
connectAttr "polySplit7.out" "polyExtrudeFace13.ip";
connectAttr "shelfShape2.wm" "polyExtrudeFace13.mp";
connectAttr "polyTweak15.out" "polyExtrudeFace14.ip";
connectAttr "shelfShape2.wm" "polyExtrudeFace14.mp";
connectAttr "polyExtrudeFace13.out" "polyTweak15.ip";
connectAttr "polyTweak16.out" "polyExtrudeFace15.ip";
connectAttr "shelfShape2.wm" "polyExtrudeFace15.mp";
connectAttr "polyExtrudeFace14.out" "polyTweak16.ip";
connectAttr "polyTweak17.out" "polyExtrudeFace16.ip";
connectAttr "shelfShape2.wm" "polyExtrudeFace16.mp";
connectAttr "polyExtrudeFace15.out" "polyTweak17.ip";
connectAttr "polyTweak18.out" "polyExtrudeFace17.ip";
connectAttr "shelfShape2.wm" "polyExtrudeFace17.mp";
connectAttr "polyExtrudeFace16.out" "polyTweak18.ip";
connectAttr "polyTweak19.out" "polyExtrudeFace18.ip";
connectAttr "shelfShape2.wm" "polyExtrudeFace18.mp";
connectAttr "polyExtrudeFace17.out" "polyTweak19.ip";
connectAttr "polyTweak20.out" "polyExtrudeFace19.ip";
connectAttr "shelfShape2.wm" "polyExtrudeFace19.mp";
connectAttr "polyExtrudeFace18.out" "polyTweak20.ip";
connectAttr "polyTweak21.out" "polyExtrudeFace20.ip";
connectAttr "shelfShape2.wm" "polyExtrudeFace20.mp";
connectAttr "polyExtrudeFace19.out" "polyTweak21.ip";
connectAttr "polyTweak22.out" "polyExtrudeFace21.ip";
connectAttr "shelfShape2.wm" "polyExtrudeFace21.mp";
connectAttr "polyExtrudeFace20.out" "polyTweak22.ip";
connectAttr "polyTweak23.out" "polyExtrudeFace22.ip";
connectAttr "shelfShape2.wm" "polyExtrudeFace22.mp";
connectAttr "polyExtrudeFace21.out" "polyTweak23.ip";
connectAttr "polyTweak24.out" "polyExtrudeFace23.ip";
connectAttr "shelfShape2.wm" "polyExtrudeFace23.mp";
connectAttr "polyExtrudeFace22.out" "polyTweak24.ip";
connectAttr "polyTweak25.out" "polyExtrudeFace24.ip";
connectAttr "shelfShape2.wm" "polyExtrudeFace24.mp";
connectAttr "polyExtrudeFace23.out" "polyTweak25.ip";
connectAttr "polyExtrudeFace24.out" "polyTweak26.ip";
connectAttr "polyTweak26.out" "deleteComponent6.ig";
connectAttr "deleteComponent6.og" "polyBridgeEdge5.ip";
connectAttr "shelfShape2.wm" "polyBridgeEdge5.mp";
connectAttr "polyBridgeEdge5.out" "polyExtrudeFace25.ip";
connectAttr "shelfShape2.wm" "polyExtrudeFace25.mp";
connectAttr "polyTweak27.out" "polyExtrudeFace26.ip";
connectAttr "shelfShape2.wm" "polyExtrudeFace26.mp";
connectAttr "polyExtrudeFace25.out" "polyTweak27.ip";
connectAttr "polyTweak28.out" "polyExtrudeFace27.ip";
connectAttr "shelfShape2.wm" "polyExtrudeFace27.mp";
connectAttr "polyExtrudeFace26.out" "polyTweak28.ip";
connectAttr "polyTweak29.out" "polyExtrudeFace28.ip";
connectAttr "shelfShape2.wm" "polyExtrudeFace28.mp";
connectAttr "polyExtrudeFace27.out" "polyTweak29.ip";
connectAttr "polyTweak30.out" "polyExtrudeFace29.ip";
connectAttr "shelfShape2.wm" "polyExtrudeFace29.mp";
connectAttr "polyExtrudeFace28.out" "polyTweak30.ip";
connectAttr "polyTweak31.out" "polyExtrudeFace30.ip";
connectAttr "shelfShape2.wm" "polyExtrudeFace30.mp";
connectAttr "polyExtrudeFace29.out" "polyTweak31.ip";
connectAttr "polyTweak32.out" "polySoftEdge6.ip";
connectAttr "shelfShape2.wm" "polySoftEdge6.mp";
connectAttr "polyExtrudeFace30.out" "polyTweak32.ip";
connectAttr "polySoftEdge6.out" "deleteComponent7.ig";
connectAttr "deleteComponent7.og" "polyBridgeEdge6.ip";
connectAttr "shelfShape2.wm" "polyBridgeEdge6.mp";
connectAttr "polyBridgeEdge6.out" "deleteComponent8.ig";
connectAttr "deleteComponent8.og" "polyBridgeEdge7.ip";
connectAttr "shelfShape2.wm" "polyBridgeEdge7.mp";
connectAttr "polyBridgeEdge7.out" "deleteComponent9.ig";
connectAttr "deleteComponent9.og" "polyBridgeEdge8.ip";
connectAttr "shelfShape2.wm" "polyBridgeEdge8.mp";
connectAttr "polyBridgeEdge8.out" "deleteComponent10.ig";
connectAttr "deleteComponent10.og" "polyBridgeEdge9.ip";
connectAttr "shelfShape2.wm" "polyBridgeEdge9.mp";
connectAttr "polyBridgeEdge9.out" "deleteComponent11.ig";
connectAttr "deleteComponent11.og" "polyBridgeEdge10.ip";
connectAttr "shelfShape2.wm" "polyBridgeEdge10.mp";
connectAttr "polyBridgeEdge10.out" "polySoftEdge7.ip";
connectAttr "shelfShape2.wm" "polySoftEdge7.mp";
connectAttr "polySoftEdge7.out" "polySoftEdge8.ip";
connectAttr "shelfShape2.wm" "polySoftEdge8.mp";
connectAttr "polySoftEdge8.out" "polySoftEdge9.ip";
connectAttr "shelfShape2.wm" "polySoftEdge9.mp";
connectAttr "polyTweak33.out" "polySplit8.ip";
connectAttr "polyCube5.out" "polyTweak33.ip";
connectAttr "polySplit8.out" "polySplit9.ip";
connectAttr "polySplit9.out" "polySplit10.ip";
connectAttr "polySplit10.out" "polyExtrudeFace31.ip";
connectAttr "shelfdoorShape1.wm" "polyExtrudeFace31.mp";
connectAttr "polyTweak34.out" "polyExtrudeFace32.ip";
connectAttr "shelfdoorShape1.wm" "polyExtrudeFace32.mp";
connectAttr "polyExtrudeFace31.out" "polyTweak34.ip";
connectAttr "polyTweak35.out" "polySoftEdge10.ip";
connectAttr "shelfdoorShape1.wm" "polySoftEdge10.mp";
connectAttr "polyExtrudeFace32.out" "polyTweak35.ip";
connectAttr "polyTweak36.out" "polyExtrudeFace33.ip";
connectAttr "vaseShape.wm" "polyExtrudeFace33.mp";
connectAttr "polyCylinder1.out" "polyTweak36.ip";
connectAttr "polyTweak37.out" "polyExtrudeFace34.ip";
connectAttr "vaseShape.wm" "polyExtrudeFace34.mp";
connectAttr "polyExtrudeFace33.out" "polyTweak37.ip";
connectAttr "polyTweak38.out" "polyExtrudeFace35.ip";
connectAttr "vaseShape.wm" "polyExtrudeFace35.mp";
connectAttr "polyExtrudeFace34.out" "polyTweak38.ip";
connectAttr "polyTweak39.out" "polyExtrudeFace36.ip";
connectAttr "vaseShape.wm" "polyExtrudeFace36.mp";
connectAttr "polyExtrudeFace35.out" "polyTweak39.ip";
connectAttr "polyTweak40.out" "polyExtrudeFace37.ip";
connectAttr "vaseShape.wm" "polyExtrudeFace37.mp";
connectAttr "polyExtrudeFace36.out" "polyTweak40.ip";
connectAttr "polyTweak41.out" "polyExtrudeFace38.ip";
connectAttr "vaseShape.wm" "polyExtrudeFace38.mp";
connectAttr "polyExtrudeFace37.out" "polyTweak41.ip";
connectAttr "polyTweak42.out" "polyExtrudeFace39.ip";
connectAttr "vaseShape.wm" "polyExtrudeFace39.mp";
connectAttr "polyExtrudeFace38.out" "polyTweak42.ip";
connectAttr "polyTweak43.out" "polyExtrudeFace40.ip";
connectAttr "vaseShape.wm" "polyExtrudeFace40.mp";
connectAttr "polyExtrudeFace39.out" "polyTweak43.ip";
connectAttr "polyTweak44.out" "polyBevel1.ip";
connectAttr "vaseShape.wm" "polyBevel1.mp";
connectAttr "polyExtrudeFace40.out" "polyTweak44.ip";
connectAttr "polyBevel1.out" "polySoftEdge11.ip";
connectAttr "vaseShape.wm" "polySoftEdge11.mp";
connectAttr ":defaultArnoldDenoiser.msg" ":defaultArnoldRenderOptions.imagers" -na
		;
connectAttr ":defaultArnoldDisplayDriver.msg" ":defaultArnoldRenderOptions.drivers"
		 -na;
connectAttr ":defaultArnoldFilter.msg" ":defaultArnoldRenderOptions.filt";
connectAttr ":defaultArnoldDriver.msg" ":defaultArnoldRenderOptions.drvr";
connectAttr "polySurfaceShape1.o" "polyAutoProj1.ip";
connectAttr "shelf3Shape.wm" "polyAutoProj1.mp";
connectAttr "polyAutoProj1.out" "polyTweakUV1.ip";
connectAttr "polyTweakUV1.out" "polyPlanarProj1.ip";
connectAttr "shelf3Shape.wm" "polyPlanarProj1.mp";
connectAttr "polyPlanarProj1.out" "polyMapCut1.ip";
connectAttr "polyMapCut1.out" "polyMapCut2.ip";
connectAttr "polyMapCut2.out" "polyMapCut3.ip";
connectAttr "polyMapCut3.out" "polyMapCut4.ip";
connectAttr "polyMapCut4.out" "polyMapCut5.ip";
connectAttr "polyMapCut5.out" "polyMapCut6.ip";
connectAttr "polyMapCut6.out" "polyMapCut7.ip";
connectAttr "polyMapCut7.out" "polyMapCut8.ip";
connectAttr "polyMapCut8.out" "polyTweakUV2.ip";
connectAttr "polyTweakUV2.out" "polyLayoutUV1.ip";
connectAttr "polyLayoutUV1.out" "polyTweakUV3.ip";
connectAttr "polyTweakUV3.out" "polyAutoProj2.ip";
connectAttr "shelf3Shape.wm" "polyAutoProj2.mp";
connectAttr "polyAutoProj2.out" "polyLayoutUV2.ip";
connectAttr "polyLayoutUV2.out" "polyTweakUV4.ip";
connectAttr "polySurfaceShape2.o" "polyAutoProj3.ip";
connectAttr "shelf4Shape.wm" "polyAutoProj3.mp";
connectAttr "polyAutoProj3.out" "polyTweakUV5.ip";
connectAttr "polySoftEdge11.out" "polyAutoProj4.ip";
connectAttr "vaseShape.wm" "polyAutoProj4.mp";
connectAttr "polyAutoProj4.out" "polyTweakUV6.ip";
connectAttr "polySoftEdge9.out" "polyAutoProj5.ip";
connectAttr "shelfShape2.wm" "polyAutoProj5.mp";
connectAttr "polyAutoProj5.out" "polyTweakUV7.ip";
connectAttr "polyTweakUV7.out" "polyPlanarProj2.ip";
connectAttr "shelfShape2.wm" "polyPlanarProj2.mp";
connectAttr "polyPlanarProj2.out" "polyMapCut9.ip";
connectAttr "polyMapCut9.out" "polyMapCut10.ip";
connectAttr "polyMapCut10.out" "polyMapCut11.ip";
connectAttr "polyMapCut11.out" "polyMapCut12.ip";
connectAttr "polyMapCut12.out" "polyMapCut13.ip";
connectAttr "polyMapCut13.out" "polyTweakUV8.ip";
connectAttr "polyTweakUV8.out" "polyLayoutUV3.ip";
connectAttr "polyLayoutUV3.out" "polyTweakUV9.ip";
connectAttr "polyTweakUV9.out" "polyAutoProj6.ip";
connectAttr "shelfShape2.wm" "polyAutoProj6.mp";
connectAttr "polyAutoProj6.out" "polyTweakUV10.ip";
connectAttr "polyTweakUV10.out" "polyMapDel1.ip";
connectAttr "polyMapDel1.out" "polyTweakUV11.ip";
connectAttr "polyTweakUV11.out" "polyAutoProj7.ip";
connectAttr "shelfShape2.wm" "polyAutoProj7.mp";
connectAttr "polyAutoProj7.out" "polyTweakUV12.ip";
connectAttr "polySoftEdge10.out" "polyAutoProj8.ip";
connectAttr "shelfdoorShape1.wm" "polyAutoProj8.mp";
connectAttr "polySurfaceShape3.o" "polyAutoProj9.ip";
connectAttr "shelfdoorShape.wm" "polyAutoProj9.mp";
connectAttr "polyAutoProj9.out" "polyTweakUV13.ip";
connectAttr "polyAutoProj8.out" "polyTweakUV14.ip";
connectAttr "polyTweakUV13.out" "polyPlanarProj3.ip";
connectAttr "shelfdoorShape.wm" "polyPlanarProj3.mp";
connectAttr "polyTweakUV14.out" "polyPlanarProj4.ip";
connectAttr "shelfdoorShape1.wm" "polyPlanarProj4.mp";
connectAttr "polyPlanarProj3.out" "polyPlanarProj5.ip";
connectAttr "shelfdoorShape.wm" "polyPlanarProj5.mp";
connectAttr "polyPlanarProj5.out" "polyMapCut14.ip";
connectAttr "polyMapCut14.out" "polyMapCut15.ip";
connectAttr "polyMapCut15.out" "polyMapCut16.ip";
connectAttr "polyMapCut16.out" "polyMapCut17.ip";
connectAttr "polyMapCut17.out" "polyMapCut18.ip";
connectAttr "polyMapCut18.out" "polyMapSew1.ip";
connectAttr "polyMapSew1.out" "polyMapCut19.ip";
connectAttr "polyMapCut19.out" "polyMapSew2.ip";
connectAttr "polyMapSew2.out" "polyTweakUV15.ip";
connectAttr "polyTweakUV15.out" "polyMapCut20.ip";
connectAttr "polyMapCut20.out" "polyTweakUV16.ip";
connectAttr "shelfdoorShape1Orig.w" "transferAttributes1.ip[0].ig";
connectAttr "shelfdoorShape1Orig.o" "transferAttributes1.orggeom[0]";
connectAttr "shelfdoorShape.w" "transferAttributes1.src[0]";
connectAttr "polySoftEdge1.out" "polyPlanarProj6.ip";
connectAttr "shelf_baseShape.wm" "polyPlanarProj6.mp";
connectAttr "polyPlanarProj6.out" "polyMapCut21.ip";
connectAttr "polyMapCut21.out" "polyMapCut22.ip";
connectAttr "polyMapCut22.out" "polyMapCut23.ip";
connectAttr "polyMapCut23.out" "polyMapCut24.ip";
connectAttr "polyMapCut24.out" "polyMapCut25.ip";
connectAttr "polyMapCut25.out" "polyMapCut26.ip";
connectAttr "polyMapCut26.out" "polyMapCut27.ip";
connectAttr "polyMapCut27.out" "polyTweakUV17.ip";
connectAttr "polyTweakUV17.out" "polyAutoProj10.ip";
connectAttr "shelf_baseShape.wm" "polyAutoProj10.mp";
connectAttr "polyAutoProj10.out" "polyTweakUV18.ip";
connectAttr "polySurfaceShape4.o" "polyAutoProj11.ip";
connectAttr "outputCloth1.wm" "polyAutoProj11.mp";
connectAttr "polyAutoProj11.out" "polyTweakUV19.ip";
connectAttr "polySoftEdge5.out" "polyAutoProj12.ip";
connectAttr "shelf_door1Shape.wm" "polyAutoProj12.mp";
connectAttr "polySoftEdge4.out" "polyAutoProj13.ip";
connectAttr "shelf_doorShape.wm" "polyAutoProj13.mp";
connectAttr "polyAutoProj12.out" "polyTweakUV20.ip";
connectAttr "polyAutoProj13.out" "polyTweakUV21.ip";
connectAttr "transferAttributes1.og[0]" "polyTweakUV22.ip";
connectAttr "defaultRenderLayer.msg" ":defaultRenderingList1.r" -na;
connectAttr "shelf_baseShape.iog" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape4.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape4.ciog.cog[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape1.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape1.ciog.cog[0]" ":initialShadingGroup.dsm" -na;
connectAttr "shelf_doorShape.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "shelf_doorShape.ciog.cog[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape3.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape3.ciog.cog[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape2.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape2.ciog.cog[0]" ":initialShadingGroup.dsm" -na;
connectAttr "shelf_door1Shape.iog.og[0]" ":initialShadingGroup.dsm" -na;
connectAttr "shelf_door1Shape.ciog.cog[0]" ":initialShadingGroup.dsm" -na;
connectAttr "shelf4Shape.iog" ":initialShadingGroup.dsm" -na;
connectAttr "shelfShape2.iog" ":initialShadingGroup.dsm" -na;
connectAttr "shelfdoorShape1.iog" ":initialShadingGroup.dsm" -na;
connectAttr "shelfdoorShape.iog" ":initialShadingGroup.dsm" -na;
connectAttr "shelf3Shape.iog" ":initialShadingGroup.dsm" -na;
connectAttr "outputCloth1.iog" ":initialShadingGroup.dsm" -na;
connectAttr "vaseShape.iog" ":initialShadingGroup.dsm" -na;
connectAttr "groupId1.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId2.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId3.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId4.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId5.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId7.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId8.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId9.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId10.msg" ":initialShadingGroup.gn" -na;
connectAttr "groupId11.msg" ":initialShadingGroup.gn" -na;
// End of shelves.ma
