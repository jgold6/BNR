.subsections_via_symbols
.section __DWARF, __debug_abbrev,regular,debug

	.byte 1,17,1,37,8,3,8,27,8,19,11,17,1,18,1,16,6,0,0,2,46,1,3,8,17,1,18,1,64,10,0,0
	.byte 3,5,0,3,8,73,19,2,10,0,0,15,5,0,3,8,73,19,2,6,0,0,4,36,0,11,11,62,11,3,8,0
	.byte 0,5,2,1,3,8,11,15,0,0,17,2,0,3,8,11,15,0,0,6,13,0,3,8,73,19,56,10,0,0,7,22
	.byte 0,3,8,73,19,0,0,8,4,1,3,8,11,15,73,19,0,0,9,40,0,3,8,28,13,0,0,10,57,1,3,8
	.byte 0,0,11,52,0,3,8,73,19,2,10,0,0,12,52,0,3,8,73,19,2,6,0,0,13,15,0,73,19,0,0,14
	.byte 16,0,73,19,0,0,16,28,0,73,19,56,10,0,0,18,46,0,3,8,17,1,18,1,0,0,0
.section __DWARF, __debug_info,regular,debug
Ldebug_info_start:

LDIFF_SYM0=Ldebug_info_end - Ldebug_info_begin
	.long LDIFF_SYM0
Ldebug_info_begin:

	.short 2
	.long 0
	.byte 4,1
	.asciz "Mono AOT Compiler 3.8.0 (mono-3.8.0-branch/45d0ba1 Tue Aug 26 07:52:59 EDT 2014)"
	.asciz "System.dll"
	.asciz ""

	.byte 2,0,0,0,0,0,0,0,0
LDIFF_SYM1=Ldebug_line_start - Ldebug_line_section_start
	.long LDIFF_SYM1
LDIE_I1:

	.byte 4,1,5
	.asciz "sbyte"
LDIE_U1:

	.byte 4,1,7
	.asciz "byte"
LDIE_I2:

	.byte 4,2,5
	.asciz "short"
LDIE_U2:

	.byte 4,2,7
	.asciz "ushort"
LDIE_I4:

	.byte 4,4,5
	.asciz "int"
LDIE_U4:

	.byte 4,4,7
	.asciz "uint"
LDIE_I8:

	.byte 4,8,5
	.asciz "long"
LDIE_U8:

	.byte 4,8,7
	.asciz "ulong"
LDIE_I:

	.byte 4,4,5
	.asciz "intptr"
LDIE_U:

	.byte 4,4,7
	.asciz "uintptr"
LDIE_R4:

	.byte 4,4,4
	.asciz "float"
LDIE_R8:

	.byte 4,8,4
	.asciz "double"
LDIE_BOOLEAN:

	.byte 4,1,2
	.asciz "boolean"
LDIE_CHAR:

	.byte 4,2,8
	.asciz "char"
LDIE_STRING:

	.byte 4,4,1
	.asciz "string"
LDIE_OBJECT:

	.byte 4,4,1
	.asciz "object"
LDIE_SZARRAY:

	.byte 4,4,1
	.asciz "object"
.section __DWARF, __debug_loc,regular,debug
Ldebug_loc_start:
.section __DWARF, __debug_frame,regular,debug
	.align 3

LDIFF_SYM2=Lcie0_end - Lcie0_start
	.long LDIFF_SYM2
Lcie0_start:

	.long -1
	.byte 3
	.asciz ""

	.byte 1,124,14
	.align 2
Lcie0_end:
.text
	.align 3
methods:
	.space 16
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1__ctor
_System_Collections_Generic_LinkedList_1__ctor:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,12,208,141,226,0,1,189,232,128,128,189,232

Lme_0:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_VerifyReferencedNode_System_Collections_Generic_LinkedListNode_1_T
_System_Collections_Generic_LinkedList_1_VerifyReferencedNode_System_Collections_Generic_LinkedListNode_1_T:

	.byte 128,64,45,233,13,112,160,225,0,5,45,233,8,208,77,226,0,0,141,229,1,160,160,225,0,0,90,227,8,0,0,10
	.byte 10,0,160,225,0,224,218,229
bl _p_1

	.byte 0,16,157,229,1,0,80,225,13,0,0,26,8,208,141,226,0,5,189,232,128,128,189,232,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . -12
	.byte 0,0,159,231,1,16,160,227
bl _p_2

	.byte 0,16,160,225,169,1,0,227,0,2,64,227
bl _mono_create_corlib_exception_1
bl _p_3

	.byte 0,2,0,227,0,2,64,227
bl _mono_create_corlib_exception_0
bl _p_3

Lme_1:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_VerifyBlankNode_System_Collections_Generic_LinkedListNode_1_T
_System_Collections_Generic_LinkedList_1_VerifyBlankNode_System_Collections_Generic_LinkedListNode_1_T:

	.byte 128,64,45,233,13,112,160,225,0,5,45,233,8,208,77,226,0,128,141,229,0,160,160,225,0,0,90,227,7,0,0,10
	.byte 10,0,160,225,0,224,218,229
bl _p_1

	.byte 0,0,80,227,13,0,0,26,8,208,141,226,0,5,189,232,128,128,189,232,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . -12
	.byte 0,0,159,231,11,16,160,227
bl _p_2

	.byte 0,16,160,225,169,1,0,227,0,2,64,227
bl _mono_create_corlib_exception_1
bl _p_3

	.byte 0,2,0,227,0,2,64,227
bl _mono_create_corlib_exception_0
bl _p_3

Lme_2:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_AddFirst_System_Collections_Generic_LinkedListNode_1_T
_System_Collections_Generic_LinkedList_1_AddFirst_System_Collections_Generic_LinkedListNode_1_T:

	.byte 128,64,45,233,13,112,160,225,0,5,45,233,8,208,77,226,0,0,141,229,1,160,160,225,0,0,157,229,0,0,144,229
bl _p_4

	.byte 0,128,160,225,10,0,160,225
bl _System_Collections_Generic_LinkedList_1_VerifyBlankNode_System_Collections_Generic_LinkedListNode_1_T

	.byte 0,0,157,229,8,0,144,229,0,0,80,227,4,0,0,26,0,16,157,229,10,0,160,225,0,224,218,229
bl _p_5

	.byte 8,0,0,234,0,0,157,229,8,0,144,229,20,16,144,229,0,0,157,229,8,32,144,229,0,48,157,229,10,0,160,225
	.byte 0,224,218,229
bl _p_6

	.byte 0,0,157,229,12,16,144,229,1,16,129,226,12,16,128,229,0,0,157,229,16,16,144,229,1,16,129,226,16,16,128,229
	.byte 0,0,157,229,8,160,128,229,8,208,141,226,0,5,189,232,128,128,189,232

Lme_3:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_AddLast_T
_System_Collections_Generic_LinkedList_1_AddLast_T:

	.byte 128,64,45,233,13,112,160,225,64,9,45,233,36,208,77,226,13,176,160,225,8,0,139,229,12,16,139,229,8,0,155,229
	.byte 8,0,144,229,0,0,80,227,14,0,0,26,8,0,155,229,20,0,139,229,8,0,155,229,0,0,144,229
bl _p_7
bl _p_8

	.byte 20,16,155,229,16,0,139,229,12,32,155,229
bl _p_9

	.byte 16,0,155,229,0,96,160,225,8,0,155,229,8,96,128,229,21,0,0,234,8,0,155,229,20,0,139,229,8,0,155,229
	.byte 8,0,144,229,20,0,144,229,24,0,139,229,8,0,155,229,8,0,144,229,28,0,139,229,8,0,155,229,0,0,144,229
bl _p_7
bl _p_8

	.byte 20,16,155,229,24,48,155,229,28,192,155,229,16,0,139,229,12,32,155,229,0,192,141,229
bl _p_10

	.byte 16,0,155,229,0,96,160,225,8,0,155,229,12,16,144,229,1,16,129,226,12,16,128,229,8,0,155,229,16,16,144,229
	.byte 1,16,129,226,16,16,128,229,6,0,160,225,36,208,139,226,64,9,189,232,128,128,189,232

Lme_4:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_Clear
_System_Collections_Generic_LinkedList_1_Clear:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,3,0,0,234,0,0,157,229,0,16,160,225
	.byte 8,16,145,229
bl _System_Collections_Generic_LinkedList_1_Remove_System_Collections_Generic_LinkedListNode_1_T

	.byte 0,0,157,229,8,0,144,229,0,0,80,227,247,255,255,26,12,208,141,226,0,1,189,232,128,128,189,232

Lme_5:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_Contains_T
_System_Collections_Generic_LinkedList_1_Contains_T:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,4,16,141,229,0,0,157,229,4,16,157,229
bl _System_Collections_Generic_LinkedList_1_Find_T

	.byte 0,0,80,227,0,0,160,19,1,0,160,3,0,0,80,227,0,0,160,19,1,0,160,3,12,208,141,226,0,1,189,232
	.byte 128,128,189,232

Lme_6:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_CopyTo_T___int
_System_Collections_Generic_LinkedList_1_CopyTo_T___int:

	.byte 128,64,45,233,13,112,160,225,96,13,45,233,52,208,77,226,36,0,141,229,1,96,160,225,2,160,160,225,0,0,86,227
	.byte 120,0,0,10,4,160,141,229,8,176,150,229,0,0,91,227,2,0,0,10,4,0,155,229,0,0,141,229,1,0,0,234
	.byte 0,0,160,227,0,0,141,229,4,0,157,229,0,16,157,229,1,0,80,225,66,0,0,58,0,0,150,229,22,0,208,229
	.byte 1,0,80,227,73,0,0,26,12,0,150,229,10,0,64,224,16,0,141,229,8,0,150,229,8,0,141,229,0,0,80,227
	.byte 3,0,0,10,8,0,157,229,4,0,144,229,12,0,141,229,1,0,0,234,0,0,160,227,12,0,141,229,16,0,157,229
	.byte 12,16,157,229,1,0,128,224,28,0,141,229,0,16,224,227,1,0,80,225,0,0,160,227,1,0,160,195,1,0,64,226
	.byte 20,0,141,229,36,16,157,229,12,16,145,229,32,16,141,229,0,16,160,227,24,16,141,229,0,0,80,227,7,0,0,202
	.byte 20,0,157,229,24,16,157,229,1,0,80,225,58,0,0,26,28,0,157,229,32,16,157,229,1,0,80,225,54,0,0,58
	.byte 36,0,157,229,8,80,144,229,36,0,157,229,8,0,144,229,0,0,80,227,15,0,0,10,5,0,160,225,0,224,213,229
bl _p_11

	.byte 0,32,160,225,6,0,160,225,10,16,160,225,0,48,150,229,15,224,160,225,68,240,147,229,1,160,138,226,16,80,149,229
	.byte 5,0,160,225,36,16,157,229,8,16,145,229,1,0,80,225,239,255,255,26,52,208,141,226,96,13,189,232,128,128,189,232
	.byte 0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . -12
	.byte 0,0,159,231,39,16,160,227
bl _p_2

	.byte 0,16,160,225,170,1,0,227,0,2,64,227
bl _mono_create_corlib_exception_1
bl _p_3

	.byte 0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . -12
	.byte 0,0,159,231,27,16,160,227
bl _p_2

	.byte 40,0,141,229,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . -12
	.byte 0,0,159,231,51,16,160,227
bl _p_2

	.byte 0,32,160,225,40,16,157,229,168,1,0,227,0,2,64,227
bl _mono_create_corlib_exception_2
bl _p_3

	.byte 0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . -12
	.byte 0,0,159,231,103,16,160,227
bl _p_2

	.byte 0,16,160,225,168,1,0,227,0,2,64,227
bl _mono_create_corlib_exception_1
bl _p_3

	.byte 0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . -12
	.byte 0,0,159,231,27,16,160,227
bl _p_2

	.byte 0,16,160,225,169,1,0,227,0,2,64,227
bl _mono_create_corlib_exception_1
bl _p_3

Lme_7:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_Find_T
_System_Collections_Generic_LinkedList_1_Find_T:

	.byte 128,64,45,233,13,112,160,225,64,5,45,233,20,208,77,226,0,0,141,229,1,160,160,225,0,0,157,229,8,96,144,229
	.byte 6,0,160,225,0,0,80,227,1,0,0,26,0,0,160,227,45,0,0,234,0,0,90,227,6,0,0,26,6,0,160,225
	.byte 0,224,214,229
bl _p_11

	.byte 0,0,80,227,31,0,0,26,6,0,160,225,36,0,0,234,0,0,157,229,0,0,144,229
bl _p_12
bl _p_13

	.byte 0,0,157,229,0,0,144,229
bl _p_12

	.byte 0,128,160,225
bl _p_14

	.byte 12,0,141,229,6,0,160,225,0,224,214,229
bl _p_11

	.byte 8,0,141,229,0,0,157,229,0,0,144,229
bl _p_12
bl _p_13

	.byte 8,16,157,229,12,48,157,229,3,0,160,225,10,32,160,225,0,48,147,229,15,224,160,225,60,240,147,229,255,0,0,226
	.byte 0,0,80,227,1,0,0,10,6,0,160,225,6,0,0,234,16,96,150,229,6,0,160,225,0,16,157,229,8,16,145,229
	.byte 1,0,80,225,210,255,255,26,0,0,160,227,20,208,141,226,64,5,189,232,128,128,189,232

Lme_8:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_GetEnumerator
_System_Collections_Generic_LinkedList_1_GetEnumerator:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,52,208,77,226,0,16,141,229,36,0,141,229,36,0,157,229,40,0,141,229
	.byte 36,0,157,229,0,0,144,229
bl _p_15

	.byte 0,32,160,225,40,16,157,229,0,0,160,227,4,0,141,229,0,0,160,227,8,0,141,229,0,0,160,227,12,0,141,229
	.byte 0,0,160,227,16,0,141,229,4,0,141,226,2,128,160,225
bl _p_16

	.byte 4,0,157,229,20,0,141,229,8,0,157,229,24,0,141,229,12,0,157,229,28,0,141,229,16,0,157,229,32,0,141,229
	.byte 0,0,157,229,20,16,157,229,0,16,128,229,24,16,157,229,4,16,128,229,28,16,157,229,8,16,128,229,32,16,157,229
	.byte 12,16,128,229,52,208,141,226,0,1,189,232,128,128,189,232

Lme_9:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_Remove_T
_System_Collections_Generic_LinkedList_1_Remove_T:

	.byte 128,64,45,233,13,112,160,225,0,5,45,233,8,208,77,226,0,0,141,229,1,160,160,225,0,0,157,229,10,16,160,225
bl _System_Collections_Generic_LinkedList_1_Find_T

	.byte 0,160,160,225,0,0,80,227,1,0,0,26,0,0,160,227,3,0,0,234,0,0,157,229,10,16,160,225
bl _System_Collections_Generic_LinkedList_1_Remove_System_Collections_Generic_LinkedListNode_1_T

	.byte 1,0,160,227,8,208,141,226,0,5,189,232,128,128,189,232

Lme_a:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_Remove_System_Collections_Generic_LinkedListNode_1_T
_System_Collections_Generic_LinkedList_1_Remove_System_Collections_Generic_LinkedListNode_1_T:

	.byte 128,64,45,233,13,112,160,225,0,5,45,233,8,208,77,226,0,0,141,229,1,160,160,225,0,0,157,229,10,16,160,225
bl _System_Collections_Generic_LinkedList_1_VerifyReferencedNode_System_Collections_Generic_LinkedListNode_1_T

	.byte 0,0,157,229,12,16,144,229,1,16,65,226,12,16,128,229,0,0,157,229,12,0,144,229,0,0,80,227,2,0,0,26
	.byte 0,0,157,229,0,16,160,227,8,16,128,229,0,0,157,229,8,0,144,229,0,0,90,225,4,0,0,26,0,0,157,229
	.byte 0,16,160,225,8,16,145,229,16,16,145,229,8,16,128,229,0,0,157,229,16,16,144,229,1,16,129,226,16,16,128,229
	.byte 10,0,160,225,0,224,218,229
bl _p_17

	.byte 8,208,141,226,0,5,189,232,128,128,189,232

Lme_b:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_RemoveLast
_System_Collections_Generic_LinkedList_1_RemoveLast:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,0,0,157,229,8,0,144,229,0,0,80,227
	.byte 7,0,0,10,0,0,157,229,0,16,160,225,8,16,145,229,20,16,145,229
bl _System_Collections_Generic_LinkedList_1_Remove_System_Collections_Generic_LinkedListNode_1_T

	.byte 12,208,141,226,0,1,189,232,128,128,189,232,0,2,0,227,0,2,64,227
bl _mono_create_corlib_exception_0
bl _p_3

Lme_c:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_System_Collections_Generic_ICollection_T_Add_T
_System_Collections_Generic_LinkedList_1_System_Collections_Generic_ICollection_T_Add_T:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,4,16,141,229,0,0,157,229,4,16,157,229
bl _System_Collections_Generic_LinkedList_1_AddLast_T

	.byte 12,208,141,226,0,1,189,232,128,128,189,232

Lme_d:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_System_Collections_Generic_IEnumerable_T_GetEnumerator
_System_Collections_Generic_LinkedList_1_System_Collections_Generic_IEnumerable_T_GetEnumerator:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,28,208,77,226,16,0,141,229,16,0,157,229,13,16,160,225
bl _System_Collections_Generic_LinkedList_1_GetEnumerator

	.byte 16,0,157,229,0,0,144,229
bl _p_18
bl _p_8

	.byte 8,16,128,226,0,32,157,229,0,32,129,229,4,32,157,229,4,32,129,229,8,32,157,229,8,32,129,229,12,32,157,229
	.byte 12,32,129,229,28,208,141,226,0,1,189,232,128,128,189,232

Lme_e:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_System_Collections_IEnumerable_GetEnumerator
_System_Collections_Generic_LinkedList_1_System_Collections_IEnumerable_GetEnumerator:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,28,208,77,226,16,0,141,229,16,0,157,229,13,16,160,225
bl _System_Collections_Generic_LinkedList_1_GetEnumerator

	.byte 16,0,157,229,0,0,144,229
bl _p_19
bl _p_8

	.byte 8,16,128,226,0,32,157,229,0,32,129,229,4,32,157,229,4,32,129,229,8,32,157,229,8,32,129,229,12,32,157,229
	.byte 12,32,129,229,28,208,141,226,0,1,189,232,128,128,189,232

Lme_f:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_get_Count
_System_Collections_Generic_LinkedList_1_get_Count:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,0,0,157,229,12,0,144,229,12,208,141,226
	.byte 0,1,189,232,128,128,189,232

Lme_10:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_get_Last
_System_Collections_Generic_LinkedList_1_get_Last:

	.byte 128,64,45,233,13,112,160,225,0,5,45,233,8,208,77,226,0,0,141,229,0,0,157,229,8,0,144,229,0,0,80,227
	.byte 3,0,0,10,0,0,157,229,8,0,144,229,20,160,144,229,0,0,0,234,0,160,160,227,10,0,160,225,8,208,141,226
	.byte 0,5,189,232,128,128,189,232

Lme_11:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_System_Collections_Generic_ICollection_T_get_IsReadOnly
_System_Collections_Generic_LinkedList_1_System_Collections_Generic_ICollection_T_get_IsReadOnly:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,0,0,160,227,12,208,141,226,0,1,189,232
	.byte 128,128,189,232

Lme_12:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_System_Collections_ICollection_get_SyncRoot
_System_Collections_Generic_LinkedList_1_System_Collections_ICollection_get_SyncRoot:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,0,0,157,229,12,208,141,226,0,1,189,232
	.byte 128,128,189,232

Lme_13:
.text
ut_20:

	.byte 8,0,128,226
	b _System_Collections_Generic_LinkedList_1_Enumerator__ctor_System_Collections_Generic_LinkedList_1_T

.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_Enumerator__ctor_System_Collections_Generic_LinkedList_1_T
_System_Collections_Generic_LinkedList_1_Enumerator__ctor_System_Collections_Generic_LinkedList_1_T:

	.byte 128,64,45,233,13,112,160,225,64,1,45,233,8,208,77,226,0,128,141,229,0,96,160,225,4,16,141,229,4,0,157,229
	.byte 0,0,134,229,0,16,160,227,4,16,134,229,0,16,224,227,8,16,134,229,16,0,144,229,12,0,134,229,8,208,141,226
	.byte 64,1,189,232,128,128,189,232

Lme_14:
.text
ut_21:

	.byte 8,0,128,226
	b _System_Collections_Generic_LinkedList_1_Enumerator_get_Current

.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_Enumerator_get_Current
_System_Collections_Generic_LinkedList_1_Enumerator_get_Current:

	.byte 128,64,45,233,13,112,160,225,0,5,45,233,8,208,77,226,0,128,141,229,0,160,160,225,0,0,154,229,0,0,80,227
	.byte 9,0,0,10,4,0,154,229,0,0,80,227,11,0,0,10,4,16,154,229,1,0,160,225,0,224,209,229
bl _p_20

	.byte 8,208,141,226,0,5,189,232,128,128,189,232,28,2,0,227,0,2,64,227,0,16,160,227
bl _mono_create_corlib_exception_1
bl _p_3

	.byte 0,2,0,227,0,2,64,227
bl _mono_create_corlib_exception_0
bl _p_3

Lme_15:
.text
ut_22:

	.byte 8,0,128,226
	b _System_Collections_Generic_LinkedList_1_Enumerator_System_Collections_IEnumerator_get_Current

.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_Enumerator_System_Collections_IEnumerator_get_Current
_System_Collections_Generic_LinkedList_1_Enumerator_System_Collections_IEnumerator_get_Current:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,128,141,229,4,0,141,229,0,0,157,229
bl _p_21

	.byte 0,128,160,225,4,0,157,229
bl _System_Collections_Generic_LinkedList_1_Enumerator_get_Current

	.byte 12,208,141,226,0,1,189,232,128,128,189,232

Lme_16:
.text
ut_23:

	.byte 8,0,128,226
	b _System_Collections_Generic_LinkedList_1_Enumerator_MoveNext

.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_Enumerator_MoveNext
_System_Collections_Generic_LinkedList_1_Enumerator_MoveNext:

	.byte 128,64,45,233,13,112,160,225,0,5,45,233,8,208,77,226,0,128,141,229,0,160,160,225,0,0,154,229,0,0,80,227
	.byte 37,0,0,10,12,0,154,229,0,16,154,229,16,16,145,229,1,0,80,225,37,0,0,26,4,0,154,229,0,0,80,227
	.byte 6,0,0,26,8,0,154,229,0,0,80,227,12,0,0,170,0,0,154,229,8,0,144,229,4,0,138,229,8,0,0,234
	.byte 4,0,154,229,16,0,144,229,4,0,138,229,0,16,154,229,8,16,145,229,1,0,80,225,1,0,0,26,0,0,160,227
	.byte 4,0,138,229,4,0,154,229,0,0,80,227,3,0,0,26,128,4,224,227,8,0,138,229,0,0,160,227,3,0,0,234
	.byte 8,0,154,229,1,0,128,226,8,0,138,229,1,0,160,227,8,208,141,226,0,5,189,232,128,128,189,232,28,2,0,227
	.byte 0,2,64,227,0,16,160,227
bl _mono_create_corlib_exception_1
bl _p_3

	.byte 0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . -12
	.byte 0,0,159,231,169,16,160,227
bl _p_2

	.byte 0,16,160,225,0,2,0,227,0,2,64,227
bl _mono_create_corlib_exception_1
bl _p_3

Lme_17:
.text
ut_24:

	.byte 8,0,128,226
	b _System_Collections_Generic_LinkedList_1_Enumerator_Dispose

.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_Enumerator_Dispose
_System_Collections_Generic_LinkedList_1_Enumerator_Dispose:

	.byte 128,64,45,233,13,112,160,225,0,5,45,233,8,208,77,226,0,128,141,229,0,160,160,225,0,0,154,229,0,0,80,227
	.byte 6,0,0,10,0,0,160,227,4,0,138,229,0,0,160,227,0,0,138,229,8,208,141,226,0,5,189,232,128,128,189,232
	.byte 28,2,0,227,0,2,64,227,0,16,160,227
bl _mono_create_corlib_exception_1
bl _p_3

Lme_18:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedListNode_1__ctor_T
_System_Collections_Generic_LinkedListNode_1__ctor_T:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,4,16,141,229,0,0,157,229,4,16,157,229
	.byte 8,16,128,229,12,208,141,226,0,1,189,232,128,128,189,232

Lme_19:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedListNode_1__ctor_System_Collections_Generic_LinkedList_1_T_T
_System_Collections_Generic_LinkedListNode_1__ctor_System_Collections_Generic_LinkedList_1_T_T:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,20,208,77,226,0,0,141,229,4,16,141,229,8,32,141,229,0,0,157,229
	.byte 4,16,157,229,12,16,128,229,0,0,157,229,8,16,157,229,8,16,128,229,0,0,157,229,0,32,160,225,0,16,157,229
	.byte 1,48,160,225,16,48,130,229,20,16,128,229,20,208,141,226,0,1,189,232,128,128,189,232

Lme_1a:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedListNode_1__ctor_System_Collections_Generic_LinkedList_1_T_T_System_Collections_Generic_LinkedListNode_1_T_System_Collections_Generic_LinkedListNode_1_T
_System_Collections_Generic_LinkedListNode_1__ctor_System_Collections_Generic_LinkedList_1_T_T_System_Collections_Generic_LinkedListNode_1_T_System_Collections_Generic_LinkedListNode_1_T:

	.byte 128,64,45,233,13,112,160,225,0,9,45,233,24,208,77,226,13,176,160,225,0,0,139,229,4,16,139,229,8,32,139,229
	.byte 12,48,139,229,40,224,157,229,16,224,139,229,0,0,155,229,4,16,155,229,12,16,128,229,0,0,155,229,8,16,155,229
	.byte 8,16,128,229,0,0,155,229,12,16,155,229,20,16,128,229,0,32,155,229,16,0,155,229,16,0,130,229,0,32,155,229
	.byte 16,32,129,229,0,16,155,229,20,16,128,229,24,208,139,226,0,9,189,232,128,128,189,232

Lme_1b:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedListNode_1_Detach
_System_Collections_Generic_LinkedListNode_1_Detach:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,0,0,157,229,20,0,144,229,0,16,157,229
	.byte 16,16,145,229,16,16,128,229,0,0,157,229,16,0,144,229,0,16,157,229,20,16,145,229,20,16,128,229,0,0,157,229
	.byte 0,16,160,225,0,32,160,227,20,32,129,229,0,16,160,227,16,16,128,229,0,0,157,229,0,16,160,227,12,16,128,229
	.byte 12,208,141,226,0,1,189,232,128,128,189,232

Lme_1c:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedListNode_1_SelfReference_System_Collections_Generic_LinkedList_1_T
_System_Collections_Generic_LinkedListNode_1_SelfReference_System_Collections_Generic_LinkedList_1_T:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,4,16,141,229,0,0,157,229,0,16,160,225
	.byte 16,16,128,229,0,0,157,229,0,16,160,225,20,16,128,229,0,0,157,229,4,16,157,229,12,16,128,229,12,208,141,226
	.byte 0,1,189,232,128,128,189,232

Lme_1d:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedListNode_1_InsertBetween_System_Collections_Generic_LinkedListNode_1_T_System_Collections_Generic_LinkedListNode_1_T_System_Collections_Generic_LinkedList_1_T
_System_Collections_Generic_LinkedListNode_1_InsertBetween_System_Collections_Generic_LinkedListNode_1_T_System_Collections_Generic_LinkedListNode_1_T_System_Collections_Generic_LinkedList_1_T:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,20,208,77,226,0,0,141,229,4,16,141,229,8,32,141,229,12,48,141,229
	.byte 0,0,157,229,4,16,157,229,16,0,129,229,0,0,157,229,8,32,157,229,20,0,130,229,0,0,157,229,16,32,128,229
	.byte 0,0,157,229,20,16,128,229,0,0,157,229,12,16,157,229,12,16,128,229,20,208,141,226,0,1,189,232,128,128,189,232

Lme_1e:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedListNode_1_get_List
_System_Collections_Generic_LinkedListNode_1_get_List:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,0,0,157,229,12,0,144,229,12,208,141,226
	.byte 0,1,189,232,128,128,189,232

Lme_1f:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedListNode_1_get_Previous
_System_Collections_Generic_LinkedListNode_1_get_Previous:

	.byte 128,64,45,233,13,112,160,225,0,5,45,233,8,208,77,226,0,0,141,229,0,0,157,229,12,0,144,229,0,0,80,227
	.byte 8,0,0,10,0,0,157,229,0,16,160,225,12,16,145,229,8,16,145,229,1,0,80,225,2,0,0,10,0,0,157,229
	.byte 20,160,144,229,0,0,0,234,0,160,160,227,10,0,160,225,8,208,141,226,0,5,189,232,128,128,189,232

Lme_20:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedListNode_1_get_Value
_System_Collections_Generic_LinkedListNode_1_get_Value:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,0,0,157,229,8,0,144,229,12,208,141,226
	.byte 0,1,189,232,128,128,189,232

Lme_21:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_Stack_1__ctor
_System_Collections_Generic_Stack_1__ctor:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,12,208,141,226,0,1,189,232,128,128,189,232

Lme_22:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_Stack_1_Peek
_System_Collections_Generic_Stack_1_Peek:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,0,0,157,229,12,0,144,229,0,0,80,227
	.byte 14,0,0,10,0,0,157,229,8,0,144,229,0,16,157,229,12,16,145,229,1,16,65,226,12,32,144,229,1,0,82,225
	.byte 10,0,0,155,1,17,160,225,1,0,128,224,16,0,128,226,0,0,144,229,12,208,141,226,0,1,189,232,128,128,189,232
	.byte 0,2,0,227,0,2,64,227
bl _mono_create_corlib_exception_0
bl _p_3

	.byte 14,16,160,225,0,0,159,229
bl _p_22

	.byte 250,1,0,2

Lme_23:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_Stack_1_Pop
_System_Collections_Generic_Stack_1_Pop:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,20,208,77,226,12,0,141,229,12,0,157,229,12,0,144,229,0,0,80,227
	.byte 34,0,0,10,12,0,157,229,16,16,144,229,1,16,129,226,16,16,128,229,12,0,157,229,8,0,144,229,12,32,157,229
	.byte 12,16,146,229,1,16,65,226,1,48,160,225,4,16,141,229,12,48,130,229,12,32,144,229,1,0,82,225,23,0,0,155
	.byte 1,17,160,225,1,0,128,224,16,0,128,226,0,0,144,229,0,0,141,229,12,0,157,229,8,48,144,229,12,0,157,229
	.byte 12,16,144,229,0,0,160,227,8,0,141,229,3,0,160,225,0,32,160,227,0,48,147,229,15,224,160,225,68,240,147,229
	.byte 0,0,157,229,20,208,141,226,0,1,189,232,128,128,189,232,0,2,0,227,0,2,64,227
bl _mono_create_corlib_exception_0
bl _p_3

	.byte 14,16,160,225,0,0,159,229
bl _p_22

	.byte 250,1,0,2

Lme_24:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_Stack_1_Push_T
_System_Collections_Generic_Stack_1_Push_T:

	.byte 128,64,45,233,13,112,160,225,16,1,45,233,16,208,77,226,8,0,141,229,12,16,141,229,8,0,157,229,8,0,144,229
	.byte 0,0,80,227,6,0,0,10,8,0,157,229,12,0,144,229,8,16,157,229,8,16,145,229,12,16,145,229,1,0,80,225
	.byte 20,0,0,26,8,0,157,229,0,0,80,227,37,0,0,11,8,16,128,226,8,0,157,229,12,0,144,229,4,16,141,229
	.byte 0,0,80,227,1,0,0,26,16,64,160,227,2,0,0,234,8,0,157,229,12,0,144,229,128,64,160,225,8,0,157,229
	.byte 0,0,144,229
bl _p_23

	.byte 0,128,160,225,4,0,157,229,4,16,160,225
bl _p_24

	.byte 8,0,157,229,16,16,144,229,1,16,129,226,16,16,128,229,8,0,157,229,8,48,144,229,8,0,157,229,12,16,144,229
	.byte 1,32,160,225,0,16,141,229,1,32,130,226,12,32,128,229,3,0,160,225,12,32,157,229,0,48,147,229,15,224,160,225
	.byte 68,240,147,229,16,208,141,226,16,1,189,232,128,128,189,232,14,16,160,225,0,0,159,229
bl _p_22

	.byte 23,2,0,2

Lme_25:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_Stack_1_get_Count
_System_Collections_Generic_Stack_1_get_Count:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,0,0,157,229,12,0,144,229,12,208,141,226
	.byte 0,1,189,232,128,128,189,232

Lme_26:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_Stack_1_System_Collections_ICollection_get_SyncRoot
_System_Collections_Generic_Stack_1_System_Collections_ICollection_get_SyncRoot:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,0,0,157,229,12,208,141,226,0,1,189,232
	.byte 128,128,189,232

Lme_27:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_Stack_1_GetEnumerator
_System_Collections_Generic_Stack_1_GetEnumerator:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,44,208,77,226,0,16,141,229,28,0,141,229,28,0,157,229,32,0,141,229
	.byte 28,0,157,229,0,0,144,229
bl _p_25

	.byte 0,32,160,225,32,16,157,229,0,0,160,227,4,0,141,229,0,0,160,227,8,0,141,229,0,0,160,227,12,0,141,229
	.byte 4,0,141,226,2,128,160,225
bl _p_26

	.byte 4,0,157,229,16,0,141,229,8,0,157,229,20,0,141,229,12,0,157,229,24,0,141,229,0,0,157,229,16,16,157,229
	.byte 0,16,128,229,20,16,157,229,4,16,128,229,24,16,157,229,8,16,128,229,44,208,141,226,0,1,189,232,128,128,189,232

Lme_28:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_Stack_1_System_Collections_Generic_IEnumerable_T_GetEnumerator
_System_Collections_Generic_Stack_1_System_Collections_Generic_IEnumerable_T_GetEnumerator:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,20,208,77,226,12,0,141,229,12,0,157,229,13,16,160,225
bl _System_Collections_Generic_Stack_1_GetEnumerator

	.byte 12,0,157,229,0,0,144,229
bl _p_27
bl _p_8

	.byte 8,16,128,226,0,32,157,229,0,32,129,229,4,32,157,229,4,32,129,229,8,32,157,229,8,32,129,229,20,208,141,226
	.byte 0,1,189,232,128,128,189,232

Lme_29:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_Stack_1_System_Collections_IEnumerable_GetEnumerator
_System_Collections_Generic_Stack_1_System_Collections_IEnumerable_GetEnumerator:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,20,208,77,226,12,0,141,229,12,0,157,229,13,16,160,225
bl _System_Collections_Generic_Stack_1_GetEnumerator

	.byte 12,0,157,229,0,0,144,229
bl _p_28
bl _p_8

	.byte 8,16,128,226,0,32,157,229,0,32,129,229,4,32,157,229,4,32,129,229,8,32,157,229,8,32,129,229,20,208,141,226
	.byte 0,1,189,232,128,128,189,232

Lme_2a:
.text
ut_43:

	.byte 8,0,128,226
	b _System_Collections_Generic_Stack_1_Enumerator__ctor_System_Collections_Generic_Stack_1_T

.text
	.align 2
	.no_dead_strip _System_Collections_Generic_Stack_1_Enumerator__ctor_System_Collections_Generic_Stack_1_T
_System_Collections_Generic_Stack_1_Enumerator__ctor_System_Collections_Generic_Stack_1_T:

	.byte 128,64,45,233,13,112,160,225,64,1,45,233,8,208,77,226,0,128,141,229,0,96,160,225,4,16,141,229,4,0,157,229
	.byte 0,0,134,229,1,16,224,227,4,16,134,229,16,0,144,229,8,0,134,229,8,208,141,226,64,1,189,232,128,128,189,232

Lme_2b:
.text
ut_44:

	.byte 8,0,128,226
	b _System_Collections_Generic_Stack_1_Enumerator_Dispose

.text
	.align 2
	.no_dead_strip _System_Collections_Generic_Stack_1_Enumerator_Dispose
_System_Collections_Generic_Stack_1_Enumerator_Dispose:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,128,141,229,4,0,141,229,4,0,157,229,0,16,224,227
	.byte 4,16,128,229,12,208,141,226,0,1,189,232,128,128,189,232

Lme_2c:
.text
ut_45:

	.byte 8,0,128,226
	b _System_Collections_Generic_Stack_1_Enumerator_MoveNext

.text
	.align 2
	.no_dead_strip _System_Collections_Generic_Stack_1_Enumerator_MoveNext
_System_Collections_Generic_Stack_1_Enumerator_MoveNext:

	.byte 128,64,45,233,13,112,160,225,32,5,45,233,12,208,77,226,4,128,141,229,0,160,160,225,8,0,154,229,0,16,154,229
	.byte 16,16,145,229,1,0,80,225,28,0,0,26,4,0,154,229,1,16,224,227,1,0,80,225,2,0,0,26,0,0,154,229
	.byte 12,0,144,229,4,0,138,229,4,0,154,229,0,16,224,227,1,0,80,225,12,0,0,10,4,0,154,229,1,0,64,226
	.byte 0,16,160,225,0,0,141,229,4,16,138,229,0,16,224,227,1,0,80,225,0,0,160,19,1,0,160,3,0,0,80,227
	.byte 0,80,160,19,1,80,160,3,0,0,0,234,0,80,160,227,5,0,160,225,12,208,141,226,32,5,189,232,128,128,189,232
	.byte 0,2,0,227,0,2,64,227
bl _mono_create_corlib_exception_0
bl _p_3

Lme_2d:
.text
ut_46:

	.byte 8,0,128,226
	b _System_Collections_Generic_Stack_1_Enumerator_get_Current

.text
	.align 2
	.no_dead_strip _System_Collections_Generic_Stack_1_Enumerator_get_Current
_System_Collections_Generic_Stack_1_Enumerator_get_Current:

	.byte 128,64,45,233,13,112,160,225,0,5,45,233,8,208,77,226,0,128,141,229,0,160,160,225,4,0,154,229,0,0,80,227
	.byte 12,0,0,186,0,0,154,229,8,0,144,229,4,16,154,229,12,32,144,229,1,0,82,225,10,0,0,155,1,17,160,225
	.byte 1,0,128,224,16,0,128,226,0,0,144,229,8,208,141,226,0,5,189,232,128,128,189,232,0,2,0,227,0,2,64,227
bl _mono_create_corlib_exception_0
bl _p_3

	.byte 14,16,160,225,0,0,159,229
bl _p_22

	.byte 250,1,0,2

Lme_2e:
.text
ut_47:

	.byte 8,0,128,226
	b _System_Collections_Generic_Stack_1_Enumerator_System_Collections_IEnumerator_get_Current

.text
	.align 2
	.no_dead_strip _System_Collections_Generic_Stack_1_Enumerator_System_Collections_IEnumerator_get_Current
_System_Collections_Generic_Stack_1_Enumerator_System_Collections_IEnumerator_get_Current:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,128,141,229,4,0,141,229,0,0,157,229
bl _p_29

	.byte 0,128,160,225,4,0,157,229
bl _System_Collections_Generic_Stack_1_Enumerator_get_Current

	.byte 12,208,141,226,0,1,189,232,128,128,189,232

Lme_2f:
.text
	.align 2
	.no_dead_strip _System_Collections_Specialized_StringDictionary__ctor
_System_Collections_Specialized_StringDictionary__ctor:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,20,208,77,226,4,0,141,229,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 4
	.byte 0,0,159,231
bl _p_30

	.byte 8,0,141,229
bl _p_31

	.byte 8,16,157,229,4,0,157,229,8,16,128,229,20,208,141,226,0,1,189,232,128,128,189,232

Lme_30:
.text
	.align 2
	.no_dead_strip _System_Collections_Specialized_StringDictionary_GetEnumerator
_System_Collections_Specialized_StringDictionary_GetEnumerator:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,0,0,157,229,8,16,144,229,1,0,160,225
	.byte 0,16,145,229,15,224,160,225,56,240,145,229,12,208,141,226,0,1,189,232,128,128,189,232

Lme_31:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_CorrelationManager__ctor
_System_Diagnostics_CorrelationManager__ctor:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,20,208,77,226,0,0,141,229,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 8
	.byte 0,0,159,231
bl _p_30

	.byte 8,0,141,229
bl _p_32

	.byte 8,16,157,229,0,0,157,229,8,16,128,229,20,208,141,226,0,1,189,232,128,128,189,232

Lme_32:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_Debug_Assert_bool_string
_System_Diagnostics_Debug_Assert_bool_string:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,205,229,4,16,141,229,0,0,221,229,4,16,157,229
bl _System_Diagnostics_TraceImpl_Assert_bool_string

	.byte 12,208,141,226,0,1,189,232,128,128,189,232

Lme_33:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_DefaultTraceListener__cctor
_System_Diagnostics_DefaultTraceListener__cctor:

	.byte 128,64,45,233,13,112,160,225,96,5,45,233
bl _p_33

	.byte 0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 12
	.byte 0,0,159,231,176,0,208,225,92,0,80,227,0,16,160,19,1,16,160,3,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 16
	.byte 0,0,159,231,0,16,192,229,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 16
	.byte 0,0,159,231,0,0,208,229,0,0,80,227,75,0,0,26,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 20
	.byte 0,0,159,231
bl _p_34

	.byte 0,160,160,225,0,0,80,227,3,0,0,26,0,160,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 24
	.byte 10,160,159,231,0,0,90,227,61,0,0,10,0,96,160,227,0,80,160,227,0,16,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 24
	.byte 1,16,159,231,10,0,160,225,0,224,218,229
bl _p_35

	.byte 255,0,0,226,0,0,80,227,11,0,0,10,0,96,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 24
	.byte 6,96,159,231,0,16,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 24
	.byte 1,16,159,231,10,0,160,225
bl _p_36

	.byte 0,80,160,225,27,0,0,234,0,16,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 28
	.byte 1,16,159,231,10,0,160,225,0,224,218,229
bl _p_35

	.byte 255,0,0,226,0,0,80,227,11,0,0,10,0,96,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 28
	.byte 6,96,159,231,0,16,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 28
	.byte 1,16,159,231,10,0,160,225
bl _p_36

	.byte 0,80,160,225,5,0,0,234,10,96,160,225,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 32
	.byte 0,0,159,231,0,80,144,229,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 36
	.byte 0,0,159,231,0,96,128,229,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 40
	.byte 0,0,159,231,0,80,128,229,0,208,141,226,96,5,189,232,128,128,189,232

Lme_34:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_DefaultTraceListener__ctor
_System_Diagnostics_DefaultTraceListener__ctor:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,0,16,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 44
	.byte 1,16,159,231,0,0,157,229
bl _p_37

	.byte 12,208,141,226,0,1,189,232,128,128,189,232

Lme_35:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_DefaultTraceListener_GetPrefix_string_string
_System_Diagnostics_DefaultTraceListener_GetPrefix_string_string:

	.byte 128,64,45,233,13,112,160,225,64,1,45,233,8,208,77,226,0,96,160,225,0,16,141,229,8,0,150,229,0,16,157,229
	.byte 8,16,145,229,1,0,80,225,6,0,0,218,0,0,157,229,8,0,144,229,1,16,128,226,6,0,160,225,0,224,214,229
bl _p_38

	.byte 4,0,0,234,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 32
	.byte 0,0,159,231,0,0,144,229,8,208,141,226,64,1,189,232,128,128,189,232

Lme_36:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_DefaultTraceListener_get_AssertUiEnabled
_System_Diagnostics_DefaultTraceListener_get_AssertUiEnabled:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,0,0,157,229,36,0,208,229,12,208,141,226
	.byte 0,1,189,232,128,128,189,232

Lme_37:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_DefaultTraceListener_get_LogFileName
_System_Diagnostics_DefaultTraceListener_get_LogFileName:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,0,0,157,229,32,0,144,229,12,208,141,226
	.byte 0,1,189,232,128,128,189,232

Lme_38:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_DefaultTraceListener_Fail_string
_System_Diagnostics_DefaultTraceListener_Fail_string:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,4,16,141,229,0,0,157,229,4,16,157,229
bl _System_Diagnostics_TraceListener_Fail_string

	.byte 12,208,141,226,0,1,189,232,128,128,189,232

Lme_39:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_DefaultTraceListener_Fail_string_string
_System_Diagnostics_DefaultTraceListener_Fail_string_string:

	.byte 128,64,45,233,13,112,160,225,32,1,45,233,16,208,77,226,0,80,160,225,0,16,141,229,4,32,141,229,5,0,160,225
	.byte 0,16,157,229,4,32,157,229
bl _p_39

	.byte 5,0,160,225,0,16,157,229,4,32,157,229
bl _p_40

	.byte 3,0,80,227,3,0,0,26
bl _p_41

	.byte 0,16,160,225,0,224,209,229
bl _p_42

	.byte 0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 48
	.byte 0,0,159,231
bl _p_30

	.byte 8,0,141,229
bl _p_43

	.byte 8,16,157,229,1,0,160,225,0,16,145,229,15,224,160,225,32,240,145,229,0,16,160,225,5,0,160,225,0,32,149,229
	.byte 15,224,160,225,52,240,146,229,16,208,141,226,32,1,189,232,128,128,189,232

Lme_3a:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_DefaultTraceListener_ProcessUI_string_string
_System_Diagnostics_DefaultTraceListener_ProcessUI_string_string:

	.byte 128,64,45,233,13,112,160,225,112,13,45,233,96,208,77,226,13,176,160,225,36,0,139,229,40,16,139,229,44,32,139,229
	.byte 0,0,160,227,4,0,139,229,36,0,155,229
bl _p_44

	.byte 255,0,0,226,0,0,80,227,1,0,0,26,0,0,160,227,1,1,0,234,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 52
	.byte 0,0,159,231
bl _p_45

	.byte 0,160,160,225,0,16,160,227
bl _p_46

	.byte 255,0,0,226,0,0,80,227,2,0,0,10,0,0,160,227,4,0,139,229,242,0,0,234,0,16,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 56
	.byte 1,16,159,231,10,0,160,225,0,32,154,229,15,224,160,225,76,240,146,229,0,96,160,225,0,16,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 60
	.byte 1,16,159,231
bl _p_47

	.byte 0,0,139,229,0,16,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 64
	.byte 1,16,159,231,10,0,160,225,0,32,154,229,15,224,160,225,76,240,146,229,56,0,139,229,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 68
	.byte 0,0,159,231,48,0,139,229,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 72
	.byte 0,0,159,231,3,16,160,227
bl _p_48

	.byte 0,48,160,225,64,0,139,229,0,32,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 76
	.byte 2,32,159,231,3,0,160,225,0,16,160,227,0,48,147,229,15,224,160,225,68,240,147,229,64,48,155,229,3,0,160,225
	.byte 60,0,139,229,0,32,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 76
	.byte 2,32,159,231,3,0,160,225,1,16,160,227,0,48,147,229,15,224,160,225,68,240,147,229,60,48,155,229,3,0,160,225
	.byte 52,0,139,229,3,0,160,225,2,16,160,227,6,32,160,225,0,48,147,229,15,224,160,225,68,240,147,229,48,16,155,229
	.byte 52,32,155,229,56,48,155,229,3,0,160,225,0,224,211,229
bl _p_49

	.byte 0,64,160,225,9,0,0,234,16,0,155,229,0,0,160,227,4,0,139,229
bl _p_50

	.byte 32,0,139,229,0,0,80,227,1,0,0,10,32,0,155,229
bl _p_3

	.byte 157,0,0,234,4,0,160,225,0,16,160,227
bl _p_51

	.byte 255,0,0,226,0,0,80,227,2,0,0,26,0,0,155,229,0,0,80,227,1,0,0,26,0,0,160,227,147,0,0,234
	.byte 0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 80
	.byte 0,0,159,231,0,16,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 84
	.byte 1,16,159,231,0,32,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 88
	.byte 2,32,159,231,0,48,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 92
	.byte 3,48,159,231
bl _p_52

	.byte 8,0,139,229,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 96
	.byte 0,0,159,231,60,0,139,229,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 100
	.byte 0,0,159,231,4,16,160,227
bl _p_48

	.byte 0,48,160,225,88,0,139,229,3,0,160,225,0,16,160,227,40,32,155,229,0,48,147,229,15,224,160,225,68,240,147,229
	.byte 88,0,155,229,84,0,139,229,80,0,139,229
bl _p_53

	.byte 0,32,160,225,84,48,155,229,3,0,160,225,1,16,160,227,0,48,147,229,15,224,160,225,68,240,147,229,80,48,155,229
	.byte 3,0,160,225,76,0,139,229,3,0,160,225,2,16,160,227,44,32,155,229,0,48,147,229,15,224,160,225,68,240,147,229
	.byte 76,0,155,229,72,0,139,229,64,0,139,229,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 48
	.byte 0,0,159,231
bl _p_30

	.byte 68,0,139,229
bl _p_43

	.byte 68,32,155,229,72,48,155,229,3,0,160,225,3,16,160,227,0,48,147,229,15,224,160,225,68,240,147,229,60,0,155,229
	.byte 64,16,155,229
bl _p_54

	.byte 12,0,139,229,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 100
	.byte 0,0,159,231,3,16,160,227
bl _p_48

	.byte 0,48,160,225,56,0,139,229,3,0,160,225,0,16,160,227,12,32,155,229,0,48,147,229,15,224,160,225,68,240,147,229
	.byte 56,48,155,229,3,0,160,225,52,0,139,229,3,0,160,225,1,16,160,227,8,32,155,229,0,48,147,229,15,224,160,225
	.byte 68,240,147,229,52,48,155,229,3,0,160,225,48,0,139,229,3,0,160,225,2,16,160,227,0,32,155,229,0,48,147,229
	.byte 15,224,160,225,68,240,147,229,48,32,155,229,4,0,160,225,0,16,160,227,0,224,212,229
bl _p_55

	.byte 0,16,160,225,0,16,145,229,15,224,160,225,32,240,145,229,0,80,160,225,0,0,80,227,22,0,0,10,0,16,159,229
	.byte 0,0,0,234
	.long _mono_aot_System_got - . + 92
	.byte 1,16,159,231,5,0,160,225
bl _p_56

	.byte 255,0,0,226,0,0,80,227,9,0,0,26,0,16,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 84
	.byte 1,16,159,231,5,0,160,225
bl _p_56

	.byte 255,0,0,226,0,0,80,227,2,0,0,26,3,0,0,234,2,0,160,227,4,0,0,234,3,0,160,227,2,0,0,234
	.byte 1,0,160,227,0,0,0,234,4,0,155,229,96,208,139,226,112,13,189,232,128,128,189,232

Lme_3b:
.text
	.align 2
	.no_dead_strip _wrapper_managed_to_native_System_Diagnostics_DefaultTraceListener_WriteWindowsDebugString_string
_wrapper_managed_to_native_System_Diagnostics_DefaultTraceListener_WriteWindowsDebugString_string:

	.byte 128,64,45,233,13,112,160,225,13,192,160,225,240,95,45,233,176,208,77,226,0,0,141,229,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - .
	.byte 0,0,159,231
bl _pthread_getspecific

	.byte 8,0,128,226,8,16,141,226,4,0,129,229,0,192,144,229,0,192,129,229,0,16,128,229,12,208,129,229,20,176,129,229
	.byte 15,192,160,225,16,192,129,229,0,0,157,229
bl _ves_icall_System_Diagnostics_DefaultTraceListener_WriteWindowsDebugString

	.byte 0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 104
	.byte 0,0,159,231,0,0,144,229,0,0,80,227,6,0,0,26,8,192,157,229,12,224,157,229,0,192,142,229,192,208,141,226
	.byte 0,31,189,232,4,208,141,226,128,128,189,232
bl _p_57

	.byte 246,255,255,234

Lme_3c:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_DefaultTraceListener_WriteDebugString_string
_System_Diagnostics_DefaultTraceListener_WriteDebugString_string:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,4,16,141,229,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 16
	.byte 0,0,159,231,0,0,208,229,0,0,80,227,2,0,0,10,4,0,157,229
bl _p_58

	.byte 2,0,0,234,0,0,157,229,4,16,157,229
bl _p_59

	.byte 12,208,141,226,0,1,189,232,128,128,189,232

Lme_3d:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_DefaultTraceListener_WriteMonoTrace_string
_System_Diagnostics_DefaultTraceListener_WriteMonoTrace_string:

	.byte 128,64,45,233,13,112,160,225,32,5,45,233,12,208,77,226,0,0,141,229,1,160,160,225,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 36
	.byte 0,0,159,231,0,80,144,229,5,0,160,225,0,0,80,227,32,0,0,10,0,16,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 24
	.byte 1,16,159,231,5,0,160,225
bl _p_56

	.byte 255,0,0,226,0,0,80,227,9,0,0,26,0,16,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 28
	.byte 1,16,159,231,5,0,160,225
bl _p_56

	.byte 255,0,0,226,0,0,80,227,7,0,0,26,13,0,0,234
bl _p_60

	.byte 0,32,160,225,10,16,160,225,0,32,146,229,15,224,160,225,100,240,146,229,14,0,0,234
bl _p_61

	.byte 0,32,160,225,10,16,160,225,0,32,146,229,15,224,160,225,100,240,146,229,7,0,0,234,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 36
	.byte 0,0,159,231,0,32,144,229,0,0,157,229,10,16,160,225
bl _p_62

	.byte 12,208,141,226,32,5,189,232,128,128,189,232

Lme_3e:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_DefaultTraceListener_WritePrefix
_System_Diagnostics_DefaultTraceListener_WritePrefix:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 16
	.byte 0,0,159,231,0,0,208,229,0,0,80,227,6,0,0,26,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 40
	.byte 0,0,159,231,0,16,144,229,0,0,157,229
bl _p_59

	.byte 12,208,141,226,0,1,189,232,128,128,189,232

Lme_3f:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_DefaultTraceListener_WriteImpl_string
_System_Diagnostics_DefaultTraceListener_WriteImpl_string:

	.byte 128,64,45,233,13,112,160,225,64,5,45,233,4,208,77,226,0,96,160,225,1,160,160,225,28,0,214,229,0,0,80,227
	.byte 5,0,0,10,6,0,160,225,0,16,150,229,15,224,160,225,56,240,145,229,6,0,160,225
bl _p_63

	.byte 6,0,160,225,10,16,160,225
bl _p_64
bl _p_65

	.byte 255,0,0,226,0,0,80,227,3,0,0,10,0,0,160,227,0,16,160,227,10,32,160,225
bl _p_66

	.byte 6,0,160,225
bl _p_67

	.byte 0,32,160,225,6,0,160,225,10,16,160,225
bl _p_62

	.byte 4,208,141,226,64,5,189,232,128,128,189,232

Lme_40:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_DefaultTraceListener_WriteLogFile_string_string
_System_Diagnostics_DefaultTraceListener_WriteLogFile_string_string:

	.byte 128,64,45,233,13,112,160,225,112,9,45,233,60,208,77,226,13,176,160,225,32,0,139,229,36,16,139,229,40,32,139,229
	.byte 0,0,160,227,0,0,139,229,40,96,155,229,6,0,160,225,0,0,80,227,66,0,0,10,8,0,150,229,0,0,80,227
	.byte 63,0,0,10,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 108
	.byte 0,0,159,231
bl _p_30

	.byte 48,0,139,229,6,16,160,225
bl _p_68

	.byte 48,0,155,229,0,80,160,225,0,64,160,227,5,0,160,225,0,16,149,229,15,224,160,225,56,240,145,229,255,0,0,226
	.byte 0,0,80,227,4,0,0,10,5,0,160,225,0,224,213,229
bl _p_69

	.byte 0,64,160,225,3,0,0,234,5,0,160,225,0,224,213,229
bl _p_70

	.byte 0,64,160,225,7,0,0,234,4,0,155,229
bl _p_50

	.byte 28,0,139,229,0,0,80,227,1,0,0,10,28,0,155,229
bl _p_3

	.byte 27,0,0,234,0,64,139,229,4,0,160,225,36,16,155,229,0,32,148,229,15,224,160,225,100,240,146,229,4,0,160,225
	.byte 0,16,148,229,15,224,160,225,116,240,145,229,0,0,0,235,15,0,0,234,24,224,139,229,0,0,155,229,0,0,80,227
	.byte 9,0,0,10,0,16,155,229,1,0,160,225,0,16,145,229,0,128,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 112
	.byte 8,128,159,231,4,224,143,226,20,240,17,229,0,0,0,0,24,192,155,229,12,240,160,225,60,208,139,226,112,9,189,232
	.byte 128,128,189,232

Lme_41:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_DefaultTraceListener_Write_string
_System_Diagnostics_DefaultTraceListener_Write_string:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,4,16,141,229,0,0,157,229,4,16,157,229
bl _p_71

	.byte 12,208,141,226,0,1,189,232,128,128,189,232

Lme_42:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_DefaultTraceListener_WriteLine_string
_System_Diagnostics_DefaultTraceListener_WriteLine_string:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,4,16,141,229
bl _p_53

	.byte 0,16,160,225,4,0,157,229
bl _p_72

	.byte 0,16,160,225,0,0,157,229
bl _p_71

	.byte 0,0,157,229,1,16,160,227,28,16,192,229,12,208,141,226,0,1,189,232,128,128,189,232

Lme_43:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_TraceImpl_get_IndentLevel
_System_Diagnostics_TraceImpl_get_IndentLevel:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,4,208,77,226
bl _mono_domain_get

	.byte 0,16,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 116
	.byte 1,16,159,231
bl _p_73

	.byte 0,0,144,229,4,208,141,226,0,1,189,232,128,128,189,232

Lme_44:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_TraceImpl_get_IndentSize
_System_Diagnostics_TraceImpl_get_IndentSize:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,4,208,77,226
bl _mono_domain_get

	.byte 0,16,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 120
	.byte 1,16,159,231
bl _p_73

	.byte 0,0,144,229,4,208,141,226,0,1,189,232,128,128,189,232

Lme_45:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_TraceImpl_get_Listeners
_System_Diagnostics_TraceImpl_get_Listeners:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,4,208,77,226,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 124
	.byte 0,0,159,231,0,0,144,229,4,208,141,226,0,1,189,232,128,128,189,232

Lme_46:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_TraceImpl_get_ListenersSyncRoot
_System_Diagnostics_TraceImpl_get_ListenersSyncRoot:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,4,208,77,226
bl _p_74

	.byte 0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 124
	.byte 0,0,159,231,0,16,144,229,1,0,160,225,0,16,145,229,0,128,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 128
	.byte 8,128,159,231,4,224,143,226,20,240,17,229,0,0,0,0,4,208,141,226,0,1,189,232,128,128,189,232

Lme_47:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_TraceImpl_InitOnce
_System_Diagnostics_TraceImpl_InitOnce:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,4,208,77,226,4,208,141,226,0,1,189,232,128,128,189,232

Lme_48:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_TraceImpl_Assert_bool_string
_System_Diagnostics_TraceImpl_Assert_bool_string:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,205,229,4,16,141,229,0,0,221,229,0,0,80,227
	.byte 1,0,0,26,4,0,157,229
bl _p_75

	.byte 12,208,141,226,0,1,189,232,128,128,189,232

Lme_49:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_TraceImpl_Fail_string
_System_Diagnostics_TraceImpl_Fail_string:

	.byte 128,64,45,233,13,112,160,225,96,13,45,233,68,208,77,226,13,176,160,225,0,160,160,225,0,0,160,227,0,0,139,229
	.byte 0,0,160,227,4,0,203,229,0,0,160,227,8,0,139,229,0,0,160,227,12,0,139,229
bl _p_76

	.byte 0,0,139,229,0,0,160,227,4,0,203,229,0,0,155,229,4,16,139,226
bl _p_77
bl _p_74

	.byte 0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 124
	.byte 0,0,159,231,0,16,144,229,1,0,160,225,0,224,209,229
bl _System_Diagnostics_TraceListenerCollection_GetEnumerator

	.byte 8,0,139,229,28,0,0,234,8,16,155,229,1,0,160,225,0,16,145,229,0,128,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 132
	.byte 8,128,159,231,4,224,143,226,16,240,17,229,0,0,0,0,0,80,160,225,0,0,85,227,9,0,0,10,0,0,149,229
	.byte 0,0,144,229,8,0,144,229,8,0,144,229,0,16,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 136
	.byte 1,16,159,231,1,0,80,225,97,0,0,27,5,96,160,225,5,0,160,225,10,16,160,225,0,32,149,229,15,224,160,225
	.byte 68,240,146,229,8,16,155,229,1,0,160,225,0,16,145,229,0,128,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 140
	.byte 8,128,159,231,4,224,143,226,60,240,17,229,0,0,0,0,255,0,0,226,0,0,80,227,213,255,255,26,0,0,0,235
	.byte 63,0,0,234,44,224,139,229,8,0,155,229,20,0,139,229,20,0,155,229,52,0,139,229,0,0,80,227,24,0,0,10
	.byte 52,0,155,229,0,0,144,229,56,0,139,229,180,1,208,225,0,16,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 144
	.byte 1,16,159,231,1,0,80,225,14,0,0,58,56,0,155,229,16,0,144,229,0,16,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 144
	.byte 1,16,159,231,193,33,160,225,2,0,128,224,0,0,208,229,7,32,1,226,1,16,160,227,17,18,160,225,1,0,0,224
	.byte 0,0,80,227,2,0,0,26,1,0,160,227,60,0,139,229,1,0,0,234,0,0,160,227,60,0,139,229,60,0,155,229
	.byte 0,0,80,227,2,0,0,10,0,0,160,227,24,0,139,229,1,0,0,234,20,0,155,229,24,0,139,229,24,0,155,229
	.byte 16,0,139,229,28,0,139,229,0,16,160,225,12,16,139,229,0,0,80,227,9,0,0,10,12,16,155,229,1,0,160,225
	.byte 0,16,145,229,0,128,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 112
	.byte 8,128,159,231,4,224,143,226,20,240,17,229,0,0,0,0,44,192,155,229,12,240,160,225,0,0,0,235,7,0,0,234
	.byte 48,224,139,229,4,0,219,229,0,0,80,227,1,0,0,10,0,0,155,229
bl _p_78

	.byte 48,192,155,229,12,240,160,225,68,208,139,226,96,13,189,232,128,128,189,232,14,16,160,225,0,0,159,229
bl _p_22

	.byte 255,1,0,2

Lme_4a:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_TraceImpl__cctor
_System_Diagnostics_TraceImpl__cctor:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 148
	.byte 0,0,159,231
bl _p_30

	.byte 4,0,141,229,1,16,160,227
bl _p_79

	.byte 4,16,157,229,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 124
	.byte 0,0,159,231,0,16,128,229,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 152
	.byte 0,0,159,231
bl _p_30

	.byte 0,0,141,229
bl _p_80

	.byte 0,16,157,229,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 156
	.byte 0,0,159,231,0,16,128,229,12,208,141,226,0,1,189,232,128,128,189,232

Lme_4b:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_TraceListener__ctor_string
_System_Diagnostics_TraceListener__ctor_string:

	.byte 128,64,45,233,13,112,160,225,64,1,45,233,16,208,77,226,0,96,160,225,4,16,141,229,4,0,160,227,24,0,134,229
	.byte 0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 160
	.byte 0,0,159,231
bl _p_30

	.byte 8,0,141,229
bl _p_81

	.byte 8,0,157,229,12,0,134,229,1,0,160,227,28,0,198,229,6,0,160,225,4,16,157,229,0,32,150,229,15,224,160,225
	.byte 76,240,146,229,16,208,141,226,64,1,189,232,128,128,189,232

Lme_4c:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_TraceListener_get_IndentLevel
_System_Diagnostics_TraceListener_get_IndentLevel:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,0,0,157,229,20,0,144,229,12,208,141,226
	.byte 0,1,189,232,128,128,189,232

Lme_4d:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_TraceListener_set_IndentLevel_int
_System_Diagnostics_TraceListener_set_IndentLevel_int:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,4,16,141,229,4,16,157,229,0,0,157,229
	.byte 20,16,128,229,12,208,141,226,0,1,189,232,128,128,189,232

Lme_4e:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_TraceListener_get_IndentSize
_System_Diagnostics_TraceListener_get_IndentSize:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,0,0,157,229,24,0,144,229,12,208,141,226
	.byte 0,1,189,232,128,128,189,232

Lme_4f:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_TraceListener_set_IndentSize_int
_System_Diagnostics_TraceListener_set_IndentSize_int:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,4,16,141,229,4,16,157,229,0,0,157,229
	.byte 24,16,128,229,12,208,141,226,0,1,189,232,128,128,189,232

Lme_50:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_TraceListener_set_Name_string
_System_Diagnostics_TraceListener_set_Name_string:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,4,16,141,229,4,16,157,229,0,0,157,229
	.byte 16,16,128,229,12,208,141,226,0,1,189,232,128,128,189,232

Lme_51:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_TraceListener_get_NeedIndent
_System_Diagnostics_TraceListener_get_NeedIndent:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,0,0,157,229,28,0,208,229,12,208,141,226
	.byte 0,1,189,232,128,128,189,232

Lme_52:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_TraceListener_set_NeedIndent_bool
_System_Diagnostics_TraceListener_set_NeedIndent_bool:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,4,16,205,229,4,16,221,229,0,0,157,229
	.byte 28,16,192,229,12,208,141,226,0,1,189,232,128,128,189,232

Lme_53:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_TraceListener_Dispose
_System_Diagnostics_TraceListener_Dispose:

	.byte 128,64,45,233,13,112,160,225,0,5,45,233,0,160,160,225,10,0,160,225,1,16,160,227,0,32,154,229,15,224,160,225
	.byte 72,240,146,229,10,0,160,225
bl _p_82

	.byte 0,208,141,226,0,5,189,232,128,128,189,232

Lme_54:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_TraceListener_Dispose_bool
_System_Diagnostics_TraceListener_Dispose_bool:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,4,16,205,229,12,208,141,226,0,1,189,232
	.byte 128,128,189,232

Lme_55:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_TraceListener_Fail_string
_System_Diagnostics_TraceListener_Fail_string:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,4,16,141,229,0,0,157,229,4,16,157,229
	.byte 0,32,160,227,0,48,157,229,0,48,147,229,15,224,160,225,64,240,147,229,12,208,141,226,0,1,189,232,128,128,189,232

Lme_56:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_TraceListener_Fail_string_string
_System_Diagnostics_TraceListener_Fail_string_string:

	.byte 128,64,45,233,13,112,160,225,32,1,45,233,8,208,77,226,0,80,160,225,0,16,141,229,4,32,141,229,0,16,159,229
	.byte 0,0,0,234
	.long _mono_aot_System_got - . + 164
	.byte 1,16,159,231,5,0,160,225,0,32,149,229,15,224,160,225,52,240,146,229,0,16,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 168
	.byte 1,16,159,231,5,0,160,225,0,32,149,229,15,224,160,225,52,240,146,229,5,0,160,225,0,16,157,229,0,32,149,229
	.byte 15,224,160,225,52,240,146,229,4,0,157,229,0,0,80,227,12,0,0,10,0,16,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 172
	.byte 1,16,159,231,5,0,160,225,0,32,149,229,15,224,160,225,52,240,146,229,5,0,160,225,4,16,157,229,0,32,149,229
	.byte 15,224,160,225,52,240,146,229,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 32
	.byte 0,0,159,231,0,16,144,229,5,0,160,225,0,32,149,229,15,224,160,225,52,240,146,229,8,208,141,226,32,1,189,232
	.byte 128,128,189,232

Lme_57:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_TraceListener_WriteIndent
_System_Diagnostics_TraceListener_WriteIndent:

	.byte 128,64,45,233,13,112,160,225,0,5,45,233,0,160,160,225,0,0,160,227,28,0,202,229,20,0,154,229,24,16,154,229
	.byte 145,0,2,224,0,0,160,227,32,16,160,227
bl _p_83

	.byte 0,16,160,225,10,0,160,225,0,32,154,229,15,224,160,225,60,240,146,229,0,208,141,226,0,5,189,232,128,128,189,232

Lme_59:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_TraceListenerCollection__ctor_bool
_System_Diagnostics_TraceListenerCollection__ctor_bool:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,20,208,77,226,0,0,141,229,4,16,205,229,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 176
	.byte 0,0,159,231
bl _p_30

	.byte 8,0,141,229,1,16,160,227
bl _p_84

	.byte 8,0,157,229
bl _p_85

	.byte 0,16,160,225,0,0,157,229,8,16,128,229,4,0,221,229,0,0,80,227,10,0,0,10
bl _p_86

	.byte 0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 180
	.byte 0,0,159,231
bl _p_30

	.byte 8,0,141,229
bl _p_87

	.byte 8,16,157,229,0,0,157,229
bl _System_Diagnostics_TraceListenerCollection_Add_System_Diagnostics_TraceListener

	.byte 20,208,141,226,0,1,189,232,128,128,189,232

Lme_5b:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_TraceListenerCollection_System_Collections_ICollection_get_SyncRoot
_System_Diagnostics_TraceListenerCollection_System_Collections_ICollection_get_SyncRoot:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,0,0,157,229,8,16,144,229,1,0,160,225
	.byte 0,16,145,229,15,224,160,225,76,240,145,229,12,208,141,226,0,1,189,232,128,128,189,232

Lme_5c:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_TraceListenerCollection_Add_System_Diagnostics_TraceListener
_System_Diagnostics_TraceListenerCollection_Add_System_Diagnostics_TraceListener:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,4,16,141,229,0,0,157,229,4,16,157,229
bl _p_88

	.byte 0,0,157,229,8,32,144,229,2,0,160,225,4,16,157,229,0,32,146,229,15,224,160,225,72,240,146,229,12,208,141,226
	.byte 0,1,189,232,128,128,189,232

Lme_5d:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_TraceListenerCollection_InitializeListener_System_Diagnostics_TraceListener
_System_Diagnostics_TraceListenerCollection_InitializeListener_System_Diagnostics_TraceListener:

	.byte 128,64,45,233,13,112,160,225,0,5,45,233,16,208,77,226,0,0,141,229,1,160,160,225
bl _mono_domain_get

	.byte 0,16,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 116
	.byte 1,16,159,231,8,0,141,229
bl _p_73

	.byte 0,16,160,225,8,0,157,229,0,16,145,229,0,224,218,229,20,16,138,229,0,16,159,229,0,0,0,234
	.long _mono_aot_System_got - . + 120
	.byte 1,16,159,231
bl _p_73

	.byte 0,0,144,229,0,224,218,229,24,0,138,229,16,208,141,226,0,5,189,232,128,128,189,232

Lme_5e:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_TraceListenerCollection_GetEnumerator
_System_Diagnostics_TraceListenerCollection_GetEnumerator:

	.byte 128,64,45,233,13,112,160,225,0,1,45,233,12,208,77,226,0,0,141,229,0,0,157,229,8,16,144,229,1,0,160,225
	.byte 0,16,145,229,15,224,160,225,60,240,145,229,12,208,141,226,0,1,189,232,128,128,189,232

Lme_5f:
.text
	.align 2
	.no_dead_strip _System_Diagnostics_TraceListenerCollection_System_Collections_IList_Contains_object
_System_Diagnostics_TraceListenerCollection_System_Collections_IList_Contains_object:

	.byte 128,64,45,233,13,112,160,225,16,5,45,233,12,208,77,226,4,0,141,229,1,160,160,225,0,160,141,229,10,64,160,225
	.byte 0,0,90,227,11,0,0,10,0,0,157,229,0,0,144,229,0,0,144,229,8,0,144,229,8,0,144,229,0,16,159,229
	.byte 0,0,0,234
	.long _mono_aot_System_got - . + 136
	.byte 1,16,159,231,1,0,80,225,0,0,0,10,0,64,160,227,0,0,84,227,8,0,0,10,4,0,157,229,8,32,144,229
	.byte 2,0,160,225,10,16,160,225,0,32,146,229,15,224,160,225,68,240,146,229,255,0,0,226,0,0,0,234,0,0,160,227
	.byte 12,208,141,226,16,5,189,232,128,128,189,232

Lme_60:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1__0__ctor
_System_Collections_Generic_LinkedList_1__0__ctor:

	.byte 128,64,45,233,13,112,160,225,0,9,45,233,16,208,77,226,13,176,160,225,8,0,139,229,8,0,155,229,0,0,144,229
bl _p_89

	.byte 0,0,139,229,0,0,144,229,0,0,160,227,4,0,139,229,16,208,139,226,0,9,189,232,128,128,189,232

Lme_62:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1__0_VerifyReferencedNode_System_Collections_Generic_LinkedListNode_1__0
_System_Collections_Generic_LinkedList_1__0_VerifyReferencedNode_System_Collections_Generic_LinkedListNode_1__0:

	.byte 128,64,45,233,13,112,160,225,0,9,45,233,16,208,77,226,13,176,160,225,8,0,139,229,12,16,139,229,8,0,155,229
	.byte 0,0,144,229
bl _p_90

	.byte 0,0,139,229,0,0,144,229,0,0,160,227,4,0,139,229,12,0,155,229,0,0,80,227,11,0,0,10,8,0,155,229
	.byte 0,0,144,229
bl _p_91

	.byte 0,16,160,225,12,0,155,229,49,255,47,225,8,16,155,229,1,0,80,225,13,0,0,26,16,208,139,226,0,9,189,232
	.byte 128,128,189,232,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . -12
	.byte 0,0,159,231,1,16,160,227
bl _p_2

	.byte 0,16,160,225,169,1,0,227,0,2,64,227
bl _mono_create_corlib_exception_1
bl _p_3

	.byte 0,2,0,227,0,2,64,227
bl _mono_create_corlib_exception_0
bl _p_3

Lme_63:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1__0_VerifyBlankNode_System_Collections_Generic_LinkedListNode_1__0
_System_Collections_Generic_LinkedList_1__0_VerifyBlankNode_System_Collections_Generic_LinkedListNode_1__0:

	.byte 128,64,45,233,13,112,160,225,0,9,45,233,16,208,77,226,13,176,160,225,4,128,139,229,12,0,139,229,4,0,155,229
bl _p_92

	.byte 0,0,139,229,0,0,144,229,0,0,160,227,8,0,139,229,12,0,155,229,0,0,80,227,9,0,0,10,4,0,155,229
bl _p_93

	.byte 0,16,160,225,12,0,155,229,49,255,47,225,0,0,80,227,13,0,0,26,16,208,139,226,0,9,189,232,128,128,189,232
	.byte 0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . -12
	.byte 0,0,159,231,11,16,160,227
bl _p_2

	.byte 0,16,160,225,169,1,0,227,0,2,64,227
bl _mono_create_corlib_exception_1
bl _p_3

	.byte 0,2,0,227,0,2,64,227
bl _mono_create_corlib_exception_0
bl _p_3

Lme_64:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1__0_AddFirst_System_Collections_Generic_LinkedListNode_1__0
_System_Collections_Generic_LinkedList_1__0_AddFirst_System_Collections_Generic_LinkedListNode_1__0:

	.byte 128,64,45,233,13,112,160,225,64,13,45,233,24,208,77,226,13,176,160,225,4,0,139,229,1,160,160,225,4,0,155,229
	.byte 0,0,144,229
bl _p_94

	.byte 0,96,160,225,0,0,150,229,0,0,160,227,0,0,139,229,4,0,155,229,0,0,144,229
bl _p_95

	.byte 8,0,139,229,4,0,155,229,0,0,144,229
bl _p_96

	.byte 0,16,160,225,8,0,155,229,0,128,160,225,10,0,160,225,49,255,47,225,4,0,155,229,4,16,150,229,1,0,128,224
	.byte 0,0,144,229,0,0,80,227,9,0,0,26,4,0,155,229,8,0,139,229,4,0,155,229,0,0,144,229
bl _p_97

	.byte 0,32,160,225,8,16,155,229,10,0,160,225,50,255,47,225,23,0,0,234,4,0,155,229,4,16,150,229,1,0,128,224
	.byte 0,0,144,229,8,16,150,229,1,0,128,224,0,0,144,229,8,0,139,229,4,0,155,229,4,16,150,229,1,0,128,224
	.byte 0,0,144,229,12,0,139,229,4,0,155,229,16,0,139,229,4,0,155,229,0,0,144,229
bl _p_98

	.byte 0,192,160,225,8,16,155,229,12,32,155,229,16,48,155,229,10,0,160,225,60,255,47,225,4,16,155,229,1,0,160,225
	.byte 12,32,150,229,2,16,129,224,0,16,145,229,1,16,129,226,12,32,150,229,2,0,128,224,0,16,128,229,4,16,155,229
	.byte 1,0,160,225,16,32,150,229,2,16,129,224,0,16,145,229,1,16,129,226,16,32,150,229,2,0,128,224,0,16,128,229
	.byte 4,0,155,229,4,16,150,229,1,0,128,224,0,160,128,229,24,208,139,226,64,13,189,232,128,128,189,232

Lme_65:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1__0_AddLast__0
_System_Collections_Generic_LinkedList_1__0_AddLast__0:

	.byte 128,64,45,233,13,112,160,225,96,13,45,233,44,208,77,226,13,176,160,225,8,0,139,229,12,16,139,229,8,0,155,229
	.byte 0,0,144,229
bl _p_99

	.byte 0,160,160,225,0,0,154,229,0,96,160,227,8,0,155,229,4,16,154,229,1,0,128,224,0,0,144,229,0,0,80,227
	.byte 22,0,0,26,8,0,155,229,24,0,139,229,8,0,155,229,0,0,144,229
bl _p_100
bl _p_8

	.byte 20,0,139,229,8,0,155,229,0,0,144,229
bl _p_101

	.byte 0,48,160,225,20,0,155,229,24,16,155,229,16,0,139,229,12,32,155,229,51,255,47,225,16,0,155,229,0,80,160,225
	.byte 8,0,155,229,4,16,154,229,1,0,128,224,0,80,128,229,35,0,0,234,8,0,155,229,28,0,139,229,8,0,155,229
	.byte 4,16,154,229,1,0,128,224,0,0,144,229,8,16,154,229,1,0,128,224,0,0,144,229,36,0,139,229,8,0,155,229
	.byte 4,16,154,229,1,0,128,224,0,0,144,229,24,0,139,229,8,0,155,229,0,0,144,229
bl _p_100
bl _p_8

	.byte 32,0,139,229,8,0,155,229,0,0,144,229
bl _p_102

	.byte 0,192,160,225,24,0,155,229,28,16,155,229,32,32,155,229,36,48,155,229,16,32,139,229,20,32,139,229,12,32,155,229
	.byte 0,0,141,229,20,0,155,229,60,255,47,225,16,0,155,229,0,80,160,225,8,16,155,229,1,0,160,225,12,32,154,229
	.byte 2,16,129,224,0,16,145,229,1,16,129,226,12,32,154,229,2,0,128,224,0,16,128,229,8,16,155,229,1,0,160,225
	.byte 16,32,154,229,2,16,129,224,0,16,145,229,1,16,129,226,16,32,154,229,2,0,128,224,0,16,128,229,5,0,160,225
	.byte 44,208,139,226,96,13,189,232,128,128,189,232

Lme_66:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1__0_Clear
_System_Collections_Generic_LinkedList_1__0_Clear:

	.byte 128,64,45,233,13,112,160,225,0,13,45,233,20,208,77,226,13,176,160,225,4,0,139,229,4,0,155,229,0,0,144,229
bl _p_103

	.byte 0,160,160,225,0,0,154,229,0,0,160,227,0,0,139,229,13,0,0,234,4,0,155,229,8,0,139,229,4,0,155,229
	.byte 4,16,154,229,1,0,128,224,0,0,144,229,12,0,139,229,4,0,155,229,0,0,144,229
bl _p_104

	.byte 0,32,160,225,8,0,155,229,12,16,155,229,50,255,47,225,4,0,155,229,4,16,154,229,1,0,128,224,0,0,144,229
	.byte 0,0,80,227,235,255,255,26,20,208,139,226,0,13,189,232,128,128,189,232

Lme_67:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1__0_Contains__0
_System_Collections_Generic_LinkedList_1__0_Contains__0:

	.byte 128,64,45,233,13,112,160,225,0,13,45,233,28,208,77,226,13,176,160,225,4,0,139,229,8,16,139,229,4,0,155,229
	.byte 0,0,144,229
bl _p_105

	.byte 0,160,160,225,0,0,154,229,0,0,160,227,0,0,139,229,4,0,155,229,16,0,139,229,4,0,155,229,0,0,144,229
bl _p_106

	.byte 0,32,160,225,16,0,155,229,0,16,155,229,8,16,155,229,50,255,47,225,0,0,80,227,0,0,160,19,1,0,160,3
	.byte 0,0,80,227,0,0,160,19,1,0,160,3,28,208,139,226,0,13,189,232,128,128,189,232

Lme_68:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1__0_CopyTo__0___int
_System_Collections_Generic_LinkedList_1__0_CopyTo__0___int:

	.byte 128,64,45,233,13,112,160,225,112,13,45,233,56,208,77,226,13,176,160,225,44,0,139,229,1,96,160,225,2,160,160,225
	.byte 44,0,155,229,0,0,144,229
bl _p_107

	.byte 0,80,160,225,0,0,149,229,7,64,128,226,7,64,196,227,4,208,77,224,0,64,141,226,0,0,86,227,145,0,0,10
	.byte 12,160,139,229,8,0,150,229,4,0,139,229,0,0,80,227,3,0,0,10,4,0,155,229,4,0,144,229,8,0,139,229
	.byte 1,0,0,234,0,0,160,227,8,0,139,229,12,0,155,229,8,16,155,229,1,0,80,225,89,0,0,58,0,0,150,229
	.byte 22,0,208,229,1,0,80,227,96,0,0,26,12,0,150,229,10,0,64,224,24,0,139,229,8,0,150,229,16,0,139,229
	.byte 0,0,80,227,3,0,0,10,16,0,155,229,4,0,144,229,20,0,139,229,1,0,0,234,0,0,160,227,20,0,139,229
	.byte 24,0,155,229,20,16,155,229,1,0,128,224,36,0,139,229,0,16,224,227,1,0,80,225,0,0,160,227,1,0,160,195
	.byte 1,0,64,226,28,0,139,229,44,16,155,229,4,32,149,229,2,16,129,224,0,16,145,229,40,16,139,229,0,16,160,227
	.byte 32,16,139,229,0,0,80,227,7,0,0,202,28,0,155,229,32,16,155,229,1,0,80,225,79,0,0,26,36,0,155,229
	.byte 40,16,155,229,1,0,80,225,75,0,0,58,44,0,155,229,8,16,149,229,1,0,128,224,0,0,144,229,0,0,139,229
	.byte 44,0,155,229,8,16,149,229,1,0,128,224,0,0,144,229,0,0,80,227,31,0,0,10,44,0,155,229,0,0,144,229
bl _p_108

	.byte 0,32,160,225,28,0,149,229,0,16,132,224,0,0,155,229,50,255,47,225,12,0,150,229,10,0,80,225,75,0,0,155
	.byte 12,0,149,229,154,0,0,224,0,0,134,224,16,0,128,226,28,16,149,229,1,16,132,224,20,32,149,229,24,48,149,229
	.byte 51,255,47,225,1,160,138,226,16,16,149,229,0,0,155,229,1,0,128,224,0,0,144,229,0,0,139,229,44,16,155,229
	.byte 8,32,149,229,2,16,129,224,0,16,145,229,1,0,80,225,223,255,255,26,56,208,139,226,112,13,189,232,128,128,189,232
	.byte 0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . -12
	.byte 0,0,159,231,39,16,160,227
bl _p_2

	.byte 0,16,160,225,170,1,0,227,0,2,64,227
bl _mono_create_corlib_exception_1
bl _p_3

	.byte 0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . -12
	.byte 0,0,159,231,27,16,160,227
bl _p_2

	.byte 48,0,139,229,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . -12
	.byte 0,0,159,231,51,16,160,227
bl _p_2

	.byte 0,32,160,225,48,16,155,229,168,1,0,227,0,2,64,227
bl _mono_create_corlib_exception_2
bl _p_3

	.byte 0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . -12
	.byte 0,0,159,231,103,16,160,227
bl _p_2

	.byte 0,16,160,225,168,1,0,227,0,2,64,227
bl _mono_create_corlib_exception_1
bl _p_3

	.byte 0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . -12
	.byte 0,0,159,231,27,16,160,227
bl _p_2

	.byte 0,16,160,225,169,1,0,227,0,2,64,227
bl _mono_create_corlib_exception_1
bl _p_3

	.byte 14,16,160,225,0,0,159,229
bl _p_22

	.byte 250,1,0,2

Lme_69:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1__0_Find__0
_System_Collections_Generic_LinkedList_1__0_Find__0:

	.byte 128,64,45,233,13,112,160,225,96,13,45,233,20,208,77,226,13,176,160,225,0,0,139,229,4,16,139,229,0,0,155,229
	.byte 0,0,144,229
bl _p_109

	.byte 0,160,160,225,0,0,154,229,7,96,128,226,7,96,198,227,6,208,77,224,0,96,141,226,0,0,155,229,4,16,154,229
	.byte 1,0,128,224,0,80,144,229,5,0,160,225,0,0,80,227,1,0,0,26,0,0,160,227,63,0,0,234,10,0,0,234
	.byte 0,0,155,229,0,0,144,229
bl _p_110

	.byte 0,32,160,225,12,0,154,229,0,16,134,224,5,0,160,225,50,255,47,225,42,0,0,234,5,0,160,225,51,0,0,234
	.byte 0,0,155,229,0,0,144,229
bl _p_111
bl _p_13

	.byte 0,0,155,229,0,0,144,229
bl _p_111

	.byte 12,0,139,229,0,0,155,229,0,0,144,229
bl _p_112

	.byte 12,16,155,229,1,128,160,225,48,255,47,225,8,0,139,229,0,0,155,229,0,0,144,229
bl _p_110

	.byte 0,32,160,225,16,0,154,229,0,16,134,224,5,0,160,225,50,255,47,225,0,0,155,229,0,0,144,229
bl _p_111
bl _p_13

	.byte 0,0,155,229,0,0,144,229
bl _p_113

	.byte 0,48,160,225,8,0,155,229,16,16,154,229,1,16,134,224,4,32,155,229,51,255,47,225,255,0,0,226,0,0,80,227
	.byte 1,0,0,10,5,0,160,225,10,0,0,234,8,0,154,229,0,0,133,224,0,80,144,229,5,0,160,225,0,16,155,229
	.byte 4,32,154,229,2,16,129,224,0,16,145,229,1,0,80,225,192,255,255,26,0,0,160,227,20,208,139,226,96,13,189,232
	.byte 128,128,189,232

Lme_6a:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1__0_GetEnumerator
_System_Collections_Generic_LinkedList_1__0_GetEnumerator:

	.byte 128,64,45,233,13,112,160,225,96,9,45,233,24,208,77,226,13,176,160,225,0,16,139,229,4,0,139,229,4,0,155,229
	.byte 0,0,144,229
bl _p_114

	.byte 0,96,160,225,0,0,150,229,7,80,128,226,7,80,197,227,5,208,77,224,0,80,141,226,4,0,155,229,12,0,139,229
	.byte 4,0,155,229,0,0,144,229
bl _p_115

	.byte 16,0,139,229,16,16,150,229,5,0,160,225,1,0,128,224,4,16,150,229,8,32,150,229,50,255,47,225,16,16,150,229
	.byte 5,0,160,225,1,0,128,224,8,0,139,229,4,0,155,229,0,0,144,229
bl _p_116

	.byte 0,32,160,225,8,0,155,229,12,16,155,229,16,48,155,229,3,128,160,225,50,255,47,225,16,16,150,229,5,0,160,225
	.byte 1,16,128,224,20,32,150,229,5,0,160,225,2,0,128,224,4,32,150,229,12,48,150,229,51,255,47,225,20,16,150,229
	.byte 5,0,160,225,1,16,128,224,0,0,155,229,4,32,150,229,12,48,150,229,51,255,47,225,24,208,139,226,96,9,189,232
	.byte 128,128,189,232

Lme_6b:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1__0_Remove__0
_System_Collections_Generic_LinkedList_1__0_Remove__0:

	.byte 128,64,45,233,13,112,160,225,64,13,45,233,16,208,77,226,13,176,160,225,0,0,139,229,4,16,139,229,0,0,155,229
	.byte 0,0,144,229
bl _p_117

	.byte 0,160,160,225,0,0,154,229,0,96,160,227,0,0,155,229,8,0,139,229,0,0,155,229,0,0,144,229
bl _p_118

	.byte 0,32,160,225,8,0,155,229,4,16,155,229,50,255,47,225,0,96,160,225,0,0,80,227,1,0,0,26,0,0,160,227
	.byte 9,0,0,234,0,0,155,229,8,0,139,229,0,0,155,229,0,0,144,229
bl _p_119

	.byte 0,32,160,225,8,0,155,229,6,16,160,225,50,255,47,225,1,0,160,227,16,208,139,226,64,13,189,232,128,128,189,232

Lme_6c:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1__0_Remove_System_Collections_Generic_LinkedListNode_1__0
_System_Collections_Generic_LinkedList_1__0_Remove_System_Collections_Generic_LinkedListNode_1__0:

	.byte 128,64,45,233,13,112,160,225,64,13,45,233,16,208,77,226,13,176,160,225,4,0,139,229,1,160,160,225,4,0,155,229
	.byte 0,0,144,229
bl _p_120

	.byte 0,96,160,225,0,0,150,229,0,0,160,227,0,0,139,229,4,0,155,229,8,0,139,229,4,0,155,229,0,0,144,229
bl _p_121

	.byte 0,32,160,225,8,0,155,229,10,16,160,225,50,255,47,225,4,16,155,229,1,0,160,225,4,32,150,229,2,16,129,224
	.byte 0,16,145,229,1,16,65,226,4,32,150,229,2,0,128,224,0,16,128,229,4,0,155,229,4,16,150,229,1,0,128,224
	.byte 0,0,144,229,0,0,80,227,4,0,0,26,4,0,155,229,8,16,150,229,1,0,128,224,0,16,160,227,0,16,128,229
	.byte 4,0,155,229,8,16,150,229,1,0,128,224,0,0,144,229,0,0,90,225,10,0,0,26,4,0,155,229,0,16,160,225
	.byte 8,32,150,229,2,16,129,224,0,16,145,229,12,32,150,229,2,16,129,224,0,16,145,229,8,32,150,229,2,0,128,224
	.byte 0,16,128,229,4,16,155,229,1,0,160,225,16,32,150,229,2,16,129,224,0,16,145,229,1,16,129,226,16,32,150,229
	.byte 2,0,128,224,0,16,128,229,4,0,155,229,0,0,144,229
bl _p_122

	.byte 0,16,160,225,10,0,160,225,49,255,47,225,16,208,139,226,64,13,189,232,128,128,189,232

Lme_6d:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1__0_RemoveLast
_System_Collections_Generic_LinkedList_1__0_RemoveLast:

	.byte 128,64,45,233,13,112,160,225,0,13,45,233,20,208,77,226,13,176,160,225,4,0,139,229,4,0,155,229,0,0,144,229
bl _p_123

	.byte 0,160,160,225,0,0,154,229,0,0,160,227,0,0,139,229,4,0,155,229,4,16,154,229,1,0,128,224,0,0,144,229
	.byte 0,0,80,227,19,0,0,10,4,0,155,229,8,0,139,229,4,0,155,229,4,16,154,229,1,0,128,224,0,0,144,229
	.byte 8,16,154,229,1,0,128,224,0,0,144,229,12,0,139,229,4,0,155,229,0,0,144,229
bl _p_124

	.byte 0,32,160,225,8,0,155,229,12,16,155,229,50,255,47,225,20,208,139,226,0,13,189,232,128,128,189,232,0,2,0,227
	.byte 0,2,64,227
bl _mono_create_corlib_exception_0
bl _p_3

Lme_6e:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1__0_System_Collections_Generic_ICollection_T_Add__0
_System_Collections_Generic_LinkedList_1__0_System_Collections_Generic_ICollection_T_Add__0:

	.byte 128,64,45,233,13,112,160,225,0,13,45,233,28,208,77,226,13,176,160,225,4,0,139,229,8,16,139,229,4,0,155,229
	.byte 0,0,144,229
bl _p_125

	.byte 0,160,160,225,0,0,154,229,0,0,160,227,0,0,139,229,4,0,155,229,16,0,139,229,4,0,155,229,0,0,144,229
bl _p_126

	.byte 0,32,160,225,16,0,155,229,0,16,155,229,8,16,155,229,50,255,47,225,28,208,139,226,0,13,189,232,128,128,189,232

Lme_6f:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1__0_System_Collections_Generic_IEnumerable_T_GetEnumerator
_System_Collections_Generic_LinkedList_1__0_System_Collections_Generic_IEnumerable_T_GetEnumerator:

	.byte 128,64,45,233,13,112,160,225,112,13,45,233,16,208,77,226,13,176,160,225,0,0,139,229,0,0,155,229,0,0,144,229
bl _p_127

	.byte 0,160,160,225,0,0,154,229,7,96,128,226,7,96,198,227,6,208,77,224,0,96,141,226,0,0,155,229,8,0,139,229
	.byte 0,0,155,229,0,0,144,229
bl _p_128

	.byte 0,32,160,225,8,0,155,229,20,48,154,229,6,16,160,225,3,16,129,224,50,255,47,225,4,80,154,229,1,0,85,227
	.byte 15,0,0,10,2,0,85,227,17,0,0,10,0,0,155,229,0,0,144,229
bl _p_129
bl _p_8

	.byte 20,16,154,229,1,16,134,224,8,0,139,229,8,0,128,226,12,32,154,229,16,48,154,229,51,255,47,225,8,0,155,229
	.byte 0,64,160,225,8,0,0,234,20,0,154,229,0,0,134,224,0,64,144,229,4,0,0,234,8,16,154,229,20,0,154,229
	.byte 0,0,134,224,49,255,47,225,0,64,160,225,4,0,160,225,16,208,139,226,112,13,189,232,128,128,189,232

Lme_70:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1__0_System_Collections_IEnumerable_GetEnumerator
_System_Collections_Generic_LinkedList_1__0_System_Collections_IEnumerable_GetEnumerator:

	.byte 128,64,45,233,13,112,160,225,112,13,45,233,16,208,77,226,13,176,160,225,0,0,139,229,0,0,155,229,0,0,144,229
bl _p_130

	.byte 0,160,160,225,0,0,154,229,7,96,128,226,7,96,198,227,6,208,77,224,0,96,141,226,0,0,155,229,8,0,139,229
	.byte 0,0,155,229,0,0,144,229
bl _p_131

	.byte 0,32,160,225,8,0,155,229,20,48,154,229,6,16,160,225,3,16,129,224,50,255,47,225,4,80,154,229,1,0,85,227
	.byte 15,0,0,10,2,0,85,227,17,0,0,10,0,0,155,229,0,0,144,229
bl _p_132
bl _p_8

	.byte 20,16,154,229,1,16,134,224,8,0,139,229,8,0,128,226,12,32,154,229,16,48,154,229,51,255,47,225,8,0,155,229
	.byte 0,64,160,225,8,0,0,234,20,0,154,229,0,0,134,224,0,64,144,229,4,0,0,234,8,16,154,229,20,0,154,229
	.byte 0,0,134,224,49,255,47,225,0,64,160,225,4,0,160,225,16,208,139,226,112,13,189,232,128,128,189,232

Lme_71:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1__0_get_Count
_System_Collections_Generic_LinkedList_1__0_get_Count:

	.byte 128,64,45,233,13,112,160,225,0,13,45,233,12,208,77,226,13,176,160,225,4,0,139,229,4,0,155,229,0,0,144,229
bl _p_133

	.byte 0,160,160,225,0,0,154,229,0,0,160,227,0,0,139,229,4,0,155,229,4,16,154,229,1,0,128,224,0,0,144,229
	.byte 12,208,139,226,0,13,189,232,128,128,189,232

Lme_72:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1__0_get_Last
_System_Collections_Generic_LinkedList_1__0_get_Last:

	.byte 128,64,45,233,13,112,160,225,64,13,45,233,8,208,77,226,13,176,160,225,4,0,139,229,4,0,155,229,0,0,144,229
bl _p_134

	.byte 0,160,160,225,0,0,154,229,0,0,160,227,0,0,139,229,4,0,155,229,4,16,154,229,1,0,128,224,0,0,144,229
	.byte 0,0,80,227,7,0,0,10,4,0,155,229,4,16,154,229,1,0,128,224,0,0,144,229,8,16,154,229,1,0,128,224
	.byte 0,96,144,229,0,0,0,234,0,96,160,227,6,0,160,225,8,208,139,226,64,13,189,232,128,128,189,232

Lme_73:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1__0_System_Collections_Generic_ICollection_T_get_IsReadOnly
_System_Collections_Generic_LinkedList_1__0_System_Collections_Generic_ICollection_T_get_IsReadOnly:

	.byte 128,64,45,233,13,112,160,225,0,9,45,233,16,208,77,226,13,176,160,225,8,0,139,229,8,0,155,229,0,0,144,229
bl _p_135

	.byte 0,0,139,229,0,0,144,229,0,0,160,227,4,0,139,229,0,0,160,227,16,208,139,226,0,9,189,232,128,128,189,232

Lme_74:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1__0_System_Collections_ICollection_get_SyncRoot
_System_Collections_Generic_LinkedList_1__0_System_Collections_ICollection_get_SyncRoot:

	.byte 128,64,45,233,13,112,160,225,0,9,45,233,16,208,77,226,13,176,160,225,8,0,139,229,8,0,155,229,0,0,144,229
bl _p_136

	.byte 0,0,139,229,0,0,144,229,0,0,160,227,4,0,139,229,8,0,155,229,16,208,139,226,0,9,189,232,128,128,189,232

Lme_75:
.text
ut_118:

	.byte 8,0,128,226
	b _System_Collections_Generic_LinkedList_1_Enumerator__0__ctor_System_Collections_Generic_LinkedList_1__0

.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_Enumerator__0__ctor_System_Collections_Generic_LinkedList_1__0
_System_Collections_Generic_LinkedList_1_Enumerator__0__ctor_System_Collections_Generic_LinkedList_1__0:

	.byte 128,64,45,233,13,112,160,225,96,9,45,233,16,208,77,226,13,176,160,225,0,128,139,229,0,96,160,225,8,16,139,229
	.byte 0,0,155,229
bl _p_137

	.byte 0,80,160,225,0,0,149,229,0,0,160,227,4,0,139,229,4,0,149,229,0,16,134,224,8,0,155,229,0,0,129,229
	.byte 8,16,149,229,1,16,134,224,0,32,160,227,0,32,129,229,12,16,149,229,1,16,134,224,0,32,224,227,0,32,129,229
	.byte 16,16,149,229,1,0,128,224,0,16,144,229,20,0,149,229,0,0,134,224,0,16,128,229,16,208,139,226,96,9,189,232
	.byte 128,128,189,232

Lme_76:
.text
ut_119:

	.byte 8,0,128,226
	b _System_Collections_Generic_LinkedList_1_Enumerator__0_get_Current

.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_Enumerator__0_get_Current
_System_Collections_Generic_LinkedList_1_Enumerator__0_get_Current:

	.byte 128,64,45,233,13,112,160,225,112,9,45,233,20,208,77,226,13,176,160,225,4,128,139,229,0,16,139,229,0,96,160,225
	.byte 4,0,155,229
bl _p_138

	.byte 0,80,160,225,0,0,149,229,7,64,128,226,7,64,196,227,4,208,77,224,0,64,141,226,4,0,149,229,0,0,134,224
	.byte 0,0,144,229,0,0,80,227,28,0,0,10,8,0,149,229,0,0,134,224,0,0,144,229,0,0,80,227,19,0,0,10
	.byte 8,0,149,229,0,0,134,224,0,0,144,229,8,0,139,229,4,0,155,229
bl _p_139

	.byte 0,32,160,225,8,0,155,229,20,16,149,229,1,16,132,224,50,255,47,225,20,0,149,229,0,16,132,224,0,0,155,229
	.byte 12,32,149,229,16,48,149,229,51,255,47,225,20,208,139,226,112,9,189,232,128,128,189,232,0,2,0,227,0,2,64,227
bl _mono_create_corlib_exception_0
bl _p_3

	.byte 28,2,0,227,0,2,64,227,0,16,160,227
bl _mono_create_corlib_exception_1
bl _p_3

Lme_77:
.text
ut_120:

	.byte 8,0,128,226
	b _System_Collections_Generic_LinkedList_1_Enumerator__0_System_Collections_IEnumerator_get_Current

.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_Enumerator__0_System_Collections_IEnumerator_get_Current
_System_Collections_Generic_LinkedList_1_Enumerator__0_System_Collections_IEnumerator_get_Current:

	.byte 128,64,45,233,13,112,160,225,112,13,45,233,16,208,77,226,13,176,160,225,0,128,139,229,0,160,160,225,0,0,155,229
bl _p_140

	.byte 0,96,160,225,0,0,150,229,7,80,128,226,7,80,197,227,5,208,77,224,0,80,141,226,0,0,155,229
bl _p_141

	.byte 8,0,139,229,0,0,155,229
bl _p_142

	.byte 0,32,160,225,8,0,155,229,0,128,160,225,20,16,150,229,5,0,160,225,1,16,128,224,10,0,160,225,50,255,47,225
	.byte 4,160,150,229,1,0,90,227,14,0,0,10,2,0,90,227,16,0,0,10,0,0,155,229
bl _p_143
bl _p_8

	.byte 20,16,150,229,1,16,133,224,8,0,139,229,8,0,128,226,12,32,150,229,16,48,150,229,51,255,47,225,8,0,155,229
	.byte 0,64,160,225,8,0,0,234,20,0,150,229,0,0,133,224,0,64,144,229,4,0,0,234,8,16,150,229,20,0,150,229
	.byte 0,0,133,224,49,255,47,225,0,64,160,225,4,0,160,225,16,208,139,226,112,13,189,232,128,128,189,232

Lme_78:
.text
ut_121:

	.byte 8,0,128,226
	b _System_Collections_Generic_LinkedList_1_Enumerator__0_MoveNext

.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_Enumerator__0_MoveNext
_System_Collections_Generic_LinkedList_1_Enumerator__0_MoveNext:

	.byte 128,64,45,233,13,112,160,225,64,13,45,233,8,208,77,226,13,176,160,225,0,128,139,229,0,160,160,225,0,0,155,229
bl _p_144

	.byte 0,96,160,225,0,0,150,229,0,0,160,227,4,0,139,229,4,0,150,229,0,0,138,224,0,0,144,229,0,0,80,227
	.byte 87,0,0,10,8,0,150,229,0,0,138,224,0,0,144,229,4,16,150,229,1,16,138,224,0,16,145,229,12,32,150,229
	.byte 2,16,129,224,0,16,145,229,1,0,80,225,65,0,0,26,16,0,150,229,0,0,138,224,0,0,144,229,0,0,80,227
	.byte 14,0,0,26,20,0,150,229,0,0,138,224,0,0,144,229,0,0,80,227,33,0,0,170,4,0,150,229,0,0,138,224
	.byte 0,0,144,229,24,16,150,229,1,0,128,224,0,16,144,229,16,0,150,229,0,0,138,224,0,16,128,229,23,0,0,234
	.byte 16,0,150,229,0,0,138,224,0,0,144,229,28,16,150,229,1,0,128,224,0,16,144,229,16,0,150,229,0,0,138,224
	.byte 0,16,128,229,16,0,150,229,0,0,138,224,0,0,144,229,4,16,150,229,1,16,138,224,0,16,145,229,24,32,150,229
	.byte 2,16,129,224,0,16,145,229,1,0,80,225,3,0,0,26,16,0,150,229,0,0,138,224,0,16,160,227,0,16,128,229
	.byte 16,0,150,229,0,0,138,224,0,0,144,229,0,0,80,227,5,0,0,26,20,0,150,229,0,0,138,224,128,20,224,227
	.byte 0,16,128,229,0,0,160,227,7,0,0,234,20,0,150,229,0,0,138,224,0,0,144,229,1,16,128,226,20,0,150,229
	.byte 0,0,138,224,0,16,128,229,1,0,160,227,8,208,139,226,64,13,189,232,128,128,189,232,0,0,159,229,0,0,0,234
	.long _mono_aot_System_got - . -12
	.byte 0,0,159,231,169,16,160,227
bl _p_2

	.byte 0,16,160,225,0,2,0,227,0,2,64,227
bl _mono_create_corlib_exception_1
bl _p_3

	.byte 28,2,0,227,0,2,64,227,0,16,160,227
bl _mono_create_corlib_exception_1
bl _p_3

Lme_79:
.text
ut_122:

	.byte 8,0,128,226
	b _System_Collections_Generic_LinkedList_1_Enumerator__0_Dispose

.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedList_1_Enumerator__0_Dispose
_System_Collections_Generic_LinkedList_1_Enumerator__0_Dispose:

	.byte 128,64,45,233,13,112,160,225,64,13,45,233,8,208,77,226,13,176,160,225,0,128,139,229,0,160,160,225,0,0,155,229
bl _p_145

	.byte 0,96,160,225,0,0,150,229,0,0,160,227,4,0,139,229,4,0,150,229,0,0,138,224,0,0,144,229,0,0,80,227
	.byte 10,0,0,10,8,0,150,229,0,0,138,224,0,16,160,227,0,16,128,229,4,0,150,229,0,0,138,224,0,16,160,227
	.byte 0,16,128,229,8,208,139,226,64,13,189,232,128,128,189,232,28,2,0,227,0,2,64,227,0,16,160,227
bl _mono_create_corlib_exception_1
bl _p_3

Lme_7a:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedListNode_1__0__ctor__0
_System_Collections_Generic_LinkedListNode_1__0__ctor__0:

	.byte 128,64,45,233,13,112,160,225,0,13,45,233,20,208,77,226,13,176,160,225,4,0,139,229,8,16,139,229,4,0,155,229
	.byte 0,0,144,229
bl _p_146

	.byte 0,160,160,225,0,0,154,229,0,16,160,227,0,0,160,227,0,0,139,229,4,0,155,229,4,32,154,229,2,0,128,224
	.byte 8,16,155,229,8,32,154,229,12,48,154,229,51,255,47,225,20,208,139,226,0,13,189,232,128,128,189,232

Lme_7b:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedListNode_1__0__ctor_System_Collections_Generic_LinkedList_1__0__0
_System_Collections_Generic_LinkedListNode_1__0__ctor_System_Collections_Generic_LinkedList_1__0__0:

	.byte 128,64,45,233,13,112,160,225,64,9,45,233,20,208,77,226,13,176,160,225,4,0,139,229,8,16,139,229,12,32,139,229
	.byte 4,0,155,229,0,0,144,229
bl _p_147

	.byte 0,96,160,225,0,0,150,229,0,16,160,227,0,0,160,227,0,0,139,229,4,0,155,229,4,32,150,229,2,0,128,224
	.byte 8,32,155,229,0,32,128,229,4,0,155,229,8,32,150,229,2,0,128,224,12,16,155,229,20,32,150,229,24,48,150,229
	.byte 51,255,47,225,4,0,155,229,0,32,160,225,4,16,155,229,1,48,160,225,12,192,150,229,12,32,130,224,0,48,130,229
	.byte 16,32,150,229,2,0,128,224,0,16,128,229,20,208,139,226,64,9,189,232,128,128,189,232

Lme_7c:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedListNode_1__0__ctor_System_Collections_Generic_LinkedList_1__0__0_System_Collections_Generic_LinkedListNode_1__0_System_Collections_Generic_LinkedListNode_1__0
_System_Collections_Generic_LinkedListNode_1__0__ctor_System_Collections_Generic_LinkedList_1__0__0_System_Collections_Generic_LinkedListNode_1__0_System_Collections_Generic_LinkedListNode_1__0:

	.byte 128,64,45,233,13,112,160,225,16,9,45,233,28,208,77,226,13,176,160,225,4,0,139,229,8,16,139,229,12,32,139,229
	.byte 16,48,139,229,48,224,157,229,20,224,139,229,4,0,155,229,0,0,144,229
bl _p_148

	.byte 0,64,160,225,0,0,148,229,0,16,160,227,0,0,160,227,0,0,139,229,4,0,155,229,4,32,148,229,2,0,128,224
	.byte 8,32,155,229,0,32,128,229,4,0,155,229,8,32,148,229,2,0,128,224,12,16,155,229,20,32,148,229,24,48,148,229
	.byte 51,255,47,225,4,0,155,229,12,16,148,229,1,0,128,224,16,16,155,229,0,16,128,229,4,0,155,229,16,32,148,229
	.byte 2,32,128,224,20,0,155,229,0,0,130,229,4,32,155,229,16,48,148,229,3,16,129,224,0,32,129,229,4,16,155,229
	.byte 12,32,148,229,2,0,128,224,0,16,128,229,28,208,139,226,16,9,189,232,128,128,189,232

Lme_7d:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedListNode_1__0_Detach
_System_Collections_Generic_LinkedListNode_1__0_Detach:

	.byte 128,64,45,233,13,112,160,225,0,13,45,233,12,208,77,226,13,176,160,225,4,0,139,229,4,0,155,229,0,0,144,229
bl _p_149

	.byte 0,160,160,225,0,0,154,229,0,0,160,227,0,0,139,229,4,0,155,229,4,16,154,229,1,0,128,224,0,0,144,229
	.byte 4,16,155,229,8,32,154,229,2,16,129,224,0,16,145,229,8,32,154,229,2,0,128,224,0,16,128,229,4,0,155,229
	.byte 8,16,154,229,1,0,128,224,0,0,144,229,4,16,155,229,4,32,154,229,2,16,129,224,0,16,145,229,4,32,154,229
	.byte 2,0,128,224,0,16,128,229,4,0,155,229,0,16,160,225,4,32,154,229,2,16,129,224,0,32,160,227,0,32,129,229
	.byte 8,16,154,229,1,0,128,224,0,16,160,227,0,16,128,229,4,0,155,229,12,16,154,229,1,0,128,224,0,16,160,227
	.byte 0,16,128,229,12,208,139,226,0,13,189,232,128,128,189,232

Lme_7e:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedListNode_1__0_SelfReference_System_Collections_Generic_LinkedList_1__0
_System_Collections_Generic_LinkedListNode_1__0_SelfReference_System_Collections_Generic_LinkedList_1__0:

	.byte 128,64,45,233,13,112,160,225,64,9,45,233,20,208,77,226,13,176,160,225,4,0,139,229,8,16,139,229,4,0,155,229
	.byte 0,0,144,229
bl _p_150

	.byte 0,96,160,225,0,0,150,229,0,0,160,227,0,0,139,229,4,0,155,229,0,16,160,225,4,32,150,229,2,0,128,224
	.byte 0,16,128,229,4,0,155,229,0,16,160,225,8,32,150,229,2,0,128,224,0,16,128,229,4,0,155,229,12,16,150,229
	.byte 1,0,128,224,8,16,155,229,0,16,128,229,20,208,139,226,64,9,189,232,128,128,189,232

Lme_7f:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedListNode_1__0_InsertBetween_System_Collections_Generic_LinkedListNode_1__0_System_Collections_Generic_LinkedListNode_1__0_System_Collections_Generic_LinkedList_1__0
_System_Collections_Generic_LinkedListNode_1__0_InsertBetween_System_Collections_Generic_LinkedListNode_1__0_System_Collections_Generic_LinkedListNode_1__0_System_Collections_Generic_LinkedList_1__0:

	.byte 128,64,45,233,13,112,160,225,16,9,45,233,28,208,77,226,13,176,160,225,4,0,139,229,8,16,139,229,12,32,139,229
	.byte 16,48,139,229,4,0,155,229,0,0,144,229
bl _p_151

	.byte 0,64,160,225,0,0,148,229,0,0,160,227,0,0,139,229,4,32,155,229,4,0,148,229,8,16,155,229,0,0,129,224
	.byte 0,32,128,229,4,48,155,229,8,0,148,229,12,32,155,229,0,0,130,224,0,48,128,229,4,0,155,229,4,48,148,229
	.byte 3,0,128,224,0,32,128,229,4,0,155,229,8,32,148,229,2,0,128,224,0,16,128,229,4,0,155,229,12,16,148,229
	.byte 1,0,128,224,16,16,155,229,0,16,128,229,28,208,139,226,16,9,189,232,128,128,189,232

Lme_80:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedListNode_1__0_get_List
_System_Collections_Generic_LinkedListNode_1__0_get_List:

	.byte 128,64,45,233,13,112,160,225,0,13,45,233,12,208,77,226,13,176,160,225,4,0,139,229,4,0,155,229,0,0,144,229
bl _p_152

	.byte 0,160,160,225,0,0,154,229,0,0,160,227,0,0,139,229,4,0,155,229,4,16,154,229,1,0,128,224,0,0,144,229
	.byte 12,208,139,226,0,13,189,232,128,128,189,232

Lme_81:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedListNode_1__0_get_Previous
_System_Collections_Generic_LinkedListNode_1__0_get_Previous:

	.byte 128,64,45,233,13,112,160,225,64,13,45,233,8,208,77,226,13,176,160,225,4,0,139,229,4,0,155,229,0,0,144,229
bl _p_153

	.byte 0,160,160,225,0,0,154,229,0,0,160,227,0,0,139,229,4,0,155,229,4,16,154,229,1,0,128,224,0,0,144,229
	.byte 0,0,80,227,14,0,0,10,4,0,155,229,0,16,160,225,4,32,154,229,2,16,129,224,0,16,145,229,8,32,154,229
	.byte 2,16,129,224,0,16,145,229,1,0,80,225,4,0,0,10,4,0,155,229,12,16,154,229,1,0,128,224,0,96,144,229
	.byte 0,0,0,234,0,96,160,227,6,0,160,225,8,208,139,226,64,13,189,232,128,128,189,232

Lme_82:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_LinkedListNode_1__0_get_Value
_System_Collections_Generic_LinkedListNode_1__0_get_Value:

	.byte 128,64,45,233,13,112,160,225,96,9,45,233,8,208,77,226,13,176,160,225,0,16,139,229,4,0,139,229,4,0,155,229
	.byte 0,0,144,229
bl _p_154

	.byte 0,96,160,225,0,0,150,229,7,80,128,226,7,80,197,227,5,208,77,224,0,80,141,226,4,0,155,229,4,16,150,229
	.byte 1,16,128,224,16,0,150,229,0,0,133,224,8,32,150,229,12,48,150,229,51,255,47,225,16,16,150,229,5,0,160,225
	.byte 1,16,128,224,0,0,155,229,8,32,150,229,12,48,150,229,51,255,47,225,8,208,139,226,96,9,189,232,128,128,189,232

Lme_83:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_Stack_1__0__ctor
_System_Collections_Generic_Stack_1__0__ctor:

	.byte 128,64,45,233,13,112,160,225,0,9,45,233,16,208,77,226,13,176,160,225,8,0,139,229,8,0,155,229,0,0,144,229
bl _p_155

	.byte 0,0,139,229,0,0,144,229,0,0,160,227,4,0,139,229,16,208,139,226,0,9,189,232,128,128,189,232

Lme_84:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_Stack_1__0_Peek
_System_Collections_Generic_Stack_1__0_Peek:

	.byte 128,64,45,233,13,112,160,225,96,9,45,233,8,208,77,226,13,176,160,225,0,16,139,229,4,0,139,229,4,0,155,229
	.byte 0,0,144,229
bl _p_156

	.byte 0,96,160,225,0,0,150,229,7,80,128,226,7,80,197,227,5,208,77,224,0,80,141,226,4,0,155,229,4,16,150,229
	.byte 1,0,128,224,0,0,144,229,0,0,80,227,29,0,0,10,4,0,155,229,8,16,150,229,1,0,128,224,0,0,144,229
	.byte 4,16,155,229,4,32,150,229,2,16,129,224,0,16,145,229,1,16,65,226,12,32,144,229,1,0,82,225,21,0,0,155
	.byte 12,32,150,229,146,1,1,224,1,0,128,224,16,16,128,226,24,0,150,229,0,0,133,224,16,32,150,229,20,48,150,229
	.byte 51,255,47,225,24,0,150,229,0,16,133,224,0,0,155,229,16,32,150,229,20,48,150,229,51,255,47,225,8,208,139,226
	.byte 96,9,189,232,128,128,189,232,0,2,0,227,0,2,64,227
bl _mono_create_corlib_exception_0
bl _p_3

	.byte 14,16,160,225,0,0,159,229
bl _p_22

	.byte 250,1,0,2

Lme_85:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_Stack_1__0_Pop
_System_Collections_Generic_Stack_1__0_Pop:

	.byte 128,64,45,233,13,112,160,225,96,9,45,233,24,208,77,226,13,176,160,225,0,16,139,229,8,0,139,229,8,0,155,229
	.byte 0,0,144,229
bl _p_157

	.byte 0,96,160,225,0,0,150,229,7,80,128,226,7,80,197,227,5,208,77,224,0,80,141,226,32,0,150,229,0,0,133,224
	.byte 20,16,150,229,24,32,150,229,50,255,47,225,36,16,150,229,5,0,160,225,1,0,128,224,20,16,150,229,24,32,150,229
	.byte 50,255,47,225,8,0,155,229,4,16,150,229,1,0,128,224,0,0,144,229,0,0,80,227,80,0,0,10,8,16,155,229
	.byte 1,0,160,225,8,32,150,229,2,16,129,224,0,16,145,229,1,16,129,226,8,32,150,229,2,0,128,224,0,16,128,229
	.byte 8,0,155,229,12,16,150,229,1,0,128,224,0,0,144,229,8,16,155,229,1,32,160,225,4,48,150,229,3,16,129,224
	.byte 0,16,145,229,1,16,65,226,1,48,160,225,4,16,139,229,4,192,150,229,12,32,130,224,0,48,130,229,12,32,144,229
	.byte 1,0,82,225,57,0,0,155,16,32,150,229,146,1,1,224,1,0,128,224,16,16,128,226,32,0,150,229,0,0,133,224
	.byte 20,32,150,229,28,48,150,229,51,255,47,225,8,0,155,229,12,16,150,229,1,0,128,224,0,0,144,229,16,0,139,229
	.byte 8,0,155,229,4,16,150,229,1,0,128,224,0,0,144,229,20,0,139,229,36,0,150,229,0,0,133,224,20,16,150,229
	.byte 24,32,150,229,50,255,47,225,36,0,150,229,0,16,133,224,40,0,150,229,0,0,133,224,20,32,150,229,28,48,150,229
	.byte 51,255,47,225,16,0,155,229,20,16,155,229,12,32,144,229,1,0,82,225,21,0,0,155,16,32,150,229,146,1,1,224
	.byte 1,0,128,224,16,0,128,226,40,16,150,229,1,16,133,224,20,32,150,229,28,48,150,229,51,255,47,225,32,0,150,229
	.byte 0,16,133,224,0,0,155,229,20,32,150,229,28,48,150,229,51,255,47,225,24,208,139,226,96,9,189,232,128,128,189,232
	.byte 0,2,0,227,0,2,64,227
bl _mono_create_corlib_exception_0
bl _p_3

	.byte 14,16,160,225,0,0,159,229
bl _p_22

	.byte 250,1,0,2

Lme_86:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_Stack_1__0_Push__0
_System_Collections_Generic_Stack_1__0_Push__0:

	.byte 128,64,45,233,13,112,160,225,0,13,45,233,36,208,77,226,13,176,160,225,16,0,139,229,20,16,139,229,16,0,155,229
	.byte 0,0,144,229
bl _p_158

	.byte 0,160,160,225,0,0,154,229,0,0,160,227,4,0,139,229,16,0,155,229,4,16,154,229,1,0,128,224,0,0,144,229
	.byte 0,0,80,227,10,0,0,10,16,0,155,229,8,16,154,229,1,0,128,224,0,0,144,229,16,16,155,229,4,32,154,229
	.byte 2,16,129,224,0,16,145,229,12,16,145,229,1,0,80,225,33,0,0,26,16,0,155,229,0,0,80,227,73,0,0,11
	.byte 4,16,154,229,1,16,128,224,16,0,155,229,8,32,154,229,2,0,128,224,0,0,144,229,8,16,139,229,0,0,80,227
	.byte 2,0,0,26,16,0,160,227,12,0,139,229,5,0,0,234,16,0,155,229,8,16,154,229,1,0,128,224,0,0,144,229
	.byte 128,0,160,225,12,0,139,229,16,0,155,229,0,0,144,229
bl _p_159

	.byte 24,0,139,229,16,0,155,229,0,0,144,229
bl _p_160

	.byte 0,32,160,225,24,0,155,229,0,128,160,225,8,0,155,229,12,16,155,229,50,255,47,225,16,16,155,229,1,0,160,225
	.byte 12,32,154,229,2,16,129,224,0,16,145,229,1,16,129,226,12,32,154,229,2,0,128,224,0,16,128,229,16,0,155,229
	.byte 4,16,154,229,1,0,128,224,0,0,144,229,16,16,155,229,1,32,160,225,8,48,154,229,3,16,129,224,0,16,145,229
	.byte 1,48,160,225,0,16,139,229,1,48,131,226,8,192,154,229,12,32,130,224,0,48,130,229,12,32,144,229,1,0,82,225
	.byte 11,0,0,155,16,32,154,229,146,1,1,224,1,0,128,224,16,0,128,226,4,16,155,229,20,16,155,229,20,32,154,229
	.byte 24,48,154,229,51,255,47,225,36,208,139,226,0,13,189,232,128,128,189,232,14,16,160,225,0,0,159,229
bl _p_22

	.byte 250,1,0,2,14,16,160,225,0,0,159,229
bl _p_22

	.byte 23,2,0,2

Lme_87:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_Stack_1__0_get_Count
_System_Collections_Generic_Stack_1__0_get_Count:

	.byte 128,64,45,233,13,112,160,225,0,13,45,233,12,208,77,226,13,176,160,225,4,0,139,229,4,0,155,229,0,0,144,229
bl _p_161

	.byte 0,160,160,225,0,0,154,229,0,0,160,227,0,0,139,229,4,0,155,229,4,16,154,229,1,0,128,224,0,0,144,229
	.byte 12,208,139,226,0,13,189,232,128,128,189,232

Lme_88:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_Stack_1__0_System_Collections_ICollection_get_SyncRoot
_System_Collections_Generic_Stack_1__0_System_Collections_ICollection_get_SyncRoot:

	.byte 128,64,45,233,13,112,160,225,0,9,45,233,16,208,77,226,13,176,160,225,8,0,139,229,8,0,155,229,0,0,144,229
bl _p_162

	.byte 0,0,139,229,0,0,144,229,0,0,160,227,4,0,139,229,8,0,155,229,16,208,139,226,0,9,189,232,128,128,189,232

Lme_89:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_Stack_1__0_GetEnumerator
_System_Collections_Generic_Stack_1__0_GetEnumerator:

	.byte 128,64,45,233,13,112,160,225,96,9,45,233,24,208,77,226,13,176,160,225,0,16,139,229,4,0,139,229,4,0,155,229
	.byte 0,0,144,229
bl _p_163

	.byte 0,96,160,225,0,0,150,229,7,80,128,226,7,80,197,227,5,208,77,224,0,80,141,226,4,0,155,229,12,0,139,229
	.byte 4,0,155,229,0,0,144,229
bl _p_164

	.byte 16,0,139,229,16,16,150,229,5,0,160,225,1,0,128,224,4,16,150,229,8,32,150,229,50,255,47,225,16,16,150,229
	.byte 5,0,160,225,1,0,128,224,8,0,139,229,4,0,155,229,0,0,144,229
bl _p_165

	.byte 0,32,160,225,8,0,155,229,12,16,155,229,16,48,155,229,3,128,160,225,50,255,47,225,16,16,150,229,5,0,160,225
	.byte 1,16,128,224,20,32,150,229,5,0,160,225,2,0,128,224,4,32,150,229,12,48,150,229,51,255,47,225,20,16,150,229
	.byte 5,0,160,225,1,16,128,224,0,0,155,229,4,32,150,229,12,48,150,229,51,255,47,225,24,208,139,226,96,9,189,232
	.byte 128,128,189,232

Lme_8a:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_Stack_1__0_System_Collections_Generic_IEnumerable_T_GetEnumerator
_System_Collections_Generic_Stack_1__0_System_Collections_Generic_IEnumerable_T_GetEnumerator:

	.byte 128,64,45,233,13,112,160,225,112,13,45,233,16,208,77,226,13,176,160,225,0,0,139,229,0,0,155,229,0,0,144,229
bl _p_166

	.byte 0,160,160,225,0,0,154,229,7,96,128,226,7,96,198,227,6,208,77,224,0,96,141,226,0,0,155,229,8,0,139,229
	.byte 0,0,155,229,0,0,144,229
bl _p_167

	.byte 0,32,160,225,8,0,155,229,20,48,154,229,6,16,160,225,3,16,129,224,50,255,47,225,4,80,154,229,1,0,85,227
	.byte 15,0,0,10,2,0,85,227,17,0,0,10,0,0,155,229,0,0,144,229
bl _p_168
bl _p_8

	.byte 20,16,154,229,1,16,134,224,8,0,139,229,8,0,128,226,12,32,154,229,16,48,154,229,51,255,47,225,8,0,155,229
	.byte 0,64,160,225,8,0,0,234,20,0,154,229,0,0,134,224,0,64,144,229,4,0,0,234,8,16,154,229,20,0,154,229
	.byte 0,0,134,224,49,255,47,225,0,64,160,225,4,0,160,225,16,208,139,226,112,13,189,232,128,128,189,232

Lme_8b:
.text
	.align 2
	.no_dead_strip _System_Collections_Generic_Stack_1__0_System_Collections_IEnumerable_GetEnumerator
_System_Collections_Generic_Stack_1__0_System_Collections_IEnumerable_GetEnumerator:

	.byte 128,64,45,233,13,112,160,225,112,13,45,233,16,208,77,226,13,176,160,225,0,0,139,229,0,0,155,229,0,0,144,229
bl _p_169

	.byte 0,160,160,225,0,0,154,229,7,96,128,226,7,96,198,227,6,208,77,224,0,96,141,226,0,0,155,229,8,0,139,229
	.byte 0,0,155,229,0,0,144,229
bl _p_170

	.byte 0,32,160,225,8,0,155,229,20,48,154,229,6,16,160,225,3,16,129,224,50,255,47,225,4,80,154,229,1,0,85,227
	.byte 15,0,0,10,2,0,85,227,17,0,0,10,0,0,155,229,0,0,144,229
bl _p_171
bl _p_8

	.byte 20,16,154,229,1,16,134,224,8,0,139,229,8,0,128,226,12,32,154,229,16,48,154,229,51,255,47,225,8,0,155,229
	.byte 0,64,160,225,8,0,0,234,20,0,154,229,0,0,134,224,0,64,144,229,4,0,0,234,8,16,154,229,20,0,154,229
	.byte 0,0,134,224,49,255,47,225,0,64,160,225,4,0,160,225,16,208,139,226,112,13,189,232,128,128,189,232

Lme_8c:
.text
ut_141:

	.byte 8,0,128,226
	b _System_Collections_Generic_Stack_1_Enumerator__0__ctor_System_Collections_Generic_Stack_1__0

.text
	.align 2
	.no_dead_strip _System_Collections_Generic_Stack_1_Enumerator__0__ctor_System_Collections_Generic_Stack_1__0
_System_Collections_Generic_Stack_1_Enumerator__0__ctor_System_Collections_Generic_Stack_1__0:

	.byte 128,64,45,233,13,112,160,225,96,9,45,233,16,208,77,226,13,176,160,225,0,128,139,229,0,96,160,225,8,16,139,229
	.byte 0,0,155,229
bl _p_172

	.byte 0,80,160,225,0,0,149,229,0,0,160,227,4,0,139,229,4,0,149,229,0,16,134,224,8,0,155,229,0,0,129,229
	.byte 8,16,149,229,1,16,134,224,1,32,224,227,0,32,129,229,12,16,149,229,1,0,128,224,0,16,144,229,16,0,149,229
	.byte 0,0,134,224,0,16,128,229,16,208,139,226,96,9,189,232,128,128,189,232

Lme_8d:
.text
ut_142:

	.byte 8,0,128,226
	b _System_Collections_Generic_Stack_1_Enumerator__0_Dispose

.text
	.align 2
	.no_dead_strip _System_Collections_Generic_Stack_1_Enumerator__0_Dispose
_System_Collections_Generic_Stack_1_Enumerator__0_Dispose:

	.byte 128,64,45,233,13,112,160,225,64,9,45,233,20,208,77,226,13,176,160,225,0,128,139,229,8,0,139,229,0,0,155,229
bl _p_173

	.byte 0,96,160,225,0,0,150,229,0,0,160,227,4,0,139,229,4,16,150,229,8,0,155,229,1,0,128,224,0,16,224,227
	.byte 0,16,128,229,20,208,139,226,64,9,189,232,128,128,189,232

Lme_8e:
.text
ut_143:

	.byte 8,0,128,226
	b _System_Collections_Generic_Stack_1_Enumerator__0_MoveNext

.text
	.align 2
	.no_dead_strip _System_Collections_Generic_Stack_1_Enumerator__0_MoveNext
_System_Collections_Generic_Stack_1_Enumerator__0_MoveNext:

	.byte 128,64,45,233,13,112,160,225,80,13,45,233,20,208,77,226,13,176,160,225,4,128,139,229,0,160,160,225,4,0,155,229
bl _p_174

	.byte 0,96,160,225,0,0,150,229,0,0,160,227,8,0,139,229,4,0,150,229,0,0,138,224,0,0,144,229,8,16,150,229
	.byte 1,16,138,224,0,16,145,229,12,32,150,229,2,16,129,224,0,16,145,229,1,0,80,225,42,0,0,26,16,0,150,229
	.byte 0,0,138,224,0,0,144,229,1,16,224,227,1,0,80,225,8,0,0,26,8,0,150,229,0,0,138,224,0,0,144,229
	.byte 20,16,150,229,1,0,128,224,0,16,144,229,16,0,150,229,0,0,138,224,0,16,128,229,16,0,150,229,0,0,138,224
	.byte 0,0,144,229,0,16,224,227,1,0,80,225,16,0,0,10,16,0,150,229,0,0,138,224,0,0,144,229,1,0,64,226
	.byte 0,32,160,225,0,0,139,229,16,16,150,229,1,16,138,224,0,32,129,229,0,16,224,227,1,0,80,225,0,0,160,19
	.byte 1,0,160,3,0,0,80,227,0,64,160,19,1,64,160,3,0,0,0,234,0,64,160,227,4,0,160,225,20,208,139,226
	.byte 80,13,189,232,128,128,189,232,0,2,0,227,0,2,64,227
bl _mono_create_corlib_exception_0
bl _p_3

Lme_8f:
.text
ut_144:

	.byte 8,0,128,226
	b _System_Collections_Generic_Stack_1_Enumerator__0_get_Current

.text
	.align 2
	.no_dead_strip _System_Collections_Generic_Stack_1_Enumerator__0_get_Current
_System_Collections_Generic_Stack_1_Enumerator__0_get_Current:

	.byte 128,64,45,233,13,112,160,225,112,9,45,233,12,208,77,226,13,176,160,225,4,128,139,229,0,16,139,229,0,96,160,225
	.byte 4,0,155,229
bl _p_175

	.byte 0,80,160,225,0,0,149,229,7,64,128,226,7,64,196,227,4,208,77,224,0,64,141,226,4,0,149,229,0,0,134,224
	.byte 0,0,144,229,0,0,80,227,29,0,0,186,8,0,149,229,0,0,134,224,0,0,144,229,12,16,149,229,1,0,128,224
	.byte 0,0,144,229,4,16,149,229,1,16,134,224,0,16,145,229,12,32,144,229,1,0,82,225,21,0,0,155,16,32,149,229
	.byte 146,1,1,224,1,0,128,224,16,16,128,226,28,0,149,229,0,0,132,224,20,32,149,229,24,48,149,229,51,255,47,225
	.byte 28,0,149,229,0,16,132,224,0,0,155,229,20,32,149,229,24,48,149,229,51,255,47,225,12,208,139,226,112,9,189,232
	.byte 128,128,189,232,0,2,0,227,0,2,64,227
bl _mono_create_corlib_exception_0
bl _p_3

	.byte 14,16,160,225,0,0,159,229
bl _p_22

	.byte 250,1,0,2

Lme_90:
.text
ut_145:

	.byte 8,0,128,226
	b _System_Collections_Generic_Stack_1_Enumerator__0_System_Collections_IEnumerator_get_Current

.text
	.align 2
	.no_dead_strip _System_Collections_Generic_Stack_1_Enumerator__0_System_Collections_IEnumerator_get_Current
_System_Collections_Generic_Stack_1_Enumerator__0_System_Collections_IEnumerator_get_Current:

	.byte 128,64,45,233,13,112,160,225,112,13,45,233,16,208,77,226,13,176,160,225,0,128,139,229,0,160,160,225,0,0,155,229
bl _p_176

	.byte 0,96,160,225,0,0,150,229,7,80,128,226,7,80,197,227,5,208,77,224,0,80,141,226,0,0,155,229
bl _p_177

	.byte 8,0,139,229,0,0,155,229
bl _p_178

	.byte 0,32,160,225,8,0,155,229,0,128,160,225,20,16,150,229,5,0,160,225,1,16,128,224,10,0,160,225,50,255,47,225
	.byte 4,160,150,229,1,0,90,227,14,0,0,10,2,0,90,227,16,0,0,10,0,0,155,229
bl _p_179
bl _p_8

	.byte 20,16,150,229,1,16,133,224,8,0,139,229,8,0,128,226,12,32,150,229,16,48,150,229,51,255,47,225,8,0,155,229
	.byte 0,64,160,225,8,0,0,234,20,0,150,229,0,0,133,224,0,64,144,229,4,0,0,234,8,16,150,229,20,0,150,229
	.byte 0,0,133,224,49,255,47,225,0,64,160,225,4,0,160,225,16,208,139,226,112,13,189,232,128,128,189,232

Lme_91:
.text
	.align 3
methods_end:

	.long 0
.text
	.align 3
method_addresses:
	.no_dead_strip method_addresses
bl _System_Collections_Generic_LinkedList_1__ctor
bl _System_Collections_Generic_LinkedList_1_VerifyReferencedNode_System_Collections_Generic_LinkedListNode_1_T
bl _System_Collections_Generic_LinkedList_1_VerifyBlankNode_System_Collections_Generic_LinkedListNode_1_T
bl _System_Collections_Generic_LinkedList_1_AddFirst_System_Collections_Generic_LinkedListNode_1_T
bl _System_Collections_Generic_LinkedList_1_AddLast_T
bl _System_Collections_Generic_LinkedList_1_Clear
bl _System_Collections_Generic_LinkedList_1_Contains_T
bl _System_Collections_Generic_LinkedList_1_CopyTo_T___int
bl _System_Collections_Generic_LinkedList_1_Find_T
bl _System_Collections_Generic_LinkedList_1_GetEnumerator
bl _System_Collections_Generic_LinkedList_1_Remove_T
bl _System_Collections_Generic_LinkedList_1_Remove_System_Collections_Generic_LinkedListNode_1_T
bl _System_Collections_Generic_LinkedList_1_RemoveLast
bl _System_Collections_Generic_LinkedList_1_System_Collections_Generic_ICollection_T_Add_T
bl _System_Collections_Generic_LinkedList_1_System_Collections_Generic_IEnumerable_T_GetEnumerator
bl _System_Collections_Generic_LinkedList_1_System_Collections_IEnumerable_GetEnumerator
bl _System_Collections_Generic_LinkedList_1_get_Count
bl _System_Collections_Generic_LinkedList_1_get_Last
bl _System_Collections_Generic_LinkedList_1_System_Collections_Generic_ICollection_T_get_IsReadOnly
bl _System_Collections_Generic_LinkedList_1_System_Collections_ICollection_get_SyncRoot
bl _System_Collections_Generic_LinkedList_1_Enumerator__ctor_System_Collections_Generic_LinkedList_1_T
bl _System_Collections_Generic_LinkedList_1_Enumerator_get_Current
bl _System_Collections_Generic_LinkedList_1_Enumerator_System_Collections_IEnumerator_get_Current
bl _System_Collections_Generic_LinkedList_1_Enumerator_MoveNext
bl _System_Collections_Generic_LinkedList_1_Enumerator_Dispose
bl _System_Collections_Generic_LinkedListNode_1__ctor_T
bl _System_Collections_Generic_LinkedListNode_1__ctor_System_Collections_Generic_LinkedList_1_T_T
bl _System_Collections_Generic_LinkedListNode_1__ctor_System_Collections_Generic_LinkedList_1_T_T_System_Collections_Generic_LinkedListNode_1_T_System_Collections_Generic_LinkedListNode_1_T
bl _System_Collections_Generic_LinkedListNode_1_Detach
bl _System_Collections_Generic_LinkedListNode_1_SelfReference_System_Collections_Generic_LinkedList_1_T
bl _System_Collections_Generic_LinkedListNode_1_InsertBetween_System_Collections_Generic_LinkedListNode_1_T_System_Collections_Generic_LinkedListNode_1_T_System_Collections_Generic_LinkedList_1_T
bl _System_Collections_Generic_LinkedListNode_1_get_List
bl _System_Collections_Generic_LinkedListNode_1_get_Previous
bl _System_Collections_Generic_LinkedListNode_1_get_Value
bl _System_Collections_Generic_Stack_1__ctor
bl _System_Collections_Generic_Stack_1_Peek
bl _System_Collections_Generic_Stack_1_Pop
bl _System_Collections_Generic_Stack_1_Push_T
bl _System_Collections_Generic_Stack_1_get_Count
bl _System_Collections_Generic_Stack_1_System_Collections_ICollection_get_SyncRoot
bl _System_Collections_Generic_Stack_1_GetEnumerator
bl _System_Collections_Generic_Stack_1_System_Collections_Generic_IEnumerable_T_GetEnumerator
bl _System_Collections_Generic_Stack_1_System_Collections_IEnumerable_GetEnumerator
bl _System_Collections_Generic_Stack_1_Enumerator__ctor_System_Collections_Generic_Stack_1_T
bl _System_Collections_Generic_Stack_1_Enumerator_Dispose
bl _System_Collections_Generic_Stack_1_Enumerator_MoveNext
bl _System_Collections_Generic_Stack_1_Enumerator_get_Current
bl _System_Collections_Generic_Stack_1_Enumerator_System_Collections_IEnumerator_get_Current
bl _System_Collections_Specialized_StringDictionary__ctor
bl _System_Collections_Specialized_StringDictionary_GetEnumerator
bl _System_Diagnostics_CorrelationManager__ctor
bl _System_Diagnostics_Debug_Assert_bool_string
bl _System_Diagnostics_DefaultTraceListener__cctor
bl _System_Diagnostics_DefaultTraceListener__ctor
bl _System_Diagnostics_DefaultTraceListener_GetPrefix_string_string
bl _System_Diagnostics_DefaultTraceListener_get_AssertUiEnabled
bl _System_Diagnostics_DefaultTraceListener_get_LogFileName
bl _System_Diagnostics_DefaultTraceListener_Fail_string
bl _System_Diagnostics_DefaultTraceListener_Fail_string_string
bl _System_Diagnostics_DefaultTraceListener_ProcessUI_string_string
bl _wrapper_managed_to_native_System_Diagnostics_DefaultTraceListener_WriteWindowsDebugString_string
bl _System_Diagnostics_DefaultTraceListener_WriteDebugString_string
bl _System_Diagnostics_DefaultTraceListener_WriteMonoTrace_string
bl _System_Diagnostics_DefaultTraceListener_WritePrefix
bl _System_Diagnostics_DefaultTraceListener_WriteImpl_string
bl _System_Diagnostics_DefaultTraceListener_WriteLogFile_string_string
bl _System_Diagnostics_DefaultTraceListener_Write_string
bl _System_Diagnostics_DefaultTraceListener_WriteLine_string
bl _System_Diagnostics_TraceImpl_get_IndentLevel
bl _System_Diagnostics_TraceImpl_get_IndentSize
bl _System_Diagnostics_TraceImpl_get_Listeners
bl _System_Diagnostics_TraceImpl_get_ListenersSyncRoot
bl _System_Diagnostics_TraceImpl_InitOnce
bl _System_Diagnostics_TraceImpl_Assert_bool_string
bl _System_Diagnostics_TraceImpl_Fail_string
bl _System_Diagnostics_TraceImpl__cctor
bl _System_Diagnostics_TraceListener__ctor_string
bl _System_Diagnostics_TraceListener_get_IndentLevel
bl _System_Diagnostics_TraceListener_set_IndentLevel_int
bl _System_Diagnostics_TraceListener_get_IndentSize
bl _System_Diagnostics_TraceListener_set_IndentSize_int
bl _System_Diagnostics_TraceListener_set_Name_string
bl _System_Diagnostics_TraceListener_get_NeedIndent
bl _System_Diagnostics_TraceListener_set_NeedIndent_bool
bl _System_Diagnostics_TraceListener_Dispose
bl _System_Diagnostics_TraceListener_Dispose_bool
bl _System_Diagnostics_TraceListener_Fail_string
bl _System_Diagnostics_TraceListener_Fail_string_string
bl method_addresses
bl _System_Diagnostics_TraceListener_WriteIndent
bl method_addresses
bl _System_Diagnostics_TraceListenerCollection__ctor_bool
bl _System_Diagnostics_TraceListenerCollection_System_Collections_ICollection_get_SyncRoot
bl _System_Diagnostics_TraceListenerCollection_Add_System_Diagnostics_TraceListener
bl _System_Diagnostics_TraceListenerCollection_InitializeListener_System_Diagnostics_TraceListener
bl _System_Diagnostics_TraceListenerCollection_GetEnumerator
bl _System_Diagnostics_TraceListenerCollection_System_Collections_IList_Contains_object
bl method_addresses
bl _System_Collections_Generic_LinkedList_1__0__ctor
bl _System_Collections_Generic_LinkedList_1__0_VerifyReferencedNode_System_Collections_Generic_LinkedListNode_1__0
bl _System_Collections_Generic_LinkedList_1__0_VerifyBlankNode_System_Collections_Generic_LinkedListNode_1__0
bl _System_Collections_Generic_LinkedList_1__0_AddFirst_System_Collections_Generic_LinkedListNode_1__0
bl _System_Collections_Generic_LinkedList_1__0_AddLast__0
bl _System_Collections_Generic_LinkedList_1__0_Clear
bl _System_Collections_Generic_LinkedList_1__0_Contains__0
bl _System_Collections_Generic_LinkedList_1__0_CopyTo__0___int
bl _System_Collections_Generic_LinkedList_1__0_Find__0
bl _System_Collections_Generic_LinkedList_1__0_GetEnumerator
bl _System_Collections_Generic_LinkedList_1__0_Remove__0
bl _System_Collections_Generic_LinkedList_1__0_Remove_System_Collections_Generic_LinkedListNode_1__0
bl _System_Collections_Generic_LinkedList_1__0_RemoveLast
bl _System_Collections_Generic_LinkedList_1__0_System_Collections_Generic_ICollection_T_Add__0
bl _System_Collections_Generic_LinkedList_1__0_System_Collections_Generic_IEnumerable_T_GetEnumerator
bl _System_Collections_Generic_LinkedList_1__0_System_Collections_IEnumerable_GetEnumerator
bl _System_Collections_Generic_LinkedList_1__0_get_Count
bl _System_Collections_Generic_LinkedList_1__0_get_Last
bl _System_Collections_Generic_LinkedList_1__0_System_Collections_Generic_ICollection_T_get_IsReadOnly
bl _System_Collections_Generic_LinkedList_1__0_System_Collections_ICollection_get_SyncRoot
bl _System_Collections_Generic_LinkedList_1_Enumerator__0__ctor_System_Collections_Generic_LinkedList_1__0
bl _System_Collections_Generic_LinkedList_1_Enumerator__0_get_Current
bl _System_Collections_Generic_LinkedList_1_Enumerator__0_System_Collections_IEnumerator_get_Current
bl _System_Collections_Generic_LinkedList_1_Enumerator__0_MoveNext
bl _System_Collections_Generic_LinkedList_1_Enumerator__0_Dispose
bl _System_Collections_Generic_LinkedListNode_1__0__ctor__0
bl _System_Collections_Generic_LinkedListNode_1__0__ctor_System_Collections_Generic_LinkedList_1__0__0
bl _System_Collections_Generic_LinkedListNode_1__0__ctor_System_Collections_Generic_LinkedList_1__0__0_System_Collections_Generic_LinkedListNode_1__0_System_Collections_Generic_LinkedListNode_1__0
bl _System_Collections_Generic_LinkedListNode_1__0_Detach
bl _System_Collections_Generic_LinkedListNode_1__0_SelfReference_System_Collections_Generic_LinkedList_1__0
bl _System_Collections_Generic_LinkedListNode_1__0_InsertBetween_System_Collections_Generic_LinkedListNode_1__0_System_Collections_Generic_LinkedListNode_1__0_System_Collections_Generic_LinkedList_1__0
bl _System_Collections_Generic_LinkedListNode_1__0_get_List
bl _System_Collections_Generic_LinkedListNode_1__0_get_Previous
bl _System_Collections_Generic_LinkedListNode_1__0_get_Value
bl _System_Collections_Generic_Stack_1__0__ctor
bl _System_Collections_Generic_Stack_1__0_Peek
bl _System_Collections_Generic_Stack_1__0_Pop
bl _System_Collections_Generic_Stack_1__0_Push__0
bl _System_Collections_Generic_Stack_1__0_get_Count
bl _System_Collections_Generic_Stack_1__0_System_Collections_ICollection_get_SyncRoot
bl _System_Collections_Generic_Stack_1__0_GetEnumerator
bl _System_Collections_Generic_Stack_1__0_System_Collections_Generic_IEnumerable_T_GetEnumerator
bl _System_Collections_Generic_Stack_1__0_System_Collections_IEnumerable_GetEnumerator
bl _System_Collections_Generic_Stack_1_Enumerator__0__ctor_System_Collections_Generic_Stack_1__0
bl _System_Collections_Generic_Stack_1_Enumerator__0_Dispose
bl _System_Collections_Generic_Stack_1_Enumerator__0_MoveNext
bl _System_Collections_Generic_Stack_1_Enumerator__0_get_Current
bl _System_Collections_Generic_Stack_1_Enumerator__0_System_Collections_IEnumerator_get_Current
method_addresses_end:
.section __TEXT, __const
	.align 3
code_offsets:

	.long 0

.text
	.align 3
unbox_trampolines:

	.long 20
bl ut_20

	.long 21
bl ut_21

	.long 22
bl ut_22

	.long 23
bl ut_23

	.long 24
bl ut_24

	.long 43
bl ut_43

	.long 44
bl ut_44

	.long 45
bl ut_45

	.long 46
bl ut_46

	.long 47
bl ut_47

	.long 118
bl ut_118

	.long 119
bl ut_119

	.long 120
bl ut_120

	.long 121
bl ut_121

	.long 122
bl ut_122

	.long 141
bl ut_141

	.long 142
bl ut_142

	.long 143
bl ut_143

	.long 144
bl ut_144

	.long 145
bl ut_145
unbox_trampolines_end:

	.long 0
.section __TEXT, __const
	.align 3
method_info_offsets:

	.long 146,10,15,2
	.short 0, 10, 20, 30, 40, 50, 60, 71
	.short 82, 98, 114, 125, 136, 147, 158
	.byte 1,2,2,2,2,2,2,2,2,2,21,2,2,2,2,2,2,2,2,2,41,2,2,2,2,2,2,2,2,2,61,2
	.byte 2,2,2,2,2,2,2,2,81,2,2,2,2,2,2,2,2,3,102,3,2,17,4,4,3,3,3,4,128,166,5,4
	.byte 7,5,3,5,3,3,4,128,209,4,5,3,3,10,7,3,2,2,128,250,2,2,2,2,2,2,2,255,255,255,254,248
	.byte 129,14,0,129,16,4,2,2,4,2,255,255,255,254,226,129,33,2,129,37,2,2,2,2,2,2,2,2,2,129,57,2
	.byte 2,2,2,2,2,2,2,2,129,77,2,2,2,2,2,2,2,2,2,129,97,2,2,2,2,2,2,2,2,2,129,117
	.byte 2,2,2,2,2
.section __TEXT, __const
	.align 3
extra_method_table:

	.long 73,0,0,0,0,0,0,869
	.long 123,0,0,0,0,0,0,0
	.long 747,117,74,711,115,0,1164,139
	.long 0,477,102,82,808,120,75,826
	.long 121,0,693,114,84,675,113,0
	.long 0,0,0,0,0,0,0,0
	.long 0,0,0,0,495,103,73,0
	.long 0,0,0,0,0,0,0,0
	.long 0,0,0,0,0,0,0,0
	.long 0,0,0,0,905,125,77,459
	.long 101,76,0,0,0,0,0,0
	.long 567,107,80,0,0,0,0,0
	.long 0,549,106,79,1110,136,0,0
	.long 0,0,0,0,0,657,112,0
	.long 1243,143,0,959,128,0,1182,140
	.long 0,639,111,0,423,99,78,585
	.long 108,0,1092,135,0,0,0,0
	.long 513,104,0,603,109,0,0,0
	.long 0,729,116,0,0,0,0,941
	.long 127,0,621,110,0,385,60,0
	.long 405,98,0,0,0,0,0,0
	.long 0,0,0,0,0,0,0,0
	.long 0,0,0,0,0,1279,145,0
	.long 772,118,0,0,0,0,0,0
	.long 0,0,0,0,0,0,0,1056
	.long 133,0,0,0,0,0,0,0
	.long 441,100,81,0,0,0,977,129
	.long 0,1207,141,0,531,105,0,790
	.long 119,0,844,122,0,887,124,0
	.long 923,126,0,995,130,0,1013,131
	.long 0,1038,132,0,1074,134,0,1128
	.long 137,83,1146,138,0,1225,142,85
	.long 1261,144,0
.section __TEXT, __const
	.align 3
extra_method_info_offsets:

	.long 49,60,385,98,405,99,423,100
	.long 441,101,459,102,477,103,495,104
	.long 513,105,531,106,549,107,567,108
	.long 585,109,603,110,621,111,639,112
	.long 657,113,675,114,693,115,711,116
	.long 729,117,747,118,772,119,790,120
	.long 808,121,826,122,844,123,869,124
	.long 887,125,905,126,923,127,941,128
	.long 959,129,977,130,995,131,1013,132
	.long 1038,133,1056,134,1074,135,1092,136
	.long 1110,137,1128,138,1146,139,1164,140
	.long 1182,141,1207,142,1225,143,1243,144
	.long 1261,145,1279
.section __TEXT, __const
	.align 3
class_name_table:

	.short 37, 0, 0, 0, 0, 0, 0, 0
	.short 0, 2, 0, 0, 0, 0, 0, 0
	.short 0, 14, 0, 0, 0, 7, 0, 6
	.short 0, 0, 0, 12, 0, 0, 0, 0
	.short 0, 0, 0, 9, 0, 0, 0, 10
	.short 0, 0, 0, 13, 0, 11, 0, 4
	.short 0, 0, 0, 0, 0, 0, 0, 3
	.short 37, 15, 0, 0, 0, 0, 0, 1
	.short 0, 5, 0, 0, 0, 0, 0, 0
	.short 0, 0, 0, 8, 0
.section __TEXT, __const
	.align 3
got_info_offsets:

	.long 49,10,5,2
	.short 0, 11, 22, 33, 44
	.byte 133,17,2,1,1,1,4,4,7,4,4,133,49,4,7,4,4,4,4,4,4,4,133,92,4,7,7,4,4,4,4,4
	.byte 7,133,138,5,5,4,4,4,5,5,3,5,133,183,3,3,4,3,4,4,4,4
.section __TEXT, __const
	.align 3
ex_info_offsets:

	.long 146,10,15,2
	.short 0, 11, 22, 33, 44, 55, 66, 77
	.short 88, 104, 120, 131, 142, 153, 164
	.byte 153,182,26,26,26,26,26,26,26,26,26,154,186,26,26,26,26,27,27,26,26,26,155,192,27,26,26,26,33,26,27,27
	.byte 26,156,206,27,26,26,26,26,26,27,27,26,157,213,27,27,27,27,26,27,26,26,4,158,177,4,3,4,3,4,3,3
	.byte 3,4,158,225,4,3,4,3,4,27,3,3,4,159,28,4,4,4,3,23,3,4,3,3,159,82,3,3,3,3,4,3
	.byte 3,255,255,255,224,152,159,108,0,159,112,4,3,3,4,3,255,255,255,224,127,159,133,31,159,195,31,31,31,31,31,31
	.byte 31,31,31,160,249,31,31,31,31,31,31,31,31,31,162,47,31,31,31,31,31,31,31,31,31,163,101,31,31,31,31,31
	.byte 31,31,31,31,164,155,31,31,31,31,31
.section __TEXT, __const
	.align 3
unwind_info:

	.byte 18,12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24,20,12,13,0,72,14,8,135,2,68,14,16,136
	.byte 4,138,3,142,1,68,14,24,25,12,13,0,72,14,8,135,2,68,14,20,134,5,136,4,139,3,142,1,68,14,56,68
	.byte 13,11,26,12,13,0,72,14,8,135,2,68,14,28,133,7,134,6,136,5,138,4,139,3,142,1,68,14,80,22,12,13
	.byte 0,72,14,8,135,2,68,14,20,134,5,136,4,138,3,142,1,68,14,40,18,12,13,0,72,14,8,135,2,68,14,12
	.byte 136,3,142,1,68,14,64,18,12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,40,20,12,13,0,72,14
	.byte 8,135,2,68,14,16,134,4,136,3,142,1,68,14,24,18,12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68
	.byte 14,32,23,12,13,0,72,14,8,135,2,68,14,16,136,4,139,3,142,1,68,14,40,68,13,11,20,12,13,0,72,14
	.byte 8,135,2,68,14,16,132,4,136,3,142,1,68,14,32,18,12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68
	.byte 14,56,22,12,13,0,72,14,8,135,2,68,14,20,133,5,136,4,138,3,142,1,68,14,32,21,12,13,0,72,14,8
	.byte 135,2,68,14,24,133,6,134,5,136,4,138,3,142,1,20,12,13,0,72,14,8,135,2,68,14,16,133,4,136,3,142
	.byte 1,68,14,32,32,12,13,0,72,14,8,135,2,68,14,32,132,8,133,7,134,6,136,5,138,4,139,3,142,1,68,14
	.byte 128,1,68,13,11,33,12,13,0,72,14,8,135,2,72,14,48,132,12,133,11,134,10,136,8,137,7,138,6,139,5,140
	.byte 4,142,3,68,14,224,1,22,12,13,0,72,14,8,135,2,68,14,20,134,5,136,4,138,3,142,1,68,14,24,29,12
	.byte 13,0,72,14,8,135,2,68,14,28,132,7,133,6,134,5,136,4,139,3,142,1,68,14,88,68,13,11,18,12,13,0
	.byte 72,14,8,135,2,68,14,12,136,3,142,1,68,14,16,29,12,13,0,72,14,8,135,2,68,14,28,133,7,134,6,136
	.byte 5,138,4,139,3,142,1,68,14,96,68,13,11,20,12,13,0,72,14,8,135,2,68,14,16,134,4,136,3,142,1,68
	.byte 14,32,17,12,13,0,72,14,8,135,2,68,14,16,136,4,138,3,142,1,20,12,13,0,72,14,8,135,2,68,14,16
	.byte 133,4,136,3,142,1,68,14,24,20,12,13,0,72,14,8,135,2,68,14,16,136,4,138,3,142,1,68,14,32,22,12
	.byte 13,0,72,14,8,135,2,68,14,20,132,5,136,4,138,3,142,1,68,14,32,23,12,13,0,72,14,8,135,2,68,14
	.byte 16,136,4,139,3,142,1,68,14,32,68,13,11,27,12,13,0,72,14,8,135,2,68,14,24,134,6,136,5,138,4,139
	.byte 3,142,1,68,14,48,68,13,11,29,12,13,0,72,14,8,135,2,68,14,28,133,7,134,6,136,5,138,4,139,3,142
	.byte 1,68,14,72,68,13,11,25,12,13,0,72,14,8,135,2,68,14,20,136,5,138,4,139,3,142,1,68,14,40,68,13
	.byte 11,25,12,13,0,72,14,8,135,2,68,14,20,136,5,138,4,139,3,142,1,68,14,48,68,13,11,31,12,13,0,72
	.byte 14,8,135,2,68,14,32,132,8,133,7,134,6,136,5,138,4,139,3,142,1,68,14,88,68,13,11,29,12,13,0,72
	.byte 14,8,135,2,68,14,28,133,7,134,6,136,5,138,4,139,3,142,1,68,14,48,68,13,11,27,12,13,0,72,14,8
	.byte 135,2,68,14,24,133,6,134,5,136,4,139,3,142,1,68,14,48,68,13,11,27,12,13,0,72,14,8,135,2,68,14
	.byte 24,134,6,136,5,138,4,139,3,142,1,68,14,40,68,13,11,31,12,13,0,72,14,8,135,2,68,14,32,132,8,133
	.byte 7,134,6,136,5,138,4,139,3,142,1,68,14,48,68,13,11,25,12,13,0,72,14,8,135,2,68,14,20,136,5,138
	.byte 4,139,3,142,1,68,14,32,68,13,11,27,12,13,0,72,14,8,135,2,68,14,24,134,6,136,5,138,4,139,3,142
	.byte 1,68,14,32,68,13,11,27,12,13,0,72,14,8,135,2,68,14,24,133,6,134,5,136,4,139,3,142,1,68,14,40
	.byte 68,13,11,29,12,13,0,72,14,8,135,2,68,14,28,132,7,133,6,134,5,136,4,139,3,142,1,68,14,48,68,13
	.byte 11,25,12,13,0,72,14,8,135,2,68,14,20,134,5,136,4,139,3,142,1,68,14,40,68,13,11,25,12,13,0,72
	.byte 14,8,135,2,68,14,20,132,5,136,4,139,3,142,1,68,14,48,68,13,11,27,12,13,0,72,14,8,135,2,68,14
	.byte 24,133,6,134,5,136,4,139,3,142,1,68,14,32,68,13,11,25,12,13,0,72,14,8,135,2,68,14,20,136,5,138
	.byte 4,139,3,142,1,68,14,56,68,13,11,29,12,13,0,72,14,8,135,2,68,14,28,132,7,134,6,136,5,138,4,139
	.byte 3,142,1,68,14,48,68,13,11,29,12,13,0,72,14,8,135,2,68,14,28,132,7,133,6,134,5,136,4,139,3,142
	.byte 1,68,14,40,68,13,11
.section __TEXT, __const
	.align 3
class_info_offsets:

	.long 15,10,2,2
	.short 0, 11
	.byte 165,85,7,5,5,5,5,5,5,25,23,165,193,32,35,23,31

.text
	.align 4
plt:
_mono_aot_System_plt:
	.no_dead_strip plt_System_Collections_Generic_LinkedListNode_1_T_get_List
plt_System_Collections_Generic_LinkedListNode_1_T_get_List:
_p_1:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 196,1509
	.no_dead_strip plt__jit_icall_mono_helper_ldstr
plt__jit_icall_mono_helper_ldstr:
_p_2:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 200,1528
	.no_dead_strip plt__jit_icall_mono_arch_throw_exception
plt__jit_icall_mono_arch_throw_exception:
_p_3:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 204,1548
	.no_dead_strip plt__rgctx_fetch_0
plt__rgctx_fetch_0:
_p_4:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 208,1593
	.no_dead_strip plt_System_Collections_Generic_LinkedListNode_1_T_SelfReference_System_Collections_Generic_LinkedList_1_T
plt_System_Collections_Generic_LinkedListNode_1_T_SelfReference_System_Collections_Generic_LinkedList_1_T:
_p_5:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 212,1600
	.no_dead_strip plt_System_Collections_Generic_LinkedListNode_1_T_InsertBetween_System_Collections_Generic_LinkedListNode_1_T_System_Collections_Generic_LinkedListNode_1_T_System_Collections_Generic_LinkedList_1_T
plt_System_Collections_Generic_LinkedListNode_1_T_InsertBetween_System_Collections_Generic_LinkedListNode_1_T_System_Collections_Generic_LinkedListNode_1_T_System_Collections_Generic_LinkedList_1_T:
_p_6:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 216,1619
	.no_dead_strip plt__rgctx_fetch_1
plt__rgctx_fetch_1:
_p_7:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 220,1655
	.no_dead_strip plt__jit_icall_mono_object_new_specific
plt__jit_icall_mono_object_new_specific:
_p_8:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 224,1663
	.no_dead_strip plt_System_Collections_Generic_LinkedListNode_1_T__ctor_System_Collections_Generic_LinkedList_1_T_T
plt_System_Collections_Generic_LinkedListNode_1_T__ctor_System_Collections_Generic_LinkedList_1_T_T:
_p_9:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 228,1690
	.no_dead_strip plt_System_Collections_Generic_LinkedListNode_1_T__ctor_System_Collections_Generic_LinkedList_1_T_T_System_Collections_Generic_LinkedListNode_1_T_System_Collections_Generic_LinkedListNode_1_T
plt_System_Collections_Generic_LinkedListNode_1_T__ctor_System_Collections_Generic_LinkedList_1_T_T_System_Collections_Generic_LinkedListNode_1_T_System_Collections_Generic_LinkedListNode_1_T:
_p_10:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 232,1709
	.no_dead_strip plt_System_Collections_Generic_LinkedListNode_1_T_get_Value
plt_System_Collections_Generic_LinkedListNode_1_T_get_Value:
_p_11:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 236,1728
	.no_dead_strip plt__rgctx_fetch_2
plt__rgctx_fetch_2:
_p_12:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 240,1772
	.no_dead_strip plt__generic_class_init
plt__generic_class_init:
_p_13:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 244,1780
	.no_dead_strip plt_System_Collections_Generic_EqualityComparer_1_T_get_Default
plt_System_Collections_Generic_EqualityComparer_1_T_get_Default:
_p_14:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 248,1781
	.no_dead_strip plt__rgctx_fetch_3
plt__rgctx_fetch_3:
_p_15:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 252,1824
	.no_dead_strip plt_System_Collections_Generic_LinkedList_1_Enumerator_T__ctor_System_Collections_Generic_LinkedList_1_T
plt_System_Collections_Generic_LinkedList_1_Enumerator_T__ctor_System_Collections_Generic_LinkedList_1_T:
_p_16:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 256,1832
	.no_dead_strip plt_System_Collections_Generic_LinkedListNode_1_T_Detach
plt_System_Collections_Generic_LinkedListNode_1_T_Detach:
_p_17:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 260,1851
	.no_dead_strip plt__rgctx_fetch_4
plt__rgctx_fetch_4:
_p_18:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 264,1887
	.no_dead_strip plt__rgctx_fetch_5
plt__rgctx_fetch_5:
_p_19:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 268,1912
	.no_dead_strip plt_System_Collections_Generic_LinkedListNode_1_T_get_Value_0
plt_System_Collections_Generic_LinkedListNode_1_T_get_Value_0:
_p_20:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 272,1934
	.no_dead_strip plt__rgctx_fetch_6
plt__rgctx_fetch_6:
_p_21:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 276,1970
	.no_dead_strip plt__jit_icall_mono_arch_throw_corlib_exception
plt__jit_icall_mono_arch_throw_corlib_exception:
_p_22:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 280,1977
	.no_dead_strip plt__rgctx_fetch_7
plt__rgctx_fetch_7:
_p_23:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 284,2036
	.no_dead_strip plt_System_Array_Resize_T_T____int
plt_System_Array_Resize_T_T____int:
_p_24:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 288,2060
	.no_dead_strip plt__rgctx_fetch_8
plt__rgctx_fetch_8:
_p_25:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 292,2104
	.no_dead_strip plt_System_Collections_Generic_Stack_1_Enumerator_T__ctor_System_Collections_Generic_Stack_1_T
plt_System_Collections_Generic_Stack_1_Enumerator_T__ctor_System_Collections_Generic_Stack_1_T:
_p_26:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 296,2112
	.no_dead_strip plt__rgctx_fetch_9
plt__rgctx_fetch_9:
_p_27:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 300,2148
	.no_dead_strip plt__rgctx_fetch_10
plt__rgctx_fetch_10:
_p_28:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 304,2173
	.no_dead_strip plt__rgctx_fetch_11
plt__rgctx_fetch_11:
_p_29:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 308,2205
	.no_dead_strip plt__jit_icall_mono_object_new_fast
plt__jit_icall_mono_object_new_fast:
_p_30:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 312,2212
	.no_dead_strip plt_System_Collections_Hashtable__ctor
plt_System_Collections_Hashtable__ctor:
_p_31:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 316,2235
	.no_dead_strip plt_System_Collections_Stack__ctor
plt_System_Collections_Stack__ctor:
_p_32:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 320,2240
	.no_dead_strip plt__class_init_System_IO_Path
plt__class_init_System_IO_Path:
_p_33:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 324,2245
	.no_dead_strip plt_System_Environment_GetEnvironmentVariable_string
plt_System_Environment_GetEnvironmentVariable_string:
_p_34:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 328,2250
	.no_dead_strip plt_string_StartsWith_string
plt_string_StartsWith_string:
_p_35:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 332,2255
	.no_dead_strip plt_System_Diagnostics_DefaultTraceListener_GetPrefix_string_string
plt_System_Diagnostics_DefaultTraceListener_GetPrefix_string_string:
_p_36:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 336,2260
	.no_dead_strip plt_System_Diagnostics_TraceListener__ctor_string
plt_System_Diagnostics_TraceListener__ctor_string:
_p_37:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 340,2262
	.no_dead_strip plt_string_Substring_int
plt_string_Substring_int:
_p_38:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 344,2264
	.no_dead_strip plt_System_Diagnostics_TraceListener_Fail_string_string
plt_System_Diagnostics_TraceListener_Fail_string_string:
_p_39:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 348,2269
	.no_dead_strip plt_System_Diagnostics_DefaultTraceListener_ProcessUI_string_string
plt_System_Diagnostics_DefaultTraceListener_ProcessUI_string_string:
_p_40:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 352,2271
	.no_dead_strip plt_System_Threading_Thread_get_CurrentThread
plt_System_Threading_Thread_get_CurrentThread:
_p_41:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 356,2273
	.no_dead_strip plt_System_Threading_Thread_Abort
plt_System_Threading_Thread_Abort:
_p_42:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 360,2278
	.no_dead_strip plt_System_Diagnostics_StackTrace__ctor
plt_System_Diagnostics_StackTrace__ctor:
_p_43:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 364,2283
	.no_dead_strip plt_System_Diagnostics_DefaultTraceListener_get_AssertUiEnabled
plt_System_Diagnostics_DefaultTraceListener_get_AssertUiEnabled:
_p_44:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 368,2288
	.no_dead_strip plt_System_Reflection_Assembly_Load_string
plt_System_Reflection_Assembly_Load_string:
_p_45:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 372,2290
	.no_dead_strip plt_System_Reflection_Assembly_op_Equality_System_Reflection_Assembly_System_Reflection_Assembly
plt_System_Reflection_Assembly_op_Equality_System_Reflection_Assembly_System_Reflection_Assembly:
_p_46:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 376,2295
	.no_dead_strip plt_System_Enum_Parse_System_Type_string
plt_System_Enum_Parse_System_Type_string:
_p_47:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 380,2300
	.no_dead_strip plt__jit_icall_mono_array_new_specific
plt__jit_icall_mono_array_new_specific:
_p_48:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 384,2305
	.no_dead_strip plt_System_Type_GetMethod_string_System_Type__
plt_System_Type_GetMethod_string_System_Type__:
_p_49:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 388,2331
	.no_dead_strip plt__jit_icall_mono_thread_get_undeniable_exception
plt__jit_icall_mono_thread_get_undeniable_exception:
_p_50:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 392,2336
	.no_dead_strip plt_System_Reflection_MethodInfo_op_Equality_System_Reflection_MethodInfo_System_Reflection_MethodInfo
plt_System_Reflection_MethodInfo_op_Equality_System_Reflection_MethodInfo_System_Reflection_MethodInfo:
_p_51:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 396,2375
	.no_dead_strip plt_string_Format_string_object_object_object
plt_string_Format_string_object_object_object:
_p_52:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 400,2380
	.no_dead_strip plt_System_Environment_get_NewLine
plt_System_Environment_get_NewLine:
_p_53:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 404,2385
	.no_dead_strip plt_string_Format_string_object__
plt_string_Format_string_object__:
_p_54:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 408,2390
	.no_dead_strip plt_System_Reflection_MethodBase_Invoke_object_object__
plt_System_Reflection_MethodBase_Invoke_object_object__:
_p_55:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 412,2395
	.no_dead_strip plt_string_op_Equality_string_string
plt_string_op_Equality_string_string:
_p_56:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 416,2400
	.no_dead_strip plt__jit_icall_mono_thread_interruption_checkpoint
plt__jit_icall_mono_thread_interruption_checkpoint:
_p_57:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 420,2405
	.no_dead_strip plt_System_Diagnostics_DefaultTraceListener_WriteWindowsDebugString_string
plt_System_Diagnostics_DefaultTraceListener_WriteWindowsDebugString_string:
_p_58:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 424,2443
	.no_dead_strip plt_System_Diagnostics_DefaultTraceListener_WriteMonoTrace_string
plt_System_Diagnostics_DefaultTraceListener_WriteMonoTrace_string:
_p_59:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 428,2445
	.no_dead_strip plt_System_Console_get_Out
plt_System_Console_get_Out:
_p_60:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 432,2447
	.no_dead_strip plt_System_Console_get_Error
plt_System_Console_get_Error:
_p_61:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 436,2452
	.no_dead_strip plt_System_Diagnostics_DefaultTraceListener_WriteLogFile_string_string
plt_System_Diagnostics_DefaultTraceListener_WriteLogFile_string_string:
_p_62:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 440,2457
	.no_dead_strip plt_System_Diagnostics_DefaultTraceListener_WritePrefix
plt_System_Diagnostics_DefaultTraceListener_WritePrefix:
_p_63:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 444,2459
	.no_dead_strip plt_System_Diagnostics_DefaultTraceListener_WriteDebugString_string
plt_System_Diagnostics_DefaultTraceListener_WriteDebugString_string:
_p_64:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 448,2461
	.no_dead_strip plt_System_Diagnostics_Debugger_IsLogging
plt_System_Diagnostics_Debugger_IsLogging:
_p_65:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 452,2463
	.no_dead_strip plt_System_Diagnostics_Debugger_Log_int_string_string
plt_System_Diagnostics_Debugger_Log_int_string_string:
_p_66:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 456,2468
	.no_dead_strip plt_System_Diagnostics_DefaultTraceListener_get_LogFileName
plt_System_Diagnostics_DefaultTraceListener_get_LogFileName:
_p_67:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 460,2473
	.no_dead_strip plt_System_IO_FileInfo__ctor_string
plt_System_IO_FileInfo__ctor_string:
_p_68:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 464,2475
	.no_dead_strip plt_System_IO_FileInfo_AppendText
plt_System_IO_FileInfo_AppendText:
_p_69:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 468,2480
	.no_dead_strip plt_System_IO_FileInfo_CreateText
plt_System_IO_FileInfo_CreateText:
_p_70:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 472,2485
	.no_dead_strip plt_System_Diagnostics_DefaultTraceListener_WriteImpl_string
plt_System_Diagnostics_DefaultTraceListener_WriteImpl_string:
_p_71:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 476,2490
	.no_dead_strip plt_string_Concat_string_string
plt_string_Concat_string_string:
_p_72:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 480,2492
	.no_dead_strip plt__jit_icall_mono_class_static_field_address
plt__jit_icall_mono_class_static_field_address:
_p_73:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 484,2497
	.no_dead_strip plt__class_init_System_Diagnostics_TraceImpl
plt__class_init_System_Diagnostics_TraceImpl:
_p_74:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 488,2531
	.no_dead_strip plt_System_Diagnostics_TraceImpl_Fail_string
plt_System_Diagnostics_TraceImpl_Fail_string:
_p_75:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 492,2534
	.no_dead_strip plt_System_Diagnostics_TraceImpl_get_ListenersSyncRoot
plt_System_Diagnostics_TraceImpl_get_ListenersSyncRoot:
_p_76:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 496,2536
	.no_dead_strip plt_System_Threading_Monitor_Enter_object_bool_
plt_System_Threading_Monitor_Enter_object_bool_:
_p_77:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 500,2538
	.no_dead_strip plt_System_Threading_Monitor_Exit_object
plt_System_Threading_Monitor_Exit_object:
_p_78:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 504,2543
	.no_dead_strip plt_System_Diagnostics_TraceListenerCollection__ctor_bool
plt_System_Diagnostics_TraceListenerCollection__ctor_bool:
_p_79:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 508,2548
	.no_dead_strip plt_System_Diagnostics_CorrelationManager__ctor
plt_System_Diagnostics_CorrelationManager__ctor:
_p_80:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 512,2550
	.no_dead_strip plt_System_Collections_Specialized_StringDictionary__ctor
plt_System_Collections_Specialized_StringDictionary__ctor:
_p_81:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 516,2552
	.no_dead_strip plt_System_GC_SuppressFinalize_object
plt_System_GC_SuppressFinalize_object:
_p_82:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 520,2554
	.no_dead_strip plt_string__ctor_char_int
plt_string__ctor_char_int:
_p_83:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 524,2559
	.no_dead_strip plt_System_Collections_ArrayList__ctor_int
plt_System_Collections_ArrayList__ctor_int:
_p_84:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 528,2564
	.no_dead_strip plt_System_Collections_ArrayList_Synchronized_System_Collections_ArrayList
plt_System_Collections_ArrayList_Synchronized_System_Collections_ArrayList:
_p_85:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 532,2569
	.no_dead_strip plt__class_init_System_Diagnostics_DefaultTraceListener
plt__class_init_System_Diagnostics_DefaultTraceListener:
_p_86:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 536,2574
	.no_dead_strip plt_System_Diagnostics_DefaultTraceListener__ctor
plt_System_Diagnostics_DefaultTraceListener__ctor:
_p_87:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 540,2577
	.no_dead_strip plt_System_Diagnostics_TraceListenerCollection_InitializeListener_System_Diagnostics_TraceListener
plt_System_Diagnostics_TraceListenerCollection_InitializeListener_System_Diagnostics_TraceListener:
_p_88:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 544,2579
	.no_dead_strip plt__rgctx_fetch_12
plt__rgctx_fetch_12:
_p_89:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 548,2599
	.no_dead_strip plt__rgctx_fetch_13
plt__rgctx_fetch_13:
_p_90:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 552,2643
	.no_dead_strip plt__rgctx_fetch_14
plt__rgctx_fetch_14:
_p_91:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 556,2669
	.no_dead_strip plt__rgctx_fetch_15
plt__rgctx_fetch_15:
_p_92:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 560,2721
	.no_dead_strip plt__rgctx_fetch_16
plt__rgctx_fetch_16:
_p_93:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 564,2747
	.no_dead_strip plt__rgctx_fetch_17
plt__rgctx_fetch_17:
_p_94:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 568,2799
	.no_dead_strip plt__rgctx_fetch_18
plt__rgctx_fetch_18:
_p_95:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 572,2845
	.no_dead_strip plt__rgctx_fetch_19
plt__rgctx_fetch_19:
_p_96:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 576,2853
	.no_dead_strip plt__rgctx_fetch_20
plt__rgctx_fetch_20:
_p_97:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 580,2888
	.no_dead_strip plt__rgctx_fetch_21
plt__rgctx_fetch_21:
_p_98:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 584,2923
	.no_dead_strip plt__rgctx_fetch_22
plt__rgctx_fetch_22:
_p_99:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 588,2990
	.no_dead_strip plt__rgctx_fetch_23
plt__rgctx_fetch_23:
_p_100:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 592,3036
	.no_dead_strip plt__rgctx_fetch_24
plt__rgctx_fetch_24:
_p_101:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 596,3044
	.no_dead_strip plt__rgctx_fetch_25
plt__rgctx_fetch_25:
_p_102:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 600,3083
	.no_dead_strip plt__rgctx_fetch_26
plt__rgctx_fetch_26:
_p_103:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 604,3154
	.no_dead_strip plt__rgctx_fetch_27
plt__rgctx_fetch_27:
_p_104:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 608,3185
	.no_dead_strip plt__rgctx_fetch_28
plt__rgctx_fetch_28:
_p_105:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 612,3238
	.no_dead_strip plt__rgctx_fetch_29
plt__rgctx_fetch_29:
_p_106:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 616,3264
	.no_dead_strip plt__rgctx_fetch_30
plt__rgctx_fetch_30:
_p_107:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 620,3320
	.no_dead_strip plt__rgctx_fetch_31
plt__rgctx_fetch_31:
_p_108:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 624,3377
	.no_dead_strip plt__rgctx_fetch_32
plt__rgctx_fetch_32:
_p_109:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 628,3426
	.no_dead_strip plt__rgctx_fetch_33
plt__rgctx_fetch_33:
_p_110:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 632,3470
	.no_dead_strip plt__rgctx_fetch_34
plt__rgctx_fetch_34:
_p_111:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 636,3509
	.no_dead_strip plt__rgctx_fetch_35
plt__rgctx_fetch_35:
_p_112:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 640,3517
	.no_dead_strip plt__rgctx_fetch_36
plt__rgctx_fetch_36:
_p_113:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 644,3552
	.no_dead_strip plt__rgctx_fetch_37
plt__rgctx_fetch_37:
_p_114:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 648,3606
	.no_dead_strip plt__rgctx_fetch_38
plt__rgctx_fetch_38:
_p_115:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 652,3652
	.no_dead_strip plt__rgctx_fetch_39
plt__rgctx_fetch_39:
_p_116:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 656,3660
	.no_dead_strip plt__rgctx_fetch_40
plt__rgctx_fetch_40:
_p_117:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 660,3713
	.no_dead_strip plt__rgctx_fetch_41
plt__rgctx_fetch_41:
_p_118:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 664,3739
	.no_dead_strip plt__rgctx_fetch_42
plt__rgctx_fetch_42:
_p_119:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 668,3777
	.no_dead_strip plt__rgctx_fetch_43
plt__rgctx_fetch_43:
_p_120:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 672,3830
	.no_dead_strip plt__rgctx_fetch_44
plt__rgctx_fetch_44:
_p_121:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 676,3876
	.no_dead_strip plt__rgctx_fetch_45
plt__rgctx_fetch_45:
_p_122:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 680,3911
	.no_dead_strip plt__rgctx_fetch_46
plt__rgctx_fetch_46:
_p_123:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 684,3957
	.no_dead_strip plt__rgctx_fetch_47
plt__rgctx_fetch_47:
_p_124:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 688,3993
	.no_dead_strip plt__rgctx_fetch_48
plt__rgctx_fetch_48:
_p_125:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 692,4046
	.no_dead_strip plt__rgctx_fetch_49
plt__rgctx_fetch_49:
_p_126:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 696,4072
	.no_dead_strip plt__rgctx_fetch_50
plt__rgctx_fetch_50:
_p_127:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 700,4128
	.no_dead_strip plt__rgctx_fetch_51
plt__rgctx_fetch_51:
_p_128:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 704,4174
	.no_dead_strip plt__rgctx_fetch_52
plt__rgctx_fetch_52:
_p_129:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 708,4208
	.no_dead_strip plt__rgctx_fetch_53
plt__rgctx_fetch_53:
_p_130:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 712,4234
	.no_dead_strip plt__rgctx_fetch_54
plt__rgctx_fetch_54:
_p_131:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 716,4280
	.no_dead_strip plt__rgctx_fetch_55
plt__rgctx_fetch_55:
_p_132:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 720,4314
	.no_dead_strip plt__rgctx_fetch_56
plt__rgctx_fetch_56:
_p_133:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 724,4340
	.no_dead_strip plt__rgctx_fetch_57
plt__rgctx_fetch_57:
_p_134:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 728,4389
	.no_dead_strip plt__rgctx_fetch_58
plt__rgctx_fetch_58:
_p_135:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 732,4443
	.no_dead_strip plt__rgctx_fetch_59
plt__rgctx_fetch_59:
_p_136:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 736,4487
	.no_dead_strip plt__rgctx_fetch_60
plt__rgctx_fetch_60:
_p_137:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 740,4531
	.no_dead_strip plt__rgctx_fetch_61
plt__rgctx_fetch_61:
_p_138:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 744,4600
	.no_dead_strip plt__rgctx_fetch_62
plt__rgctx_fetch_62:
_p_139:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 748,4648
	.no_dead_strip plt__rgctx_fetch_63
plt__rgctx_fetch_63:
_p_140:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 752,4697
	.no_dead_strip plt__rgctx_fetch_64
plt__rgctx_fetch_64:
_p_141:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 756,4743
	.no_dead_strip plt__rgctx_fetch_65
plt__rgctx_fetch_65:
_p_142:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 760,4751
	.no_dead_strip plt__rgctx_fetch_66
plt__rgctx_fetch_66:
_p_143:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 764,4782
	.no_dead_strip plt__rgctx_fetch_67
plt__rgctx_fetch_67:
_p_144:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 768,4808
	.no_dead_strip plt__rgctx_fetch_68
plt__rgctx_fetch_68:
_p_145:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 772,4887
	.no_dead_strip plt__rgctx_fetch_69
plt__rgctx_fetch_69:
_p_146:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 776,4941
	.no_dead_strip plt__rgctx_fetch_70
plt__rgctx_fetch_70:
_p_147:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 780,4998
	.no_dead_strip plt__rgctx_fetch_71
plt__rgctx_fetch_71:
_p_148:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 784,5070
	.no_dead_strip plt__rgctx_fetch_72
plt__rgctx_fetch_72:
_p_149:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 788,5142
	.no_dead_strip plt__rgctx_fetch_73
plt__rgctx_fetch_73:
_p_150:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 792,5201
	.no_dead_strip plt__rgctx_fetch_74
plt__rgctx_fetch_74:
_p_151:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 796,5260
	.no_dead_strip plt__rgctx_fetch_75
plt__rgctx_fetch_75:
_p_152:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 800,5319
	.no_dead_strip plt__rgctx_fetch_76
plt__rgctx_fetch_76:
_p_153:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 804,5368
	.no_dead_strip plt__rgctx_fetch_77
plt__rgctx_fetch_77:
_p_154:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 808,5427
	.no_dead_strip plt__rgctx_fetch_78
plt__rgctx_fetch_78:
_p_155:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 812,5488
	.no_dead_strip plt__rgctx_fetch_79
plt__rgctx_fetch_79:
_p_156:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 816,5532
	.no_dead_strip plt__rgctx_fetch_80
plt__rgctx_fetch_80:
_p_157:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 820,5602
	.no_dead_strip plt__rgctx_fetch_81
plt__rgctx_fetch_81:
_p_158:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 824,5689
	.no_dead_strip plt__rgctx_fetch_82
plt__rgctx_fetch_82:
_p_159:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 828,5742
	.no_dead_strip plt__rgctx_fetch_83
plt__rgctx_fetch_83:
_p_160:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 832,5766
	.no_dead_strip plt__rgctx_fetch_84
plt__rgctx_fetch_84:
_p_161:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 836,5820
	.no_dead_strip plt__rgctx_fetch_85
plt__rgctx_fetch_85:
_p_162:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 840,5869
	.no_dead_strip plt__rgctx_fetch_86
plt__rgctx_fetch_86:
_p_163:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 844,5913
	.no_dead_strip plt__rgctx_fetch_87
plt__rgctx_fetch_87:
_p_164:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 848,5959
	.no_dead_strip plt__rgctx_fetch_88
plt__rgctx_fetch_88:
_p_165:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 852,5967
	.no_dead_strip plt__rgctx_fetch_89
plt__rgctx_fetch_89:
_p_166:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 856,6020
	.no_dead_strip plt__rgctx_fetch_90
plt__rgctx_fetch_90:
_p_167:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 860,6066
	.no_dead_strip plt__rgctx_fetch_91
plt__rgctx_fetch_91:
_p_168:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 864,6100
	.no_dead_strip plt__rgctx_fetch_92
plt__rgctx_fetch_92:
_p_169:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 868,6126
	.no_dead_strip plt__rgctx_fetch_93
plt__rgctx_fetch_93:
_p_170:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 872,6172
	.no_dead_strip plt__rgctx_fetch_94
plt__rgctx_fetch_94:
_p_171:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 876,6206
	.no_dead_strip plt__rgctx_fetch_95
plt__rgctx_fetch_95:
_p_172:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 880,6232
	.no_dead_strip plt__rgctx_fetch_96
plt__rgctx_fetch_96:
_p_173:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 884,6296
	.no_dead_strip plt__rgctx_fetch_97
plt__rgctx_fetch_97:
_p_174:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 888,6345
	.no_dead_strip plt__rgctx_fetch_98
plt__rgctx_fetch_98:
_p_175:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 892,6414
	.no_dead_strip plt__rgctx_fetch_99
plt__rgctx_fetch_99:
_p_176:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 896,6489
	.no_dead_strip plt__rgctx_fetch_100
plt__rgctx_fetch_100:
_p_177:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 900,6535
	.no_dead_strip plt__rgctx_fetch_101
plt__rgctx_fetch_101:
_p_178:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 904,6543
	.no_dead_strip plt__rgctx_fetch_102
plt__rgctx_fetch_102:
_p_179:

	.byte 0,192,159,229,12,240,159,231
	.long _mono_aot_System_got - . + 908,6574
plt_end:
.section __TEXT, __const
	.align 3
image_table:

	.long 2
	.asciz "System"
	.asciz "C8DE3713-CD79-45EA-AC4F-F9AC120643F0"
	.asciz ""
	.asciz "7cec85d7bea7798e"
	.align 3

	.long 1,2,0,5,0
	.asciz "mscorlib"
	.asciz "6B3E8066-599B-4D3F-90DF-C69F0383CE36"
	.asciz ""
	.asciz "7cec85d7bea7798e"
	.align 3

	.long 1,2,0,5,0
.data
	.align 3
_mono_aot_System_got:
	.space 916
got_end:
.section __TEXT, __const
	.align 2
assembly_guid:
	.asciz "C8DE3713-CD79-45EA-AC4F-F9AC120643F0"
.section __TEXT, __const
	.align 2
runtime_version:
	.asciz ""
.section __TEXT, __const
	.align 2
assembly_name:
	.asciz "System"
.data
	.align 3
_mono_aot_file_info:

	.long 100,0
	.align 2
	.long _mono_aot_System_got
	.align 2
	.long methods
	.align 2
	.long 0
	.align 2
	.long blob
	.align 2
	.long class_name_table
	.align 2
	.long class_info_offsets
	.align 2
	.long method_info_offsets
	.align 2
	.long ex_info_offsets
	.align 2
	.long code_offsets
	.align 2
	.long method_addresses
	.align 2
	.long extra_method_info_offsets
	.align 2
	.long extra_method_table
	.align 2
	.long got_info_offsets
	.align 2
	.long methods_end
	.align 2
	.long unwind_info
	.align 2
	.long mem_end
	.align 2
	.long image_table
	.align 2
	.long plt
	.align 2
	.long plt_end
	.align 2
	.long assembly_guid
	.align 2
	.long runtime_version
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long 0
	.align 2
	.long globals
	.align 2
	.long assembly_name
	.align 2
	.long unbox_trampolines
	.align 2
	.long unbox_trampolines_end

	.long 49,916,180,146,10,387000831,0,9812
	.long 0,0,0,0,0,0,0,0
	.long 0,0,0,0,128,4,4,14
	.long 0,0,0,0,0
	.globl _mono_aot_module_System_info
	.align 2
_mono_aot_module_System_info:
	.align 2
	.long _mono_aot_file_info
.section __TEXT, __const
	.align 3
blob:

	.byte 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	.byte 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	.byte 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	.byte 0,0,1,4,0,0,0,1,5,0,0,1,11,14,6,7,7,8,9,9,9,9,10,10,10,11,12,13,1,11,1,14
	.byte 1,11,1,11,1,11,0,1,11,0,1,11,0,1,11,1,15,1,11,18,16,17,18,19,20,21,22,22,23,24,25,26
	.byte 27,28,15,28,26,24,1,11,2,3,29,1,11,1,7,1,11,4,12,9,10,12,1,11,2,7,13,1,11,0,1,11
	.byte 2,30,31,1,11,0,1,11,0,1,13,1,32,1,13,1,33,1,13,1,34,1,13,2,34,35,1,13,0,1,13,0
	.byte 1,13,7,34,36,37,38,39,39,31,1,13,4,40,34,41,42,0,1,43,0,0,0,0,0,0,0,0,0,0,0,0
	.byte 0,0,0,0,0,0,0,0,0,4,44,45,46,11,0,0,0,2,47,48,0,0,0,0,0,2,32,33,0,0,0,1
	.byte 37,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	.byte 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	.byte 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	.byte 0,255,252,0,0,0,6,0,61,5,19,0,0,1,4,1,3,1,7,129,137,255,253,0,0,0,7,129,142,0,198,0
	.byte 0,1,1,7,129,137,0,255,253,0,0,0,7,129,142,0,198,0,0,2,1,7,129,137,0,255,253,0,0,0,7,129
	.byte 142,0,198,0,0,3,1,7,129,137,0,255,253,0,0,0,7,129,142,0,198,0,0,4,1,7,129,137,0,255,253,0
	.byte 0,0,7,129,142,0,198,0,0,5,1,7,129,137,0,255,253,0,0,0,7,129,142,0,198,0,0,6,1,7,129,137
	.byte 0,255,253,0,0,0,7,129,142,0,198,0,0,7,1,7,129,137,0,255,253,0,0,0,7,129,142,0,198,0,0,8
	.byte 1,7,129,137,0,255,253,0,0,0,7,129,142,0,198,0,0,9,1,7,129,137,0,255,253,0,0,0,7,129,142,0
	.byte 198,0,0,10,1,7,129,137,0,255,253,0,0,0,7,129,142,0,198,0,0,11,1,7,129,137,0,255,253,0,0,0
	.byte 7,129,142,0,198,0,0,12,1,7,129,137,0,255,253,0,0,0,7,129,142,0,198,0,0,13,1,7,129,137,0,255
	.byte 253,0,0,0,7,129,142,0,198,0,0,14,1,7,129,137,0,255,253,0,0,0,7,129,142,0,198,0,0,15,1,7
	.byte 129,137,0,255,253,0,0,0,7,129,142,0,198,0,0,16,1,7,129,137,0,255,253,0,0,0,7,129,142,0,198,0
	.byte 0,17,1,7,129,137,0,255,253,0,0,0,7,129,142,0,198,0,0,18,1,7,129,137,0,255,253,0,0,0,7,129
	.byte 142,0,198,0,0,19,1,7,129,137,0,255,253,0,0,0,7,129,142,0,198,0,0,20,1,7,129,137,0,4,1,4
	.byte 1,7,129,137,255,253,0,0,0,7,130,253,0,198,0,0,21,1,7,129,137,0,255,253,0,0,0,7,130,253,0,198
	.byte 0,0,22,1,7,129,137,0,255,253,0,0,0,7,130,253,0,198,0,0,23,1,7,129,137,0,255,253,0,0,0,7
	.byte 130,253,0,198,0,0,24,1,7,129,137,0,255,253,0,0,0,7,130,253,0,198,0,0,25,1,7,129,137,0,4,1
	.byte 5,1,7,129,137,255,253,0,0,0,7,131,94,0,198,0,0,26,1,7,129,137,0,255,253,0,0,0,7,131,94,0
	.byte 198,0,0,27,1,7,129,137,0,255,253,0,0,0,7,131,94,0,198,0,0,28,1,7,129,137,0,255,253,0,0,0
	.byte 7,131,94,0,198,0,0,29,1,7,129,137,0,255,253,0,0,0,7,131,94,0,198,0,0,30,1,7,129,137,0,255
	.byte 253,0,0,0,7,131,94,0,198,0,0,31,1,7,129,137,0,255,253,0,0,0,7,131,94,0,198,0,0,32,1,7
	.byte 129,137,0,255,253,0,0,0,7,131,94,0,198,0,0,33,1,7,129,137,0,255,253,0,0,0,7,131,94,0,198,0
	.byte 0,34,1,7,129,137,0,4,1,6,1,7,129,137,255,253,0,0,0,7,132,7,0,198,0,0,35,1,7,129,137,0
	.byte 255,253,0,0,0,7,132,7,0,198,0,0,36,1,7,129,137,0,255,253,0,0,0,7,132,7,0,198,0,0,37,1
	.byte 7,129,137,0,255,253,0,0,0,7,132,7,0,198,0,0,38,1,7,129,137,0,255,253,0,0,0,7,132,7,0,198
	.byte 0,0,39,1,7,129,137,0,255,253,0,0,0,7,132,7,0,198,0,0,40,1,7,129,137,0,255,253,0,0,0,7
	.byte 132,7,0,198,0,0,41,1,7,129,137,0,255,253,0,0,0,7,132,7,0,198,0,0,42,1,7,129,137,0,255,253
	.byte 0,0,0,7,132,7,0,198,0,0,43,1,7,129,137,0,4,1,7,1,7,129,137,255,253,0,0,0,7,132,176,0
	.byte 198,0,0,44,1,7,129,137,0,255,253,0,0,0,7,132,176,0,198,0,0,45,1,7,129,137,0,255,253,0,0,0
	.byte 7,132,176,0,198,0,0,46,1,7,129,137,0,255,253,0,0,0,7,132,176,0,198,0,0,47,1,7,129,137,0,255
	.byte 253,0,0,0,7,132,176,0,198,0,0,48,1,7,129,137,0,12,0,39,42,47,14,2,71,1,14,2,91,1,16,2
	.byte 128,144,1,130,108,16,1,11,20,17,0,128,197,17,0,128,237,17,0,129,5,16,2,130,47,1,135,101,16,1,11,22
	.byte 16,1,11,21,17,0,129,33,14,2,102,1,17,0,129,49,17,0,129,226,17,0,130,48,17,0,130,82,17,0,130,146
	.byte 14,6,1,2,130,58,1,19,0,193,0,0,24,0,17,0,130,156,17,0,131,22,17,0,131,34,17,0,131,46,17,0
	.byte 131,60,14,6,1,2,130,27,1,33,14,2,128,128,1,6,193,0,10,33,13,1,13,30,13,1,13,31,16,1,13,32
	.byte 6,193,0,1,168,6,193,0,1,171,11,1,14,6,193,0,1,172,23,2,129,246,1,14,1,15,14,1,9,16,1,13
	.byte 33,14,1,8,17,0,131,98,17,0,131,164,17,0,131,226,14,2,64,1,14,1,11,5,19,0,1,0,1,3,4,1
	.byte 5,1,7,133,215,3,255,253,0,0,0,7,133,222,0,198,0,0,32,1,7,133,215,0,7,17,109,111,110,111,95,104
	.byte 101,108,112,101,114,95,108,100,115,116,114,0,7,25,109,111,110,111,95,97,114,99,104,95,116,104,114,111,119,95,101,120
	.byte 99,101,112,116,105,111,110,0,255,253,0,0,0,1,3,0,198,0,0,4,1,7,133,215,0,35,134,40,150,4,1,3
	.byte 3,255,253,0,0,0,7,133,222,0,198,0,0,30,1,7,133,215,0,3,255,253,0,0,0,7,133,222,0,198,0,0
	.byte 31,1,7,133,215,0,255,253,0,0,0,1,3,0,198,0,0,5,1,7,133,215,0,35,134,102,150,4,7,133,222,7
	.byte 24,109,111,110,111,95,111,98,106,101,99,116,95,110,101,119,95,115,112,101,99,105,102,105,99,0,3,255,253,0,0,0
	.byte 7,133,222,0,198,0,0,27,1,7,133,215,0,3,255,253,0,0,0,7,133,222,0,198,0,0,28,1,7,133,215,0
	.byte 3,255,253,0,0,0,7,133,222,0,198,0,0,34,1,7,133,215,0,255,253,0,0,0,1,3,0,198,0,0,9,1
	.byte 7,133,215,0,4,2,42,1,1,7,133,215,35,134,211,150,4,7,134,228,36,3,255,253,0,0,0,7,134,228,1,198
	.byte 0,1,3,1,7,133,215,0,255,253,0,0,0,1,3,0,198,0,0,10,1,7,133,215,0,4,1,4,1,7,133,215
	.byte 35,135,8,150,4,7,135,25,3,255,253,0,0,0,7,135,25,0,198,0,0,21,1,7,133,215,0,3,255,253,0,0
	.byte 0,7,133,222,0,198,0,0,29,1,7,133,215,0,255,253,0,0,0,1,3,0,198,0,0,15,1,7,133,215,0,35
	.byte 135,78,150,4,7,135,25,255,253,0,0,0,1,3,0,198,0,0,16,1,7,133,215,0,35,135,103,150,4,7,135,25
	.byte 5,19,0,1,0,1,4,4,1,5,1,7,135,128,3,255,253,0,0,0,7,135,135,0,198,0,0,34,1,7,135,128
	.byte 0,255,253,0,0,0,1,4,0,198,0,0,23,1,7,135,128,0,35,135,161,150,4,1,4,7,32,109,111,110,111,95
	.byte 97,114,99,104,95,116,104,114,111,119,95,99,111,114,108,105,98,95,101,120,99,101,112,116,105,111,110,0,5,19,0,1
	.byte 0,1,6,255,253,0,0,0,1,6,0,198,0,0,38,1,7,135,220,0,35,135,227,140,16,255,253,0,0,0,2,129
	.byte 172,1,1,198,0,8,149,0,1,7,135,220,3,255,253,0,0,0,2,129,172,1,1,198,0,8,149,0,1,7,135,220
	.byte 255,253,0,0,0,1,6,0,198,0,0,41,1,7,135,220,0,4,1,7,1,7,135,220,35,136,32,150,4,7,136,49
	.byte 3,255,253,0,0,0,7,136,49,0,198,0,0,44,1,7,135,220,0,255,253,0,0,0,1,6,0,198,0,0,42,1
	.byte 7,135,220,0,35,136,83,150,4,7,136,49,255,253,0,0,0,1,6,0,198,0,0,43,1,7,135,220,0,35,136,108
	.byte 150,4,7,136,49,5,19,0,1,0,1,7,255,253,0,0,0,1,7,0,198,0,0,48,1,7,136,133,0,35,136,140
	.byte 150,4,1,7,7,20,109,111,110,111,95,111,98,106,101,99,116,95,110,101,119,95,102,97,115,116,0,3,193,0,1,151
	.byte 3,193,0,1,194,15,2,128,144,1,3,193,0,9,208,3,193,0,11,200,3,55,3,77,3,193,0,11,166,3,88,3
	.byte 60,3,193,0,7,164,3,193,0,7,173,3,193,0,1,218,3,56,3,193,0,3,195,3,193,0,3,204,3,193,0,9
	.byte 178,7,23,109,111,110,111,95,97,114,114,97,121,95,110,101,119,95,115,112,101,99,105,102,105,99,0,3,193,0,12,128
	.byte 7,36,109,111,110,111,95,116,104,114,101,97,100,95,103,101,116,95,117,110,100,101,110,105,97,98,108,101,95,101,120,99
	.byte 101,112,116,105,111,110,0,3,193,0,4,112,3,193,0,11,212,3,193,0,9,204,3,193,0,11,213,3,193,0,4,85
	.byte 3,193,0,11,156,7,35,109,111,110,111,95,116,104,114,101,97,100,95,105,110,116,101,114,114,117,112,116,105,111,110,95
	.byte 99,104,101,99,107,112,111,105,110,116,0,3,61,3,63,3,193,0,8,254,3,193,0,8,253,3,66,3,64,3,62,3
	.byte 193,0,1,201,3,193,0,1,202,3,57,3,193,0,2,163,3,193,0,2,167,3,193,0,2,166,3,65,3,193,0,11
	.byte 218,7,31,109,111,110,111,95,99,108,97,115,115,95,115,116,97,116,105,99,95,102,105,101,108,100,95,97,100,100,114,101
	.byte 115,115,0,15,1,13,3,75,3,72,3,193,0,7,130,3,193,0,7,128,3,92,3,51,3,49,3,193,0,10,26,3
	.byte 193,0,11,154,3,193,0,1,108,3,193,0,1,119,15,1,11,3,54,3,95,255,253,0,0,0,7,129,142,0,198,0
	.byte 0,1,1,7,129,137,0,35,138,21,192,0,92,40,255,253,0,0,0,7,129,142,0,198,0,0,1,1,7,129,137,0
	.byte 0,255,253,0,0,0,7,129,142,0,198,0,0,2,1,7,129,137,0,35,138,65,192,0,92,40,255,253,0,0,0,7
	.byte 129,142,0,198,0,0,2,1,7,129,137,0,0,35,138,65,192,0,90,32,32,0,21,1,3,1,7,129,137,255,253,0
	.byte 0,0,7,131,94,0,198,0,0,32,1,7,129,137,0,255,253,0,0,0,7,129,142,0,198,0,0,3,1,7,129,137
	.byte 0,35,138,143,192,0,92,40,255,253,0,0,0,7,129,142,0,198,0,0,3,1,7,129,137,0,0,35,138,143,192,0
	.byte 90,32,32,0,21,1,3,1,7,129,137,255,253,0,0,0,7,131,94,0,198,0,0,32,1,7,129,137,0,255,253,0
	.byte 0,0,7,129,142,0,198,0,0,4,1,7,129,137,0,35,138,221,192,0,92,40,255,253,0,0,0,7,129,142,0,198
	.byte 0,0,4,1,7,129,137,0,4,15,7,129,142,3,15,7,131,94,11,15,7,129,142,1,15,7,129,142,2,35,138,221
	.byte 150,4,7,129,142,35,138,221,192,0,90,32,0,1,1,21,1,5,1,7,129,137,255,253,0,0,0,7,129,142,0,198
	.byte 0,0,3,1,7,129,137,0,35,138,221,192,0,90,32,32,1,1,21,1,3,1,7,129,137,255,253,0,0,0,7,131
	.byte 94,0,198,0,0,30,1,7,129,137,0,35,138,221,192,0,90,32,32,3,1,21,1,5,1,7,129,137,21,1,5,1
	.byte 7,129,137,21,1,3,1,7,129,137,255,253,0,0,0,7,131,94,0,198,0,0,31,1,7,129,137,0,255,253,0,0
	.byte 0,7,129,142,0,198,0,0,5,1,7,129,137,0,35,139,156,192,0,92,40,255,253,0,0,0,7,129,142,0,198,0
	.byte 0,5,1,7,129,137,0,4,15,7,129,142,3,15,7,131,94,11,15,7,129,142,1,15,7,129,142,2,35,139,156,150
	.byte 4,7,131,94,35,139,156,192,0,90,32,32,2,1,21,1,3,1,7,129,137,19,7,129,137,255,253,0,0,0,7,131
	.byte 94,0,198,0,0,27,1,7,129,137,0,35,139,156,192,0,90,32,32,4,1,21,1,3,1,7,129,137,19,7,129,137
	.byte 21,1,5,1,7,129,137,21,1,5,1,7,129,137,255,253,0,0,0,7,131,94,0,198,0,0,28,1,7,129,137,0
	.byte 255,253,0,0,0,7,129,142,0,198,0,0,6,1,7,129,137,0,35,140,64,192,0,92,40,255,253,0,0,0,7,129
	.byte 142,0,198,0,0,6,1,7,129,137,0,1,15,7,129,142,3,35,140,64,192,0,90,32,32,1,1,21,1,5,1,7
	.byte 129,137,255,253,0,0,0,7,129,142,0,198,0,0,12,1,7,129,137,0,255,253,0,0,0,7,129,142,0,198,0,0
	.byte 7,1,7,129,137,0,35,140,148,192,0,92,40,255,253,0,0,0,7,129,142,0,198,0,0,7,1,7,129,137,0,0
	.byte 35,140,148,192,0,90,32,32,1,21,1,5,1,7,129,137,19,7,129,137,255,253,0,0,0,7,129,142,0,198,0,0
	.byte 9,1,7,129,137,0,255,253,0,0,0,7,129,142,0,198,0,0,8,1,7,129,137,0,35,140,230,192,0,92,40,255
	.byte 253,0,0,0,7,129,142,0,198,0,0,8,1,7,129,137,0,7,15,7,129,142,1,15,7,129,142,3,13,7,129,137
	.byte 15,7,131,94,10,14,7,129,137,22,7,129,137,21,7,129,137,35,140,230,192,0,90,32,32,0,19,7,129,137,255,253
	.byte 0,0,0,7,131,94,0,198,0,0,34,1,7,129,137,0,255,253,0,0,0,7,129,142,0,198,0,0,9,1,7,129
	.byte 137,0,35,141,80,192,0,92,40,255,253,0,0,0,7,129,142,0,198,0,0,9,1,7,129,137,0,4,15,7,129,142
	.byte 3,15,7,131,94,10,21,7,129,137,21,7,129,137,35,141,80,192,0,90,32,32,0,19,7,129,137,255,253,0,0,0
	.byte 7,131,94,0,198,0,0,34,1,7,129,137,0,4,2,42,1,1,7,129,137,35,141,80,150,4,7,141,173,35,141,80
	.byte 192,0,90,32,0,0,21,2,42,1,1,7,129,137,255,253,0,0,0,7,141,173,1,198,0,1,3,1,7,129,137,0
	.byte 35,141,80,192,0,90,34,32,2,2,19,7,129,137,19,7,129,137,255,253,0,0,0,7,141,173,1,198,0,1,2,1
	.byte 7,129,137,0,255,253,0,0,0,7,129,142,0,198,0,0,10,1,7,129,137,0,35,142,4,192,0,92,40,255,253,0
	.byte 0,0,7,129,142,0,198,0,0,10,1,7,129,137,0,5,14,7,130,253,23,7,130,253,22,7,130,253,21,7,130,253
	.byte 21,7,130,253,35,142,4,150,4,7,130,253,35,142,4,192,0,90,32,32,1,1,21,1,3,1,7,129,137,255,253,0
	.byte 0,0,7,130,253,0,198,0,0,21,1,7,129,137,0,255,253,0,0,0,7,129,142,0,198,0,0,11,1,7,129,137
	.byte 0,35,142,111,192,0,92,40,255,253,0,0,0,7,129,142,0,198,0,0,11,1,7,129,137,0,0,35,142,111,192,0
	.byte 90,32,32,1,21,1,5,1,7,129,137,19,7,129,137,255,253,0,0,0,7,129,142,0,198,0,0,9,1,7,129,137
	.byte 0,35,142,111,192,0,90,32,32,1,1,21,1,5,1,7,129,137,255,253,0,0,0,7,129,142,0,198,0,0,12,1
	.byte 7,129,137,0,255,253,0,0,0,7,129,142,0,198,0,0,12,1,7,129,137,0,35,142,228,192,0,92,40,255,253,0
	.byte 0,0,7,129,142,0,198,0,0,12,1,7,129,137,0,4,15,7,129,142,1,15,7,129,142,3,15,7,131,94,10,15
	.byte 7,129,142,2,35,142,228,192,0,90,32,32,1,1,21,1,5,1,7,129,137,255,253,0,0,0,7,129,142,0,198,0
	.byte 0,2,1,7,129,137,0,35,142,228,192,0,90,32,32,0,1,255,253,0,0,0,7,131,94,0,198,0,0,29,1,7
	.byte 129,137,0,255,253,0,0,0,7,129,142,0,198,0,0,13,1,7,129,137,0,35,143,99,192,0,92,40,255,253,0,0
	.byte 0,7,129,142,0,198,0,0,13,1,7,129,137,0,2,15,7,129,142,3,15,7,131,94,11,35,143,99,192,0,90,32
	.byte 32,1,1,21,1,5,1,7,129,137,255,253,0,0,0,7,129,142,0,198,0,0,12,1,7,129,137,0,255,253,0,0
	.byte 0,7,129,142,0,198,0,0,14,1,7,129,137,0,35,143,188,192,0,92,40,255,253,0,0,0,7,129,142,0,198,0
	.byte 0,14,1,7,129,137,0,0,35,143,188,192,0,90,32,32,1,21,1,5,1,7,129,137,19,7,129,137,255,253,0,0
	.byte 0,7,129,142,0,198,0,0,5,1,7,129,137,0,255,253,0,0,0,7,129,142,0,198,0,0,15,1,7,129,137,0
	.byte 35,144,14,192,0,92,40,255,253,0,0,0,7,129,142,0,198,0,0,15,1,7,129,137,0,5,19,7,130,253,24,7
	.byte 130,253,14,7,130,253,22,7,130,253,21,7,130,253,35,144,14,192,0,90,32,32,0,21,1,4,1,7,129,137,255,253
	.byte 0,0,0,7,129,142,0,198,0,0,10,1,7,129,137,0,35,144,14,150,4,7,130,253,255,253,0,0,0,7,129,142
	.byte 0,198,0,0,16,1,7,129,137,0,35,144,120,192,0,92,40,255,253,0,0,0,7,129,142,0,198,0,0,16,1,7
	.byte 129,137,0,5,19,7,130,253,24,7,130,253,14,7,130,253,22,7,130,253,21,7,130,253,35,144,120,192,0,90,32,32
	.byte 0,21,1,4,1,7,129,137,255,253,0,0,0,7,129,142,0,198,0,0,10,1,7,129,137,0,35,144,120,150,4,7
	.byte 130,253,255,253,0,0,0,7,129,142,0,198,0,0,17,1,7,129,137,0,35,144,226,192,0,92,40,255,253,0,0,0
	.byte 7,129,142,0,198,0,0,17,1,7,129,137,0,1,15,7,129,142,1,255,253,0,0,0,7,129,142,0,198,0,0,18
	.byte 1,7,129,137,0,35,145,19,192,0,92,40,255,253,0,0,0,7,129,142,0,198,0,0,18,1,7,129,137,0,2,15
	.byte 7,129,142,3,15,7,131,94,11,255,253,0,0,0,7,129,142,0,198,0,0,19,1,7,129,137,0,35,145,73,192,0
	.byte 92,40,255,253,0,0,0,7,129,142,0,198,0,0,19,1,7,129,137,0,0,255,253,0,0,0,7,129,142,0,198,0
	.byte 0,20,1,7,129,137,0,35,145,117,192,0,92,40,255,253,0,0,0,7,129,142,0,198,0,0,20,1,7,129,137,0
	.byte 0,255,253,0,0,0,7,130,253,0,198,0,0,21,1,7,129,137,0,35,145,161,192,0,92,40,255,253,0,0,0,7
	.byte 130,253,0,198,0,0,21,1,7,129,137,0,5,15,7,130,253,4,15,7,130,253,5,15,7,130,253,6,15,7,129,142
	.byte 2,15,7,130,253,7,255,253,0,0,0,7,130,253,0,198,0,0,22,1,7,129,137,0,35,145,230,192,0,92,40,255
	.byte 253,0,0,0,7,130,253,0,198,0,0,22,1,7,129,137,0,5,15,7,130,253,4,15,7,130,253,5,14,7,129,137
	.byte 22,7,129,137,21,7,129,137,35,145,230,192,0,90,32,32,0,19,7,129,137,255,253,0,0,0,7,131,94,0,198,0
	.byte 0,34,1,7,129,137,0,255,253,0,0,0,7,130,253,0,198,0,0,23,1,7,129,137,0,35,146,71,192,0,92,40
	.byte 255,253,0,0,0,7,130,253,0,198,0,0,23,1,7,129,137,0,5,19,7,129,137,24,7,129,137,14,7,129,137,22
	.byte 7,129,137,21,7,129,137,35,146,71,150,4,7,130,253,35,146,71,192,0,90,32,32,0,19,7,129,137,255,253,0,0
	.byte 0,7,130,253,0,198,0,0,22,1,7,129,137,0,35,146,71,150,4,7,129,137,255,253,0,0,0,7,130,253,0,198
	.byte 0,0,24,1,7,129,137,0,35,146,182,192,0,92,40,255,253,0,0,0,7,130,253,0,198,0,0,24,1,7,129,137
	.byte 0,7,15,7,130,253,4,15,7,130,253,7,15,7,129,142,2,15,7,130,253,5,15,7,130,253,6,15,7,129,142,3
	.byte 15,7,131,94,10,255,253,0,0,0,7,130,253,0,198,0,0,25,1,7,129,137,0,35,147,5,192,0,92,40,255,253
	.byte 0,0,0,7,130,253,0,198,0,0,25,1,7,129,137,0,2,15,7,130,253,4,15,7,130,253,5,255,253,0,0,0
	.byte 7,131,94,0,198,0,0,26,1,7,129,137,0,35,147,59,192,0,92,40,255,253,0,0,0,7,131,94,0,198,0,0
	.byte 26,1,7,129,137,0,3,15,7,131,94,8,14,7,129,137,22,7,129,137,255,253,0,0,0,7,131,94,0,198,0,0
	.byte 27,1,7,129,137,0,35,147,116,192,0,92,40,255,253,0,0,0,7,131,94,0,198,0,0,27,1,7,129,137,0,6
	.byte 15,7,131,94,9,15,7,131,94,8,15,7,131,94,10,15,7,131,94,11,14,7,129,137,22,7,129,137,255,253,0,0
	.byte 0,7,131,94,0,198,0,0,28,1,7,129,137,0,35,147,188,192,0,92,40,255,253,0,0,0,7,131,94,0,198,0
	.byte 0,28,1,7,129,137,0,6,15,7,131,94,9,15,7,131,94,8,15,7,131,94,11,15,7,131,94,10,14,7,129,137
	.byte 22,7,129,137,255,253,0,0,0,7,131,94,0,198,0,0,29,1,7,129,137,0,35,148,4,192,0,92,40,255,253,0
	.byte 0,0,7,131,94,0,198,0,0,29,1,7,129,137,0,3,15,7,131,94,11,15,7,131,94,10,15,7,131,94,9,255
	.byte 253,0,0,0,7,131,94,0,198,0,0,30,1,7,129,137,0,35,148,63,192,0,92,40,255,253,0,0,0,7,131,94
	.byte 0,198,0,0,30,1,7,129,137,0,3,15,7,131,94,10,15,7,131,94,11,15,7,131,94,9,255,253,0,0,0,7
	.byte 131,94,0,198,0,0,31,1,7,129,137,0,35,148,122,192,0,92,40,255,253,0,0,0,7,131,94,0,198,0,0,31
	.byte 1,7,129,137,0,3,15,7,131,94,10,15,7,131,94,11,15,7,131,94,9,255,253,0,0,0,7,131,94,0,198,0
	.byte 0,32,1,7,129,137,0,35,148,181,192,0,92,40,255,253,0,0,0,7,131,94,0,198,0,0,32,1,7,129,137,0
	.byte 1,15,7,131,94,9,255,253,0,0,0,7,131,94,0,198,0,0,33,1,7,129,137,0,35,148,230,192,0,92,40,255
	.byte 253,0,0,0,7,131,94,0,198,0,0,33,1,7,129,137,0,3,15,7,131,94,9,15,7,129,142,3,15,7,131,94
	.byte 11,255,253,0,0,0,7,131,94,0,198,0,0,34,1,7,129,137,0,35,149,33,192,0,92,40,255,253,0,0,0,7
	.byte 131,94,0,198,0,0,34,1,7,129,137,0,4,15,7,131,94,8,14,7,129,137,22,7,129,137,21,7,129,137,255,253
	.byte 0,0,0,7,132,7,0,198,0,0,35,1,7,129,137,0,35,149,94,192,0,92,40,255,253,0,0,0,7,132,7,0
	.byte 198,0,0,35,1,7,129,137,0,0,255,253,0,0,0,7,132,7,0,198,0,0,36,1,7,129,137,0,35,149,138,192
	.byte 0,92,40,255,253,0,0,0,7,132,7,0,198,0,0,36,1,7,129,137,0,6,15,7,132,7,13,15,7,132,7,12
	.byte 13,7,129,137,14,7,129,137,22,7,129,137,21,7,129,137,255,253,0,0,0,7,132,7,0,198,0,0,37,1,7,129
	.byte 137,0,35,149,208,192,0,92,40,255,253,0,0,0,7,132,7,0,198,0,0,37,1,7,129,137,0,10,15,7,132,7
	.byte 13,15,7,132,7,14,15,7,132,7,12,13,7,129,137,14,7,129,137,23,7,129,137,22,7,129,137,21,7,129,137,21
	.byte 7,129,137,21,7,129,137,255,253,0,0,0,7,132,7,0,198,0,0,38,1,7,129,137,0,35,150,39,192,0,92,40
	.byte 255,253,0,0,0,7,132,7,0,198,0,0,38,1,7,129,137,0,6,15,7,132,7,12,15,7,132,7,13,15,7,132
	.byte 7,14,13,7,129,137,14,7,129,137,22,7,129,137,35,150,39,140,16,255,253,0,0,0,2,129,172,1,1,198,0,8
	.byte 149,0,1,7,129,137,35,150,39,192,0,90,32,16,1,2,1,16,29,7,129,137,8,255,253,0,0,0,2,129,172,1
	.byte 1,198,0,8,149,0,1,7,129,137,255,253,0,0,0,7,132,7,0,198,0,0,39,1,7,129,137,0,35,150,170,192
	.byte 0,92,40,255,253,0,0,0,7,132,7,0,198,0,0,39,1,7,129,137,0,1,15,7,132,7,13,255,253,0,0,0
	.byte 7,132,7,0,198,0,0,40,1,7,129,137,0,35,150,219,192,0,92,40,255,253,0,0,0,7,132,7,0,198,0,0
	.byte 40,1,7,129,137,0,0,255,253,0,0,0,7,132,7,0,198,0,0,41,1,7,129,137,0,35,151,7,192,0,92,40
	.byte 255,253,0,0,0,7,132,7,0,198,0,0,41,1,7,129,137,0,5,14,7,132,176,23,7,132,176,22,7,132,176,21
	.byte 7,132,176,21,7,132,176,35,151,7,150,4,7,132,176,35,151,7,192,0,90,32,32,1,1,21,1,6,1,7,129,137
	.byte 255,253,0,0,0,7,132,176,0,198,0,0,44,1,7,129,137,0,255,253,0,0,0,7,132,7,0,198,0,0,42,1
	.byte 7,129,137,0,35,151,114,192,0,92,40,255,253,0,0,0,7,132,7,0,198,0,0,42,1,7,129,137,0,5,19,7
	.byte 132,176,24,7,132,176,14,7,132,176,22,7,132,176,21,7,132,176,35,151,114,192,0,90,32,32,0,21,1,7,1,7
	.byte 129,137,255,253,0,0,0,7,132,7,0,198,0,0,41,1,7,129,137,0,35,151,114,150,4,7,132,176,255,253,0,0
	.byte 0,7,132,7,0,198,0,0,43,1,7,129,137,0,35,151,220,192,0,92,40,255,253,0,0,0,7,132,7,0,198,0
	.byte 0,43,1,7,129,137,0,5,19,7,132,176,24,7,132,176,14,7,132,176,22,7,132,176,21,7,132,176,35,151,220,192
	.byte 0,90,32,32,0,21,1,7,1,7,129,137,255,253,0,0,0,7,132,7,0,198,0,0,41,1,7,129,137,0,35,151
	.byte 220,150,4,7,132,176,255,253,0,0,0,7,132,176,0,198,0,0,44,1,7,129,137,0,35,152,70,192,0,92,40,255
	.byte 253,0,0,0,7,132,176,0,198,0,0,44,1,7,129,137,0,4,15,7,132,176,15,15,7,132,176,16,15,7,132,7
	.byte 14,15,7,132,176,17,255,253,0,0,0,7,132,176,0,198,0,0,45,1,7,129,137,0,35,152,134,192,0,92,40,255
	.byte 253,0,0,0,7,132,176,0,198,0,0,45,1,7,129,137,0,1,15,7,132,176,16,255,253,0,0,0,7,132,176,0
	.byte 198,0,0,46,1,7,129,137,0,35,152,183,192,0,92,40,255,253,0,0,0,7,132,176,0,198,0,0,46,1,7,129
	.byte 137,0,5,15,7,132,176,17,15,7,132,176,15,15,7,132,7,14,15,7,132,176,16,15,7,132,7,13,255,253,0,0
	.byte 0,7,132,176,0,198,0,0,47,1,7,129,137,0,35,152,252,192,0,92,40,255,253,0,0,0,7,132,176,0,198,0
	.byte 0,47,1,7,129,137,0,7,15,7,132,176,16,15,7,132,176,15,15,7,132,7,12,13,7,129,137,14,7,129,137,22
	.byte 7,129,137,21,7,129,137,255,253,0,0,0,7,132,176,0,198,0,0,48,1,7,129,137,0,35,153,71,192,0,92,40
	.byte 255,253,0,0,0,7,132,176,0,198,0,0,48,1,7,129,137,0,5,19,7,129,137,24,7,129,137,14,7,129,137,22
	.byte 7,129,137,21,7,129,137,35,153,71,150,4,7,132,176,35,153,71,192,0,90,32,32,0,19,7,129,137,255,253,0,0
	.byte 0,7,132,176,0,198,0,0,47,1,7,129,137,0,35,153,71,150,4,7,129,137,3,0,0,1,13,0,17,255,253,0
	.byte 0,0,1,3,0,198,0,0,1,1,7,133,215,0,0,0,3,19,0,1,13,0,17,255,253,0,0,0,1,3,0,198
	.byte 0,0,2,1,7,133,215,0,0,0,3,19,0,1,13,0,17,255,253,0,0,0,1,3,0,198,0,0,3,1,7,133
	.byte 215,0,0,0,3,19,0,1,13,0,17,255,253,0,0,0,1,3,0,198,0,0,4,1,7,133,215,0,0,0,3,40
	.byte 0,1,11,8,17,255,253,0,0,0,1,3,0,198,0,0,5,1,7,133,215,0,0,0,3,0,0,1,13,0,17,255
	.byte 253,0,0,0,1,3,0,198,0,0,6,1,7,133,215,0,0,0,3,0,0,1,13,0,17,255,253,0,0,0,1,3
	.byte 0,198,0,0,7,1,7,133,215,0,0,0,3,66,0,1,13,36,17,255,253,0,0,0,1,3,0,198,0,0,8,1
	.byte 7,133,215,0,0,0,3,93,0,1,13,0,17,255,253,0,0,0,1,3,0,198,0,0,9,1,7,133,215,0,0,0
	.byte 3,116,0,1,13,36,17,255,253,0,0,0,1,3,0,198,0,0,10,1,7,133,215,0,0,0,3,19,0,1,13,0
	.byte 17,255,253,0,0,0,1,3,0,198,0,0,11,1,7,133,215,0,0,0,3,19,0,1,13,0,17,255,253,0,0,0
	.byte 1,3,0,198,0,0,12,1,7,133,215,0,0,0,3,0,0,1,13,0,17,255,253,0,0,0,1,3,0,198,0,0
	.byte 13,1,7,133,215,0,0,0,3,0,0,1,13,0,17,255,253,0,0,0,1,3,0,198,0,0,14,1,7,133,215,0
	.byte 0,0,3,128,135,0,1,13,16,17,255,253,0,0,0,1,3,0,198,0,0,15,1,7,133,215,0,0,0,3,128,135
	.byte 0,1,13,16,17,255,253,0,0,0,1,3,0,198,0,0,16,1,7,133,215,0,0,0,3,0,0,1,13,0,17,255
	.byte 253,0,0,0,1,3,0,198,0,0,17,1,7,133,215,0,0,0,3,19,0,1,13,0,17,255,253,0,0,0,1,3
	.byte 0,198,0,0,18,1,7,133,215,0,0,0,3,0,0,1,13,0,17,255,253,0,0,0,1,3,0,198,0,0,19,1
	.byte 7,133,215,0,0,0,3,0,0,1,13,0,17,255,253,0,0,0,1,3,0,198,0,0,20,1,7,133,215,0,0,0
	.byte 3,128,154,0,1,13,0,17,255,253,0,0,0,1,4,0,198,0,0,21,1,7,135,128,0,0,0,3,19,0,1,13
	.byte 0,17,255,253,0,0,0,1,4,0,198,0,0,22,1,7,135,128,0,0,0,3,0,0,1,13,0,17,255,253,0,0
	.byte 0,1,4,0,198,0,0,23,1,7,135,128,0,0,0,3,19,0,1,13,0,17,255,253,0,0,0,1,4,0,198,0
	.byte 0,24,1,7,135,128,0,0,0,3,19,0,1,13,0,17,255,253,0,0,0,1,4,0,198,0,0,25,1,7,135,128
	.byte 0,0,0,5,19,0,1,0,1,5,3,0,0,1,13,0,17,255,253,0,0,0,1,5,0,198,0,0,26,1,7,156
	.byte 67,0,0,0,3,128,175,0,1,13,0,17,255,253,0,0,0,1,5,0,198,0,0,27,1,7,156,67,0,0,0,3
	.byte 128,194,0,1,11,0,17,255,253,0,0,0,1,5,0,198,0,0,28,1,7,156,67,0,0,0,3,0,0,1,13,0
	.byte 17,255,253,0,0,0,1,5,0,198,0,0,29,1,7,156,67,0,0,0,3,0,0,1,13,0,17,255,253,0,0,0
	.byte 1,5,0,198,0,0,30,1,7,156,67,0,0,0,3,128,175,0,1,13,0,17,255,253,0,0,0,1,5,0,198,0
	.byte 0,31,1,7,156,67,0,0,0,3,0,0,1,13,0,17,255,253,0,0,0,1,5,0,198,0,0,32,1,7,156,67
	.byte 0,0,0,3,19,0,1,13,0,17,255,253,0,0,0,1,5,0,198,0,0,33,1,7,156,67,0,0,0,3,0,0
	.byte 1,13,0,17,255,253,0,0,0,1,5,0,198,0,0,34,1,7,156,67,0,0,0,3,0,0,1,13,0,17,255,253
	.byte 0,0,0,1,6,0,198,0,0,35,1,7,135,220,0,0,0,3,0,0,1,13,0,17,255,253,0,0,0,1,6,0
	.byte 198,0,0,36,1,7,135,220,0,0,0,3,128,175,0,1,13,12,17,255,253,0,0,0,1,6,0,198,0,0,37,1
	.byte 7,135,220,0,0,0,3,128,218,0,1,13,8,17,255,253,0,0,0,1,6,0,198,0,0,38,1,7,135,220,0,0
	.byte 0,3,0,0,1,13,0,17,255,253,0,0,0,1,6,0,198,0,0,39,1,7,135,220,0,0,0,3,0,0,1,13
	.byte 0,17,255,253,0,0,0,1,6,0,198,0,0,40,1,7,135,220,0,0,0,3,128,239,0,1,13,28,17,255,253,0
	.byte 0,0,1,6,0,198,0,0,41,1,7,135,220,0,0,0,3,128,175,0,1,13,12,17,255,253,0,0,0,1,6,0
	.byte 198,0,0,42,1,7,135,220,0,0,0,3,128,175,0,1,13,12,17,255,253,0,0,0,1,6,0,198,0,0,43,1
	.byte 7,135,220,0,0,0,3,128,154,0,1,13,0,17,255,253,0,0,0,1,7,0,198,0,0,44,1,7,136,133,0,0
	.byte 0,3,0,0,1,13,0,17,255,253,0,0,0,1,7,0,198,0,0,45,1,7,136,133,0,0,0,3,129,2,0,1
	.byte 13,4,17,255,253,0,0,0,1,7,0,198,0,0,46,1,7,136,133,0,0,0,3,19,0,1,13,0,17,255,253,0
	.byte 0,0,1,7,0,198,0,0,47,1,7,136,133,0,0,0,3,0,0,1,13,0,17,255,253,0,0,0,1,7,0,198
	.byte 0,0,48,1,7,136,133,0,0,0,2,128,175,0,2,0,0,2,128,175,0,2,0,0,2,129,25,0,2,0,0,2
	.byte 128,154,0,2,0,0,2,0,0,2,0,0,2,129,47,0,6,129,68,1,0,16,4,2,130,27,1,68,129,168,129,168
	.byte 0,2,129,101,0,2,0,0,2,129,2,0,2,0,0,2,129,135,0,6,129,158,2,0,4,4,2,130,27,1,112,128
	.byte 180,128,180,2,24,129,68,128,216,129,0,129,4,0,2,0,0,2,0,0,2,129,188,0,2,129,188,0,2,129,188,0
	.byte 2,129,188,0,2,129,188,0,2,0,0,6,129,207,2,2,44,130,48,124,129,44,129,48,2,48,130,88,72,130,52,130
	.byte 56,0,2,0,0,2,129,237,0,2,0,0,2,0,0,2,0,0,2,0,0,2,0,0,2,0,0,2,0,0,2,130
	.byte 2,0,2,0,0,2,0,0,2,130,20,0,2,130,2,0,2,128,175,0,2,0,0,2,0,0,2,130,41,0,2,0
	.byte 0,2,130,62,0,3,130,85,0,1,11,8,18,255,253,0,0,0,7,129,142,0,198,0,0,1,1,7,129,137,0,1
	.byte 1,1,0,0,3,130,85,0,1,11,8,18,255,253,0,0,0,7,129,142,0,198,0,0,2,1,7,129,137,0,1,1
	.byte 1,0,0,3,130,85,0,1,11,4,18,255,253,0,0,0,7,129,142,0,198,0,0,3,1,7,129,137,0,1,1,1
	.byte 0,0,3,130,109,0,1,11,4,18,255,253,0,0,0,7,129,142,0,198,0,0,4,1,7,129,137,0,1,1,1,0
	.byte 0,3,130,137,0,1,11,8,18,255,253,0,0,0,7,129,142,0,198,0,0,5,1,7,129,137,0,1,1,1,0,0
	.byte 3,130,167,0,1,11,4,18,255,253,0,0,0,7,129,142,0,198,0,0,6,1,7,129,137,0,1,1,1,0,0,3
	.byte 130,193,0,1,11,4,18,255,253,0,0,0,7,129,142,0,198,0,0,7,1,7,129,137,0,1,1,1,0,0,3,130
	.byte 219,0,1,11,44,18,255,253,0,0,0,7,129,142,0,198,0,0,8,1,7,129,137,0,1,1,1,0,0,3,130,251
	.byte 0,1,11,0,18,255,253,0,0,0,7,129,142,0,198,0,0,9,1,7,129,137,0,1,1,1,0,0,3,131,25,0
	.byte 1,11,4,18,255,253,0,0,0,7,129,142,0,198,0,0,10,1,7,129,137,0,1,1,1,0,0,3,131,53,0,1
	.byte 11,0,18,255,253,0,0,0,7,129,142,0,198,0,0,11,1,7,129,137,0,1,1,1,0,0,3,131,53,0,1,11
	.byte 4,18,255,253,0,0,0,7,129,142,0,198,0,0,12,1,7,129,137,0,1,1,1,0,0,3,130,167,0,1,11,4
	.byte 18,255,253,0,0,0,7,129,142,0,198,0,0,13,1,7,129,137,0,1,1,1,0,0,3,130,193,0,1,11,4,18
	.byte 255,253,0,0,0,7,129,142,0,198,0,0,14,1,7,129,137,0,1,1,1,0,0,3,131,81,0,1,11,0,18,255
	.byte 253,0,0,0,7,129,142,0,198,0,0,15,1,7,129,137,0,1,1,1,0,0,3,131,81,0,1,11,0,18,255,253
	.byte 0,0,0,7,129,142,0,198,0,0,16,1,7,129,137,0,1,1,1,0,0,3,131,113,0,1,11,4,18,255,253,0
	.byte 0,0,7,129,142,0,198,0,0,17,1,7,129,137,0,1,1,1,0,0,3,131,139,0,1,11,4,18,255,253,0,0
	.byte 0,7,129,142,0,198,0,0,18,1,7,129,137,0,1,1,1,0,0,3,130,85,0,1,11,8,18,255,253,0,0,0
	.byte 7,129,142,0,198,0,0,19,1,7,129,137,0,1,1,1,0,0,3,130,85,0,1,11,8,18,255,253,0,0,0,7
	.byte 129,142,0,198,0,0,20,1,7,129,137,0,1,1,1,0,0,3,131,167,0,1,11,0,18,255,253,0,0,0,7,130
	.byte 253,0,198,0,0,21,1,7,129,137,0,1,1,1,0,0,3,131,195,0,1,11,4,18,255,253,0,0,0,7,130,253
	.byte 0,198,0,0,22,1,7,129,137,0,1,1,1,0,0,3,131,81,0,1,11,0,18,255,253,0,0,0,7,130,253,0
	.byte 198,0,0,23,1,7,129,137,0,1,1,1,0,0,3,131,139,0,1,11,0,18,255,253,0,0,0,7,130,253,0,198
	.byte 0,0,24,1,7,129,137,0,1,1,1,0,0,3,131,139,0,1,11,0,18,255,253,0,0,0,7,130,253,0,198,0
	.byte 0,25,1,7,129,137,0,1,1,1,0,0,3,130,167,0,1,11,4,18,255,253,0,0,0,7,131,94,0,198,0,0
	.byte 26,1,7,129,137,0,1,1,1,0,0,3,131,225,0,1,11,4,18,255,253,0,0,0,7,131,94,0,198,0,0,27
	.byte 1,7,129,137,0,1,1,1,0,0,3,131,251,0,1,11,4,18,255,253,0,0,0,7,131,94,0,198,0,0,28,1
	.byte 7,129,137,0,1,1,1,0,0,3,131,113,0,1,11,4,18,255,253,0,0,0,7,131,94,0,198,0,0,29,1,7
	.byte 129,137,0,1,1,1,0,0,3,131,225,0,1,11,4,18,255,253,0,0,0,7,131,94,0,198,0,0,30,1,7,129
	.byte 137,0,1,1,1,0,0,3,131,251,0,1,11,4,18,255,253,0,0,0,7,131,94,0,198,0,0,31,1,7,129,137
	.byte 0,1,1,1,0,0,3,131,113,0,1,11,4,18,255,253,0,0,0,7,131,94,0,198,0,0,32,1,7,129,137,0
	.byte 1,1,1,0,0,3,131,139,0,1,11,4,18,255,253,0,0,0,7,131,94,0,198,0,0,33,1,7,129,137,0,1
	.byte 1,1,0,0,3,132,21,0,1,11,4,18,255,253,0,0,0,7,131,94,0,198,0,0,34,1,7,129,137,0,1,1
	.byte 1,0,0,3,130,85,0,1,11,8,18,255,253,0,0,0,7,132,7,0,198,0,0,35,1,7,129,137,0,1,1,1
	.byte 0,0,3,132,21,0,1,11,4,18,255,253,0,0,0,7,132,7,0,198,0,0,36,1,7,129,137,0,1,1,1,0
	.byte 0,3,131,25,0,1,11,8,18,255,253,0,0,0,7,132,7,0,198,0,0,37,1,7,129,137,0,1,1,1,0,0
	.byte 3,132,49,0,1,11,16,18,255,253,0,0,0,7,132,7,0,198,0,0,38,1,7,129,137,0,1,1,1,0,0,3
	.byte 131,113,0,1,11,4,18,255,253,0,0,0,7,132,7,0,198,0,0,39,1,7,129,137,0,1,1,1,0,0,3,130
	.byte 85,0,1,11,8,18,255,253,0,0,0,7,132,7,0,198,0,0,40,1,7,129,137,0,1,1,1,0,0,3,131,25
	.byte 0,1,11,4,18,255,253,0,0,0,7,132,7,0,198,0,0,41,1,7,129,137,0,1,1,1,0,0,3,131,81,0
	.byte 1,11,0,18,255,253,0,0,0,7,132,7,0,198,0,0,42,1,7,129,137,0,1,1,1,0,0,3,131,81,0,1
	.byte 11,0,18,255,253,0,0,0,7,132,7,0,198,0,0,43,1,7,129,137,0,1,1,1,0,0,3,131,167,0,1,11
	.byte 0,18,255,253,0,0,0,7,132,176,0,198,0,0,44,1,7,129,137,0,1,1,1,0,0,3,131,225,0,1,11,0
	.byte 18,255,253,0,0,0,7,132,176,0,198,0,0,45,1,7,129,137,0,1,1,1,0,0,3,132,75,0,1,11,4,18
	.byte 255,253,0,0,0,7,132,176,0,198,0,0,46,1,7,129,137,0,1,1,1,0,0,3,132,105,0,1,11,4,18,255
	.byte 253,0,0,0,7,132,176,0,198,0,0,47,1,7,129,137,0,1,1,1,0,0,3,131,81,0,1,11,0,18,255,253
	.byte 0,0,0,7,132,176,0,198,0,0,48,1,7,129,137,0,1,1,1,0,0,0,128,144,8,0,0,1,255,255,255,255
	.byte 255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,6,128,160,12,0,0
	.byte 4,193,0,11,86,193,0,11,83,193,0,11,82,193,0,11,80,50,50,4,128,160,12,0,0,4,193,0,11,86,193,0
	.byte 11,83,193,0,11,82,193,0,11,80,4,128,144,8,0,0,1,193,0,11,86,193,0,11,83,193,0,11,82,193,0,11
	.byte 80,12,128,236,53,40,12,0,4,193,0,11,86,193,0,11,83,193,0,11,82,193,0,11,80,85,68,90,67,59,58,86
	.byte 82,7,128,144,12,0,0,4,193,0,9,185,193,0,9,198,193,0,11,82,193,0,9,196,193,0,9,184,193,0,9,186
	.byte 193,0,9,170,4,68,76,8,16,0,1,193,0,11,86,193,0,11,83,193,0,11,82,193,0,11,80,12,128,160,32,0
	.byte 0,4,193,0,11,86,193,0,11,83,193,0,11,82,193,0,11,80,85,0,90,0,88,87,86,82,7,128,160,12,0,0
	.byte 4,193,0,11,86,193,0,11,83,193,0,11,82,193,0,11,80,97,93,96,98,111,101,104,109,0
.section __TEXT, __const
	.align 3
Lglobals_hash:

	.short 11, 0, 0, 0, 0, 0, 0, 0
	.short 0, 0, 0, 0, 0, 0, 0, 0
	.short 0, 0, 0, 0, 0, 0, 0
.data
	.align 3
globals:
	.align 2
	.long Lglobals_hash

	.long 0,0
.section __DWARF, __debug_info,regular,debug
LTDIE_1:

	.byte 17
	.asciz "System_Object"

	.byte 8,7
	.asciz "System_Object"

LDIFF_SYM3=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM3
LTDIE_1_POINTER:

	.byte 13
LDIFF_SYM4=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM4
LTDIE_1_REFERENCE:

	.byte 14
LDIFF_SYM5=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM5
LTDIE_3:

	.byte 5
	.asciz "System_ValueType"

	.byte 8,16
LDIFF_SYM6=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM6
	.byte 2,35,0,0,7
	.asciz "System_ValueType"

LDIFF_SYM7=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM7
LTDIE_3_POINTER:

	.byte 13
LDIFF_SYM8=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM8
LTDIE_3_REFERENCE:

	.byte 14
LDIFF_SYM9=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM9
LTDIE_2:

	.byte 5
	.asciz "System_UInt32"

	.byte 12,16
LDIFF_SYM10=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM10
	.byte 2,35,0,6
	.asciz "m_value"

LDIFF_SYM11=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM11
	.byte 2,35,8,0,7
	.asciz "System_UInt32"

LDIFF_SYM12=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM12
LTDIE_2_POINTER:

	.byte 13
LDIFF_SYM13=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM13
LTDIE_2_REFERENCE:

	.byte 14
LDIFF_SYM14=LTDIE_2 - Ldebug_info_start
	.long LDIFF_SYM14
LTDIE_4:

	.byte 5
	.asciz "System_Collections_Generic_LinkedListNode`1"

	.byte 24,16
LDIFF_SYM15=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM15
	.byte 2,35,0,6
	.asciz "item"

LDIFF_SYM16=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM16
	.byte 2,35,8,6
	.asciz "container"

LDIFF_SYM17=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM17
	.byte 2,35,12,6
	.asciz "forward"

LDIFF_SYM18=LTDIE_4_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM18
	.byte 2,35,16,6
	.asciz "back"

LDIFF_SYM19=LTDIE_4_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM19
	.byte 2,35,20,0,7
	.asciz "System_Collections_Generic_LinkedListNode`1"

LDIFF_SYM20=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM20
LTDIE_4_POINTER:

	.byte 13
LDIFF_SYM21=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM21
LTDIE_4_REFERENCE:

	.byte 14
LDIFF_SYM22=LTDIE_4 - Ldebug_info_start
	.long LDIFF_SYM22
LTDIE_0:

	.byte 5
	.asciz "System_Collections_Generic_LinkedList`1"

	.byte 20,16
LDIFF_SYM23=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM23
	.byte 2,35,0,6
	.asciz "count"

LDIFF_SYM24=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM24
	.byte 2,35,12,6
	.asciz "version"

LDIFF_SYM25=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM25
	.byte 2,35,16,6
	.asciz "first"

LDIFF_SYM26=LTDIE_4_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM26
	.byte 2,35,8,0,7
	.asciz "System_Collections_Generic_LinkedList`1"

LDIFF_SYM27=LTDIE_0 - Ldebug_info_start
	.long LDIFF_SYM27
LTDIE_0_POINTER:

	.byte 13
LDIFF_SYM28=LTDIE_0 - Ldebug_info_start
	.long LDIFF_SYM28
LTDIE_0_REFERENCE:

	.byte 14
LDIFF_SYM29=LTDIE_0 - Ldebug_info_start
	.long LDIFF_SYM29
	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1:.ctor"
	.long _System_Collections_Generic_LinkedList_1__ctor
	.long Lme_0

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM30=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM30
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM31=Lfde0_end - Lfde0_start
	.long LDIFF_SYM31
Lfde0_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1__ctor

LDIFF_SYM32=Lme_0 - _System_Collections_Generic_LinkedList_1__ctor
	.long LDIFF_SYM32
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde0_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1:VerifyReferencedNode"
	.long _System_Collections_Generic_LinkedList_1_VerifyReferencedNode_System_Collections_Generic_LinkedListNode_1_T
	.long Lme_1

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM33=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM33
	.byte 2,125,0,3
	.asciz "node"

LDIFF_SYM34=LTDIE_4_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM34
	.byte 1,90,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM35=Lfde1_end - Lfde1_start
	.long LDIFF_SYM35
Lfde1_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_VerifyReferencedNode_System_Collections_Generic_LinkedListNode_1_T

LDIFF_SYM36=Lme_1 - _System_Collections_Generic_LinkedList_1_VerifyReferencedNode_System_Collections_Generic_LinkedListNode_1_T
	.long LDIFF_SYM36
	.byte 12,13,0,72,14,8,135,2,68,14,16,136,4,138,3,142,1,68,14,24
	.align 2
Lfde1_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1:VerifyBlankNode"
	.long _System_Collections_Generic_LinkedList_1_VerifyBlankNode_System_Collections_Generic_LinkedListNode_1_T
	.long Lme_2

	.byte 2,118,16,3
	.asciz "newNode"

LDIFF_SYM37=LTDIE_4_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM37
	.byte 1,90,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM38=Lfde2_end - Lfde2_start
	.long LDIFF_SYM38
Lfde2_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_VerifyBlankNode_System_Collections_Generic_LinkedListNode_1_T

LDIFF_SYM39=Lme_2 - _System_Collections_Generic_LinkedList_1_VerifyBlankNode_System_Collections_Generic_LinkedListNode_1_T
	.long LDIFF_SYM39
	.byte 12,13,0,72,14,8,135,2,68,14,16,136,4,138,3,142,1,68,14,24
	.align 2
Lfde2_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1:AddFirst"
	.long _System_Collections_Generic_LinkedList_1_AddFirst_System_Collections_Generic_LinkedListNode_1_T
	.long Lme_3

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM40=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM40
	.byte 2,125,0,3
	.asciz "node"

LDIFF_SYM41=LTDIE_4_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM41
	.byte 1,90,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM42=Lfde3_end - Lfde3_start
	.long LDIFF_SYM42
Lfde3_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_AddFirst_System_Collections_Generic_LinkedListNode_1_T

LDIFF_SYM43=Lme_3 - _System_Collections_Generic_LinkedList_1_AddFirst_System_Collections_Generic_LinkedListNode_1_T
	.long LDIFF_SYM43
	.byte 12,13,0,72,14,8,135,2,68,14,16,136,4,138,3,142,1,68,14,24
	.align 2
Lfde3_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1:AddLast"
	.long _System_Collections_Generic_LinkedList_1_AddLast_T
	.long Lme_4

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM44=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM44
	.byte 2,123,8,3
	.asciz "value"

LDIFF_SYM45=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM45
	.byte 2,123,12,11
	.asciz "newNode"

LDIFF_SYM46=LTDIE_4_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM46
	.byte 1,86,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM47=Lfde4_end - Lfde4_start
	.long LDIFF_SYM47
Lfde4_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_AddLast_T

LDIFF_SYM48=Lme_4 - _System_Collections_Generic_LinkedList_1_AddLast_T
	.long LDIFF_SYM48
	.byte 12,13,0,72,14,8,135,2,68,14,20,134,5,136,4,139,3,142,1,68,14,56,68,13,11
	.align 2
Lfde4_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1:Clear"
	.long _System_Collections_Generic_LinkedList_1_Clear
	.long Lme_5

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM49=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM49
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM50=Lfde5_end - Lfde5_start
	.long LDIFF_SYM50
Lfde5_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_Clear

LDIFF_SYM51=Lme_5 - _System_Collections_Generic_LinkedList_1_Clear
	.long LDIFF_SYM51
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde5_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1:Contains"
	.long _System_Collections_Generic_LinkedList_1_Contains_T
	.long Lme_6

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM52=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM52
	.byte 2,125,0,3
	.asciz "value"

LDIFF_SYM53=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM53
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM54=Lfde6_end - Lfde6_start
	.long LDIFF_SYM54
Lfde6_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_Contains_T

LDIFF_SYM55=Lme_6 - _System_Collections_Generic_LinkedList_1_Contains_T
	.long LDIFF_SYM55
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde6_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_5:

	.byte 5
	.asciz "System_Int32"

	.byte 12,16
LDIFF_SYM56=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM56
	.byte 2,35,0,6
	.asciz "m_value"

LDIFF_SYM57=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM57
	.byte 2,35,8,0,7
	.asciz "System_Int32"

LDIFF_SYM58=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM58
LTDIE_5_POINTER:

	.byte 13
LDIFF_SYM59=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM59
LTDIE_5_REFERENCE:

	.byte 14
LDIFF_SYM60=LTDIE_5 - Ldebug_info_start
	.long LDIFF_SYM60
	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1:CopyTo"
	.long _System_Collections_Generic_LinkedList_1_CopyTo_T___int
	.long Lme_7

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM61=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM61
	.byte 2,125,36,3
	.asciz "array"

LDIFF_SYM62=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM62
	.byte 1,86,3
	.asciz "index"

LDIFF_SYM63=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM63
	.byte 1,90,11
	.asciz "node"

LDIFF_SYM64=LTDIE_4_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM64
	.byte 1,85,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM65=Lfde7_end - Lfde7_start
	.long LDIFF_SYM65
Lfde7_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_CopyTo_T___int

LDIFF_SYM66=Lme_7 - _System_Collections_Generic_LinkedList_1_CopyTo_T___int
	.long LDIFF_SYM66
	.byte 12,13,0,72,14,8,135,2,68,14,28,133,7,134,6,136,5,138,4,139,3,142,1,68,14,80
	.align 2
Lfde7_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1:Find"
	.long _System_Collections_Generic_LinkedList_1_Find_T
	.long Lme_8

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM67=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM67
	.byte 2,125,0,3
	.asciz "value"

LDIFF_SYM68=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM68
	.byte 1,90,11
	.asciz "node"

LDIFF_SYM69=LTDIE_4_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM69
	.byte 1,86,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM70=Lfde8_end - Lfde8_start
	.long LDIFF_SYM70
Lfde8_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_Find_T

LDIFF_SYM71=Lme_8 - _System_Collections_Generic_LinkedList_1_Find_T
	.long LDIFF_SYM71
	.byte 12,13,0,72,14,8,135,2,68,14,20,134,5,136,4,138,3,142,1,68,14,40
	.align 2
Lfde8_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1:GetEnumerator"
	.long _System_Collections_Generic_LinkedList_1_GetEnumerator
	.long Lme_9

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM72=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM72
	.byte 2,125,36,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM73=Lfde9_end - Lfde9_start
	.long LDIFF_SYM73
Lfde9_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_GetEnumerator

LDIFF_SYM74=Lme_9 - _System_Collections_Generic_LinkedList_1_GetEnumerator
	.long LDIFF_SYM74
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,64
	.align 2
Lfde9_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1:Remove"
	.long _System_Collections_Generic_LinkedList_1_Remove_T
	.long Lme_a

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM75=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM75
	.byte 2,125,0,3
	.asciz "value"

LDIFF_SYM76=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM76
	.byte 1,90,11
	.asciz "node"

LDIFF_SYM77=LTDIE_4_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM77
	.byte 1,90,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM78=Lfde10_end - Lfde10_start
	.long LDIFF_SYM78
Lfde10_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_Remove_T

LDIFF_SYM79=Lme_a - _System_Collections_Generic_LinkedList_1_Remove_T
	.long LDIFF_SYM79
	.byte 12,13,0,72,14,8,135,2,68,14,16,136,4,138,3,142,1,68,14,24
	.align 2
Lfde10_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1:Remove"
	.long _System_Collections_Generic_LinkedList_1_Remove_System_Collections_Generic_LinkedListNode_1_T
	.long Lme_b

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM80=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM80
	.byte 2,125,0,3
	.asciz "node"

LDIFF_SYM81=LTDIE_4_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM81
	.byte 1,90,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM82=Lfde11_end - Lfde11_start
	.long LDIFF_SYM82
Lfde11_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_Remove_System_Collections_Generic_LinkedListNode_1_T

LDIFF_SYM83=Lme_b - _System_Collections_Generic_LinkedList_1_Remove_System_Collections_Generic_LinkedListNode_1_T
	.long LDIFF_SYM83
	.byte 12,13,0,72,14,8,135,2,68,14,16,136,4,138,3,142,1,68,14,24
	.align 2
Lfde11_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1:RemoveLast"
	.long _System_Collections_Generic_LinkedList_1_RemoveLast
	.long Lme_c

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM84=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM84
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM85=Lfde12_end - Lfde12_start
	.long LDIFF_SYM85
Lfde12_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_RemoveLast

LDIFF_SYM86=Lme_c - _System_Collections_Generic_LinkedList_1_RemoveLast
	.long LDIFF_SYM86
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde12_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1:System.Collections.Generic.ICollection<T>.Add"
	.long _System_Collections_Generic_LinkedList_1_System_Collections_Generic_ICollection_T_Add_T
	.long Lme_d

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM87=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM87
	.byte 2,125,0,3
	.asciz "value"

LDIFF_SYM88=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM88
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM89=Lfde13_end - Lfde13_start
	.long LDIFF_SYM89
Lfde13_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_System_Collections_Generic_ICollection_T_Add_T

LDIFF_SYM90=Lme_d - _System_Collections_Generic_LinkedList_1_System_Collections_Generic_ICollection_T_Add_T
	.long LDIFF_SYM90
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde13_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1:System.Collections.Generic.IEnumerable<T>.GetEnumerator"
	.long _System_Collections_Generic_LinkedList_1_System_Collections_Generic_IEnumerable_T_GetEnumerator
	.long Lme_e

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM91=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM91
	.byte 2,125,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM92=Lfde14_end - Lfde14_start
	.long LDIFF_SYM92
Lfde14_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_System_Collections_Generic_IEnumerable_T_GetEnumerator

LDIFF_SYM93=Lme_e - _System_Collections_Generic_LinkedList_1_System_Collections_Generic_IEnumerable_T_GetEnumerator
	.long LDIFF_SYM93
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,40
	.align 2
Lfde14_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1:System.Collections.IEnumerable.GetEnumerator"
	.long _System_Collections_Generic_LinkedList_1_System_Collections_IEnumerable_GetEnumerator
	.long Lme_f

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM94=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM94
	.byte 2,125,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM95=Lfde15_end - Lfde15_start
	.long LDIFF_SYM95
Lfde15_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_System_Collections_IEnumerable_GetEnumerator

LDIFF_SYM96=Lme_f - _System_Collections_Generic_LinkedList_1_System_Collections_IEnumerable_GetEnumerator
	.long LDIFF_SYM96
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,40
	.align 2
Lfde15_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1:get_Count"
	.long _System_Collections_Generic_LinkedList_1_get_Count
	.long Lme_10

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM97=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM97
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM98=Lfde16_end - Lfde16_start
	.long LDIFF_SYM98
Lfde16_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_get_Count

LDIFF_SYM99=Lme_10 - _System_Collections_Generic_LinkedList_1_get_Count
	.long LDIFF_SYM99
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde16_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1:get_Last"
	.long _System_Collections_Generic_LinkedList_1_get_Last
	.long Lme_11

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM100=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM100
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM101=Lfde17_end - Lfde17_start
	.long LDIFF_SYM101
Lfde17_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_get_Last

LDIFF_SYM102=Lme_11 - _System_Collections_Generic_LinkedList_1_get_Last
	.long LDIFF_SYM102
	.byte 12,13,0,72,14,8,135,2,68,14,16,136,4,138,3,142,1,68,14,24
	.align 2
Lfde17_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1:System.Collections.Generic.ICollection<T>.get_IsReadOnly"
	.long _System_Collections_Generic_LinkedList_1_System_Collections_Generic_ICollection_T_get_IsReadOnly
	.long Lme_12

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM103=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM103
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM104=Lfde18_end - Lfde18_start
	.long LDIFF_SYM104
Lfde18_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_System_Collections_Generic_ICollection_T_get_IsReadOnly

LDIFF_SYM105=Lme_12 - _System_Collections_Generic_LinkedList_1_System_Collections_Generic_ICollection_T_get_IsReadOnly
	.long LDIFF_SYM105
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde18_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1:System.Collections.ICollection.get_SyncRoot"
	.long _System_Collections_Generic_LinkedList_1_System_Collections_ICollection_get_SyncRoot
	.long Lme_13

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM106=LTDIE_0_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM106
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM107=Lfde19_end - Lfde19_start
	.long LDIFF_SYM107
Lfde19_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_System_Collections_ICollection_get_SyncRoot

LDIFF_SYM108=Lme_13 - _System_Collections_Generic_LinkedList_1_System_Collections_ICollection_get_SyncRoot
	.long LDIFF_SYM108
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde19_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_8:

	.byte 5
	.asciz "System_Collections_Generic_LinkedListNode`1"

	.byte 24,16
LDIFF_SYM109=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM109
	.byte 2,35,0,6
	.asciz "item"

LDIFF_SYM110=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM110
	.byte 2,35,8,6
	.asciz "container"

LDIFF_SYM111=LTDIE_7_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM111
	.byte 2,35,12,6
	.asciz "forward"

LDIFF_SYM112=LTDIE_8_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM112
	.byte 2,35,16,6
	.asciz "back"

LDIFF_SYM113=LTDIE_8_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM113
	.byte 2,35,20,0,7
	.asciz "System_Collections_Generic_LinkedListNode`1"

LDIFF_SYM114=LTDIE_8 - Ldebug_info_start
	.long LDIFF_SYM114
LTDIE_8_POINTER:

	.byte 13
LDIFF_SYM115=LTDIE_8 - Ldebug_info_start
	.long LDIFF_SYM115
LTDIE_8_REFERENCE:

	.byte 14
LDIFF_SYM116=LTDIE_8 - Ldebug_info_start
	.long LDIFF_SYM116
LTDIE_7:

	.byte 5
	.asciz "System_Collections_Generic_LinkedList`1"

	.byte 20,16
LDIFF_SYM117=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM117
	.byte 2,35,0,6
	.asciz "count"

LDIFF_SYM118=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM118
	.byte 2,35,12,6
	.asciz "version"

LDIFF_SYM119=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM119
	.byte 2,35,16,6
	.asciz "first"

LDIFF_SYM120=LTDIE_8_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM120
	.byte 2,35,8,0,7
	.asciz "System_Collections_Generic_LinkedList`1"

LDIFF_SYM121=LTDIE_7 - Ldebug_info_start
	.long LDIFF_SYM121
LTDIE_7_POINTER:

	.byte 13
LDIFF_SYM122=LTDIE_7 - Ldebug_info_start
	.long LDIFF_SYM122
LTDIE_7_REFERENCE:

	.byte 14
LDIFF_SYM123=LTDIE_7 - Ldebug_info_start
	.long LDIFF_SYM123
LTDIE_6:

	.byte 5
	.asciz "_Enumerator"

	.byte 24,16
LDIFF_SYM124=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM124
	.byte 2,35,0,6
	.asciz "list"

LDIFF_SYM125=LTDIE_7_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM125
	.byte 2,35,0,6
	.asciz "current"

LDIFF_SYM126=LTDIE_8_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM126
	.byte 2,35,4,6
	.asciz "index"

LDIFF_SYM127=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM127
	.byte 2,35,8,6
	.asciz "version"

LDIFF_SYM128=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM128
	.byte 2,35,12,0,7
	.asciz "_Enumerator"

LDIFF_SYM129=LTDIE_6 - Ldebug_info_start
	.long LDIFF_SYM129
LTDIE_6_POINTER:

	.byte 13
LDIFF_SYM130=LTDIE_6 - Ldebug_info_start
	.long LDIFF_SYM130
LTDIE_6_REFERENCE:

	.byte 14
LDIFF_SYM131=LTDIE_6 - Ldebug_info_start
	.long LDIFF_SYM131
	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1/Enumerator:.ctor"
	.long _System_Collections_Generic_LinkedList_1_Enumerator__ctor_System_Collections_Generic_LinkedList_1_T
	.long Lme_14

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM132=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM132
	.byte 1,86,3
	.asciz "parent"

LDIFF_SYM133=LTDIE_7_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM133
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM134=Lfde20_end - Lfde20_start
	.long LDIFF_SYM134
Lfde20_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_Enumerator__ctor_System_Collections_Generic_LinkedList_1_T

LDIFF_SYM135=Lme_14 - _System_Collections_Generic_LinkedList_1_Enumerator__ctor_System_Collections_Generic_LinkedList_1_T
	.long LDIFF_SYM135
	.byte 12,13,0,72,14,8,135,2,68,14,16,134,4,136,3,142,1,68,14,24
	.align 2
Lfde20_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1/Enumerator:get_Current"
	.long _System_Collections_Generic_LinkedList_1_Enumerator_get_Current
	.long Lme_15

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM136=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM136
	.byte 1,90,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM137=Lfde21_end - Lfde21_start
	.long LDIFF_SYM137
Lfde21_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_Enumerator_get_Current

LDIFF_SYM138=Lme_15 - _System_Collections_Generic_LinkedList_1_Enumerator_get_Current
	.long LDIFF_SYM138
	.byte 12,13,0,72,14,8,135,2,68,14,16,136,4,138,3,142,1,68,14,24
	.align 2
Lfde21_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1/Enumerator:System.Collections.IEnumerator.get_Current"
	.long _System_Collections_Generic_LinkedList_1_Enumerator_System_Collections_IEnumerator_get_Current
	.long Lme_16

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM139=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM139
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM140=Lfde22_end - Lfde22_start
	.long LDIFF_SYM140
Lfde22_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_Enumerator_System_Collections_IEnumerator_get_Current

LDIFF_SYM141=Lme_16 - _System_Collections_Generic_LinkedList_1_Enumerator_System_Collections_IEnumerator_get_Current
	.long LDIFF_SYM141
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde22_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1/Enumerator:MoveNext"
	.long _System_Collections_Generic_LinkedList_1_Enumerator_MoveNext
	.long Lme_17

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM142=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM142
	.byte 1,90,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM143=Lfde23_end - Lfde23_start
	.long LDIFF_SYM143
Lfde23_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_Enumerator_MoveNext

LDIFF_SYM144=Lme_17 - _System_Collections_Generic_LinkedList_1_Enumerator_MoveNext
	.long LDIFF_SYM144
	.byte 12,13,0,72,14,8,135,2,68,14,16,136,4,138,3,142,1,68,14,24
	.align 2
Lfde23_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1/Enumerator:Dispose"
	.long _System_Collections_Generic_LinkedList_1_Enumerator_Dispose
	.long Lme_18

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM145=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM145
	.byte 1,90,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM146=Lfde24_end - Lfde24_start
	.long LDIFF_SYM146
Lfde24_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_Enumerator_Dispose

LDIFF_SYM147=Lme_18 - _System_Collections_Generic_LinkedList_1_Enumerator_Dispose
	.long LDIFF_SYM147
	.byte 12,13,0,72,14,8,135,2,68,14,16,136,4,138,3,142,1,68,14,24
	.align 2
Lfde24_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_10:

	.byte 5
	.asciz "System_Collections_Generic_LinkedList`1"

	.byte 20,16
LDIFF_SYM148=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM148
	.byte 2,35,0,6
	.asciz "count"

LDIFF_SYM149=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM149
	.byte 2,35,12,6
	.asciz "version"

LDIFF_SYM150=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM150
	.byte 2,35,16,6
	.asciz "first"

LDIFF_SYM151=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM151
	.byte 2,35,8,0,7
	.asciz "System_Collections_Generic_LinkedList`1"

LDIFF_SYM152=LTDIE_10 - Ldebug_info_start
	.long LDIFF_SYM152
LTDIE_10_POINTER:

	.byte 13
LDIFF_SYM153=LTDIE_10 - Ldebug_info_start
	.long LDIFF_SYM153
LTDIE_10_REFERENCE:

	.byte 14
LDIFF_SYM154=LTDIE_10 - Ldebug_info_start
	.long LDIFF_SYM154
LTDIE_9:

	.byte 5
	.asciz "System_Collections_Generic_LinkedListNode`1"

	.byte 24,16
LDIFF_SYM155=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM155
	.byte 2,35,0,6
	.asciz "item"

LDIFF_SYM156=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM156
	.byte 2,35,8,6
	.asciz "container"

LDIFF_SYM157=LTDIE_10_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM157
	.byte 2,35,12,6
	.asciz "forward"

LDIFF_SYM158=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM158
	.byte 2,35,16,6
	.asciz "back"

LDIFF_SYM159=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM159
	.byte 2,35,20,0,7
	.asciz "System_Collections_Generic_LinkedListNode`1"

LDIFF_SYM160=LTDIE_9 - Ldebug_info_start
	.long LDIFF_SYM160
LTDIE_9_POINTER:

	.byte 13
LDIFF_SYM161=LTDIE_9 - Ldebug_info_start
	.long LDIFF_SYM161
LTDIE_9_REFERENCE:

	.byte 14
LDIFF_SYM162=LTDIE_9 - Ldebug_info_start
	.long LDIFF_SYM162
	.byte 2
	.asciz "System.Collections.Generic.LinkedListNode`1:.ctor"
	.long _System_Collections_Generic_LinkedListNode_1__ctor_T
	.long Lme_19

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM163=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM163
	.byte 2,125,0,3
	.asciz "value"

LDIFF_SYM164=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM164
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM165=Lfde25_end - Lfde25_start
	.long LDIFF_SYM165
Lfde25_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedListNode_1__ctor_T

LDIFF_SYM166=Lme_19 - _System_Collections_Generic_LinkedListNode_1__ctor_T
	.long LDIFF_SYM166
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde25_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedListNode`1:.ctor"
	.long _System_Collections_Generic_LinkedListNode_1__ctor_System_Collections_Generic_LinkedList_1_T_T
	.long Lme_1a

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM167=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM167
	.byte 2,125,0,3
	.asciz "list"

LDIFF_SYM168=LTDIE_10_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM168
	.byte 2,125,4,3
	.asciz "value"

LDIFF_SYM169=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM169
	.byte 2,125,8,11
	.asciz ""

LDIFF_SYM170=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM170
	.byte 0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM171=Lfde26_end - Lfde26_start
	.long LDIFF_SYM171
Lfde26_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedListNode_1__ctor_System_Collections_Generic_LinkedList_1_T_T

LDIFF_SYM172=Lme_1a - _System_Collections_Generic_LinkedListNode_1__ctor_System_Collections_Generic_LinkedList_1_T_T
	.long LDIFF_SYM172
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,32
	.align 2
Lfde26_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedListNode`1:.ctor"
	.long _System_Collections_Generic_LinkedListNode_1__ctor_System_Collections_Generic_LinkedList_1_T_T_System_Collections_Generic_LinkedListNode_1_T_System_Collections_Generic_LinkedListNode_1_T
	.long Lme_1b

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM173=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM173
	.byte 2,123,0,3
	.asciz "list"

LDIFF_SYM174=LTDIE_10_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM174
	.byte 2,123,4,3
	.asciz "value"

LDIFF_SYM175=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM175
	.byte 2,123,8,3
	.asciz "previousNode"

LDIFF_SYM176=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM176
	.byte 2,123,12,3
	.asciz "nextNode"

LDIFF_SYM177=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM177
	.byte 2,123,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM178=Lfde27_end - Lfde27_start
	.long LDIFF_SYM178
Lfde27_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedListNode_1__ctor_System_Collections_Generic_LinkedList_1_T_T_System_Collections_Generic_LinkedListNode_1_T_System_Collections_Generic_LinkedListNode_1_T

LDIFF_SYM179=Lme_1b - _System_Collections_Generic_LinkedListNode_1__ctor_System_Collections_Generic_LinkedList_1_T_T_System_Collections_Generic_LinkedListNode_1_T_System_Collections_Generic_LinkedListNode_1_T
	.long LDIFF_SYM179
	.byte 12,13,0,72,14,8,135,2,68,14,16,136,4,139,3,142,1,68,14,40,68,13,11
	.align 2
Lfde27_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedListNode`1:Detach"
	.long _System_Collections_Generic_LinkedListNode_1_Detach
	.long Lme_1c

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM180=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM180
	.byte 2,125,0,11
	.asciz ""

LDIFF_SYM181=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM181
	.byte 0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM182=Lfde28_end - Lfde28_start
	.long LDIFF_SYM182
Lfde28_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedListNode_1_Detach

LDIFF_SYM183=Lme_1c - _System_Collections_Generic_LinkedListNode_1_Detach
	.long LDIFF_SYM183
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde28_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedListNode`1:SelfReference"
	.long _System_Collections_Generic_LinkedListNode_1_SelfReference_System_Collections_Generic_LinkedList_1_T
	.long Lme_1d

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM184=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM184
	.byte 2,125,0,3
	.asciz "list"

LDIFF_SYM185=LTDIE_10_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM185
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM186=Lfde29_end - Lfde29_start
	.long LDIFF_SYM186
Lfde29_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedListNode_1_SelfReference_System_Collections_Generic_LinkedList_1_T

LDIFF_SYM187=Lme_1d - _System_Collections_Generic_LinkedListNode_1_SelfReference_System_Collections_Generic_LinkedList_1_T
	.long LDIFF_SYM187
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde29_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedListNode`1:InsertBetween"
	.long _System_Collections_Generic_LinkedListNode_1_InsertBetween_System_Collections_Generic_LinkedListNode_1_T_System_Collections_Generic_LinkedListNode_1_T_System_Collections_Generic_LinkedList_1_T
	.long Lme_1e

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM188=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM188
	.byte 2,125,0,3
	.asciz "previousNode"

LDIFF_SYM189=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM189
	.byte 2,125,4,3
	.asciz "nextNode"

LDIFF_SYM190=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM190
	.byte 2,125,8,3
	.asciz "list"

LDIFF_SYM191=LTDIE_10_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM191
	.byte 2,125,12,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM192=Lfde30_end - Lfde30_start
	.long LDIFF_SYM192
Lfde30_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedListNode_1_InsertBetween_System_Collections_Generic_LinkedListNode_1_T_System_Collections_Generic_LinkedListNode_1_T_System_Collections_Generic_LinkedList_1_T

LDIFF_SYM193=Lme_1e - _System_Collections_Generic_LinkedListNode_1_InsertBetween_System_Collections_Generic_LinkedListNode_1_T_System_Collections_Generic_LinkedListNode_1_T_System_Collections_Generic_LinkedList_1_T
	.long LDIFF_SYM193
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,32
	.align 2
Lfde30_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedListNode`1:get_List"
	.long _System_Collections_Generic_LinkedListNode_1_get_List
	.long Lme_1f

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM194=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM194
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM195=Lfde31_end - Lfde31_start
	.long LDIFF_SYM195
Lfde31_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedListNode_1_get_List

LDIFF_SYM196=Lme_1f - _System_Collections_Generic_LinkedListNode_1_get_List
	.long LDIFF_SYM196
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde31_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedListNode`1:get_Previous"
	.long _System_Collections_Generic_LinkedListNode_1_get_Previous
	.long Lme_20

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM197=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM197
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM198=Lfde32_end - Lfde32_start
	.long LDIFF_SYM198
Lfde32_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedListNode_1_get_Previous

LDIFF_SYM199=Lme_20 - _System_Collections_Generic_LinkedListNode_1_get_Previous
	.long LDIFF_SYM199
	.byte 12,13,0,72,14,8,135,2,68,14,16,136,4,138,3,142,1,68,14,24
	.align 2
Lfde32_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedListNode`1:get_Value"
	.long _System_Collections_Generic_LinkedListNode_1_get_Value
	.long Lme_21

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM200=LTDIE_9_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM200
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM201=Lfde33_end - Lfde33_start
	.long LDIFF_SYM201
Lfde33_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedListNode_1_get_Value

LDIFF_SYM202=Lme_21 - _System_Collections_Generic_LinkedListNode_1_get_Value
	.long LDIFF_SYM202
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde33_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_11:

	.byte 5
	.asciz "System_Collections_Generic_Stack`1"

	.byte 20,16
LDIFF_SYM203=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM203
	.byte 2,35,0,6
	.asciz "_array"

LDIFF_SYM204=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM204
	.byte 2,35,8,6
	.asciz "_size"

LDIFF_SYM205=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM205
	.byte 2,35,12,6
	.asciz "_version"

LDIFF_SYM206=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM206
	.byte 2,35,16,0,7
	.asciz "System_Collections_Generic_Stack`1"

LDIFF_SYM207=LTDIE_11 - Ldebug_info_start
	.long LDIFF_SYM207
LTDIE_11_POINTER:

	.byte 13
LDIFF_SYM208=LTDIE_11 - Ldebug_info_start
	.long LDIFF_SYM208
LTDIE_11_REFERENCE:

	.byte 14
LDIFF_SYM209=LTDIE_11 - Ldebug_info_start
	.long LDIFF_SYM209
	.byte 2
	.asciz "System.Collections.Generic.Stack`1:.ctor"
	.long _System_Collections_Generic_Stack_1__ctor
	.long Lme_22

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM210=LTDIE_11_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM210
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM211=Lfde34_end - Lfde34_start
	.long LDIFF_SYM211
Lfde34_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_Stack_1__ctor

LDIFF_SYM212=Lme_22 - _System_Collections_Generic_Stack_1__ctor
	.long LDIFF_SYM212
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde34_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.Stack`1:Peek"
	.long _System_Collections_Generic_Stack_1_Peek
	.long Lme_23

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM213=LTDIE_11_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM213
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM214=Lfde35_end - Lfde35_start
	.long LDIFF_SYM214
Lfde35_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_Stack_1_Peek

LDIFF_SYM215=Lme_23 - _System_Collections_Generic_Stack_1_Peek
	.long LDIFF_SYM215
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde35_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.Stack`1:Pop"
	.long _System_Collections_Generic_Stack_1_Pop
	.long Lme_24

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM216=LTDIE_11_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM216
	.byte 2,125,12,11
	.asciz "popped"

LDIFF_SYM217=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM217
	.byte 2,125,0,11
	.asciz ""

LDIFF_SYM218=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM218
	.byte 2,125,4,11
	.asciz ""

LDIFF_SYM219=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM219
	.byte 2,125,8,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM220=Lfde36_end - Lfde36_start
	.long LDIFF_SYM220
Lfde36_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_Stack_1_Pop

LDIFF_SYM221=Lme_24 - _System_Collections_Generic_Stack_1_Pop
	.long LDIFF_SYM221
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,32
	.align 2
Lfde36_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.Stack`1:Push"
	.long _System_Collections_Generic_Stack_1_Push_T
	.long Lme_25

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM222=LTDIE_11_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM222
	.byte 2,125,8,3
	.asciz "item"

LDIFF_SYM223=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM223
	.byte 2,125,12,11
	.asciz ""

LDIFF_SYM224=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM224
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM225=Lfde37_end - Lfde37_start
	.long LDIFF_SYM225
Lfde37_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_Stack_1_Push_T

LDIFF_SYM226=Lme_25 - _System_Collections_Generic_Stack_1_Push_T
	.long LDIFF_SYM226
	.byte 12,13,0,72,14,8,135,2,68,14,16,132,4,136,3,142,1,68,14,32
	.align 2
Lfde37_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.Stack`1:get_Count"
	.long _System_Collections_Generic_Stack_1_get_Count
	.long Lme_26

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM227=LTDIE_11_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM227
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM228=Lfde38_end - Lfde38_start
	.long LDIFF_SYM228
Lfde38_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_Stack_1_get_Count

LDIFF_SYM229=Lme_26 - _System_Collections_Generic_Stack_1_get_Count
	.long LDIFF_SYM229
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde38_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.Stack`1:System.Collections.ICollection.get_SyncRoot"
	.long _System_Collections_Generic_Stack_1_System_Collections_ICollection_get_SyncRoot
	.long Lme_27

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM230=LTDIE_11_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM230
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM231=Lfde39_end - Lfde39_start
	.long LDIFF_SYM231
Lfde39_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_Stack_1_System_Collections_ICollection_get_SyncRoot

LDIFF_SYM232=Lme_27 - _System_Collections_Generic_Stack_1_System_Collections_ICollection_get_SyncRoot
	.long LDIFF_SYM232
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde39_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.Stack`1:GetEnumerator"
	.long _System_Collections_Generic_Stack_1_GetEnumerator
	.long Lme_28

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM233=LTDIE_11_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM233
	.byte 2,125,28,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM234=Lfde40_end - Lfde40_start
	.long LDIFF_SYM234
Lfde40_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_Stack_1_GetEnumerator

LDIFF_SYM235=Lme_28 - _System_Collections_Generic_Stack_1_GetEnumerator
	.long LDIFF_SYM235
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,56
	.align 2
Lfde40_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.Stack`1:System.Collections.Generic.IEnumerable<T>.GetEnumerator"
	.long _System_Collections_Generic_Stack_1_System_Collections_Generic_IEnumerable_T_GetEnumerator
	.long Lme_29

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM236=LTDIE_11_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM236
	.byte 2,125,12,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM237=Lfde41_end - Lfde41_start
	.long LDIFF_SYM237
Lfde41_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_Stack_1_System_Collections_Generic_IEnumerable_T_GetEnumerator

LDIFF_SYM238=Lme_29 - _System_Collections_Generic_Stack_1_System_Collections_Generic_IEnumerable_T_GetEnumerator
	.long LDIFF_SYM238
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,32
	.align 2
Lfde41_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.Stack`1:System.Collections.IEnumerable.GetEnumerator"
	.long _System_Collections_Generic_Stack_1_System_Collections_IEnumerable_GetEnumerator
	.long Lme_2a

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM239=LTDIE_11_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM239
	.byte 2,125,12,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM240=Lfde42_end - Lfde42_start
	.long LDIFF_SYM240
Lfde42_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_Stack_1_System_Collections_IEnumerable_GetEnumerator

LDIFF_SYM241=Lme_2a - _System_Collections_Generic_Stack_1_System_Collections_IEnumerable_GetEnumerator
	.long LDIFF_SYM241
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,32
	.align 2
Lfde42_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_13:

	.byte 5
	.asciz "System_Collections_Generic_Stack`1"

	.byte 20,16
LDIFF_SYM242=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM242
	.byte 2,35,0,6
	.asciz "_array"

LDIFF_SYM243=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM243
	.byte 2,35,8,6
	.asciz "_size"

LDIFF_SYM244=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM244
	.byte 2,35,12,6
	.asciz "_version"

LDIFF_SYM245=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM245
	.byte 2,35,16,0,7
	.asciz "System_Collections_Generic_Stack`1"

LDIFF_SYM246=LTDIE_13 - Ldebug_info_start
	.long LDIFF_SYM246
LTDIE_13_POINTER:

	.byte 13
LDIFF_SYM247=LTDIE_13 - Ldebug_info_start
	.long LDIFF_SYM247
LTDIE_13_REFERENCE:

	.byte 14
LDIFF_SYM248=LTDIE_13 - Ldebug_info_start
	.long LDIFF_SYM248
LTDIE_12:

	.byte 5
	.asciz "_Enumerator"

	.byte 20,16
LDIFF_SYM249=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM249
	.byte 2,35,0,6
	.asciz "parent"

LDIFF_SYM250=LTDIE_13_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM250
	.byte 2,35,0,6
	.asciz "idx"

LDIFF_SYM251=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM251
	.byte 2,35,4,6
	.asciz "_version"

LDIFF_SYM252=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM252
	.byte 2,35,8,0,7
	.asciz "_Enumerator"

LDIFF_SYM253=LTDIE_12 - Ldebug_info_start
	.long LDIFF_SYM253
LTDIE_12_POINTER:

	.byte 13
LDIFF_SYM254=LTDIE_12 - Ldebug_info_start
	.long LDIFF_SYM254
LTDIE_12_REFERENCE:

	.byte 14
LDIFF_SYM255=LTDIE_12 - Ldebug_info_start
	.long LDIFF_SYM255
	.byte 2
	.asciz "System.Collections.Generic.Stack`1/Enumerator:.ctor"
	.long _System_Collections_Generic_Stack_1_Enumerator__ctor_System_Collections_Generic_Stack_1_T
	.long Lme_2b

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM256=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM256
	.byte 1,86,3
	.asciz "t"

LDIFF_SYM257=LTDIE_13_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM257
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM258=Lfde43_end - Lfde43_start
	.long LDIFF_SYM258
Lfde43_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_Stack_1_Enumerator__ctor_System_Collections_Generic_Stack_1_T

LDIFF_SYM259=Lme_2b - _System_Collections_Generic_Stack_1_Enumerator__ctor_System_Collections_Generic_Stack_1_T
	.long LDIFF_SYM259
	.byte 12,13,0,72,14,8,135,2,68,14,16,134,4,136,3,142,1,68,14,24
	.align 2
Lfde43_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.Stack`1/Enumerator:Dispose"
	.long _System_Collections_Generic_Stack_1_Enumerator_Dispose
	.long Lme_2c

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM260=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM260
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM261=Lfde44_end - Lfde44_start
	.long LDIFF_SYM261
Lfde44_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_Stack_1_Enumerator_Dispose

LDIFF_SYM262=Lme_2c - _System_Collections_Generic_Stack_1_Enumerator_Dispose
	.long LDIFF_SYM262
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde44_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.Stack`1/Enumerator:MoveNext"
	.long _System_Collections_Generic_Stack_1_Enumerator_MoveNext
	.long Lme_2d

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM263=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM263
	.byte 1,90,11
	.asciz ""

LDIFF_SYM264=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM264
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM265=Lfde45_end - Lfde45_start
	.long LDIFF_SYM265
Lfde45_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_Stack_1_Enumerator_MoveNext

LDIFF_SYM266=Lme_2d - _System_Collections_Generic_Stack_1_Enumerator_MoveNext
	.long LDIFF_SYM266
	.byte 12,13,0,72,14,8,135,2,68,14,20,133,5,136,4,138,3,142,1,68,14,32
	.align 2
Lfde45_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.Stack`1/Enumerator:get_Current"
	.long _System_Collections_Generic_Stack_1_Enumerator_get_Current
	.long Lme_2e

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM267=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM267
	.byte 1,90,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM268=Lfde46_end - Lfde46_start
	.long LDIFF_SYM268
Lfde46_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_Stack_1_Enumerator_get_Current

LDIFF_SYM269=Lme_2e - _System_Collections_Generic_Stack_1_Enumerator_get_Current
	.long LDIFF_SYM269
	.byte 12,13,0,72,14,8,135,2,68,14,16,136,4,138,3,142,1,68,14,24
	.align 2
Lfde46_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.Stack`1/Enumerator:System.Collections.IEnumerator.get_Current"
	.long _System_Collections_Generic_Stack_1_Enumerator_System_Collections_IEnumerator_get_Current
	.long Lme_2f

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM270=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM270
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM271=Lfde47_end - Lfde47_start
	.long LDIFF_SYM271
Lfde47_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_Stack_1_Enumerator_System_Collections_IEnumerator_get_Current

LDIFF_SYM272=Lme_2f - _System_Collections_Generic_Stack_1_Enumerator_System_Collections_IEnumerator_get_Current
	.long LDIFF_SYM272
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde47_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_16:

	.byte 17
	.asciz "System_Collections_IHashCodeProvider"

	.byte 8,7
	.asciz "System_Collections_IHashCodeProvider"

LDIFF_SYM273=LTDIE_16 - Ldebug_info_start
	.long LDIFF_SYM273
LTDIE_16_POINTER:

	.byte 13
LDIFF_SYM274=LTDIE_16 - Ldebug_info_start
	.long LDIFF_SYM274
LTDIE_16_REFERENCE:

	.byte 14
LDIFF_SYM275=LTDIE_16 - Ldebug_info_start
	.long LDIFF_SYM275
LTDIE_17:

	.byte 17
	.asciz "System_Collections_IComparer"

	.byte 8,7
	.asciz "System_Collections_IComparer"

LDIFF_SYM276=LTDIE_17 - Ldebug_info_start
	.long LDIFF_SYM276
LTDIE_17_POINTER:

	.byte 13
LDIFF_SYM277=LTDIE_17 - Ldebug_info_start
	.long LDIFF_SYM277
LTDIE_17_REFERENCE:

	.byte 14
LDIFF_SYM278=LTDIE_17 - Ldebug_info_start
	.long LDIFF_SYM278
LTDIE_18:

	.byte 5
	.asciz "System_Single"

	.byte 12,16
LDIFF_SYM279=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM279
	.byte 2,35,0,6
	.asciz "m_value"

LDIFF_SYM280=LDIE_R4 - Ldebug_info_start
	.long LDIFF_SYM280
	.byte 2,35,8,0,7
	.asciz "System_Single"

LDIFF_SYM281=LTDIE_18 - Ldebug_info_start
	.long LDIFF_SYM281
LTDIE_18_POINTER:

	.byte 13
LDIFF_SYM282=LTDIE_18 - Ldebug_info_start
	.long LDIFF_SYM282
LTDIE_18_REFERENCE:

	.byte 14
LDIFF_SYM283=LTDIE_18 - Ldebug_info_start
	.long LDIFF_SYM283
LTDIE_15:

	.byte 5
	.asciz "System_Collections_Hashtable"

	.byte 40,16
LDIFF_SYM284=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM284
	.byte 2,35,0,6
	.asciz "table"

LDIFF_SYM285=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM285
	.byte 2,35,8,6
	.asciz "hashes"

LDIFF_SYM286=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM286
	.byte 2,35,12,6
	.asciz "hcpRef"

LDIFF_SYM287=LTDIE_16_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM287
	.byte 2,35,16,6
	.asciz "comparerRef"

LDIFF_SYM288=LTDIE_17_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM288
	.byte 2,35,20,6
	.asciz "inUse"

LDIFF_SYM289=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM289
	.byte 2,35,24,6
	.asciz "modificationCount"

LDIFF_SYM290=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM290
	.byte 2,35,28,6
	.asciz "loadFactor"

LDIFF_SYM291=LDIE_R4 - Ldebug_info_start
	.long LDIFF_SYM291
	.byte 2,35,32,6
	.asciz "threshold"

LDIFF_SYM292=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM292
	.byte 2,35,36,0,7
	.asciz "System_Collections_Hashtable"

LDIFF_SYM293=LTDIE_15 - Ldebug_info_start
	.long LDIFF_SYM293
LTDIE_15_POINTER:

	.byte 13
LDIFF_SYM294=LTDIE_15 - Ldebug_info_start
	.long LDIFF_SYM294
LTDIE_15_REFERENCE:

	.byte 14
LDIFF_SYM295=LTDIE_15 - Ldebug_info_start
	.long LDIFF_SYM295
LTDIE_14:

	.byte 5
	.asciz "System_Collections_Specialized_StringDictionary"

	.byte 12,16
LDIFF_SYM296=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM296
	.byte 2,35,0,6
	.asciz "contents"

LDIFF_SYM297=LTDIE_15_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM297
	.byte 2,35,8,0,7
	.asciz "System_Collections_Specialized_StringDictionary"

LDIFF_SYM298=LTDIE_14 - Ldebug_info_start
	.long LDIFF_SYM298
LTDIE_14_POINTER:

	.byte 13
LDIFF_SYM299=LTDIE_14 - Ldebug_info_start
	.long LDIFF_SYM299
LTDIE_14_REFERENCE:

	.byte 14
LDIFF_SYM300=LTDIE_14 - Ldebug_info_start
	.long LDIFF_SYM300
	.byte 2
	.asciz "System.Collections.Specialized.StringDictionary:.ctor"
	.long _System_Collections_Specialized_StringDictionary__ctor
	.long Lme_30

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM301=LTDIE_14_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM301
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM302=Lfde48_end - Lfde48_start
	.long LDIFF_SYM302
Lfde48_start:

	.long 0
	.align 2
	.long _System_Collections_Specialized_StringDictionary__ctor

LDIFF_SYM303=Lme_30 - _System_Collections_Specialized_StringDictionary__ctor
	.long LDIFF_SYM303
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,32
	.align 2
Lfde48_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Specialized.StringDictionary:GetEnumerator"
	.long _System_Collections_Specialized_StringDictionary_GetEnumerator
	.long Lme_31

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM304=LTDIE_14_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM304
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM305=Lfde49_end - Lfde49_start
	.long LDIFF_SYM305
Lfde49_start:

	.long 0
	.align 2
	.long _System_Collections_Specialized_StringDictionary_GetEnumerator

LDIFF_SYM306=Lme_31 - _System_Collections_Specialized_StringDictionary_GetEnumerator
	.long LDIFF_SYM306
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde49_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_20:

	.byte 5
	.asciz "System_Collections_Stack"

	.byte 28,16
LDIFF_SYM307=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM307
	.byte 2,35,0,6
	.asciz "contents"

LDIFF_SYM308=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM308
	.byte 2,35,8,6
	.asciz "current"

LDIFF_SYM309=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM309
	.byte 2,35,12,6
	.asciz "count"

LDIFF_SYM310=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM310
	.byte 2,35,16,6
	.asciz "capacity"

LDIFF_SYM311=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM311
	.byte 2,35,20,6
	.asciz "modCount"

LDIFF_SYM312=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM312
	.byte 2,35,24,0,7
	.asciz "System_Collections_Stack"

LDIFF_SYM313=LTDIE_20 - Ldebug_info_start
	.long LDIFF_SYM313
LTDIE_20_POINTER:

	.byte 13
LDIFF_SYM314=LTDIE_20 - Ldebug_info_start
	.long LDIFF_SYM314
LTDIE_20_REFERENCE:

	.byte 14
LDIFF_SYM315=LTDIE_20 - Ldebug_info_start
	.long LDIFF_SYM315
LTDIE_19:

	.byte 5
	.asciz "System_Diagnostics_CorrelationManager"

	.byte 12,16
LDIFF_SYM316=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM316
	.byte 2,35,0,6
	.asciz "op_stack"

LDIFF_SYM317=LTDIE_20_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM317
	.byte 2,35,8,0,7
	.asciz "System_Diagnostics_CorrelationManager"

LDIFF_SYM318=LTDIE_19 - Ldebug_info_start
	.long LDIFF_SYM318
LTDIE_19_POINTER:

	.byte 13
LDIFF_SYM319=LTDIE_19 - Ldebug_info_start
	.long LDIFF_SYM319
LTDIE_19_REFERENCE:

	.byte 14
LDIFF_SYM320=LTDIE_19 - Ldebug_info_start
	.long LDIFF_SYM320
	.byte 2
	.asciz "System.Diagnostics.CorrelationManager:.ctor"
	.long _System_Diagnostics_CorrelationManager__ctor
	.long Lme_32

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM321=LTDIE_19_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM321
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM322=Lfde50_end - Lfde50_start
	.long LDIFF_SYM322
Lfde50_start:

	.long 0
	.align 2
	.long _System_Diagnostics_CorrelationManager__ctor

LDIFF_SYM323=Lme_32 - _System_Diagnostics_CorrelationManager__ctor
	.long LDIFF_SYM323
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,32
	.align 2
Lfde50_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_21:

	.byte 5
	.asciz "System_Boolean"

	.byte 9,16
LDIFF_SYM324=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM324
	.byte 2,35,0,6
	.asciz "m_value"

LDIFF_SYM325=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM325
	.byte 2,35,8,0,7
	.asciz "System_Boolean"

LDIFF_SYM326=LTDIE_21 - Ldebug_info_start
	.long LDIFF_SYM326
LTDIE_21_POINTER:

	.byte 13
LDIFF_SYM327=LTDIE_21 - Ldebug_info_start
	.long LDIFF_SYM327
LTDIE_21_REFERENCE:

	.byte 14
LDIFF_SYM328=LTDIE_21 - Ldebug_info_start
	.long LDIFF_SYM328
	.byte 2
	.asciz "System.Diagnostics.Debug:Assert"
	.long _System_Diagnostics_Debug_Assert_bool_string
	.long Lme_33

	.byte 2,118,16,3
	.asciz "condition"

LDIFF_SYM329=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM329
	.byte 2,125,0,3
	.asciz "message"

LDIFF_SYM330=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM330
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM331=Lfde51_end - Lfde51_start
	.long LDIFF_SYM331
Lfde51_start:

	.long 0
	.align 2
	.long _System_Diagnostics_Debug_Assert_bool_string

LDIFF_SYM332=Lme_33 - _System_Diagnostics_Debug_Assert_bool_string
	.long LDIFF_SYM332
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde51_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.DefaultTraceListener:.cctor"
	.long _System_Diagnostics_DefaultTraceListener__cctor
	.long Lme_34

	.byte 2,118,16,11
	.asciz "trace"

LDIFF_SYM333=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM333
	.byte 1,90,11
	.asciz "file"

LDIFF_SYM334=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM334
	.byte 1,86,11
	.asciz "prefix"

LDIFF_SYM335=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM335
	.byte 1,85,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM336=Lfde52_end - Lfde52_start
	.long LDIFF_SYM336
Lfde52_start:

	.long 0
	.align 2
	.long _System_Diagnostics_DefaultTraceListener__cctor

LDIFF_SYM337=Lme_34 - _System_Diagnostics_DefaultTraceListener__cctor
	.long LDIFF_SYM337
	.byte 12,13,0,72,14,8,135,2,68,14,24,133,6,134,5,136,4,138,3,142,1
	.align 2
Lfde52_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_24:

	.byte 5
	.asciz "System_MarshalByRefObject"

	.byte 12,16
LDIFF_SYM338=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM338
	.byte 2,35,0,6
	.asciz "_identity"

LDIFF_SYM339=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM339
	.byte 2,35,8,0,7
	.asciz "System_MarshalByRefObject"

LDIFF_SYM340=LTDIE_24 - Ldebug_info_start
	.long LDIFF_SYM340
LTDIE_24_POINTER:

	.byte 13
LDIFF_SYM341=LTDIE_24 - Ldebug_info_start
	.long LDIFF_SYM341
LTDIE_24_REFERENCE:

	.byte 14
LDIFF_SYM342=LTDIE_24 - Ldebug_info_start
	.long LDIFF_SYM342
LTDIE_23:

	.byte 5
	.asciz "System_Diagnostics_TraceListener"

	.byte 32,16
LDIFF_SYM343=LTDIE_24 - Ldebug_info_start
	.long LDIFF_SYM343
	.byte 2,35,0,6
	.asciz "indentLevel"

LDIFF_SYM344=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM344
	.byte 2,35,20,6
	.asciz "indentSize"

LDIFF_SYM345=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM345
	.byte 2,35,24,6
	.asciz "attributes"

LDIFF_SYM346=LTDIE_14_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM346
	.byte 2,35,12,6
	.asciz "name"

LDIFF_SYM347=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM347
	.byte 2,35,16,6
	.asciz "needIndent"

LDIFF_SYM348=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM348
	.byte 2,35,28,0,7
	.asciz "System_Diagnostics_TraceListener"

LDIFF_SYM349=LTDIE_23 - Ldebug_info_start
	.long LDIFF_SYM349
LTDIE_23_POINTER:

	.byte 13
LDIFF_SYM350=LTDIE_23 - Ldebug_info_start
	.long LDIFF_SYM350
LTDIE_23_REFERENCE:

	.byte 14
LDIFF_SYM351=LTDIE_23 - Ldebug_info_start
	.long LDIFF_SYM351
LTDIE_22:

	.byte 5
	.asciz "System_Diagnostics_DefaultTraceListener"

	.byte 40,16
LDIFF_SYM352=LTDIE_23 - Ldebug_info_start
	.long LDIFF_SYM352
	.byte 2,35,0,6
	.asciz "logFileName"

LDIFF_SYM353=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM353
	.byte 2,35,32,6
	.asciz "assertUiEnabled"

LDIFF_SYM354=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM354
	.byte 2,35,36,0,7
	.asciz "System_Diagnostics_DefaultTraceListener"

LDIFF_SYM355=LTDIE_22 - Ldebug_info_start
	.long LDIFF_SYM355
LTDIE_22_POINTER:

	.byte 13
LDIFF_SYM356=LTDIE_22 - Ldebug_info_start
	.long LDIFF_SYM356
LTDIE_22_REFERENCE:

	.byte 14
LDIFF_SYM357=LTDIE_22 - Ldebug_info_start
	.long LDIFF_SYM357
	.byte 2
	.asciz "System.Diagnostics.DefaultTraceListener:.ctor"
	.long _System_Diagnostics_DefaultTraceListener__ctor
	.long Lme_35

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM358=LTDIE_22_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM358
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM359=Lfde53_end - Lfde53_start
	.long LDIFF_SYM359
Lfde53_start:

	.long 0
	.align 2
	.long _System_Diagnostics_DefaultTraceListener__ctor

LDIFF_SYM360=Lme_35 - _System_Diagnostics_DefaultTraceListener__ctor
	.long LDIFF_SYM360
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde53_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.DefaultTraceListener:GetPrefix"
	.long _System_Diagnostics_DefaultTraceListener_GetPrefix_string_string
	.long Lme_36

	.byte 2,118,16,3
	.asciz "var"

LDIFF_SYM361=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM361
	.byte 1,86,3
	.asciz "target"

LDIFF_SYM362=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM362
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM363=Lfde54_end - Lfde54_start
	.long LDIFF_SYM363
Lfde54_start:

	.long 0
	.align 2
	.long _System_Diagnostics_DefaultTraceListener_GetPrefix_string_string

LDIFF_SYM364=Lme_36 - _System_Diagnostics_DefaultTraceListener_GetPrefix_string_string
	.long LDIFF_SYM364
	.byte 12,13,0,72,14,8,135,2,68,14,16,134,4,136,3,142,1,68,14,24
	.align 2
Lfde54_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.DefaultTraceListener:get_AssertUiEnabled"
	.long _System_Diagnostics_DefaultTraceListener_get_AssertUiEnabled
	.long Lme_37

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM365=LTDIE_22_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM365
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM366=Lfde55_end - Lfde55_start
	.long LDIFF_SYM366
Lfde55_start:

	.long 0
	.align 2
	.long _System_Diagnostics_DefaultTraceListener_get_AssertUiEnabled

LDIFF_SYM367=Lme_37 - _System_Diagnostics_DefaultTraceListener_get_AssertUiEnabled
	.long LDIFF_SYM367
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde55_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.DefaultTraceListener:get_LogFileName"
	.long _System_Diagnostics_DefaultTraceListener_get_LogFileName
	.long Lme_38

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM368=LTDIE_22_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM368
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM369=Lfde56_end - Lfde56_start
	.long LDIFF_SYM369
Lfde56_start:

	.long 0
	.align 2
	.long _System_Diagnostics_DefaultTraceListener_get_LogFileName

LDIFF_SYM370=Lme_38 - _System_Diagnostics_DefaultTraceListener_get_LogFileName
	.long LDIFF_SYM370
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde56_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.DefaultTraceListener:Fail"
	.long _System_Diagnostics_DefaultTraceListener_Fail_string
	.long Lme_39

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM371=LTDIE_22_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM371
	.byte 2,125,0,3
	.asciz "message"

LDIFF_SYM372=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM372
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM373=Lfde57_end - Lfde57_start
	.long LDIFF_SYM373
Lfde57_start:

	.long 0
	.align 2
	.long _System_Diagnostics_DefaultTraceListener_Fail_string

LDIFF_SYM374=Lme_39 - _System_Diagnostics_DefaultTraceListener_Fail_string
	.long LDIFF_SYM374
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde57_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.DefaultTraceListener:Fail"
	.long _System_Diagnostics_DefaultTraceListener_Fail_string_string
	.long Lme_3a

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM375=LTDIE_22_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM375
	.byte 1,85,3
	.asciz "message"

LDIFF_SYM376=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM376
	.byte 2,125,0,3
	.asciz "detailMessage"

LDIFF_SYM377=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM377
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM378=Lfde58_end - Lfde58_start
	.long LDIFF_SYM378
Lfde58_start:

	.long 0
	.align 2
	.long _System_Diagnostics_DefaultTraceListener_Fail_string_string

LDIFF_SYM379=Lme_3a - _System_Diagnostics_DefaultTraceListener_Fail_string_string
	.long LDIFF_SYM379
	.byte 12,13,0,72,14,8,135,2,68,14,16,133,4,136,3,142,1,68,14,32
	.align 2
Lfde58_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_27:

	.byte 5
	.asciz "System_Reflection_MemberInfo"

	.byte 8,16
LDIFF_SYM380=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM380
	.byte 2,35,0,0,7
	.asciz "System_Reflection_MemberInfo"

LDIFF_SYM381=LTDIE_27 - Ldebug_info_start
	.long LDIFF_SYM381
LTDIE_27_POINTER:

	.byte 13
LDIFF_SYM382=LTDIE_27 - Ldebug_info_start
	.long LDIFF_SYM382
LTDIE_27_REFERENCE:

	.byte 14
LDIFF_SYM383=LTDIE_27 - Ldebug_info_start
	.long LDIFF_SYM383
LTDIE_26:

	.byte 5
	.asciz "System_Reflection_MethodBase"

	.byte 8,16
LDIFF_SYM384=LTDIE_27 - Ldebug_info_start
	.long LDIFF_SYM384
	.byte 2,35,0,0,7
	.asciz "System_Reflection_MethodBase"

LDIFF_SYM385=LTDIE_26 - Ldebug_info_start
	.long LDIFF_SYM385
LTDIE_26_POINTER:

	.byte 13
LDIFF_SYM386=LTDIE_26 - Ldebug_info_start
	.long LDIFF_SYM386
LTDIE_26_REFERENCE:

	.byte 14
LDIFF_SYM387=LTDIE_26 - Ldebug_info_start
	.long LDIFF_SYM387
LTDIE_25:

	.byte 5
	.asciz "System_Reflection_MethodInfo"

	.byte 8,16
LDIFF_SYM388=LTDIE_26 - Ldebug_info_start
	.long LDIFF_SYM388
	.byte 2,35,0,0,7
	.asciz "System_Reflection_MethodInfo"

LDIFF_SYM389=LTDIE_25 - Ldebug_info_start
	.long LDIFF_SYM389
LTDIE_25_POINTER:

	.byte 13
LDIFF_SYM390=LTDIE_25 - Ldebug_info_start
	.long LDIFF_SYM390
LTDIE_25_REFERENCE:

	.byte 14
LDIFF_SYM391=LTDIE_25 - Ldebug_info_start
	.long LDIFF_SYM391
LTDIE_29:

	.byte 5
	.asciz "_ResolveEventHolder"

	.byte 8,16
LDIFF_SYM392=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM392
	.byte 2,35,0,0,7
	.asciz "_ResolveEventHolder"

LDIFF_SYM393=LTDIE_29 - Ldebug_info_start
	.long LDIFF_SYM393
LTDIE_29_POINTER:

	.byte 13
LDIFF_SYM394=LTDIE_29 - Ldebug_info_start
	.long LDIFF_SYM394
LTDIE_29_REFERENCE:

	.byte 14
LDIFF_SYM395=LTDIE_29 - Ldebug_info_start
	.long LDIFF_SYM395
LTDIE_28:

	.byte 5
	.asciz "System_Reflection_Assembly"

	.byte 48,16
LDIFF_SYM396=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM396
	.byte 2,35,0,6
	.asciz "_mono_assembly"

LDIFF_SYM397=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM397
	.byte 2,35,8,6
	.asciz "resolve_event_holder"

LDIFF_SYM398=LTDIE_29_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM398
	.byte 2,35,12,6
	.asciz "_evidence"

LDIFF_SYM399=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM399
	.byte 2,35,16,6
	.asciz "_minimum"

LDIFF_SYM400=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM400
	.byte 2,35,20,6
	.asciz "_optional"

LDIFF_SYM401=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM401
	.byte 2,35,24,6
	.asciz "_refuse"

LDIFF_SYM402=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM402
	.byte 2,35,28,6
	.asciz "_granted"

LDIFF_SYM403=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM403
	.byte 2,35,32,6
	.asciz "_denied"

LDIFF_SYM404=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM404
	.byte 2,35,36,6
	.asciz "fromByteArray"

LDIFF_SYM405=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM405
	.byte 2,35,40,6
	.asciz "assemblyName"

LDIFF_SYM406=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM406
	.byte 2,35,44,0,7
	.asciz "System_Reflection_Assembly"

LDIFF_SYM407=LTDIE_28 - Ldebug_info_start
	.long LDIFF_SYM407
LTDIE_28_POINTER:

	.byte 13
LDIFF_SYM408=LTDIE_28 - Ldebug_info_start
	.long LDIFF_SYM408
LTDIE_28_REFERENCE:

	.byte 14
LDIFF_SYM409=LTDIE_28 - Ldebug_info_start
	.long LDIFF_SYM409
LTDIE_30:

	.byte 8
	.asciz "_DialogResult"

	.byte 4
LDIFF_SYM410=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM410
	.byte 9
	.asciz "None"

	.byte 0,9
	.asciz "Retry"

	.byte 1,9
	.asciz "Ignore"

	.byte 2,9
	.asciz "Abort"

	.byte 3,0,7
	.asciz "_DialogResult"

LDIFF_SYM411=LTDIE_30 - Ldebug_info_start
	.long LDIFF_SYM411
LTDIE_30_POINTER:

	.byte 13
LDIFF_SYM412=LTDIE_30 - Ldebug_info_start
	.long LDIFF_SYM412
LTDIE_30_REFERENCE:

	.byte 14
LDIFF_SYM413=LTDIE_30 - Ldebug_info_start
	.long LDIFF_SYM413
LTDIE_31:

	.byte 5
	.asciz "System_Type"

	.byte 12,16
LDIFF_SYM414=LTDIE_27 - Ldebug_info_start
	.long LDIFF_SYM414
	.byte 2,35,0,6
	.asciz "_impl"

LDIFF_SYM415=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM415
	.byte 2,35,8,0,7
	.asciz "System_Type"

LDIFF_SYM416=LTDIE_31 - Ldebug_info_start
	.long LDIFF_SYM416
LTDIE_31_POINTER:

	.byte 13
LDIFF_SYM417=LTDIE_31 - Ldebug_info_start
	.long LDIFF_SYM417
LTDIE_31_REFERENCE:

	.byte 14
LDIFF_SYM418=LTDIE_31 - Ldebug_info_start
	.long LDIFF_SYM418
	.byte 2
	.asciz "System.Diagnostics.DefaultTraceListener:ProcessUI"
	.long _System_Diagnostics_DefaultTraceListener_ProcessUI_string_string
	.long Lme_3b

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM419=LTDIE_22_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM419
	.byte 2,123,36,3
	.asciz "message"

LDIFF_SYM420=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM420
	.byte 2,123,40,3
	.asciz "detailMessage"

LDIFF_SYM421=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM421
	.byte 2,123,44,11
	.asciz "messageBoxButtonsAbortRetryIgnore"

LDIFF_SYM422=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM422
	.byte 2,123,0,11
	.asciz "msgboxShow"

LDIFF_SYM423=LTDIE_25_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM423
	.byte 1,84,11
	.asciz "wfAsm"

LDIFF_SYM424=LTDIE_28_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM424
	.byte 1,90,11
	.asciz ""

LDIFF_SYM425=LTDIE_30 - Ldebug_info_start
	.long LDIFF_SYM425
	.byte 2,123,4,11
	.asciz "buttons"

LDIFF_SYM426=LTDIE_31_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM426
	.byte 1,86,11
	.asciz "caption"

LDIFF_SYM427=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM427
	.byte 2,123,8,11
	.asciz "msg"

LDIFF_SYM428=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM428
	.byte 2,123,12,11
	.asciz ""

LDIFF_SYM429=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM429
	.byte 1,85,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM430=Lfde59_end - Lfde59_start
	.long LDIFF_SYM430
Lfde59_start:

	.long 0
	.align 2
	.long _System_Diagnostics_DefaultTraceListener_ProcessUI_string_string

LDIFF_SYM431=Lme_3b - _System_Diagnostics_DefaultTraceListener_ProcessUI_string_string
	.long LDIFF_SYM431
	.byte 12,13,0,72,14,8,135,2,68,14,32,132,8,133,7,134,6,136,5,138,4,139,3,142,1,68,14,128,1,68,13,11
	.align 2
Lfde59_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "(wrapper managed-to-native) System.Diagnostics.DefaultTraceListener:WriteWindowsDebugString"
	.long _wrapper_managed_to_native_System_Diagnostics_DefaultTraceListener_WriteWindowsDebugString_string
	.long Lme_3c

	.byte 2,118,16,3
	.asciz "param0"

LDIFF_SYM432=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM432
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM433=Lfde60_end - Lfde60_start
	.long LDIFF_SYM433
Lfde60_start:

	.long 0
	.align 2
	.long _wrapper_managed_to_native_System_Diagnostics_DefaultTraceListener_WriteWindowsDebugString_string

LDIFF_SYM434=Lme_3c - _wrapper_managed_to_native_System_Diagnostics_DefaultTraceListener_WriteWindowsDebugString_string
	.long LDIFF_SYM434
	.byte 12,13,0,72,14,8,135,2,72,14,48,132,12,133,11,134,10,136,8,137,7,138,6,139,5,140,4,142,3,68,14,224
	.byte 1
	.align 2
Lfde60_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.DefaultTraceListener:WriteDebugString"
	.long _System_Diagnostics_DefaultTraceListener_WriteDebugString_string
	.long Lme_3d

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM435=LTDIE_22_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM435
	.byte 2,125,0,3
	.asciz "message"

LDIFF_SYM436=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM436
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM437=Lfde61_end - Lfde61_start
	.long LDIFF_SYM437
Lfde61_start:

	.long 0
	.align 2
	.long _System_Diagnostics_DefaultTraceListener_WriteDebugString_string

LDIFF_SYM438=Lme_3d - _System_Diagnostics_DefaultTraceListener_WriteDebugString_string
	.long LDIFF_SYM438
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde61_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.DefaultTraceListener:WriteMonoTrace"
	.long _System_Diagnostics_DefaultTraceListener_WriteMonoTrace_string
	.long Lme_3e

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM439=LTDIE_22_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM439
	.byte 2,125,0,3
	.asciz "message"

LDIFF_SYM440=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM440
	.byte 1,90,11
	.asciz ""

LDIFF_SYM441=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM441
	.byte 1,85,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM442=Lfde62_end - Lfde62_start
	.long LDIFF_SYM442
Lfde62_start:

	.long 0
	.align 2
	.long _System_Diagnostics_DefaultTraceListener_WriteMonoTrace_string

LDIFF_SYM443=Lme_3e - _System_Diagnostics_DefaultTraceListener_WriteMonoTrace_string
	.long LDIFF_SYM443
	.byte 12,13,0,72,14,8,135,2,68,14,20,133,5,136,4,138,3,142,1,68,14,32
	.align 2
Lfde62_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.DefaultTraceListener:WritePrefix"
	.long _System_Diagnostics_DefaultTraceListener_WritePrefix
	.long Lme_3f

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM444=LTDIE_22_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM444
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM445=Lfde63_end - Lfde63_start
	.long LDIFF_SYM445
Lfde63_start:

	.long 0
	.align 2
	.long _System_Diagnostics_DefaultTraceListener_WritePrefix

LDIFF_SYM446=Lme_3f - _System_Diagnostics_DefaultTraceListener_WritePrefix
	.long LDIFF_SYM446
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde63_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.DefaultTraceListener:WriteImpl"
	.long _System_Diagnostics_DefaultTraceListener_WriteImpl_string
	.long Lme_40

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM447=LTDIE_22_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM447
	.byte 1,86,3
	.asciz "message"

LDIFF_SYM448=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM448
	.byte 1,90,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM449=Lfde64_end - Lfde64_start
	.long LDIFF_SYM449
Lfde64_start:

	.long 0
	.align 2
	.long _System_Diagnostics_DefaultTraceListener_WriteImpl_string

LDIFF_SYM450=Lme_40 - _System_Diagnostics_DefaultTraceListener_WriteImpl_string
	.long LDIFF_SYM450
	.byte 12,13,0,72,14,8,135,2,68,14,20,134,5,136,4,138,3,142,1,68,14,24
	.align 2
Lfde64_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_33:

	.byte 5
	.asciz "System_IO_FileSystemInfo"

	.byte 56,16
LDIFF_SYM451=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM451
	.byte 2,35,0,6
	.asciz "FullPath"

LDIFF_SYM452=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM452
	.byte 2,35,8,6
	.asciz "OriginalPath"

LDIFF_SYM453=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM453
	.byte 2,35,12,6
	.asciz "stat"

LDIFF_SYM454=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM454
	.byte 2,35,16,6
	.asciz "valid"

LDIFF_SYM455=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM455
	.byte 2,35,52,0,7
	.asciz "System_IO_FileSystemInfo"

LDIFF_SYM456=LTDIE_33 - Ldebug_info_start
	.long LDIFF_SYM456
LTDIE_33_POINTER:

	.byte 13
LDIFF_SYM457=LTDIE_33 - Ldebug_info_start
	.long LDIFF_SYM457
LTDIE_33_REFERENCE:

	.byte 14
LDIFF_SYM458=LTDIE_33 - Ldebug_info_start
	.long LDIFF_SYM458
LTDIE_32:

	.byte 5
	.asciz "System_IO_FileInfo"

	.byte 60,16
LDIFF_SYM459=LTDIE_33 - Ldebug_info_start
	.long LDIFF_SYM459
	.byte 2,35,0,6
	.asciz "exists"

LDIFF_SYM460=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM460
	.byte 2,35,56,0,7
	.asciz "System_IO_FileInfo"

LDIFF_SYM461=LTDIE_32 - Ldebug_info_start
	.long LDIFF_SYM461
LTDIE_32_POINTER:

	.byte 13
LDIFF_SYM462=LTDIE_32 - Ldebug_info_start
	.long LDIFF_SYM462
LTDIE_32_REFERENCE:

	.byte 14
LDIFF_SYM463=LTDIE_32 - Ldebug_info_start
	.long LDIFF_SYM463
LTDIE_35:

	.byte 5
	.asciz "System_IO_TextWriter"

	.byte 12,16
LDIFF_SYM464=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM464
	.byte 2,35,0,6
	.asciz "CoreNewLine"

LDIFF_SYM465=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM465
	.byte 2,35,8,0,7
	.asciz "System_IO_TextWriter"

LDIFF_SYM466=LTDIE_35 - Ldebug_info_start
	.long LDIFF_SYM466
LTDIE_35_POINTER:

	.byte 13
LDIFF_SYM467=LTDIE_35 - Ldebug_info_start
	.long LDIFF_SYM467
LTDIE_35_REFERENCE:

	.byte 14
LDIFF_SYM468=LTDIE_35 - Ldebug_info_start
	.long LDIFF_SYM468
LTDIE_37:

	.byte 5
	.asciz "System_Text_DecoderFallback"

	.byte 8,16
LDIFF_SYM469=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM469
	.byte 2,35,0,0,7
	.asciz "System_Text_DecoderFallback"

LDIFF_SYM470=LTDIE_37 - Ldebug_info_start
	.long LDIFF_SYM470
LTDIE_37_POINTER:

	.byte 13
LDIFF_SYM471=LTDIE_37 - Ldebug_info_start
	.long LDIFF_SYM471
LTDIE_37_REFERENCE:

	.byte 14
LDIFF_SYM472=LTDIE_37 - Ldebug_info_start
	.long LDIFF_SYM472
LTDIE_38:

	.byte 5
	.asciz "System_Text_EncoderFallback"

	.byte 8,16
LDIFF_SYM473=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM473
	.byte 2,35,0,0,7
	.asciz "System_Text_EncoderFallback"

LDIFF_SYM474=LTDIE_38 - Ldebug_info_start
	.long LDIFF_SYM474
LTDIE_38_POINTER:

	.byte 13
LDIFF_SYM475=LTDIE_38 - Ldebug_info_start
	.long LDIFF_SYM475
LTDIE_38_REFERENCE:

	.byte 14
LDIFF_SYM476=LTDIE_38 - Ldebug_info_start
	.long LDIFF_SYM476
LTDIE_36:

	.byte 5
	.asciz "System_Text_Encoding"

	.byte 48,16
LDIFF_SYM477=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM477
	.byte 2,35,0,6
	.asciz "codePage"

LDIFF_SYM478=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM478
	.byte 2,35,32,6
	.asciz "windows_code_page"

LDIFF_SYM479=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM479
	.byte 2,35,36,6
	.asciz "is_readonly"

LDIFF_SYM480=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM480
	.byte 2,35,40,6
	.asciz "decoder_fallback"

LDIFF_SYM481=LTDIE_37_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM481
	.byte 2,35,8,6
	.asciz "encoder_fallback"

LDIFF_SYM482=LTDIE_38_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM482
	.byte 2,35,12,6
	.asciz "is_mail_news_display"

LDIFF_SYM483=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM483
	.byte 2,35,41,6
	.asciz "is_mail_news_save"

LDIFF_SYM484=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM484
	.byte 2,35,42,6
	.asciz "is_browser_save"

LDIFF_SYM485=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM485
	.byte 2,35,43,6
	.asciz "is_browser_display"

LDIFF_SYM486=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM486
	.byte 2,35,44,6
	.asciz "body_name"

LDIFF_SYM487=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM487
	.byte 2,35,16,6
	.asciz "encoding_name"

LDIFF_SYM488=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM488
	.byte 2,35,20,6
	.asciz "header_name"

LDIFF_SYM489=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM489
	.byte 2,35,24,6
	.asciz "web_name"

LDIFF_SYM490=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM490
	.byte 2,35,28,0,7
	.asciz "System_Text_Encoding"

LDIFF_SYM491=LTDIE_36 - Ldebug_info_start
	.long LDIFF_SYM491
LTDIE_36_POINTER:

	.byte 13
LDIFF_SYM492=LTDIE_36 - Ldebug_info_start
	.long LDIFF_SYM492
LTDIE_36_REFERENCE:

	.byte 14
LDIFF_SYM493=LTDIE_36 - Ldebug_info_start
	.long LDIFF_SYM493
LTDIE_43:

	.byte 5
	.asciz "System_DelegateData"

	.byte 20,16
LDIFF_SYM494=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM494
	.byte 2,35,0,6
	.asciz "target_type"

LDIFF_SYM495=LTDIE_31_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM495
	.byte 2,35,8,6
	.asciz "method_name"

LDIFF_SYM496=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM496
	.byte 2,35,12,6
	.asciz "curried_first_arg"

LDIFF_SYM497=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM497
	.byte 2,35,16,0,7
	.asciz "System_DelegateData"

LDIFF_SYM498=LTDIE_43 - Ldebug_info_start
	.long LDIFF_SYM498
LTDIE_43_POINTER:

	.byte 13
LDIFF_SYM499=LTDIE_43 - Ldebug_info_start
	.long LDIFF_SYM499
LTDIE_43_REFERENCE:

	.byte 14
LDIFF_SYM500=LTDIE_43 - Ldebug_info_start
	.long LDIFF_SYM500
LTDIE_42:

	.byte 5
	.asciz "System_Delegate"

	.byte 44,16
LDIFF_SYM501=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM501
	.byte 2,35,0,6
	.asciz "method_ptr"

LDIFF_SYM502=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM502
	.byte 2,35,8,6
	.asciz "invoke_impl"

LDIFF_SYM503=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM503
	.byte 2,35,12,6
	.asciz "m_target"

LDIFF_SYM504=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM504
	.byte 2,35,16,6
	.asciz "method"

LDIFF_SYM505=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM505
	.byte 2,35,20,6
	.asciz "delegate_trampoline"

LDIFF_SYM506=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM506
	.byte 2,35,24,6
	.asciz "method_code"

LDIFF_SYM507=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM507
	.byte 2,35,28,6
	.asciz "method_info"

LDIFF_SYM508=LTDIE_25_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM508
	.byte 2,35,32,6
	.asciz "original_method_info"

LDIFF_SYM509=LTDIE_25_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM509
	.byte 2,35,36,6
	.asciz "data"

LDIFF_SYM510=LTDIE_43_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM510
	.byte 2,35,40,0,7
	.asciz "System_Delegate"

LDIFF_SYM511=LTDIE_42 - Ldebug_info_start
	.long LDIFF_SYM511
LTDIE_42_POINTER:

	.byte 13
LDIFF_SYM512=LTDIE_42 - Ldebug_info_start
	.long LDIFF_SYM512
LTDIE_42_REFERENCE:

	.byte 14
LDIFF_SYM513=LTDIE_42 - Ldebug_info_start
	.long LDIFF_SYM513
LTDIE_41:

	.byte 5
	.asciz "System_MulticastDelegate"

	.byte 52,16
LDIFF_SYM514=LTDIE_42 - Ldebug_info_start
	.long LDIFF_SYM514
	.byte 2,35,0,6
	.asciz "prev"

LDIFF_SYM515=LTDIE_41_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM515
	.byte 2,35,44,6
	.asciz "kpm_next"

LDIFF_SYM516=LTDIE_41_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM516
	.byte 2,35,48,0,7
	.asciz "System_MulticastDelegate"

LDIFF_SYM517=LTDIE_41 - Ldebug_info_start
	.long LDIFF_SYM517
LTDIE_41_POINTER:

	.byte 13
LDIFF_SYM518=LTDIE_41 - Ldebug_info_start
	.long LDIFF_SYM518
LTDIE_41_REFERENCE:

	.byte 14
LDIFF_SYM519=LTDIE_41 - Ldebug_info_start
	.long LDIFF_SYM519
LTDIE_40:

	.byte 5
	.asciz "System_Func`4"

	.byte 52,16
LDIFF_SYM520=LTDIE_41 - Ldebug_info_start
	.long LDIFF_SYM520
	.byte 2,35,0,0,7
	.asciz "System_Func`4"

LDIFF_SYM521=LTDIE_40 - Ldebug_info_start
	.long LDIFF_SYM521
LTDIE_40_POINTER:

	.byte 13
LDIFF_SYM522=LTDIE_40 - Ldebug_info_start
	.long LDIFF_SYM522
LTDIE_40_REFERENCE:

	.byte 14
LDIFF_SYM523=LTDIE_40 - Ldebug_info_start
	.long LDIFF_SYM523
LTDIE_44:

	.byte 5
	.asciz "System_Action`3"

	.byte 52,16
LDIFF_SYM524=LTDIE_41 - Ldebug_info_start
	.long LDIFF_SYM524
	.byte 2,35,0,0,7
	.asciz "System_Action`3"

LDIFF_SYM525=LTDIE_44 - Ldebug_info_start
	.long LDIFF_SYM525
LTDIE_44_POINTER:

	.byte 13
LDIFF_SYM526=LTDIE_44 - Ldebug_info_start
	.long LDIFF_SYM526
LTDIE_44_REFERENCE:

	.byte 14
LDIFF_SYM527=LTDIE_44 - Ldebug_info_start
	.long LDIFF_SYM527
LTDIE_51:

	.byte 5
	.asciz "System_Runtime_ConstrainedExecution_CriticalFinalizerObject"

	.byte 8,16
LDIFF_SYM528=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM528
	.byte 2,35,0,0,7
	.asciz "System_Runtime_ConstrainedExecution_CriticalFinalizerObject"

LDIFF_SYM529=LTDIE_51 - Ldebug_info_start
	.long LDIFF_SYM529
LTDIE_51_POINTER:

	.byte 13
LDIFF_SYM530=LTDIE_51 - Ldebug_info_start
	.long LDIFF_SYM530
LTDIE_51_REFERENCE:

	.byte 14
LDIFF_SYM531=LTDIE_51 - Ldebug_info_start
	.long LDIFF_SYM531
LTDIE_50:

	.byte 5
	.asciz "System_Runtime_InteropServices_SafeHandle"

	.byte 24,16
LDIFF_SYM532=LTDIE_51 - Ldebug_info_start
	.long LDIFF_SYM532
	.byte 2,35,0,6
	.asciz "handle"

LDIFF_SYM533=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM533
	.byte 2,35,8,6
	.asciz "invalid_handle_value"

LDIFF_SYM534=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM534
	.byte 2,35,12,6
	.asciz "refcount"

LDIFF_SYM535=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM535
	.byte 2,35,16,6
	.asciz "owns_handle"

LDIFF_SYM536=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM536
	.byte 2,35,20,0,7
	.asciz "System_Runtime_InteropServices_SafeHandle"

LDIFF_SYM537=LTDIE_50 - Ldebug_info_start
	.long LDIFF_SYM537
LTDIE_50_POINTER:

	.byte 13
LDIFF_SYM538=LTDIE_50 - Ldebug_info_start
	.long LDIFF_SYM538
LTDIE_50_REFERENCE:

	.byte 14
LDIFF_SYM539=LTDIE_50 - Ldebug_info_start
	.long LDIFF_SYM539
LTDIE_49:

	.byte 5
	.asciz "Microsoft_Win32_SafeHandles_SafeHandleZeroOrMinusOneIsInvalid"

	.byte 24,16
LDIFF_SYM540=LTDIE_50 - Ldebug_info_start
	.long LDIFF_SYM540
	.byte 2,35,0,0,7
	.asciz "Microsoft_Win32_SafeHandles_SafeHandleZeroOrMinusOneIsInvalid"

LDIFF_SYM541=LTDIE_49 - Ldebug_info_start
	.long LDIFF_SYM541
LTDIE_49_POINTER:

	.byte 13
LDIFF_SYM542=LTDIE_49 - Ldebug_info_start
	.long LDIFF_SYM542
LTDIE_49_REFERENCE:

	.byte 14
LDIFF_SYM543=LTDIE_49 - Ldebug_info_start
	.long LDIFF_SYM543
LTDIE_48:

	.byte 5
	.asciz "Microsoft_Win32_SafeHandles_SafeWaitHandle"

	.byte 24,16
LDIFF_SYM544=LTDIE_49 - Ldebug_info_start
	.long LDIFF_SYM544
	.byte 2,35,0,0,7
	.asciz "Microsoft_Win32_SafeHandles_SafeWaitHandle"

LDIFF_SYM545=LTDIE_48 - Ldebug_info_start
	.long LDIFF_SYM545
LTDIE_48_POINTER:

	.byte 13
LDIFF_SYM546=LTDIE_48 - Ldebug_info_start
	.long LDIFF_SYM546
LTDIE_48_REFERENCE:

	.byte 14
LDIFF_SYM547=LTDIE_48 - Ldebug_info_start
	.long LDIFF_SYM547
LTDIE_47:

	.byte 5
	.asciz "System_Threading_WaitHandle"

	.byte 20,16
LDIFF_SYM548=LTDIE_24 - Ldebug_info_start
	.long LDIFF_SYM548
	.byte 2,35,0,6
	.asciz "safe_wait_handle"

LDIFF_SYM549=LTDIE_48_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM549
	.byte 2,35,12,6
	.asciz "disposed"

LDIFF_SYM550=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM550
	.byte 2,35,16,0,7
	.asciz "System_Threading_WaitHandle"

LDIFF_SYM551=LTDIE_47 - Ldebug_info_start
	.long LDIFF_SYM551
LTDIE_47_POINTER:

	.byte 13
LDIFF_SYM552=LTDIE_47 - Ldebug_info_start
	.long LDIFF_SYM552
LTDIE_47_REFERENCE:

	.byte 14
LDIFF_SYM553=LTDIE_47 - Ldebug_info_start
	.long LDIFF_SYM553
LTDIE_46:

	.byte 5
	.asciz "System_Threading_EventWaitHandle"

	.byte 20,16
LDIFF_SYM554=LTDIE_47 - Ldebug_info_start
	.long LDIFF_SYM554
	.byte 2,35,0,0,7
	.asciz "System_Threading_EventWaitHandle"

LDIFF_SYM555=LTDIE_46 - Ldebug_info_start
	.long LDIFF_SYM555
LTDIE_46_POINTER:

	.byte 13
LDIFF_SYM556=LTDIE_46 - Ldebug_info_start
	.long LDIFF_SYM556
LTDIE_46_REFERENCE:

	.byte 14
LDIFF_SYM557=LTDIE_46 - Ldebug_info_start
	.long LDIFF_SYM557
LTDIE_45:

	.byte 5
	.asciz "System_Threading_AutoResetEvent"

	.byte 20,16
LDIFF_SYM558=LTDIE_46 - Ldebug_info_start
	.long LDIFF_SYM558
	.byte 2,35,0,0,7
	.asciz "System_Threading_AutoResetEvent"

LDIFF_SYM559=LTDIE_45 - Ldebug_info_start
	.long LDIFF_SYM559
LTDIE_45_POINTER:

	.byte 13
LDIFF_SYM560=LTDIE_45 - Ldebug_info_start
	.long LDIFF_SYM560
LTDIE_45_REFERENCE:

	.byte 14
LDIFF_SYM561=LTDIE_45 - Ldebug_info_start
	.long LDIFF_SYM561
LTDIE_39:

	.byte 5
	.asciz "System_IO_Stream"

	.byte 20,16
LDIFF_SYM562=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM562
	.byte 2,35,0,6
	.asciz "async_read"

LDIFF_SYM563=LTDIE_40_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM563
	.byte 2,35,8,6
	.asciz "async_write"

LDIFF_SYM564=LTDIE_44_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM564
	.byte 2,35,12,6
	.asciz "async_event"

LDIFF_SYM565=LTDIE_45_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM565
	.byte 2,35,16,0,7
	.asciz "System_IO_Stream"

LDIFF_SYM566=LTDIE_39 - Ldebug_info_start
	.long LDIFF_SYM566
LTDIE_39_POINTER:

	.byte 13
LDIFF_SYM567=LTDIE_39 - Ldebug_info_start
	.long LDIFF_SYM567
LTDIE_39_REFERENCE:

	.byte 14
LDIFF_SYM568=LTDIE_39 - Ldebug_info_start
	.long LDIFF_SYM568
LTDIE_52:

	.byte 17
	.asciz "System_Threading_Tasks_IDecoupledTask"

	.byte 8,7
	.asciz "System_Threading_Tasks_IDecoupledTask"

LDIFF_SYM569=LTDIE_52 - Ldebug_info_start
	.long LDIFF_SYM569
LTDIE_52_POINTER:

	.byte 13
LDIFF_SYM570=LTDIE_52 - Ldebug_info_start
	.long LDIFF_SYM570
LTDIE_52_REFERENCE:

	.byte 14
LDIFF_SYM571=LTDIE_52 - Ldebug_info_start
	.long LDIFF_SYM571
LTDIE_34:

	.byte 5
	.asciz "System_IO_StreamWriter"

	.byte 44,16
LDIFF_SYM572=LTDIE_35 - Ldebug_info_start
	.long LDIFF_SYM572
	.byte 2,35,0,6
	.asciz "internalEncoding"

LDIFF_SYM573=LTDIE_36_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM573
	.byte 2,35,12,6
	.asciz "internalStream"

LDIFF_SYM574=LTDIE_39_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM574
	.byte 2,35,16,6
	.asciz "byte_buf"

LDIFF_SYM575=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM575
	.byte 2,35,20,6
	.asciz "decode_buf"

LDIFF_SYM576=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM576
	.byte 2,35,24,6
	.asciz "byte_pos"

LDIFF_SYM577=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM577
	.byte 2,35,32,6
	.asciz "decode_pos"

LDIFF_SYM578=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM578
	.byte 2,35,36,6
	.asciz "iflush"

LDIFF_SYM579=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM579
	.byte 2,35,40,6
	.asciz "preamble_done"

LDIFF_SYM580=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM580
	.byte 2,35,41,6
	.asciz "leave_open"

LDIFF_SYM581=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM581
	.byte 2,35,42,6
	.asciz "async_task"

LDIFF_SYM582=LTDIE_52_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM582
	.byte 2,35,28,0,7
	.asciz "System_IO_StreamWriter"

LDIFF_SYM583=LTDIE_34 - Ldebug_info_start
	.long LDIFF_SYM583
LTDIE_34_POINTER:

	.byte 13
LDIFF_SYM584=LTDIE_34 - Ldebug_info_start
	.long LDIFF_SYM584
LTDIE_34_REFERENCE:

	.byte 14
LDIFF_SYM585=LTDIE_34 - Ldebug_info_start
	.long LDIFF_SYM585
	.byte 2
	.asciz "System.Diagnostics.DefaultTraceListener:WriteLogFile"
	.long _System_Diagnostics_DefaultTraceListener_WriteLogFile_string_string
	.long Lme_41

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM586=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM586
	.byte 0,3
	.asciz "message"

LDIFF_SYM587=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM587
	.byte 2,123,36,3
	.asciz "logFile"

LDIFF_SYM588=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM588
	.byte 2,123,40,11
	.asciz "fname"

LDIFF_SYM589=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM589
	.byte 1,86,11
	.asciz "info"

LDIFF_SYM590=LTDIE_32_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM590
	.byte 1,85,11
	.asciz "sw"

LDIFF_SYM591=LTDIE_34_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM591
	.byte 1,84,11
	.asciz ""

LDIFF_SYM592=LTDIE_34_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM592
	.byte 2,123,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM593=Lfde65_end - Lfde65_start
	.long LDIFF_SYM593
Lfde65_start:

	.long 0
	.align 2
	.long _System_Diagnostics_DefaultTraceListener_WriteLogFile_string_string

LDIFF_SYM594=Lme_41 - _System_Diagnostics_DefaultTraceListener_WriteLogFile_string_string
	.long LDIFF_SYM594
	.byte 12,13,0,72,14,8,135,2,68,14,28,132,7,133,6,134,5,136,4,139,3,142,1,68,14,88,68,13,11
	.align 2
Lfde65_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.DefaultTraceListener:Write"
	.long _System_Diagnostics_DefaultTraceListener_Write_string
	.long Lme_42

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM595=LTDIE_22_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM595
	.byte 2,125,0,3
	.asciz "message"

LDIFF_SYM596=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM596
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM597=Lfde66_end - Lfde66_start
	.long LDIFF_SYM597
Lfde66_start:

	.long 0
	.align 2
	.long _System_Diagnostics_DefaultTraceListener_Write_string

LDIFF_SYM598=Lme_42 - _System_Diagnostics_DefaultTraceListener_Write_string
	.long LDIFF_SYM598
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde66_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.DefaultTraceListener:WriteLine"
	.long _System_Diagnostics_DefaultTraceListener_WriteLine_string
	.long Lme_43

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM599=LTDIE_22_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM599
	.byte 2,125,0,3
	.asciz "message"

LDIFF_SYM600=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM600
	.byte 2,125,4,11
	.asciz "msg"

LDIFF_SYM601=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM601
	.byte 0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM602=Lfde67_end - Lfde67_start
	.long LDIFF_SYM602
Lfde67_start:

	.long 0
	.align 2
	.long _System_Diagnostics_DefaultTraceListener_WriteLine_string

LDIFF_SYM603=Lme_43 - _System_Diagnostics_DefaultTraceListener_WriteLine_string
	.long LDIFF_SYM603
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde67_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.TraceImpl:get_IndentLevel"
	.long _System_Diagnostics_TraceImpl_get_IndentLevel
	.long Lme_44

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM604=Lfde68_end - Lfde68_start
	.long LDIFF_SYM604
Lfde68_start:

	.long 0
	.align 2
	.long _System_Diagnostics_TraceImpl_get_IndentLevel

LDIFF_SYM605=Lme_44 - _System_Diagnostics_TraceImpl_get_IndentLevel
	.long LDIFF_SYM605
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,16
	.align 2
Lfde68_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.TraceImpl:get_IndentSize"
	.long _System_Diagnostics_TraceImpl_get_IndentSize
	.long Lme_45

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM606=Lfde69_end - Lfde69_start
	.long LDIFF_SYM606
Lfde69_start:

	.long 0
	.align 2
	.long _System_Diagnostics_TraceImpl_get_IndentSize

LDIFF_SYM607=Lme_45 - _System_Diagnostics_TraceImpl_get_IndentSize
	.long LDIFF_SYM607
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,16
	.align 2
Lfde69_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.TraceImpl:get_Listeners"
	.long _System_Diagnostics_TraceImpl_get_Listeners
	.long Lme_46

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM608=Lfde70_end - Lfde70_start
	.long LDIFF_SYM608
Lfde70_start:

	.long 0
	.align 2
	.long _System_Diagnostics_TraceImpl_get_Listeners

LDIFF_SYM609=Lme_46 - _System_Diagnostics_TraceImpl_get_Listeners
	.long LDIFF_SYM609
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,16
	.align 2
Lfde70_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.TraceImpl:get_ListenersSyncRoot"
	.long _System_Diagnostics_TraceImpl_get_ListenersSyncRoot
	.long Lme_47

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM610=Lfde71_end - Lfde71_start
	.long LDIFF_SYM610
Lfde71_start:

	.long 0
	.align 2
	.long _System_Diagnostics_TraceImpl_get_ListenersSyncRoot

LDIFF_SYM611=Lme_47 - _System_Diagnostics_TraceImpl_get_ListenersSyncRoot
	.long LDIFF_SYM611
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,16
	.align 2
Lfde71_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.TraceImpl:InitOnce"
	.long _System_Diagnostics_TraceImpl_InitOnce
	.long Lme_48

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM612=Lfde72_end - Lfde72_start
	.long LDIFF_SYM612
Lfde72_start:

	.long 0
	.align 2
	.long _System_Diagnostics_TraceImpl_InitOnce

LDIFF_SYM613=Lme_48 - _System_Diagnostics_TraceImpl_InitOnce
	.long LDIFF_SYM613
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,16
	.align 2
Lfde72_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.TraceImpl:Assert"
	.long _System_Diagnostics_TraceImpl_Assert_bool_string
	.long Lme_49

	.byte 2,118,16,3
	.asciz "condition"

LDIFF_SYM614=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM614
	.byte 2,125,0,3
	.asciz "message"

LDIFF_SYM615=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM615
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM616=Lfde73_end - Lfde73_start
	.long LDIFF_SYM616
Lfde73_start:

	.long 0
	.align 2
	.long _System_Diagnostics_TraceImpl_Assert_bool_string

LDIFF_SYM617=Lme_49 - _System_Diagnostics_TraceImpl_Assert_bool_string
	.long LDIFF_SYM617
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde73_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_53:

	.byte 17
	.asciz "System_Collections_IEnumerator"

	.byte 8,7
	.asciz "System_Collections_IEnumerator"

LDIFF_SYM618=LTDIE_53 - Ldebug_info_start
	.long LDIFF_SYM618
LTDIE_53_POINTER:

	.byte 13
LDIFF_SYM619=LTDIE_53 - Ldebug_info_start
	.long LDIFF_SYM619
LTDIE_53_REFERENCE:

	.byte 14
LDIFF_SYM620=LTDIE_53 - Ldebug_info_start
	.long LDIFF_SYM620
LTDIE_54:

	.byte 17
	.asciz "System_IDisposable"

	.byte 8,7
	.asciz "System_IDisposable"

LDIFF_SYM621=LTDIE_54 - Ldebug_info_start
	.long LDIFF_SYM621
LTDIE_54_POINTER:

	.byte 13
LDIFF_SYM622=LTDIE_54 - Ldebug_info_start
	.long LDIFF_SYM622
LTDIE_54_REFERENCE:

	.byte 14
LDIFF_SYM623=LTDIE_54 - Ldebug_info_start
	.long LDIFF_SYM623
	.byte 2
	.asciz "System.Diagnostics.TraceImpl:Fail"
	.long _System_Diagnostics_TraceImpl_Fail_string
	.long Lme_4a

	.byte 2,118,16,3
	.asciz "message"

LDIFF_SYM624=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM624
	.byte 1,90,11
	.asciz ""

LDIFF_SYM625=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM625
	.byte 2,123,0,11
	.asciz ""

LDIFF_SYM626=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM626
	.byte 2,123,4,11
	.asciz "listener"

LDIFF_SYM627=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM627
	.byte 1,86,11
	.asciz ""

LDIFF_SYM628=LTDIE_53_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM628
	.byte 2,123,8,11
	.asciz ""

LDIFF_SYM629=LTDIE_54_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM629
	.byte 2,123,12,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM630=Lfde74_end - Lfde74_start
	.long LDIFF_SYM630
Lfde74_start:

	.long 0
	.align 2
	.long _System_Diagnostics_TraceImpl_Fail_string

LDIFF_SYM631=Lme_4a - _System_Diagnostics_TraceImpl_Fail_string
	.long LDIFF_SYM631
	.byte 12,13,0,72,14,8,135,2,68,14,28,133,7,134,6,136,5,138,4,139,3,142,1,68,14,96,68,13,11
	.align 2
Lfde74_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.TraceImpl:.cctor"
	.long _System_Diagnostics_TraceImpl__cctor
	.long Lme_4b

	.byte 2,118,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM632=Lfde75_end - Lfde75_start
	.long LDIFF_SYM632
Lfde75_start:

	.long 0
	.align 2
	.long _System_Diagnostics_TraceImpl__cctor

LDIFF_SYM633=Lme_4b - _System_Diagnostics_TraceImpl__cctor
	.long LDIFF_SYM633
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde75_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.TraceListener:.ctor"
	.long _System_Diagnostics_TraceListener__ctor_string
	.long Lme_4c

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM634=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM634
	.byte 1,86,3
	.asciz "name"

LDIFF_SYM635=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM635
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM636=Lfde76_end - Lfde76_start
	.long LDIFF_SYM636
Lfde76_start:

	.long 0
	.align 2
	.long _System_Diagnostics_TraceListener__ctor_string

LDIFF_SYM637=Lme_4c - _System_Diagnostics_TraceListener__ctor_string
	.long LDIFF_SYM637
	.byte 12,13,0,72,14,8,135,2,68,14,16,134,4,136,3,142,1,68,14,32
	.align 2
Lfde76_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.TraceListener:get_IndentLevel"
	.long _System_Diagnostics_TraceListener_get_IndentLevel
	.long Lme_4d

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM638=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM638
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM639=Lfde77_end - Lfde77_start
	.long LDIFF_SYM639
Lfde77_start:

	.long 0
	.align 2
	.long _System_Diagnostics_TraceListener_get_IndentLevel

LDIFF_SYM640=Lme_4d - _System_Diagnostics_TraceListener_get_IndentLevel
	.long LDIFF_SYM640
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde77_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.TraceListener:set_IndentLevel"
	.long _System_Diagnostics_TraceListener_set_IndentLevel_int
	.long Lme_4e

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM641=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM641
	.byte 2,125,0,3
	.asciz "value"

LDIFF_SYM642=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM642
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM643=Lfde78_end - Lfde78_start
	.long LDIFF_SYM643
Lfde78_start:

	.long 0
	.align 2
	.long _System_Diagnostics_TraceListener_set_IndentLevel_int

LDIFF_SYM644=Lme_4e - _System_Diagnostics_TraceListener_set_IndentLevel_int
	.long LDIFF_SYM644
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde78_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.TraceListener:get_IndentSize"
	.long _System_Diagnostics_TraceListener_get_IndentSize
	.long Lme_4f

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM645=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM645
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM646=Lfde79_end - Lfde79_start
	.long LDIFF_SYM646
Lfde79_start:

	.long 0
	.align 2
	.long _System_Diagnostics_TraceListener_get_IndentSize

LDIFF_SYM647=Lme_4f - _System_Diagnostics_TraceListener_get_IndentSize
	.long LDIFF_SYM647
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde79_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.TraceListener:set_IndentSize"
	.long _System_Diagnostics_TraceListener_set_IndentSize_int
	.long Lme_50

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM648=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM648
	.byte 2,125,0,3
	.asciz "value"

LDIFF_SYM649=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM649
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM650=Lfde80_end - Lfde80_start
	.long LDIFF_SYM650
Lfde80_start:

	.long 0
	.align 2
	.long _System_Diagnostics_TraceListener_set_IndentSize_int

LDIFF_SYM651=Lme_50 - _System_Diagnostics_TraceListener_set_IndentSize_int
	.long LDIFF_SYM651
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde80_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.TraceListener:set_Name"
	.long _System_Diagnostics_TraceListener_set_Name_string
	.long Lme_51

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM652=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM652
	.byte 2,125,0,3
	.asciz "value"

LDIFF_SYM653=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM653
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM654=Lfde81_end - Lfde81_start
	.long LDIFF_SYM654
Lfde81_start:

	.long 0
	.align 2
	.long _System_Diagnostics_TraceListener_set_Name_string

LDIFF_SYM655=Lme_51 - _System_Diagnostics_TraceListener_set_Name_string
	.long LDIFF_SYM655
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde81_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.TraceListener:get_NeedIndent"
	.long _System_Diagnostics_TraceListener_get_NeedIndent
	.long Lme_52

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM656=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM656
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM657=Lfde82_end - Lfde82_start
	.long LDIFF_SYM657
Lfde82_start:

	.long 0
	.align 2
	.long _System_Diagnostics_TraceListener_get_NeedIndent

LDIFF_SYM658=Lme_52 - _System_Diagnostics_TraceListener_get_NeedIndent
	.long LDIFF_SYM658
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde82_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.TraceListener:set_NeedIndent"
	.long _System_Diagnostics_TraceListener_set_NeedIndent_bool
	.long Lme_53

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM659=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM659
	.byte 2,125,0,3
	.asciz "value"

LDIFF_SYM660=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM660
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM661=Lfde83_end - Lfde83_start
	.long LDIFF_SYM661
Lfde83_start:

	.long 0
	.align 2
	.long _System_Diagnostics_TraceListener_set_NeedIndent_bool

LDIFF_SYM662=Lme_53 - _System_Diagnostics_TraceListener_set_NeedIndent_bool
	.long LDIFF_SYM662
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde83_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.TraceListener:Dispose"
	.long _System_Diagnostics_TraceListener_Dispose
	.long Lme_54

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM663=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM663
	.byte 1,90,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM664=Lfde84_end - Lfde84_start
	.long LDIFF_SYM664
Lfde84_start:

	.long 0
	.align 2
	.long _System_Diagnostics_TraceListener_Dispose

LDIFF_SYM665=Lme_54 - _System_Diagnostics_TraceListener_Dispose
	.long LDIFF_SYM665
	.byte 12,13,0,72,14,8,135,2,68,14,16,136,4,138,3,142,1
	.align 2
Lfde84_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.TraceListener:Dispose"
	.long _System_Diagnostics_TraceListener_Dispose_bool
	.long Lme_55

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM666=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM666
	.byte 0,3
	.asciz "disposing"

LDIFF_SYM667=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM667
	.byte 0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM668=Lfde85_end - Lfde85_start
	.long LDIFF_SYM668
Lfde85_start:

	.long 0
	.align 2
	.long _System_Diagnostics_TraceListener_Dispose_bool

LDIFF_SYM669=Lme_55 - _System_Diagnostics_TraceListener_Dispose_bool
	.long LDIFF_SYM669
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde85_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.TraceListener:Fail"
	.long _System_Diagnostics_TraceListener_Fail_string
	.long Lme_56

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM670=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM670
	.byte 2,125,0,3
	.asciz "message"

LDIFF_SYM671=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM671
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM672=Lfde86_end - Lfde86_start
	.long LDIFF_SYM672
Lfde86_start:

	.long 0
	.align 2
	.long _System_Diagnostics_TraceListener_Fail_string

LDIFF_SYM673=Lme_56 - _System_Diagnostics_TraceListener_Fail_string
	.long LDIFF_SYM673
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde86_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.TraceListener:Fail"
	.long _System_Diagnostics_TraceListener_Fail_string_string
	.long Lme_57

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM674=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM674
	.byte 1,85,3
	.asciz "message"

LDIFF_SYM675=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM675
	.byte 2,125,0,3
	.asciz "detailMessage"

LDIFF_SYM676=LDIE_STRING - Ldebug_info_start
	.long LDIFF_SYM676
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM677=Lfde87_end - Lfde87_start
	.long LDIFF_SYM677
Lfde87_start:

	.long 0
	.align 2
	.long _System_Diagnostics_TraceListener_Fail_string_string

LDIFF_SYM678=Lme_57 - _System_Diagnostics_TraceListener_Fail_string_string
	.long LDIFF_SYM678
	.byte 12,13,0,72,14,8,135,2,68,14,16,133,4,136,3,142,1,68,14,24
	.align 2
Lfde87_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.TraceListener:WriteIndent"
	.long _System_Diagnostics_TraceListener_WriteIndent
	.long Lme_59

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM679=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM679
	.byte 1,90,11
	.asciz "indent"

LDIFF_SYM680=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM680
	.byte 0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM681=Lfde88_end - Lfde88_start
	.long LDIFF_SYM681
Lfde88_start:

	.long 0
	.align 2
	.long _System_Diagnostics_TraceListener_WriteIndent

LDIFF_SYM682=Lme_59 - _System_Diagnostics_TraceListener_WriteIndent
	.long LDIFF_SYM682
	.byte 12,13,0,72,14,8,135,2,68,14,16,136,4,138,3,142,1
	.align 2
Lfde88_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_56:

	.byte 5
	.asciz "System_Collections_ArrayList"

	.byte 20,16
LDIFF_SYM683=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM683
	.byte 2,35,0,6
	.asciz "_items"

LDIFF_SYM684=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM684
	.byte 2,35,8,6
	.asciz "_size"

LDIFF_SYM685=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM685
	.byte 2,35,12,6
	.asciz "_version"

LDIFF_SYM686=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM686
	.byte 2,35,16,0,7
	.asciz "System_Collections_ArrayList"

LDIFF_SYM687=LTDIE_56 - Ldebug_info_start
	.long LDIFF_SYM687
LTDIE_56_POINTER:

	.byte 13
LDIFF_SYM688=LTDIE_56 - Ldebug_info_start
	.long LDIFF_SYM688
LTDIE_56_REFERENCE:

	.byte 14
LDIFF_SYM689=LTDIE_56 - Ldebug_info_start
	.long LDIFF_SYM689
LTDIE_55:

	.byte 5
	.asciz "System_Diagnostics_TraceListenerCollection"

	.byte 12,16
LDIFF_SYM690=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM690
	.byte 2,35,0,6
	.asciz "listeners"

LDIFF_SYM691=LTDIE_56_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM691
	.byte 2,35,8,0,7
	.asciz "System_Diagnostics_TraceListenerCollection"

LDIFF_SYM692=LTDIE_55 - Ldebug_info_start
	.long LDIFF_SYM692
LTDIE_55_POINTER:

	.byte 13
LDIFF_SYM693=LTDIE_55 - Ldebug_info_start
	.long LDIFF_SYM693
LTDIE_55_REFERENCE:

	.byte 14
LDIFF_SYM694=LTDIE_55 - Ldebug_info_start
	.long LDIFF_SYM694
	.byte 2
	.asciz "System.Diagnostics.TraceListenerCollection:.ctor"
	.long _System_Diagnostics_TraceListenerCollection__ctor_bool
	.long Lme_5b

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM695=LTDIE_55_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM695
	.byte 2,125,0,3
	.asciz "addDefault"

LDIFF_SYM696=LDIE_BOOLEAN - Ldebug_info_start
	.long LDIFF_SYM696
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM697=Lfde89_end - Lfde89_start
	.long LDIFF_SYM697
Lfde89_start:

	.long 0
	.align 2
	.long _System_Diagnostics_TraceListenerCollection__ctor_bool

LDIFF_SYM698=Lme_5b - _System_Diagnostics_TraceListenerCollection__ctor_bool
	.long LDIFF_SYM698
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,32
	.align 2
Lfde89_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.TraceListenerCollection:System.Collections.ICollection.get_SyncRoot"
	.long _System_Diagnostics_TraceListenerCollection_System_Collections_ICollection_get_SyncRoot
	.long Lme_5c

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM699=LTDIE_55_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM699
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM700=Lfde90_end - Lfde90_start
	.long LDIFF_SYM700
Lfde90_start:

	.long 0
	.align 2
	.long _System_Diagnostics_TraceListenerCollection_System_Collections_ICollection_get_SyncRoot

LDIFF_SYM701=Lme_5c - _System_Diagnostics_TraceListenerCollection_System_Collections_ICollection_get_SyncRoot
	.long LDIFF_SYM701
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde90_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.TraceListenerCollection:Add"
	.long _System_Diagnostics_TraceListenerCollection_Add_System_Diagnostics_TraceListener
	.long Lme_5d

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM702=LTDIE_55_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM702
	.byte 2,125,0,3
	.asciz "listener"

LDIFF_SYM703=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM703
	.byte 2,125,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM704=Lfde91_end - Lfde91_start
	.long LDIFF_SYM704
Lfde91_start:

	.long 0
	.align 2
	.long _System_Diagnostics_TraceListenerCollection_Add_System_Diagnostics_TraceListener

LDIFF_SYM705=Lme_5d - _System_Diagnostics_TraceListenerCollection_Add_System_Diagnostics_TraceListener
	.long LDIFF_SYM705
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde91_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.TraceListenerCollection:InitializeListener"
	.long _System_Diagnostics_TraceListenerCollection_InitializeListener_System_Diagnostics_TraceListener
	.long Lme_5e

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM706=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM706
	.byte 0,3
	.asciz "listener"

LDIFF_SYM707=LTDIE_23_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM707
	.byte 1,90,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM708=Lfde92_end - Lfde92_start
	.long LDIFF_SYM708
Lfde92_start:

	.long 0
	.align 2
	.long _System_Diagnostics_TraceListenerCollection_InitializeListener_System_Diagnostics_TraceListener

LDIFF_SYM709=Lme_5e - _System_Diagnostics_TraceListenerCollection_InitializeListener_System_Diagnostics_TraceListener
	.long LDIFF_SYM709
	.byte 12,13,0,72,14,8,135,2,68,14,16,136,4,138,3,142,1,68,14,32
	.align 2
Lfde92_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.TraceListenerCollection:GetEnumerator"
	.long _System_Diagnostics_TraceListenerCollection_GetEnumerator
	.long Lme_5f

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM710=LTDIE_55_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM710
	.byte 2,125,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM711=Lfde93_end - Lfde93_start
	.long LDIFF_SYM711
Lfde93_start:

	.long 0
	.align 2
	.long _System_Diagnostics_TraceListenerCollection_GetEnumerator

LDIFF_SYM712=Lme_5f - _System_Diagnostics_TraceListenerCollection_GetEnumerator
	.long LDIFF_SYM712
	.byte 12,13,0,72,14,8,135,2,68,14,12,136,3,142,1,68,14,24
	.align 2
Lfde93_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Diagnostics.TraceListenerCollection:System.Collections.IList.Contains"
	.long _System_Diagnostics_TraceListenerCollection_System_Collections_IList_Contains_object
	.long Lme_60

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM713=LTDIE_55_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM713
	.byte 2,125,4,3
	.asciz "value"

LDIFF_SYM714=LDIE_OBJECT - Ldebug_info_start
	.long LDIFF_SYM714
	.byte 1,90,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM715=Lfde94_end - Lfde94_start
	.long LDIFF_SYM715
Lfde94_start:

	.long 0
	.align 2
	.long _System_Diagnostics_TraceListenerCollection_System_Collections_IList_Contains_object

LDIFF_SYM716=Lme_60 - _System_Diagnostics_TraceListenerCollection_System_Collections_IList_Contains_object
	.long LDIFF_SYM716
	.byte 12,13,0,72,14,8,135,2,68,14,20,132,5,136,4,138,3,142,1,68,14,32
	.align 2
Lfde94_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_58:

	.byte 5
	.asciz "System_Collections_Generic_LinkedListNode`1"

	.byte 24,16
LDIFF_SYM717=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM717
	.byte 2,35,0,6
	.asciz "item"

LDIFF_SYM718=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM718
	.byte 2,35,8,6
	.asciz "container"

LDIFF_SYM719=LTDIE_57_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM719
	.byte 2,35,12,6
	.asciz "forward"

LDIFF_SYM720=LTDIE_58_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM720
	.byte 2,35,16,6
	.asciz "back"

LDIFF_SYM721=LTDIE_58_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM721
	.byte 2,35,20,0,7
	.asciz "System_Collections_Generic_LinkedListNode`1"

LDIFF_SYM722=LTDIE_58 - Ldebug_info_start
	.long LDIFF_SYM722
LTDIE_58_POINTER:

	.byte 13
LDIFF_SYM723=LTDIE_58 - Ldebug_info_start
	.long LDIFF_SYM723
LTDIE_58_REFERENCE:

	.byte 14
LDIFF_SYM724=LTDIE_58 - Ldebug_info_start
	.long LDIFF_SYM724
LTDIE_57:

	.byte 5
	.asciz "System_Collections_Generic_LinkedList`1"

	.byte 20,16
LDIFF_SYM725=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM725
	.byte 2,35,0,6
	.asciz "count"

LDIFF_SYM726=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM726
	.byte 2,35,12,6
	.asciz "version"

LDIFF_SYM727=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM727
	.byte 2,35,16,6
	.asciz "first"

LDIFF_SYM728=LTDIE_58_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM728
	.byte 2,35,8,0,7
	.asciz "System_Collections_Generic_LinkedList`1"

LDIFF_SYM729=LTDIE_57 - Ldebug_info_start
	.long LDIFF_SYM729
LTDIE_57_POINTER:

	.byte 13
LDIFF_SYM730=LTDIE_57 - Ldebug_info_start
	.long LDIFF_SYM730
LTDIE_57_REFERENCE:

	.byte 14
LDIFF_SYM731=LTDIE_57 - Ldebug_info_start
	.long LDIFF_SYM731
	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1<!0>:.ctor"
	.long _System_Collections_Generic_LinkedList_1__0__ctor
	.long Lme_62

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM732=LTDIE_57_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM732
	.byte 2,123,8,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM733=Lfde95_end - Lfde95_start
	.long LDIFF_SYM733
Lfde95_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1__0__ctor

LDIFF_SYM734=Lme_62 - _System_Collections_Generic_LinkedList_1__0__ctor
	.long LDIFF_SYM734
	.byte 12,13,0,72,14,8,135,2,68,14,16,136,4,139,3,142,1,68,14,32,68,13,11
	.align 2
Lfde95_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1<!0>:VerifyReferencedNode"
	.long _System_Collections_Generic_LinkedList_1__0_VerifyReferencedNode_System_Collections_Generic_LinkedListNode_1__0
	.long Lme_63

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM735=LTDIE_57_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM735
	.byte 2,123,8,3
	.asciz "node"

LDIFF_SYM736=LTDIE_58_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM736
	.byte 2,123,12,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM737=Lfde96_end - Lfde96_start
	.long LDIFF_SYM737
Lfde96_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1__0_VerifyReferencedNode_System_Collections_Generic_LinkedListNode_1__0

LDIFF_SYM738=Lme_63 - _System_Collections_Generic_LinkedList_1__0_VerifyReferencedNode_System_Collections_Generic_LinkedListNode_1__0
	.long LDIFF_SYM738
	.byte 12,13,0,72,14,8,135,2,68,14,16,136,4,139,3,142,1,68,14,32,68,13,11
	.align 2
Lfde96_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1<!0>:VerifyBlankNode"
	.long _System_Collections_Generic_LinkedList_1__0_VerifyBlankNode_System_Collections_Generic_LinkedListNode_1__0
	.long Lme_64

	.byte 2,118,16,3
	.asciz "newNode"

LDIFF_SYM739=LTDIE_58_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM739
	.byte 2,123,12,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM740=Lfde97_end - Lfde97_start
	.long LDIFF_SYM740
Lfde97_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1__0_VerifyBlankNode_System_Collections_Generic_LinkedListNode_1__0

LDIFF_SYM741=Lme_64 - _System_Collections_Generic_LinkedList_1__0_VerifyBlankNode_System_Collections_Generic_LinkedListNode_1__0
	.long LDIFF_SYM741
	.byte 12,13,0,72,14,8,135,2,68,14,16,136,4,139,3,142,1,68,14,32,68,13,11
	.align 2
Lfde97_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1<!0>:AddFirst"
	.long _System_Collections_Generic_LinkedList_1__0_AddFirst_System_Collections_Generic_LinkedListNode_1__0
	.long Lme_65

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM742=LTDIE_57_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM742
	.byte 2,123,4,3
	.asciz "node"

LDIFF_SYM743=LTDIE_58_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM743
	.byte 1,90,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM744=Lfde98_end - Lfde98_start
	.long LDIFF_SYM744
Lfde98_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1__0_AddFirst_System_Collections_Generic_LinkedListNode_1__0

LDIFF_SYM745=Lme_65 - _System_Collections_Generic_LinkedList_1__0_AddFirst_System_Collections_Generic_LinkedListNode_1__0
	.long LDIFF_SYM745
	.byte 12,13,0,72,14,8,135,2,68,14,24,134,6,136,5,138,4,139,3,142,1,68,14,48,68,13,11
	.align 2
Lfde98_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1<!0>:AddLast"
	.long _System_Collections_Generic_LinkedList_1__0_AddLast__0
	.long Lme_66

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM746=LTDIE_57_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM746
	.byte 2,123,8,3
	.asciz "value"

LDIFF_SYM747=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM747
	.byte 1,80,11
	.asciz "newNode"

LDIFF_SYM748=LTDIE_58_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM748
	.byte 1,85,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM749=Lfde99_end - Lfde99_start
	.long LDIFF_SYM749
Lfde99_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1__0_AddLast__0

LDIFF_SYM750=Lme_66 - _System_Collections_Generic_LinkedList_1__0_AddLast__0
	.long LDIFF_SYM750
	.byte 12,13,0,72,14,8,135,2,68,14,28,133,7,134,6,136,5,138,4,139,3,142,1,68,14,72,68,13,11
	.align 2
Lfde99_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1<!0>:Clear"
	.long _System_Collections_Generic_LinkedList_1__0_Clear
	.long Lme_67

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM751=LTDIE_57_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM751
	.byte 2,123,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM752=Lfde100_end - Lfde100_start
	.long LDIFF_SYM752
Lfde100_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1__0_Clear

LDIFF_SYM753=Lme_67 - _System_Collections_Generic_LinkedList_1__0_Clear
	.long LDIFF_SYM753
	.byte 12,13,0,72,14,8,135,2,68,14,20,136,5,138,4,139,3,142,1,68,14,40,68,13,11
	.align 2
Lfde100_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1<!0>:Contains"
	.long _System_Collections_Generic_LinkedList_1__0_Contains__0
	.long Lme_68

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM754=LTDIE_57_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM754
	.byte 2,123,4,3
	.asciz "value"

LDIFF_SYM755=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM755
	.byte 1,80,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM756=Lfde101_end - Lfde101_start
	.long LDIFF_SYM756
Lfde101_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1__0_Contains__0

LDIFF_SYM757=Lme_68 - _System_Collections_Generic_LinkedList_1__0_Contains__0
	.long LDIFF_SYM757
	.byte 12,13,0,72,14,8,135,2,68,14,20,136,5,138,4,139,3,142,1,68,14,48,68,13,11
	.align 2
Lfde101_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1<!0>:CopyTo"
	.long _System_Collections_Generic_LinkedList_1__0_CopyTo__0___int
	.long Lme_69

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM758=LTDIE_57_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM758
	.byte 2,123,44,3
	.asciz "array"

LDIFF_SYM759=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM759
	.byte 1,86,3
	.asciz "index"

LDIFF_SYM760=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM760
	.byte 1,90,11
	.asciz "node"

LDIFF_SYM761=LTDIE_58_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM761
	.byte 2,123,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM762=Lfde102_end - Lfde102_start
	.long LDIFF_SYM762
Lfde102_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1__0_CopyTo__0___int

LDIFF_SYM763=Lme_69 - _System_Collections_Generic_LinkedList_1__0_CopyTo__0___int
	.long LDIFF_SYM763
	.byte 12,13,0,72,14,8,135,2,68,14,32,132,8,133,7,134,6,136,5,138,4,139,3,142,1,68,14,88,68,13,11
	.align 2
Lfde102_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1<!0>:Find"
	.long _System_Collections_Generic_LinkedList_1__0_Find__0
	.long Lme_6a

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM764=LTDIE_57_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM764
	.byte 2,123,0,3
	.asciz "value"

LDIFF_SYM765=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM765
	.byte 1,80,11
	.asciz "node"

LDIFF_SYM766=LTDIE_58_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM766
	.byte 1,85,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM767=Lfde103_end - Lfde103_start
	.long LDIFF_SYM767
Lfde103_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1__0_Find__0

LDIFF_SYM768=Lme_6a - _System_Collections_Generic_LinkedList_1__0_Find__0
	.long LDIFF_SYM768
	.byte 12,13,0,72,14,8,135,2,68,14,28,133,7,134,6,136,5,138,4,139,3,142,1,68,14,48,68,13,11
	.align 2
Lfde103_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1<!0>:GetEnumerator"
	.long _System_Collections_Generic_LinkedList_1__0_GetEnumerator
	.long Lme_6b

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM769=LTDIE_57_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM769
	.byte 2,123,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM770=Lfde104_end - Lfde104_start
	.long LDIFF_SYM770
Lfde104_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1__0_GetEnumerator

LDIFF_SYM771=Lme_6b - _System_Collections_Generic_LinkedList_1__0_GetEnumerator
	.long LDIFF_SYM771
	.byte 12,13,0,72,14,8,135,2,68,14,24,133,6,134,5,136,4,139,3,142,1,68,14,48,68,13,11
	.align 2
Lfde104_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1<!0>:Remove"
	.long _System_Collections_Generic_LinkedList_1__0_Remove__0
	.long Lme_6c

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM772=LTDIE_57_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM772
	.byte 2,123,0,3
	.asciz "value"

LDIFF_SYM773=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM773
	.byte 1,80,11
	.asciz "node"

LDIFF_SYM774=LTDIE_58_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM774
	.byte 1,86,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM775=Lfde105_end - Lfde105_start
	.long LDIFF_SYM775
Lfde105_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1__0_Remove__0

LDIFF_SYM776=Lme_6c - _System_Collections_Generic_LinkedList_1__0_Remove__0
	.long LDIFF_SYM776
	.byte 12,13,0,72,14,8,135,2,68,14,24,134,6,136,5,138,4,139,3,142,1,68,14,40,68,13,11
	.align 2
Lfde105_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1<!0>:Remove"
	.long _System_Collections_Generic_LinkedList_1__0_Remove_System_Collections_Generic_LinkedListNode_1__0
	.long Lme_6d

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM777=LTDIE_57_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM777
	.byte 2,123,4,3
	.asciz "node"

LDIFF_SYM778=LTDIE_58_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM778
	.byte 1,90,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM779=Lfde106_end - Lfde106_start
	.long LDIFF_SYM779
Lfde106_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1__0_Remove_System_Collections_Generic_LinkedListNode_1__0

LDIFF_SYM780=Lme_6d - _System_Collections_Generic_LinkedList_1__0_Remove_System_Collections_Generic_LinkedListNode_1__0
	.long LDIFF_SYM780
	.byte 12,13,0,72,14,8,135,2,68,14,24,134,6,136,5,138,4,139,3,142,1,68,14,40,68,13,11
	.align 2
Lfde106_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1<!0>:RemoveLast"
	.long _System_Collections_Generic_LinkedList_1__0_RemoveLast
	.long Lme_6e

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM781=LTDIE_57_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM781
	.byte 2,123,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM782=Lfde107_end - Lfde107_start
	.long LDIFF_SYM782
Lfde107_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1__0_RemoveLast

LDIFF_SYM783=Lme_6e - _System_Collections_Generic_LinkedList_1__0_RemoveLast
	.long LDIFF_SYM783
	.byte 12,13,0,72,14,8,135,2,68,14,20,136,5,138,4,139,3,142,1,68,14,40,68,13,11
	.align 2
Lfde107_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1<!0>:System.Collections.Generic.ICollection<T>.Add"
	.long _System_Collections_Generic_LinkedList_1__0_System_Collections_Generic_ICollection_T_Add__0
	.long Lme_6f

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM784=LTDIE_57_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM784
	.byte 2,123,4,3
	.asciz "value"

LDIFF_SYM785=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM785
	.byte 1,80,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM786=Lfde108_end - Lfde108_start
	.long LDIFF_SYM786
Lfde108_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1__0_System_Collections_Generic_ICollection_T_Add__0

LDIFF_SYM787=Lme_6f - _System_Collections_Generic_LinkedList_1__0_System_Collections_Generic_ICollection_T_Add__0
	.long LDIFF_SYM787
	.byte 12,13,0,72,14,8,135,2,68,14,20,136,5,138,4,139,3,142,1,68,14,48,68,13,11
	.align 2
Lfde108_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1<!0>:System.Collections.Generic.IEnumerable<T>.GetEnumerator"
	.long _System_Collections_Generic_LinkedList_1__0_System_Collections_Generic_IEnumerable_T_GetEnumerator
	.long Lme_70

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM788=LTDIE_57_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM788
	.byte 2,123,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM789=Lfde109_end - Lfde109_start
	.long LDIFF_SYM789
Lfde109_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1__0_System_Collections_Generic_IEnumerable_T_GetEnumerator

LDIFF_SYM790=Lme_70 - _System_Collections_Generic_LinkedList_1__0_System_Collections_Generic_IEnumerable_T_GetEnumerator
	.long LDIFF_SYM790
	.byte 12,13,0,72,14,8,135,2,68,14,32,132,8,133,7,134,6,136,5,138,4,139,3,142,1,68,14,48,68,13,11
	.align 2
Lfde109_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1<!0>:System.Collections.IEnumerable.GetEnumerator"
	.long _System_Collections_Generic_LinkedList_1__0_System_Collections_IEnumerable_GetEnumerator
	.long Lme_71

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM791=LTDIE_57_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM791
	.byte 2,123,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM792=Lfde110_end - Lfde110_start
	.long LDIFF_SYM792
Lfde110_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1__0_System_Collections_IEnumerable_GetEnumerator

LDIFF_SYM793=Lme_71 - _System_Collections_Generic_LinkedList_1__0_System_Collections_IEnumerable_GetEnumerator
	.long LDIFF_SYM793
	.byte 12,13,0,72,14,8,135,2,68,14,32,132,8,133,7,134,6,136,5,138,4,139,3,142,1,68,14,48,68,13,11
	.align 2
Lfde110_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1<!0>:get_Count"
	.long _System_Collections_Generic_LinkedList_1__0_get_Count
	.long Lme_72

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM794=LTDIE_57_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM794
	.byte 2,123,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM795=Lfde111_end - Lfde111_start
	.long LDIFF_SYM795
Lfde111_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1__0_get_Count

LDIFF_SYM796=Lme_72 - _System_Collections_Generic_LinkedList_1__0_get_Count
	.long LDIFF_SYM796
	.byte 12,13,0,72,14,8,135,2,68,14,20,136,5,138,4,139,3,142,1,68,14,32,68,13,11
	.align 2
Lfde111_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1<!0>:get_Last"
	.long _System_Collections_Generic_LinkedList_1__0_get_Last
	.long Lme_73

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM797=LTDIE_57_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM797
	.byte 2,123,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM798=Lfde112_end - Lfde112_start
	.long LDIFF_SYM798
Lfde112_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1__0_get_Last

LDIFF_SYM799=Lme_73 - _System_Collections_Generic_LinkedList_1__0_get_Last
	.long LDIFF_SYM799
	.byte 12,13,0,72,14,8,135,2,68,14,24,134,6,136,5,138,4,139,3,142,1,68,14,32,68,13,11
	.align 2
Lfde112_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1<!0>:System.Collections.Generic.ICollection<T>.get_IsReadOnly"
	.long _System_Collections_Generic_LinkedList_1__0_System_Collections_Generic_ICollection_T_get_IsReadOnly
	.long Lme_74

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM800=LTDIE_57_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM800
	.byte 2,123,8,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM801=Lfde113_end - Lfde113_start
	.long LDIFF_SYM801
Lfde113_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1__0_System_Collections_Generic_ICollection_T_get_IsReadOnly

LDIFF_SYM802=Lme_74 - _System_Collections_Generic_LinkedList_1__0_System_Collections_Generic_ICollection_T_get_IsReadOnly
	.long LDIFF_SYM802
	.byte 12,13,0,72,14,8,135,2,68,14,16,136,4,139,3,142,1,68,14,32,68,13,11
	.align 2
Lfde113_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1<!0>:System.Collections.ICollection.get_SyncRoot"
	.long _System_Collections_Generic_LinkedList_1__0_System_Collections_ICollection_get_SyncRoot
	.long Lme_75

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM803=LTDIE_57_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM803
	.byte 2,123,8,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM804=Lfde114_end - Lfde114_start
	.long LDIFF_SYM804
Lfde114_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1__0_System_Collections_ICollection_get_SyncRoot

LDIFF_SYM805=Lme_75 - _System_Collections_Generic_LinkedList_1__0_System_Collections_ICollection_get_SyncRoot
	.long LDIFF_SYM805
	.byte 12,13,0,72,14,8,135,2,68,14,16,136,4,139,3,142,1,68,14,32,68,13,11
	.align 2
Lfde114_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_59:

	.byte 5
	.asciz "_Enumerator"

	.byte 24,16
LDIFF_SYM806=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM806
	.byte 2,35,0,6
	.asciz "list"

LDIFF_SYM807=LTDIE_57_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM807
	.byte 2,35,8,6
	.asciz "current"

LDIFF_SYM808=LTDIE_58_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM808
	.byte 2,35,12,6
	.asciz "index"

LDIFF_SYM809=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM809
	.byte 2,35,16,6
	.asciz "version"

LDIFF_SYM810=LDIE_U4 - Ldebug_info_start
	.long LDIFF_SYM810
	.byte 2,35,20,0,7
	.asciz "_Enumerator"

LDIFF_SYM811=LTDIE_59 - Ldebug_info_start
	.long LDIFF_SYM811
LTDIE_59_POINTER:

	.byte 13
LDIFF_SYM812=LTDIE_59 - Ldebug_info_start
	.long LDIFF_SYM812
LTDIE_59_REFERENCE:

	.byte 14
LDIFF_SYM813=LTDIE_59 - Ldebug_info_start
	.long LDIFF_SYM813
	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1/Enumerator<!0>:.ctor"
	.long _System_Collections_Generic_LinkedList_1_Enumerator__0__ctor_System_Collections_Generic_LinkedList_1__0
	.long Lme_76

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM814=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM814
	.byte 1,86,3
	.asciz "parent"

LDIFF_SYM815=LTDIE_57_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM815
	.byte 2,123,8,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM816=Lfde115_end - Lfde115_start
	.long LDIFF_SYM816
Lfde115_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_Enumerator__0__ctor_System_Collections_Generic_LinkedList_1__0

LDIFF_SYM817=Lme_76 - _System_Collections_Generic_LinkedList_1_Enumerator__0__ctor_System_Collections_Generic_LinkedList_1__0
	.long LDIFF_SYM817
	.byte 12,13,0,72,14,8,135,2,68,14,24,133,6,134,5,136,4,139,3,142,1,68,14,40,68,13,11
	.align 2
Lfde115_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1/Enumerator<!0>:get_Current"
	.long _System_Collections_Generic_LinkedList_1_Enumerator__0_get_Current
	.long Lme_77

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM818=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM818
	.byte 1,86,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM819=Lfde116_end - Lfde116_start
	.long LDIFF_SYM819
Lfde116_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_Enumerator__0_get_Current

LDIFF_SYM820=Lme_77 - _System_Collections_Generic_LinkedList_1_Enumerator__0_get_Current
	.long LDIFF_SYM820
	.byte 12,13,0,72,14,8,135,2,68,14,28,132,7,133,6,134,5,136,4,139,3,142,1,68,14,48,68,13,11
	.align 2
Lfde116_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1/Enumerator<!0>:System.Collections.IEnumerator.get_Current"
	.long _System_Collections_Generic_LinkedList_1_Enumerator__0_System_Collections_IEnumerator_get_Current
	.long Lme_78

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM821=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM821
	.byte 1,90,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM822=Lfde117_end - Lfde117_start
	.long LDIFF_SYM822
Lfde117_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_Enumerator__0_System_Collections_IEnumerator_get_Current

LDIFF_SYM823=Lme_78 - _System_Collections_Generic_LinkedList_1_Enumerator__0_System_Collections_IEnumerator_get_Current
	.long LDIFF_SYM823
	.byte 12,13,0,72,14,8,135,2,68,14,32,132,8,133,7,134,6,136,5,138,4,139,3,142,1,68,14,48,68,13,11
	.align 2
Lfde117_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1/Enumerator<!0>:MoveNext"
	.long _System_Collections_Generic_LinkedList_1_Enumerator__0_MoveNext
	.long Lme_79

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM824=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM824
	.byte 1,90,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM825=Lfde118_end - Lfde118_start
	.long LDIFF_SYM825
Lfde118_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_Enumerator__0_MoveNext

LDIFF_SYM826=Lme_79 - _System_Collections_Generic_LinkedList_1_Enumerator__0_MoveNext
	.long LDIFF_SYM826
	.byte 12,13,0,72,14,8,135,2,68,14,24,134,6,136,5,138,4,139,3,142,1,68,14,32,68,13,11
	.align 2
Lfde118_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedList`1/Enumerator<!0>:Dispose"
	.long _System_Collections_Generic_LinkedList_1_Enumerator__0_Dispose
	.long Lme_7a

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM827=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM827
	.byte 1,90,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM828=Lfde119_end - Lfde119_start
	.long LDIFF_SYM828
Lfde119_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedList_1_Enumerator__0_Dispose

LDIFF_SYM829=Lme_7a - _System_Collections_Generic_LinkedList_1_Enumerator__0_Dispose
	.long LDIFF_SYM829
	.byte 12,13,0,72,14,8,135,2,68,14,24,134,6,136,5,138,4,139,3,142,1,68,14,32,68,13,11
	.align 2
Lfde119_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedListNode`1<!0>:.ctor"
	.long _System_Collections_Generic_LinkedListNode_1__0__ctor__0
	.long Lme_7b

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM830=LTDIE_58_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM830
	.byte 2,123,4,3
	.asciz "value"

LDIFF_SYM831=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM831
	.byte 1,80,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM832=Lfde120_end - Lfde120_start
	.long LDIFF_SYM832
Lfde120_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedListNode_1__0__ctor__0

LDIFF_SYM833=Lme_7b - _System_Collections_Generic_LinkedListNode_1__0__ctor__0
	.long LDIFF_SYM833
	.byte 12,13,0,72,14,8,135,2,68,14,20,136,5,138,4,139,3,142,1,68,14,40,68,13,11
	.align 2
Lfde120_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedListNode`1<!0>:.ctor"
	.long _System_Collections_Generic_LinkedListNode_1__0__ctor_System_Collections_Generic_LinkedList_1__0__0
	.long Lme_7c

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM834=LTDIE_58_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM834
	.byte 2,123,4,3
	.asciz "list"

LDIFF_SYM835=LTDIE_57_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM835
	.byte 2,123,8,3
	.asciz "value"

LDIFF_SYM836=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM836
	.byte 1,80,11
	.asciz ""

LDIFF_SYM837=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM837
	.byte 0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM838=Lfde121_end - Lfde121_start
	.long LDIFF_SYM838
Lfde121_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedListNode_1__0__ctor_System_Collections_Generic_LinkedList_1__0__0

LDIFF_SYM839=Lme_7c - _System_Collections_Generic_LinkedListNode_1__0__ctor_System_Collections_Generic_LinkedList_1__0__0
	.long LDIFF_SYM839
	.byte 12,13,0,72,14,8,135,2,68,14,20,134,5,136,4,139,3,142,1,68,14,40,68,13,11
	.align 2
Lfde121_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedListNode`1<!0>:.ctor"
	.long _System_Collections_Generic_LinkedListNode_1__0__ctor_System_Collections_Generic_LinkedList_1__0__0_System_Collections_Generic_LinkedListNode_1__0_System_Collections_Generic_LinkedListNode_1__0
	.long Lme_7d

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM840=LTDIE_58_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM840
	.byte 2,123,4,3
	.asciz "list"

LDIFF_SYM841=LTDIE_57_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM841
	.byte 2,123,8,3
	.asciz "value"

LDIFF_SYM842=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM842
	.byte 1,80,3
	.asciz "previousNode"

LDIFF_SYM843=LTDIE_58_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM843
	.byte 2,123,16,3
	.asciz "nextNode"

LDIFF_SYM844=LTDIE_58_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM844
	.byte 2,123,20,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM845=Lfde122_end - Lfde122_start
	.long LDIFF_SYM845
Lfde122_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedListNode_1__0__ctor_System_Collections_Generic_LinkedList_1__0__0_System_Collections_Generic_LinkedListNode_1__0_System_Collections_Generic_LinkedListNode_1__0

LDIFF_SYM846=Lme_7d - _System_Collections_Generic_LinkedListNode_1__0__ctor_System_Collections_Generic_LinkedList_1__0__0_System_Collections_Generic_LinkedListNode_1__0_System_Collections_Generic_LinkedListNode_1__0
	.long LDIFF_SYM846
	.byte 12,13,0,72,14,8,135,2,68,14,20,132,5,136,4,139,3,142,1,68,14,48,68,13,11
	.align 2
Lfde122_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedListNode`1<!0>:Detach"
	.long _System_Collections_Generic_LinkedListNode_1__0_Detach
	.long Lme_7e

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM847=LTDIE_58_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM847
	.byte 2,123,4,11
	.asciz ""

LDIFF_SYM848=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM848
	.byte 0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM849=Lfde123_end - Lfde123_start
	.long LDIFF_SYM849
Lfde123_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedListNode_1__0_Detach

LDIFF_SYM850=Lme_7e - _System_Collections_Generic_LinkedListNode_1__0_Detach
	.long LDIFF_SYM850
	.byte 12,13,0,72,14,8,135,2,68,14,20,136,5,138,4,139,3,142,1,68,14,32,68,13,11
	.align 2
Lfde123_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedListNode`1<!0>:SelfReference"
	.long _System_Collections_Generic_LinkedListNode_1__0_SelfReference_System_Collections_Generic_LinkedList_1__0
	.long Lme_7f

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM851=LTDIE_58_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM851
	.byte 2,123,4,3
	.asciz "list"

LDIFF_SYM852=LTDIE_57_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM852
	.byte 2,123,8,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM853=Lfde124_end - Lfde124_start
	.long LDIFF_SYM853
Lfde124_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedListNode_1__0_SelfReference_System_Collections_Generic_LinkedList_1__0

LDIFF_SYM854=Lme_7f - _System_Collections_Generic_LinkedListNode_1__0_SelfReference_System_Collections_Generic_LinkedList_1__0
	.long LDIFF_SYM854
	.byte 12,13,0,72,14,8,135,2,68,14,20,134,5,136,4,139,3,142,1,68,14,40,68,13,11
	.align 2
Lfde124_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedListNode`1<!0>:InsertBetween"
	.long _System_Collections_Generic_LinkedListNode_1__0_InsertBetween_System_Collections_Generic_LinkedListNode_1__0_System_Collections_Generic_LinkedListNode_1__0_System_Collections_Generic_LinkedList_1__0
	.long Lme_80

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM855=LTDIE_58_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM855
	.byte 2,123,4,3
	.asciz "previousNode"

LDIFF_SYM856=LTDIE_58_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM856
	.byte 2,123,8,3
	.asciz "nextNode"

LDIFF_SYM857=LTDIE_58_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM857
	.byte 2,123,12,3
	.asciz "list"

LDIFF_SYM858=LTDIE_57_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM858
	.byte 2,123,16,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM859=Lfde125_end - Lfde125_start
	.long LDIFF_SYM859
Lfde125_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedListNode_1__0_InsertBetween_System_Collections_Generic_LinkedListNode_1__0_System_Collections_Generic_LinkedListNode_1__0_System_Collections_Generic_LinkedList_1__0

LDIFF_SYM860=Lme_80 - _System_Collections_Generic_LinkedListNode_1__0_InsertBetween_System_Collections_Generic_LinkedListNode_1__0_System_Collections_Generic_LinkedListNode_1__0_System_Collections_Generic_LinkedList_1__0
	.long LDIFF_SYM860
	.byte 12,13,0,72,14,8,135,2,68,14,20,132,5,136,4,139,3,142,1,68,14,48,68,13,11
	.align 2
Lfde125_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedListNode`1<!0>:get_List"
	.long _System_Collections_Generic_LinkedListNode_1__0_get_List
	.long Lme_81

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM861=LTDIE_58_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM861
	.byte 2,123,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM862=Lfde126_end - Lfde126_start
	.long LDIFF_SYM862
Lfde126_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedListNode_1__0_get_List

LDIFF_SYM863=Lme_81 - _System_Collections_Generic_LinkedListNode_1__0_get_List
	.long LDIFF_SYM863
	.byte 12,13,0,72,14,8,135,2,68,14,20,136,5,138,4,139,3,142,1,68,14,32,68,13,11
	.align 2
Lfde126_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedListNode`1<!0>:get_Previous"
	.long _System_Collections_Generic_LinkedListNode_1__0_get_Previous
	.long Lme_82

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM864=LTDIE_58_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM864
	.byte 2,123,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM865=Lfde127_end - Lfde127_start
	.long LDIFF_SYM865
Lfde127_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedListNode_1__0_get_Previous

LDIFF_SYM866=Lme_82 - _System_Collections_Generic_LinkedListNode_1__0_get_Previous
	.long LDIFF_SYM866
	.byte 12,13,0,72,14,8,135,2,68,14,24,134,6,136,5,138,4,139,3,142,1,68,14,32,68,13,11
	.align 2
Lfde127_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.LinkedListNode`1<!0>:get_Value"
	.long _System_Collections_Generic_LinkedListNode_1__0_get_Value
	.long Lme_83

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM867=LTDIE_58_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM867
	.byte 2,123,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM868=Lfde128_end - Lfde128_start
	.long LDIFF_SYM868
Lfde128_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_LinkedListNode_1__0_get_Value

LDIFF_SYM869=Lme_83 - _System_Collections_Generic_LinkedListNode_1__0_get_Value
	.long LDIFF_SYM869
	.byte 12,13,0,72,14,8,135,2,68,14,24,133,6,134,5,136,4,139,3,142,1,68,14,32,68,13,11
	.align 2
Lfde128_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_60:

	.byte 5
	.asciz "System_Collections_Generic_Stack`1"

	.byte 20,16
LDIFF_SYM870=LTDIE_1 - Ldebug_info_start
	.long LDIFF_SYM870
	.byte 2,35,0,6
	.asciz "_array"

LDIFF_SYM871=LDIE_SZARRAY - Ldebug_info_start
	.long LDIFF_SYM871
	.byte 2,35,8,6
	.asciz "_size"

LDIFF_SYM872=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM872
	.byte 2,35,12,6
	.asciz "_version"

LDIFF_SYM873=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM873
	.byte 2,35,16,0,7
	.asciz "System_Collections_Generic_Stack`1"

LDIFF_SYM874=LTDIE_60 - Ldebug_info_start
	.long LDIFF_SYM874
LTDIE_60_POINTER:

	.byte 13
LDIFF_SYM875=LTDIE_60 - Ldebug_info_start
	.long LDIFF_SYM875
LTDIE_60_REFERENCE:

	.byte 14
LDIFF_SYM876=LTDIE_60 - Ldebug_info_start
	.long LDIFF_SYM876
	.byte 2
	.asciz "System.Collections.Generic.Stack`1<!0>:.ctor"
	.long _System_Collections_Generic_Stack_1__0__ctor
	.long Lme_84

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM877=LTDIE_60_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM877
	.byte 2,123,8,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM878=Lfde129_end - Lfde129_start
	.long LDIFF_SYM878
Lfde129_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_Stack_1__0__ctor

LDIFF_SYM879=Lme_84 - _System_Collections_Generic_Stack_1__0__ctor
	.long LDIFF_SYM879
	.byte 12,13,0,72,14,8,135,2,68,14,16,136,4,139,3,142,1,68,14,32,68,13,11
	.align 2
Lfde129_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.Stack`1<!0>:Peek"
	.long _System_Collections_Generic_Stack_1__0_Peek
	.long Lme_85

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM880=LTDIE_60_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM880
	.byte 2,123,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM881=Lfde130_end - Lfde130_start
	.long LDIFF_SYM881
Lfde130_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_Stack_1__0_Peek

LDIFF_SYM882=Lme_85 - _System_Collections_Generic_Stack_1__0_Peek
	.long LDIFF_SYM882
	.byte 12,13,0,72,14,8,135,2,68,14,24,133,6,134,5,136,4,139,3,142,1,68,14,32,68,13,11
	.align 2
Lfde130_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.Stack`1<!0>:Pop"
	.long _System_Collections_Generic_Stack_1__0_Pop
	.long Lme_86

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM883=LTDIE_60_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM883
	.byte 2,123,8,11
	.asciz "popped"

LDIFF_SYM884=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM884
	.byte 1,80,11
	.asciz ""

LDIFF_SYM885=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM885
	.byte 2,123,4,11
	.asciz ""

LDIFF_SYM886=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM886
	.byte 1,80,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM887=Lfde131_end - Lfde131_start
	.long LDIFF_SYM887
Lfde131_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_Stack_1__0_Pop

LDIFF_SYM888=Lme_86 - _System_Collections_Generic_Stack_1__0_Pop
	.long LDIFF_SYM888
	.byte 12,13,0,72,14,8,135,2,68,14,24,133,6,134,5,136,4,139,3,142,1,68,14,48,68,13,11
	.align 2
Lfde131_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.Stack`1<!0>:Push"
	.long _System_Collections_Generic_Stack_1__0_Push__0
	.long Lme_87

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM889=LTDIE_60_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM889
	.byte 2,123,16,3
	.asciz "item"

LDIFF_SYM890=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM890
	.byte 1,80,11
	.asciz ""

LDIFF_SYM891=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM891
	.byte 2,123,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM892=Lfde132_end - Lfde132_start
	.long LDIFF_SYM892
Lfde132_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_Stack_1__0_Push__0

LDIFF_SYM893=Lme_87 - _System_Collections_Generic_Stack_1__0_Push__0
	.long LDIFF_SYM893
	.byte 12,13,0,72,14,8,135,2,68,14,20,136,5,138,4,139,3,142,1,68,14,56,68,13,11
	.align 2
Lfde132_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.Stack`1<!0>:get_Count"
	.long _System_Collections_Generic_Stack_1__0_get_Count
	.long Lme_88

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM894=LTDIE_60_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM894
	.byte 2,123,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM895=Lfde133_end - Lfde133_start
	.long LDIFF_SYM895
Lfde133_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_Stack_1__0_get_Count

LDIFF_SYM896=Lme_88 - _System_Collections_Generic_Stack_1__0_get_Count
	.long LDIFF_SYM896
	.byte 12,13,0,72,14,8,135,2,68,14,20,136,5,138,4,139,3,142,1,68,14,32,68,13,11
	.align 2
Lfde133_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.Stack`1<!0>:System.Collections.ICollection.get_SyncRoot"
	.long _System_Collections_Generic_Stack_1__0_System_Collections_ICollection_get_SyncRoot
	.long Lme_89

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM897=LTDIE_60_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM897
	.byte 2,123,8,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM898=Lfde134_end - Lfde134_start
	.long LDIFF_SYM898
Lfde134_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_Stack_1__0_System_Collections_ICollection_get_SyncRoot

LDIFF_SYM899=Lme_89 - _System_Collections_Generic_Stack_1__0_System_Collections_ICollection_get_SyncRoot
	.long LDIFF_SYM899
	.byte 12,13,0,72,14,8,135,2,68,14,16,136,4,139,3,142,1,68,14,32,68,13,11
	.align 2
Lfde134_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.Stack`1<!0>:GetEnumerator"
	.long _System_Collections_Generic_Stack_1__0_GetEnumerator
	.long Lme_8a

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM900=LTDIE_60_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM900
	.byte 2,123,4,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM901=Lfde135_end - Lfde135_start
	.long LDIFF_SYM901
Lfde135_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_Stack_1__0_GetEnumerator

LDIFF_SYM902=Lme_8a - _System_Collections_Generic_Stack_1__0_GetEnumerator
	.long LDIFF_SYM902
	.byte 12,13,0,72,14,8,135,2,68,14,24,133,6,134,5,136,4,139,3,142,1,68,14,48,68,13,11
	.align 2
Lfde135_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.Stack`1<!0>:System.Collections.Generic.IEnumerable<T>.GetEnumerator"
	.long _System_Collections_Generic_Stack_1__0_System_Collections_Generic_IEnumerable_T_GetEnumerator
	.long Lme_8b

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM903=LTDIE_60_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM903
	.byte 2,123,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM904=Lfde136_end - Lfde136_start
	.long LDIFF_SYM904
Lfde136_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_Stack_1__0_System_Collections_Generic_IEnumerable_T_GetEnumerator

LDIFF_SYM905=Lme_8b - _System_Collections_Generic_Stack_1__0_System_Collections_Generic_IEnumerable_T_GetEnumerator
	.long LDIFF_SYM905
	.byte 12,13,0,72,14,8,135,2,68,14,32,132,8,133,7,134,6,136,5,138,4,139,3,142,1,68,14,48,68,13,11
	.align 2
Lfde136_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.Stack`1<!0>:System.Collections.IEnumerable.GetEnumerator"
	.long _System_Collections_Generic_Stack_1__0_System_Collections_IEnumerable_GetEnumerator
	.long Lme_8c

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM906=LTDIE_60_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM906
	.byte 2,123,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM907=Lfde137_end - Lfde137_start
	.long LDIFF_SYM907
Lfde137_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_Stack_1__0_System_Collections_IEnumerable_GetEnumerator

LDIFF_SYM908=Lme_8c - _System_Collections_Generic_Stack_1__0_System_Collections_IEnumerable_GetEnumerator
	.long LDIFF_SYM908
	.byte 12,13,0,72,14,8,135,2,68,14,32,132,8,133,7,134,6,136,5,138,4,139,3,142,1,68,14,48,68,13,11
	.align 2
Lfde137_end:

.section __DWARF, __debug_info,regular,debug
LTDIE_61:

	.byte 5
	.asciz "_Enumerator"

	.byte 20,16
LDIFF_SYM909=LTDIE_3 - Ldebug_info_start
	.long LDIFF_SYM909
	.byte 2,35,0,6
	.asciz "parent"

LDIFF_SYM910=LTDIE_60_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM910
	.byte 2,35,8,6
	.asciz "idx"

LDIFF_SYM911=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM911
	.byte 2,35,12,6
	.asciz "_version"

LDIFF_SYM912=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM912
	.byte 2,35,16,0,7
	.asciz "_Enumerator"

LDIFF_SYM913=LTDIE_61 - Ldebug_info_start
	.long LDIFF_SYM913
LTDIE_61_POINTER:

	.byte 13
LDIFF_SYM914=LTDIE_61 - Ldebug_info_start
	.long LDIFF_SYM914
LTDIE_61_REFERENCE:

	.byte 14
LDIFF_SYM915=LTDIE_61 - Ldebug_info_start
	.long LDIFF_SYM915
	.byte 2
	.asciz "System.Collections.Generic.Stack`1/Enumerator<!0>:.ctor"
	.long _System_Collections_Generic_Stack_1_Enumerator__0__ctor_System_Collections_Generic_Stack_1__0
	.long Lme_8d

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM916=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM916
	.byte 1,86,3
	.asciz "t"

LDIFF_SYM917=LTDIE_60_REFERENCE - Ldebug_info_start
	.long LDIFF_SYM917
	.byte 2,123,8,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM918=Lfde138_end - Lfde138_start
	.long LDIFF_SYM918
Lfde138_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_Stack_1_Enumerator__0__ctor_System_Collections_Generic_Stack_1__0

LDIFF_SYM919=Lme_8d - _System_Collections_Generic_Stack_1_Enumerator__0__ctor_System_Collections_Generic_Stack_1__0
	.long LDIFF_SYM919
	.byte 12,13,0,72,14,8,135,2,68,14,24,133,6,134,5,136,4,139,3,142,1,68,14,40,68,13,11
	.align 2
Lfde138_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.Stack`1/Enumerator<!0>:Dispose"
	.long _System_Collections_Generic_Stack_1_Enumerator__0_Dispose
	.long Lme_8e

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM920=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM920
	.byte 2,123,8,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM921=Lfde139_end - Lfde139_start
	.long LDIFF_SYM921
Lfde139_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_Stack_1_Enumerator__0_Dispose

LDIFF_SYM922=Lme_8e - _System_Collections_Generic_Stack_1_Enumerator__0_Dispose
	.long LDIFF_SYM922
	.byte 12,13,0,72,14,8,135,2,68,14,20,134,5,136,4,139,3,142,1,68,14,40,68,13,11
	.align 2
Lfde139_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.Stack`1/Enumerator<!0>:MoveNext"
	.long _System_Collections_Generic_Stack_1_Enumerator__0_MoveNext
	.long Lme_8f

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM923=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM923
	.byte 1,90,11
	.asciz ""

LDIFF_SYM924=LDIE_I4 - Ldebug_info_start
	.long LDIFF_SYM924
	.byte 2,123,0,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM925=Lfde140_end - Lfde140_start
	.long LDIFF_SYM925
Lfde140_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_Stack_1_Enumerator__0_MoveNext

LDIFF_SYM926=Lme_8f - _System_Collections_Generic_Stack_1_Enumerator__0_MoveNext
	.long LDIFF_SYM926
	.byte 12,13,0,72,14,8,135,2,68,14,28,132,7,134,6,136,5,138,4,139,3,142,1,68,14,48,68,13,11
	.align 2
Lfde140_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.Stack`1/Enumerator<!0>:get_Current"
	.long _System_Collections_Generic_Stack_1_Enumerator__0_get_Current
	.long Lme_90

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM927=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM927
	.byte 1,86,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM928=Lfde141_end - Lfde141_start
	.long LDIFF_SYM928
Lfde141_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_Stack_1_Enumerator__0_get_Current

LDIFF_SYM929=Lme_90 - _System_Collections_Generic_Stack_1_Enumerator__0_get_Current
	.long LDIFF_SYM929
	.byte 12,13,0,72,14,8,135,2,68,14,28,132,7,133,6,134,5,136,4,139,3,142,1,68,14,40,68,13,11
	.align 2
Lfde141_end:

.section __DWARF, __debug_info,regular,debug

	.byte 2
	.asciz "System.Collections.Generic.Stack`1/Enumerator<!0>:System.Collections.IEnumerator.get_Current"
	.long _System_Collections_Generic_Stack_1_Enumerator__0_System_Collections_IEnumerator_get_Current
	.long Lme_91

	.byte 2,118,16,3
	.asciz "this"

LDIFF_SYM930=LDIE_I - Ldebug_info_start
	.long LDIFF_SYM930
	.byte 1,90,0

.section __DWARF, __debug_frame,regular,debug

LDIFF_SYM931=Lfde142_end - Lfde142_start
	.long LDIFF_SYM931
Lfde142_start:

	.long 0
	.align 2
	.long _System_Collections_Generic_Stack_1_Enumerator__0_System_Collections_IEnumerator_get_Current

LDIFF_SYM932=Lme_91 - _System_Collections_Generic_Stack_1_Enumerator__0_System_Collections_IEnumerator_get_Current
	.long LDIFF_SYM932
	.byte 12,13,0,72,14,8,135,2,68,14,32,132,8,133,7,134,6,136,5,138,4,139,3,142,1,68,14,48,68,13,11
	.align 2
Lfde142_end:

.section __DWARF, __debug_info,regular,debug

	.byte 0
Ldebug_info_end:
.section __DWARF, __debug_line,regular,debug
Ldebug_line_section_start:
Ldebug_line_start:

	.long Ldebug_line_end - . -4
	.short 2
	.long Ldebug_line_header_end - . -4
	.byte 1,1,251,14,13,0,1,1,1,1,0,0,0,1,0,0,1
.section __DWARF, __debug_line,regular,debug
	.asciz "///Library/Frameworks/Xamarin.iOS.framework/Versions/7.4.0.108/src/mono/mcs/class/System/System.Collections.Generic"
	.asciz "///Library/Frameworks/Xamarin.iOS.framework/Versions/7.4.0.108/src/mono/mcs/class/System/System.Collections.Specialized"
	.asciz "///Library/Frameworks/Xamarin.iOS.framework/Versions/7.4.0.108/src/mono/mcs/class/System/System.Diagnostics"

	.byte 0
	.asciz "<unknown>"

	.byte 0,0,0
	.asciz "LinkedList.cs"

	.byte 1,0,0
	.asciz "LinkedListNode.cs"

	.byte 1,0,0
	.asciz "Stack.cs"

	.byte 1,0,0
	.asciz "StringDictionary.cs"

	.byte 2,0,0
	.asciz "CorrelationManager.cs"

	.byte 3,0,0
	.asciz "Debug.cs"

	.byte 3,0,0
	.asciz "DefaultTraceListener.cs"

	.byte 3,0,0
	.asciz "TraceImpl.cs"

	.byte 3,0,0
	.asciz "TraceListener.cs"

	.byte 3,0,0
	.asciz "TraceListenerCollection.cs"

	.byte 3,0,0,0
Ldebug_line_header_end:
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1__ctor

	.byte 3,53,4,2,1,3,53,2,20,1,2,12,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_VerifyReferencedNode_System_Collections_Generic_LinkedListNode_1_T

	.byte 3,198,0,4,2,1,3,198,0,2,24,1,133,8,117,183,3,3,2,44,1,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_VerifyBlankNode_System_Collections_Generic_LinkedListNode_1_T

	.byte 3,207,0,4,2,1,3,207,0,2,24,1,133,8,61,183,3,3,2,44,1,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_AddFirst_System_Collections_Generic_LinkedListNode_1_T

	.byte 3,130,1,4,2,1,3,130,1,2,28,1,8,117,243,8,62,3,1,2,36,1,243,243,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_AddLast_T

	.byte 3,156,1,4,2,1,3,156,1,2,32,1,8,118,3,1,2,40,1,8,63,3,1,2,208,0,1,243,187,2,16,1
	.byte 0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_Clear

	.byte 3,184,1,4,2,1,3,184,1,2,20,1,187,185,2,24,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_Contains_T

	.byte 3,190,1,4,2,1,3,190,1,2,32,1,2,40,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_CopyTo_T___int

	.byte 3,195,1,4,2,1,3,195,1,2,28,1,132,3,2,2,52,1,8,62,3,3,2,152,1,1,131,190,3,1,2,36
	.byte 1,75,76,3,113,2,32,1,3,2,2,44,1,3,2,2,204,0,1,3,122,2,60,1,2,28,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_Find_T

	.byte 3,218,1,4,2,1,3,218,1,2,28,1,75,187,133,131,8,61,188,3,1,2,236,0,1,133,75,8,62,2,16,1
	.byte 0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_GetEnumerator

	.byte 3,132,2,4,2,1,3,132,2,2,36,1,2,140,1,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_Remove_T

	.byte 3,159,2,4,2,1,3,159,2,2,28,1,187,131,187,131,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_Remove_System_Collections_Generic_LinkedListNode_1_T

	.byte 3,168,2,4,2,1,3,168,2,2,28,1,187,243,8,61,132,8,61,244,187,2,24,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_RemoveLast

	.byte 3,190,2,4,2,1,3,190,2,2,24,1,8,63,8,114,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_System_Collections_Generic_ICollection_T_Add_T

	.byte 3,198,2,4,2,1,3,198,2,2,32,1,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_System_Collections_Generic_IEnumerable_T_GetEnumerator

	.byte 3,211,2,4,2,1,3,211,2,2,24,1,2,200,0,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_System_Collections_IEnumerable_GetEnumerator

	.byte 3,216,2,4,2,1,3,216,2,2,24,1,2,200,0,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_get_Count

	.byte 3,220,2,4,2,1,3,220,2,2,24,1,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_get_Last

	.byte 3,228,2,4,2,1,3,228,2,2,24,1,2,48,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_System_Collections_Generic_ICollection_T_get_IsReadOnly

	.byte 3,232,2,4,2,1,3,232,2,2,20,1,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_System_Collections_ICollection_get_SyncRoot

	.byte 3,240,2,4,2,1,3,240,2,2,24,1,2,12,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_Enumerator__ctor_System_Collections_Generic_LinkedList_1_T

	.byte 3,147,3,4,2,1,3,147,3,2,32,1,131,131,75,2,20,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_Enumerator_get_Current

	.byte 3,155,3,4,2,1,3,155,3,2,24,1,188,188,8,169,8,62,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_Enumerator_System_Collections_IEnumerator_get_Current

	.byte 3,164,3,4,2,1,3,164,3,2,28,1,2,28,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_Enumerator_MoveNext

	.byte 3,169,3,4,2,1,3,169,3,2,24,1,188,8,63,187,187,244,187,8,61,77,243,75,133,187,3,109,2,16,1,8
	.byte 62,2,44,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_Enumerator_Dispose

	.byte 3,205,3,4,2,1,3,205,3,2,24,1,244,131,240,2,20,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedListNode_1__ctor_T

	.byte 3,47,4,3,1,3,47,2,32,1,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedListNode_1__ctor_System_Collections_Generic_LinkedList_1_T_T

	.byte 3,52,4,3,1,3,52,2,36,1,187,243,2,24,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedListNode_1__ctor_System_Collections_Generic_LinkedList_1_T_T_System_Collections_Generic_LinkedListNode_1_T_System_Collections_Generic_LinkedListNode_1_T

	.byte 3,59,4,3,1,3,59,2,52,1,187,187,187,131,131,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedListNode_1_Detach

	.byte 3,197,0,4,3,1,3,197,0,2,24,1,8,61,8,174,8,61,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedListNode_1_SelfReference_System_Collections_Generic_LinkedList_1_T

	.byte 3,206,0,4,3,1,3,206,0,2,32,1,187,187,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedListNode_1_InsertBetween_System_Collections_Generic_LinkedListNode_1_T_System_Collections_Generic_LinkedListNode_1_T_System_Collections_Generic_LinkedList_1_T

	.byte 3,213,0,4,3,1,3,213,0,2,40,1,187,131,131,187,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedListNode_1_get_List

	.byte 3,221,0,4,3,1,3,221,0,2,24,1,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedListNode_1_get_Previous

	.byte 3,229,0,4,3,1,3,229,0,2,24,1,2,196,0,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedListNode_1_get_Value

	.byte 3,233,0,4,3,1,3,233,0,2,24,1,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_Stack_1__ctor

	.byte 3,51,4,4,1,3,51,2,20,1,2,12,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_Stack_1_Peek

	.byte 3,238,0,4,4,1,3,238,0,2,24,1,245,3,126,2,56,1,2,32,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_Stack_1_Pop

	.byte 3,246,0,4,4,1,3,246,0,2,24,1,245,243,3,2,2,192,0,1,3,1,2,44,1,3,122,2,12,1,2,32
	.byte 1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_Stack_1_Push_T

	.byte 3,130,1,4,4,1,3,130,1,2,28,1,3,1,2,44,1,3,2,2,212,0,1,244,2,204,0,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_Stack_1_get_Count

	.byte 3,153,1,4,4,1,3,153,1,2,24,1,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_Stack_1_System_Collections_ICollection_get_SyncRoot

	.byte 3,161,1,4,4,1,3,161,1,2,24,1,2,12,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_Stack_1_GetEnumerator

	.byte 3,178,1,4,4,1,3,178,1,2,36,1,2,244,0,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_Stack_1_System_Collections_Generic_IEnumerable_T_GetEnumerator

	.byte 3,183,1,4,4,1,3,183,1,2,24,1,2,192,0,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_Stack_1_System_Collections_IEnumerable_GetEnumerator

	.byte 3,188,1,4,4,1,3,188,1,2,24,1,2,192,0,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_Stack_1_Enumerator__ctor_System_Collections_Generic_Stack_1_T

	.byte 3,205,1,4,4,1,3,205,1,2,32,1,131,75,2,20,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_Stack_1_Enumerator_Dispose

	.byte 3,214,1,4,4,1,3,214,1,2,32,1,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_Stack_1_Enumerator_MoveNext

	.byte 3,219,1,4,4,1,3,219,1,2,24,1,8,63,243,188,3,123,2,216,0,1,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_Stack_1_Enumerator_get_Current

	.byte 3,230,1,4,4,1,3,230,1,2,24,1,189,3,126,2,52,1,2,32,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_Stack_1_Enumerator_System_Collections_IEnumerator_get_Current

	.byte 3,246,1,4,4,1,3,246,1,2,28,1,2,28,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Specialized_StringDictionary__ctor

	.byte 3,46,4,5,1,3,46,2,20,1,2,52,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Specialized_StringDictionary_GetEnumerator

	.byte 3,134,1,4,5,1,3,134,1,2,24,1,2,32,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_CorrelationManager__ctor

	.byte 3,38,4,6,1,3,38,2,20,1,3,2,2,40,1,2,12,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_Debug_Assert_bool_string

	.byte 3,196,0,4,7,1,3,196,0,2,36,1,2,12,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_DefaultTraceListener__cctor

	.byte 3,63,4,8,1,3,63,2,12,1,3,2,2,56,1,8,179,8,120,131,245,131,75,76,3,1,2,40,1,243,8,230
	.byte 3,1,2,40,1,243,8,231,3,10,2,4,1,8,63,8,61,2,32,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_DefaultTraceListener__ctor

	.byte 3,142,1,4,8,1,3,142,1,2,20,1,2,36,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_DefaultTraceListener_GetPrefix_string_string

	.byte 3,133,1,4,8,1,3,133,1,2,36,1,243,8,61,2,32,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_DefaultTraceListener_get_AssertUiEnabled

	.byte 3,148,1,4,8,1,3,148,1,2,24,1,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_DefaultTraceListener_get_LogFileName

	.byte 3,154,1,4,8,1,3,154,1,2,24,1,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_DefaultTraceListener_Fail_string

	.byte 3,160,1,4,8,1,3,160,1,2,36,1,2,12,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_DefaultTraceListener_Fail_string_string

	.byte 3,165,1,4,8,1,3,165,1,2,28,1,243,8,117,243,2,208,0,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_DefaultTraceListener_ProcessUI_string_string

	.byte 3,174,1,4,8,1,3,174,1,2,44,1,243,136,8,117,8,117,132,3,1,2,36,1,8,117,3,3,2,236,1,1
	.byte 187,8,231,3,1,2,36,1,132,3,1,2,200,0,1,3,2,2,144,2,1,3,2,2,220,1,1,132,132,2,24,1
	.byte 0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_DefaultTraceListener_WriteDebugString_string

	.byte 3,226,1,4,8,1,3,226,1,2,24,1,8,229,245,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_DefaultTraceListener_WriteMonoTrace_string

	.byte 3,235,1,4,8,1,3,235,1,2,24,1,3,2,2,236,0,1,8,117,76,8,117,76,8,229,2,12,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_DefaultTraceListener_WritePrefix

	.byte 3,250,1,4,8,1,3,250,1,2,20,1,8,173,2,40,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_DefaultTraceListener_WriteImpl_string

	.byte 3,129,2,4,8,1,3,129,2,2,28,1,131,243,133,188,243,244,2,36,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_DefaultTraceListener_WriteLogFile_string_string

	.byte 3,145,2,4,8,1,3,145,2,2,48,1,8,61,3,1,2,40,1,78,3,1,2,44,1,8,64,133,8,175,75,8
	.byte 61,2,228,0,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_DefaultTraceListener_Write_string

	.byte 3,171,2,4,8,1,3,171,2,2,32,1,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_DefaultTraceListener_WriteLine_string

	.byte 3,176,2,4,8,1,3,176,2,2,24,1,8,117,244,2,12,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_TraceImpl_get_IndentLevel

	.byte 3,223,0,4,9,1,3,223,0,2,16,1,2,40,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_TraceImpl_get_IndentSize

	.byte 3,239,0,4,9,1,3,239,0,2,16,1,2,40,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_TraceImpl_get_Listeners

	.byte 3,128,1,4,9,1,3,128,1,2,16,1,2,32,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_TraceImpl_get_ListenersSyncRoot

	.byte 3,134,1,4,9,1,3,134,1,2,40,1,2,48,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_TraceImpl_Assert_bool_string

	.byte 3,204,1,4,9,1,3,204,1,2,28,1,187,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_TraceImpl_Fail_string

	.byte 3,229,1,4,9,1,3,229,1,2,196,0,1,3,1,2,56,1,3,1,2,228,0,1,2,148,3,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_TraceImpl__cctor

	.byte 3,201,0,4,9,1,3,201,0,2,16,1,3,6,2,56,1,2,192,0,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_TraceListener__ctor_string

	.byte 3,226,0,4,10,1,3,226,0,2,28,1,77,3,10,2,40,1,82,2,32,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_TraceListener_get_IndentLevel

	.byte 3,251,0,4,10,1,3,251,0,2,24,1,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_TraceListener_set_IndentLevel_int

	.byte 3,252,0,4,10,1,3,252,0,2,32,1,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_TraceListener_get_IndentSize

	.byte 3,128,1,4,10,1,3,128,1,2,24,1,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_TraceListener_set_IndentSize_int

	.byte 3,129,1,4,10,1,3,129,1,2,32,1,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_TraceListener_set_Name_string

	.byte 3,134,1,4,10,1,3,134,1,2,32,1,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_TraceListener_get_NeedIndent

	.byte 3,138,1,4,10,1,3,138,1,2,24,1,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_TraceListener_set_NeedIndent_bool

	.byte 3,139,1,4,10,1,3,139,1,2,32,1,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_TraceListener_Dispose

	.byte 3,154,1,4,10,1,3,154,1,2,16,1,8,61,2,20,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_TraceListener_Fail_string

	.byte 3,164,1,4,10,1,3,164,1,2,32,1,2,32,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_TraceListener_Fail_string_string

	.byte 3,169,1,4,10,1,3,169,1,2,28,1,8,229,8,229,8,117,131,8,229,8,63,2,48,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_TraceListener_WriteIndent

	.byte 3,206,1,4,10,1,3,206,1,2,32,1,8,61,2,28,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_TraceListenerCollection__ctor_bool

	.byte 3,43,4,11,1,3,43,2,24,1,3,9,2,56,1,131,2,56,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_TraceListenerCollection_System_Collections_ICollection_get_SyncRoot

	.byte 3,222,0,4,11,1,3,222,0,2,24,1,2,32,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_TraceListenerCollection_Add_System_Diagnostics_TraceListener

	.byte 3,235,0,4,11,1,3,235,0,2,32,1,131,2,36,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_TraceListenerCollection_InitializeListener_System_Diagnostics_TraceListener

	.byte 3,251,0,4,11,1,3,251,0,2,24,1,2,220,0,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_TraceListenerCollection_GetEnumerator

	.byte 3,163,1,4,11,1,3,163,1,2,24,1,2,32,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Diagnostics_TraceListenerCollection_System_Collections_IList_Contains_object

	.byte 3,181,1,4,11,1,3,181,1,2,24,1,3,1,2,204,0,1,8,229,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1__0__ctor

	.byte 3,53,4,2,1,3,53,2,28,1,2,36,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1__0_VerifyReferencedNode_System_Collections_Generic_LinkedListNode_1__0

	.byte 3,198,0,4,2,1,3,198,0,2,32,1,3,3,2,40,1,8,229,183,3,3,2,44,1,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1__0_VerifyBlankNode_System_Collections_Generic_LinkedListNode_1__0

	.byte 3,207,0,4,2,1,3,207,0,2,32,1,3,3,2,36,1,8,117,183,3,3,2,44,1,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1__0_AddFirst_System_Collections_Generic_LinkedListNode_1__0

	.byte 3,130,1,4,2,1,3,130,1,2,32,1,3,1,2,204,0,1,8,229,8,230,3,1,2,224,0,1,3,1,2,36
	.byte 1,3,1,2,36,1,2,24,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1__0_AddLast__0

	.byte 3,156,1,4,2,1,3,156,1,2,32,1,3,2,2,56,1,3,1,2,192,0,1,8,175,3,1,2,136,1,1,3
	.byte 1,2,36,1,8,229,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1__0_Clear

	.byte 3,184,1,4,2,1,3,184,1,2,28,1,3,1,2,40,1,3,127,2,48,1,2,32,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1__0_Contains__0

	.byte 3,190,1,4,2,1,3,190,1,2,32,1,2,228,0,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1__0_CopyTo__0___int

	.byte 3,195,1,4,2,1,3,195,1,2,36,1,3,2,2,40,1,3,2,2,60,1,8,62,3,3,2,160,1,1,8,61
	.byte 8,120,3,1,2,204,0,1,75,8,118,3,113,2,32,1,3,2,2,44,1,3,2,2,204,0,1,3,122,2,60,1
	.byte 2,44,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1__0_Find__0

	.byte 3,218,1,4,2,1,3,218,1,2,32,1,3,1,2,48,1,187,133,131,8,229,188,3,1,2,152,1,1,133,187,8
	.byte 174,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1__0_GetEnumerator

	.byte 3,132,2,4,2,1,3,132,2,2,32,1,2,208,1,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1__0_Remove__0

	.byte 3,159,2,4,2,1,3,159,2,2,32,1,3,1,2,60,1,131,8,61,8,117,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1__0_Remove_System_Collections_Generic_LinkedListNode_1__0

	.byte 3,168,2,4,2,1,3,168,2,2,32,1,3,1,2,192,0,1,3,1,2,36,1,8,117,8,62,8,173,3,2,2
	.byte 40,1,3,1,2,36,1,2,32,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1__0_RemoveLast

	.byte 3,190,2,4,2,1,3,190,2,2,28,1,3,3,2,60,1,3,126,2,196,0,1,2,16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1__0_System_Collections_Generic_ICollection_T_Add__0

	.byte 3,198,2,4,2,1,3,198,2,2,32,1,2,204,0,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1__0_System_Collections_Generic_IEnumerable_T_GetEnumerator

	.byte 3,211,2,4,2,1,3,211,2,2,28,1,2,204,1,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1__0_System_Collections_IEnumerable_GetEnumerator

	.byte 3,216,2,4,2,1,3,216,2,2,28,1,2,204,1,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1__0_get_Count

	.byte 3,220,2,4,2,1,3,220,2,2,28,1,2,52,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1__0_get_Last

	.byte 3,228,2,4,2,1,3,228,2,2,28,1,2,228,0,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1__0_System_Collections_Generic_ICollection_T_get_IsReadOnly

	.byte 3,232,2,4,2,1,3,232,2,2,28,1,2,40,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1__0_System_Collections_ICollection_get_SyncRoot

	.byte 3,240,2,4,2,1,3,240,2,2,28,1,2,40,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_Enumerator__0__ctor_System_Collections_Generic_LinkedList_1__0

	.byte 3,147,3,4,2,1,3,147,3,2,36,1,3,1,2,36,1,243,243,2,36,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_Enumerator__0_get_Current

	.byte 3,155,3,4,2,1,3,155,3,2,36,1,3,2,2,48,1,8,62,3,127,2,208,0,1,8,114,2,12,1,0,1
	.byte 1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_Enumerator__0_System_Collections_IEnumerator_get_Current

	.byte 3,164,3,4,2,1,3,164,3,2,32,1,2,204,1,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_Enumerator__0_MoveNext

	.byte 3,169,3,4,2,1,3,169,3,2,32,1,3,2,2,40,1,3,3,2,44,1,8,61,8,61,3,2,2,40,1,3
	.byte 1,2,36,1,3,1,2,44,1,245,8,61,243,133,8,173,3,111,2,16,1,3,126,2,52,1,2,12,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedList_1_Enumerator__0_Dispose

	.byte 3,205,3,4,2,1,3,205,3,2,32,1,3,2,2,40,1,243,8,170,2,20,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedListNode_1__0__ctor__0

	.byte 3,45,4,3,1,3,45,2,32,1,8,230,2,36,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedListNode_1__0__ctor_System_Collections_Generic_LinkedList_1__0__0

	.byte 3,50,4,3,1,3,50,2,36,1,8,230,8,61,3,1,2,36,1,2,40,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedListNode_1__0__ctor_System_Collections_Generic_LinkedList_1__0__0_System_Collections_Generic_LinkedListNode_1__0_System_Collections_Generic_LinkedListNode_1__0

	.byte 3,57,4,3,1,3,57,2,48,1,8,230,8,61,8,173,8,61,8,61,243,2,24,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedListNode_1__0_Detach

	.byte 3,197,0,4,3,1,3,197,0,2,28,1,3,1,2,200,0,1,3,2,2,48,1,3,1,2,36,1,2,28,1,0
	.byte 1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedListNode_1__0_SelfReference_System_Collections_Generic_LinkedList_1__0

	.byte 3,206,0,4,3,1,3,206,0,2,32,1,3,1,2,52,1,243,2,28,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedListNode_1__0_InsertBetween_System_Collections_Generic_LinkedListNode_1__0_System_Collections_Generic_LinkedListNode_1__0_System_Collections_Generic_LinkedList_1__0

	.byte 3,213,0,4,3,1,3,213,0,2,40,1,3,1,2,48,1,8,61,243,243,2,28,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedListNode_1__0_get_List

	.byte 3,221,0,4,3,1,3,221,0,2,28,1,2,52,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedListNode_1__0_get_Previous

	.byte 3,229,0,4,3,1,3,229,0,2,28,1,2,128,1,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_LinkedListNode_1__0_get_Value

	.byte 3,233,0,4,3,1,3,233,0,2,32,1,2,232,0,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_Stack_1__0__ctor

	.byte 3,51,4,4,1,3,51,2,28,1,2,36,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_Stack_1__0_Peek

	.byte 3,238,0,4,4,1,3,238,0,2,32,1,3,3,2,60,1,3,126,2,244,0,1,2,32,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_Stack_1__0_Pop

	.byte 3,246,0,4,4,1,3,246,0,2,32,1,3,3,2,232,0,1,3,1,2,36,1,3,2,2,236,0,1,3,1,2
	.byte 164,1,1,3,122,2,12,1,2,32,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_Stack_1__0_Push__0

	.byte 3,130,1,4,4,1,3,130,1,2,32,1,3,1,2,224,0,1,3,2,2,136,1,1,3,2,2,36,1,2,148,1
	.byte 1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_Stack_1__0_get_Count

	.byte 3,153,1,4,4,1,3,153,1,2,28,1,2,52,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_Stack_1__0_System_Collections_ICollection_get_SyncRoot

	.byte 3,161,1,4,4,1,3,161,1,2,28,1,2,40,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_Stack_1__0_GetEnumerator

	.byte 3,178,1,4,4,1,3,178,1,2,32,1,2,208,1,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_Stack_1__0_System_Collections_Generic_IEnumerable_T_GetEnumerator

	.byte 3,183,1,4,4,1,3,183,1,2,28,1,2,204,1,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_Stack_1__0_System_Collections_IEnumerable_GetEnumerator

	.byte 3,188,1,4,4,1,3,188,1,2,28,1,2,204,1,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_Stack_1_Enumerator__0__ctor_System_Collections_Generic_Stack_1__0

	.byte 3,205,1,4,4,1,3,205,1,2,36,1,3,1,2,36,1,243,2,36,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_Stack_1_Enumerator__0_Dispose

	.byte 3,214,1,4,4,1,3,214,1,2,32,1,2,52,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_Stack_1_Enumerator__0_MoveNext

	.byte 3,219,1,4,4,1,3,219,1,2,32,1,3,3,2,192,0,1,8,117,3,2,2,36,1,3,123,2,240,0,1,2
	.byte 16,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_Stack_1_Enumerator__0_get_Current

	.byte 3,230,1,4,4,1,3,230,1,2,36,1,3,3,2,48,1,3,126,2,248,0,1,2,32,1,0,1,1
.section __DWARF, __debug_line,regular,debug

	.byte 0,5,2
	.long _System_Collections_Generic_Stack_1_Enumerator__0_System_Collections_IEnumerator_get_Current

	.byte 3,246,1,4,4,1,3,246,1,2,32,1,2,204,1,1,0,1,1,0,1,1
Ldebug_line_end:
.text
	.align 3
mem_end:
