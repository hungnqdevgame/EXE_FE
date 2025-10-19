#define ICALL_TABLE_corlib 1

static int corlib_icall_indexes [] = {
188,
201,
202,
203,
204,
205,
206,
207,
208,
209,
212,
213,
214,
382,
383,
384,
407,
408,
409,
426,
427,
428,
524,
525,
526,
529,
561,
562,
563,
564,
565,
569,
571,
573,
575,
581,
589,
590,
591,
592,
593,
594,
595,
596,
597,
675,
676,
718,
727,
728,
797,
803,
806,
808,
813,
814,
816,
817,
821,
822,
824,
825,
828,
829,
830,
833,
835,
838,
840,
842,
851,
915,
917,
919,
929,
930,
931,
933,
939,
940,
941,
942,
943,
951,
952,
953,
957,
958,
960,
964,
965,
966,
1258,
1418,
1419,
8667,
8668,
8670,
8671,
8672,
8673,
8674,
8676,
8677,
8678,
8695,
8697,
8704,
8706,
8708,
8710,
8713,
8763,
8764,
8766,
8767,
8768,
8769,
8770,
8772,
8774,
9790,
9794,
9796,
9797,
9798,
9799,
10218,
10219,
10220,
10221,
10239,
10240,
10241,
10285,
10350,
10353,
10361,
10362,
10363,
10364,
10365,
10642,
10646,
10647,
10674,
10708,
10715,
10722,
10733,
10737,
10760,
10838,
10840,
10849,
10851,
10852,
10859,
10874,
10894,
10895,
10903,
10905,
10912,
10913,
10916,
10918,
10923,
10929,
10930,
10937,
10939,
10951,
10954,
10955,
10956,
10967,
10977,
10983,
10984,
10985,
10987,
10988,
11005,
11007,
11022,
11040,
11067,
11097,
11098,
11582,
11666,
11667,
11851,
11852,
11856,
11857,
11858,
11863,
11914,
12313,
12314,
12510,
12515,
12525,
13361,
13382,
13384,
13386,
};
void ves_icall_System_Array_InternalCreate (int,int,int,int,int);
int ves_icall_System_Array_GetCorElementTypeOfElementTypeInternal (int);
int ves_icall_System_Array_IsValueOfElementTypeInternal (int,int);
int ves_icall_System_Array_CanChangePrimitive (int,int,int);
int ves_icall_System_Array_FastCopy (int,int,int,int,int);
int ves_icall_System_Array_GetLengthInternal_raw (int,int,int);
int ves_icall_System_Array_GetLowerBoundInternal_raw (int,int,int);
void ves_icall_System_Array_GetGenericValue_icall (int,int,int);
void ves_icall_System_Array_GetValueImpl_raw (int,int,int,int);
void ves_icall_System_Array_SetGenericValue_icall (int,int,int);
void ves_icall_System_Array_SetValueImpl_raw (int,int,int,int);
void ves_icall_System_Array_InitializeInternal_raw (int,int);
void ves_icall_System_Array_SetValueRelaxedImpl_raw (int,int,int,int);
void ves_icall_System_Runtime_RuntimeImports_ZeroMemory (int,int);
void ves_icall_System_Runtime_RuntimeImports_Memmove (int,int,int);
void ves_icall_System_Buffer_BulkMoveWithWriteBarrier (int,int,int,int);
int ves_icall_System_Delegate_AllocDelegateLike_internal_raw (int,int);
int ves_icall_System_Delegate_CreateDelegate_internal_raw (int,int,int,int,int);
int ves_icall_System_Delegate_GetVirtualMethod_internal_raw (int,int);
void ves_icall_System_Enum_GetEnumValuesAndNames_raw (int,int,int,int);
int ves_icall_System_Enum_InternalGetCorElementType (int);
void ves_icall_System_Enum_InternalGetUnderlyingType_raw (int,int,int);
int ves_icall_System_Environment_get_ProcessorCount ();
int ves_icall_System_Environment_get_TickCount ();
int64_t ves_icall_System_Environment_get_TickCount64 ();
void ves_icall_System_Environment_FailFast_raw (int,int,int,int);
int ves_icall_System_GC_GetCollectionCount (int);
int ves_icall_System_GC_GetMaxGeneration ();
void ves_icall_System_GC_register_ephemeron_array_raw (int,int);
int ves_icall_System_GC_get_ephemeron_tombstone_raw (int);
int64_t ves_icall_System_GC_GetTotalAllocatedBytes_raw (int,int);
void ves_icall_System_GC_SuppressFinalize_raw (int,int);
void ves_icall_System_GC_ReRegisterForFinalize_raw (int,int);
void ves_icall_System_GC_GetGCMemoryInfo (int,int,int,int,int,int);
int ves_icall_System_GC_AllocPinnedArray_raw (int,int,int);
int ves_icall_System_Object_MemberwiseClone_raw (int,int);
double ves_icall_System_Math_Ceiling (double);
double ves_icall_System_Math_Cos (double);
double ves_icall_System_Math_Floor (double);
double ves_icall_System_Math_Pow (double,double);
double ves_icall_System_Math_Sin (double);
double ves_icall_System_Math_Sqrt (double);
double ves_icall_System_Math_Tan (double);
double ves_icall_System_Math_Log2 (double);
double ves_icall_System_Math_ModF (double,int);
float ves_icall_System_MathF_Log2 (float);
float ves_icall_System_MathF_ModF (float,int);
int ves_icall_RuntimeMethodHandle_GetFunctionPointer_raw (int,int);
void ves_icall_RuntimeMethodHandle_ReboxFromNullable_raw (int,int,int);
void ves_icall_RuntimeMethodHandle_ReboxToNullable_raw (int,int,int,int);
int ves_icall_RuntimeType_GetCorrespondingInflatedMethod_raw (int,int,int);
void ves_icall_RuntimeType_make_array_type_raw (int,int,int,int);
void ves_icall_RuntimeType_make_byref_type_raw (int,int,int);
void ves_icall_RuntimeType_make_pointer_type_raw (int,int,int);
void ves_icall_RuntimeType_MakeGenericType_raw (int,int,int,int);
int ves_icall_RuntimeType_GetMethodsByName_native_raw (int,int,int,int,int);
int ves_icall_RuntimeType_GetPropertiesByName_native_raw (int,int,int,int,int);
int ves_icall_RuntimeType_GetConstructors_native_raw (int,int,int);
int ves_icall_System_RuntimeType_CreateInstanceInternal_raw (int,int);
void ves_icall_RuntimeType_GetDeclaringMethod_raw (int,int,int);
void ves_icall_System_RuntimeType_getFullName_raw (int,int,int,int,int);
void ves_icall_RuntimeType_GetGenericArgumentsInternal_raw (int,int,int,int);
int ves_icall_RuntimeType_GetGenericParameterPosition (int);
int ves_icall_RuntimeType_GetEvents_native_raw (int,int,int,int);
int ves_icall_RuntimeType_GetFields_native_raw (int,int,int,int,int);
void ves_icall_RuntimeType_GetInterfaces_raw (int,int,int);
int ves_icall_RuntimeType_GetNestedTypes_native_raw (int,int,int,int,int);
void ves_icall_RuntimeType_GetDeclaringType_raw (int,int,int);
void ves_icall_RuntimeType_GetName_raw (int,int,int);
void ves_icall_RuntimeType_GetNamespace_raw (int,int,int);
int ves_icall_RuntimeType_FunctionPointerReturnAndParameterTypes_raw (int,int);
int ves_icall_RuntimeTypeHandle_GetAttributes (int);
int ves_icall_RuntimeTypeHandle_GetMetadataToken_raw (int,int);
void ves_icall_RuntimeTypeHandle_GetGenericTypeDefinition_impl_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_GetCorElementType (int);
int ves_icall_RuntimeTypeHandle_HasInstantiation (int);
int ves_icall_RuntimeTypeHandle_IsInstanceOfType_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_HasReferences_raw (int,int);
int ves_icall_RuntimeTypeHandle_GetArrayRank_raw (int,int);
void ves_icall_RuntimeTypeHandle_GetAssembly_raw (int,int,int);
void ves_icall_RuntimeTypeHandle_GetElementType_raw (int,int,int);
void ves_icall_RuntimeTypeHandle_GetModule_raw (int,int,int);
void ves_icall_RuntimeTypeHandle_GetBaseType_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_type_is_assignable_from_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_IsGenericTypeDefinition (int);
int ves_icall_RuntimeTypeHandle_GetGenericParameterInfo_raw (int,int);
int ves_icall_RuntimeTypeHandle_is_subclass_of_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_IsByRefLike_raw (int,int);
void ves_icall_System_RuntimeTypeHandle_internal_from_name_raw (int,int,int,int,int,int);
int ves_icall_System_String_FastAllocateString_raw (int,int);
int ves_icall_System_String_InternalIsInterned_raw (int,int);
int ves_icall_System_String_InternalIntern_raw (int,int);
int ves_icall_System_Type_internal_from_handle_raw (int,int);
int ves_icall_System_ValueType_InternalGetHashCode_raw (int,int,int);
int ves_icall_System_ValueType_Equals_raw (int,int,int,int);
int ves_icall_System_Threading_Interlocked_CompareExchange_Int (int,int,int);
void ves_icall_System_Threading_Interlocked_CompareExchange_Object (int,int,int,int);
int ves_icall_System_Threading_Interlocked_Decrement_Int (int);
int ves_icall_System_Threading_Interlocked_Increment_Int (int);
int64_t ves_icall_System_Threading_Interlocked_Increment_Long (int);
int ves_icall_System_Threading_Interlocked_Exchange_Int (int,int);
void ves_icall_System_Threading_Interlocked_Exchange_Object (int,int,int);
int64_t ves_icall_System_Threading_Interlocked_CompareExchange_Long (int,int64_t,int64_t);
int64_t ves_icall_System_Threading_Interlocked_Exchange_Long (int,int64_t);
int ves_icall_System_Threading_Interlocked_Add_Int (int,int);
void ves_icall_System_Threading_Monitor_Monitor_Enter_raw (int,int);
void mono_monitor_exit_icall_raw (int,int);
void ves_icall_System_Threading_Monitor_Monitor_pulse_raw (int,int);
void ves_icall_System_Threading_Monitor_Monitor_pulse_all_raw (int,int);
int ves_icall_System_Threading_Monitor_Monitor_wait_raw (int,int,int,int);
void ves_icall_System_Threading_Monitor_Monitor_try_enter_with_atomic_var_raw (int,int,int,int,int);
int64_t ves_icall_System_Threading_Monitor_Monitor_get_lock_contention_count ();
void ves_icall_System_Threading_Thread_InitInternal_raw (int,int);
int ves_icall_System_Threading_Thread_GetCurrentThread ();
void ves_icall_System_Threading_InternalThread_Thread_free_internal_raw (int,int);
int ves_icall_System_Threading_Thread_GetState_raw (int,int);
void ves_icall_System_Threading_Thread_SetState_raw (int,int,int);
void ves_icall_System_Threading_Thread_ClrState_raw (int,int,int);
void ves_icall_System_Threading_Thread_SetName_icall_raw (int,int,int,int);
int ves_icall_System_Threading_Thread_YieldInternal ();
void ves_icall_System_Threading_Thread_SetPriority_raw (int,int,int);
void ves_icall_System_Runtime_Loader_AssemblyLoadContext_PrepareForAssemblyLoadContextRelease_raw (int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_GetLoadContextForAssembly_raw (int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFile_raw (int,int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalInitializeNativeALC_raw (int,int,int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFromStream_raw (int,int,int,int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalGetLoadedAssemblies_raw (int);
int ves_icall_System_GCHandle_InternalAlloc_raw (int,int,int);
void ves_icall_System_GCHandle_InternalFree_raw (int,int);
int ves_icall_System_GCHandle_InternalGet_raw (int,int);
void ves_icall_System_GCHandle_InternalSet_raw (int,int,int);
int ves_icall_System_Runtime_InteropServices_Marshal_GetLastPInvokeError ();
void ves_icall_System_Runtime_InteropServices_Marshal_SetLastPInvokeError (int);
void ves_icall_System_Runtime_InteropServices_Marshal_StructureToPtr_raw (int,int,int,int);
int ves_icall_System_Runtime_InteropServices_NativeLibrary_LoadByName_raw (int,int,int,int,int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalGetHashCode_raw (int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetObjectValue_raw (int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetUninitializedObjectInternal_raw (int,int);
void ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InitializeArray_raw (int,int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetSpanDataFrom_raw (int,int,int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_SufficientExecutionStack ();
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalBox_raw (int,int,int);
int ves_icall_System_Reflection_Assembly_GetEntryAssembly_raw (int);
int ves_icall_System_Reflection_Assembly_InternalLoad_raw (int,int,int,int);
int ves_icall_System_Reflection_Assembly_InternalGetType_raw (int,int,int,int,int,int);
int ves_icall_System_Reflection_AssemblyName_GetNativeName (int);
int ves_icall_MonoCustomAttrs_GetCustomAttributesInternal_raw (int,int,int,int);
int ves_icall_MonoCustomAttrs_GetCustomAttributesDataInternal_raw (int,int);
int ves_icall_MonoCustomAttrs_IsDefinedInternal_raw (int,int,int);
int ves_icall_System_Reflection_FieldInfo_internal_from_handle_type_raw (int,int,int);
int ves_icall_System_Reflection_FieldInfo_get_marshal_info_raw (int,int);
int ves_icall_System_Reflection_LoaderAllocatorScout_Destroy (int);
void ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceNames_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeAssembly_GetExportedTypes_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeAssembly_GetInfo_raw (int,int,int,int);
int ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceInternal_raw (int,int,int,int,int);
void ves_icall_System_Reflection_Assembly_GetManifestModuleInternal_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeCustomAttributeData_ResolveArgumentsInternal_raw (int,int,int,int,int,int,int);
void ves_icall_RuntimeEventInfo_get_event_info_raw (int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_System_Reflection_EventInfo_internal_from_handle_type_raw (int,int,int);
int ves_icall_RuntimeFieldInfo_ResolveType_raw (int,int);
int ves_icall_RuntimeFieldInfo_GetParentType_raw (int,int,int);
int ves_icall_RuntimeFieldInfo_GetFieldOffset_raw (int,int);
int ves_icall_RuntimeFieldInfo_GetValueInternal_raw (int,int,int);
void ves_icall_RuntimeFieldInfo_SetValueInternal_raw (int,int,int,int);
int ves_icall_RuntimeFieldInfo_GetRawConstantValue_raw (int,int);
int ves_icall_reflection_get_token_raw (int,int);
void ves_icall_get_method_info_raw (int,int,int);
int ves_icall_get_method_attributes (int);
int ves_icall_System_Reflection_MonoMethodInfo_get_parameter_info_raw (int,int,int);
int ves_icall_System_MonoMethodInfo_get_retval_marshal_raw (int,int);
int ves_icall_System_Reflection_RuntimeMethodInfo_GetMethodFromHandleInternalType_native_raw (int,int,int,int);
int ves_icall_RuntimeMethodInfo_get_name_raw (int,int);
int ves_icall_RuntimeMethodInfo_get_base_method_raw (int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_InternalInvoke_raw (int,int,int,int,int);
void ves_icall_RuntimeMethodInfo_GetPInvoke_raw (int,int,int,int,int);
int ves_icall_RuntimeMethodInfo_MakeGenericMethod_impl_raw (int,int,int);
int ves_icall_RuntimeMethodInfo_GetGenericArguments_raw (int,int);
int ves_icall_RuntimeMethodInfo_GetGenericMethodDefinition_raw (int,int);
int ves_icall_RuntimeMethodInfo_get_IsGenericMethodDefinition_raw (int,int);
int ves_icall_RuntimeMethodInfo_get_IsGenericMethod_raw (int,int);
void ves_icall_InvokeClassConstructor_raw (int,int);
int ves_icall_InternalInvoke_raw (int,int,int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_System_Reflection_RuntimeModule_ResolveMethodToken_raw (int,int,int,int,int,int);
void ves_icall_RuntimePropertyInfo_get_property_info_raw (int,int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_System_Reflection_RuntimePropertyInfo_internal_from_handle_type_raw (int,int,int);
void ves_icall_DynamicMethod_create_dynamic_method_raw (int,int,int,int,int);
void ves_icall_AssemblyBuilder_basic_init_raw (int,int);
void ves_icall_AssemblyBuilder_UpdateNativeCustomAttributes_raw (int,int);
void ves_icall_ModuleBuilder_basic_init_raw (int,int);
void ves_icall_ModuleBuilder_set_wrappers_type_raw (int,int,int);
int ves_icall_ModuleBuilder_getUSIndex_raw (int,int,int);
int ves_icall_ModuleBuilder_getToken_raw (int,int,int,int);
int ves_icall_ModuleBuilder_getMethodToken_raw (int,int,int,int);
void ves_icall_ModuleBuilder_RegisterToken_raw (int,int,int,int);
int ves_icall_TypeBuilder_create_runtime_class_raw (int,int);
int ves_icall_System_IO_Stream_HasOverriddenBeginEndRead_raw (int,int);
int ves_icall_System_IO_Stream_HasOverriddenBeginEndWrite_raw (int,int);
int ves_icall_System_Diagnostics_Debugger_IsAttached_internal ();
int ves_icall_System_Diagnostics_StackFrame_GetFrameInfo (int,int,int,int,int,int,int,int);
void ves_icall_System_Diagnostics_StackTrace_GetTrace (int,int,int,int);
int ves_icall_Mono_RuntimeClassHandle_GetTypeFromClass (int);
void ves_icall_Mono_RuntimeGPtrArrayHandle_GPtrArrayFree (int);
int ves_icall_Mono_SafeStringMarshal_StringToUtf8 (int);
void ves_icall_Mono_SafeStringMarshal_GFree (int);
static void *corlib_icall_funcs [] = {
// token 188,
ves_icall_System_Array_InternalCreate,
// token 201,
ves_icall_System_Array_GetCorElementTypeOfElementTypeInternal,
// token 202,
ves_icall_System_Array_IsValueOfElementTypeInternal,
// token 203,
ves_icall_System_Array_CanChangePrimitive,
// token 204,
ves_icall_System_Array_FastCopy,
// token 205,
ves_icall_System_Array_GetLengthInternal_raw,
// token 206,
ves_icall_System_Array_GetLowerBoundInternal_raw,
// token 207,
ves_icall_System_Array_GetGenericValue_icall,
// token 208,
ves_icall_System_Array_GetValueImpl_raw,
// token 209,
ves_icall_System_Array_SetGenericValue_icall,
// token 212,
ves_icall_System_Array_SetValueImpl_raw,
// token 213,
ves_icall_System_Array_InitializeInternal_raw,
// token 214,
ves_icall_System_Array_SetValueRelaxedImpl_raw,
// token 382,
ves_icall_System_Runtime_RuntimeImports_ZeroMemory,
// token 383,
ves_icall_System_Runtime_RuntimeImports_Memmove,
// token 384,
ves_icall_System_Buffer_BulkMoveWithWriteBarrier,
// token 407,
ves_icall_System_Delegate_AllocDelegateLike_internal_raw,
// token 408,
ves_icall_System_Delegate_CreateDelegate_internal_raw,
// token 409,
ves_icall_System_Delegate_GetVirtualMethod_internal_raw,
// token 426,
ves_icall_System_Enum_GetEnumValuesAndNames_raw,
// token 427,
ves_icall_System_Enum_InternalGetCorElementType,
// token 428,
ves_icall_System_Enum_InternalGetUnderlyingType_raw,
// token 524,
ves_icall_System_Environment_get_ProcessorCount,
// token 525,
ves_icall_System_Environment_get_TickCount,
// token 526,
ves_icall_System_Environment_get_TickCount64,
// token 529,
ves_icall_System_Environment_FailFast_raw,
// token 561,
ves_icall_System_GC_GetCollectionCount,
// token 562,
ves_icall_System_GC_GetMaxGeneration,
// token 563,
ves_icall_System_GC_register_ephemeron_array_raw,
// token 564,
ves_icall_System_GC_get_ephemeron_tombstone_raw,
// token 565,
ves_icall_System_GC_GetTotalAllocatedBytes_raw,
// token 569,
ves_icall_System_GC_SuppressFinalize_raw,
// token 571,
ves_icall_System_GC_ReRegisterForFinalize_raw,
// token 573,
ves_icall_System_GC_GetGCMemoryInfo,
// token 575,
ves_icall_System_GC_AllocPinnedArray_raw,
// token 581,
ves_icall_System_Object_MemberwiseClone_raw,
// token 589,
ves_icall_System_Math_Ceiling,
// token 590,
ves_icall_System_Math_Cos,
// token 591,
ves_icall_System_Math_Floor,
// token 592,
ves_icall_System_Math_Pow,
// token 593,
ves_icall_System_Math_Sin,
// token 594,
ves_icall_System_Math_Sqrt,
// token 595,
ves_icall_System_Math_Tan,
// token 596,
ves_icall_System_Math_Log2,
// token 597,
ves_icall_System_Math_ModF,
// token 675,
ves_icall_System_MathF_Log2,
// token 676,
ves_icall_System_MathF_ModF,
// token 718,
ves_icall_RuntimeMethodHandle_GetFunctionPointer_raw,
// token 727,
ves_icall_RuntimeMethodHandle_ReboxFromNullable_raw,
// token 728,
ves_icall_RuntimeMethodHandle_ReboxToNullable_raw,
// token 797,
ves_icall_RuntimeType_GetCorrespondingInflatedMethod_raw,
// token 803,
ves_icall_RuntimeType_make_array_type_raw,
// token 806,
ves_icall_RuntimeType_make_byref_type_raw,
// token 808,
ves_icall_RuntimeType_make_pointer_type_raw,
// token 813,
ves_icall_RuntimeType_MakeGenericType_raw,
// token 814,
ves_icall_RuntimeType_GetMethodsByName_native_raw,
// token 816,
ves_icall_RuntimeType_GetPropertiesByName_native_raw,
// token 817,
ves_icall_RuntimeType_GetConstructors_native_raw,
// token 821,
ves_icall_System_RuntimeType_CreateInstanceInternal_raw,
// token 822,
ves_icall_RuntimeType_GetDeclaringMethod_raw,
// token 824,
ves_icall_System_RuntimeType_getFullName_raw,
// token 825,
ves_icall_RuntimeType_GetGenericArgumentsInternal_raw,
// token 828,
ves_icall_RuntimeType_GetGenericParameterPosition,
// token 829,
ves_icall_RuntimeType_GetEvents_native_raw,
// token 830,
ves_icall_RuntimeType_GetFields_native_raw,
// token 833,
ves_icall_RuntimeType_GetInterfaces_raw,
// token 835,
ves_icall_RuntimeType_GetNestedTypes_native_raw,
// token 838,
ves_icall_RuntimeType_GetDeclaringType_raw,
// token 840,
ves_icall_RuntimeType_GetName_raw,
// token 842,
ves_icall_RuntimeType_GetNamespace_raw,
// token 851,
ves_icall_RuntimeType_FunctionPointerReturnAndParameterTypes_raw,
// token 915,
ves_icall_RuntimeTypeHandle_GetAttributes,
// token 917,
ves_icall_RuntimeTypeHandle_GetMetadataToken_raw,
// token 919,
ves_icall_RuntimeTypeHandle_GetGenericTypeDefinition_impl_raw,
// token 929,
ves_icall_RuntimeTypeHandle_GetCorElementType,
// token 930,
ves_icall_RuntimeTypeHandle_HasInstantiation,
// token 931,
ves_icall_RuntimeTypeHandle_IsInstanceOfType_raw,
// token 933,
ves_icall_RuntimeTypeHandle_HasReferences_raw,
// token 939,
ves_icall_RuntimeTypeHandle_GetArrayRank_raw,
// token 940,
ves_icall_RuntimeTypeHandle_GetAssembly_raw,
// token 941,
ves_icall_RuntimeTypeHandle_GetElementType_raw,
// token 942,
ves_icall_RuntimeTypeHandle_GetModule_raw,
// token 943,
ves_icall_RuntimeTypeHandle_GetBaseType_raw,
// token 951,
ves_icall_RuntimeTypeHandle_type_is_assignable_from_raw,
// token 952,
ves_icall_RuntimeTypeHandle_IsGenericTypeDefinition,
// token 953,
ves_icall_RuntimeTypeHandle_GetGenericParameterInfo_raw,
// token 957,
ves_icall_RuntimeTypeHandle_is_subclass_of_raw,
// token 958,
ves_icall_RuntimeTypeHandle_IsByRefLike_raw,
// token 960,
ves_icall_System_RuntimeTypeHandle_internal_from_name_raw,
// token 964,
ves_icall_System_String_FastAllocateString_raw,
// token 965,
ves_icall_System_String_InternalIsInterned_raw,
// token 966,
ves_icall_System_String_InternalIntern_raw,
// token 1258,
ves_icall_System_Type_internal_from_handle_raw,
// token 1418,
ves_icall_System_ValueType_InternalGetHashCode_raw,
// token 1419,
ves_icall_System_ValueType_Equals_raw,
// token 8667,
ves_icall_System_Threading_Interlocked_CompareExchange_Int,
// token 8668,
ves_icall_System_Threading_Interlocked_CompareExchange_Object,
// token 8670,
ves_icall_System_Threading_Interlocked_Decrement_Int,
// token 8671,
ves_icall_System_Threading_Interlocked_Increment_Int,
// token 8672,
ves_icall_System_Threading_Interlocked_Increment_Long,
// token 8673,
ves_icall_System_Threading_Interlocked_Exchange_Int,
// token 8674,
ves_icall_System_Threading_Interlocked_Exchange_Object,
// token 8676,
ves_icall_System_Threading_Interlocked_CompareExchange_Long,
// token 8677,
ves_icall_System_Threading_Interlocked_Exchange_Long,
// token 8678,
ves_icall_System_Threading_Interlocked_Add_Int,
// token 8695,
ves_icall_System_Threading_Monitor_Monitor_Enter_raw,
// token 8697,
mono_monitor_exit_icall_raw,
// token 8704,
ves_icall_System_Threading_Monitor_Monitor_pulse_raw,
// token 8706,
ves_icall_System_Threading_Monitor_Monitor_pulse_all_raw,
// token 8708,
ves_icall_System_Threading_Monitor_Monitor_wait_raw,
// token 8710,
ves_icall_System_Threading_Monitor_Monitor_try_enter_with_atomic_var_raw,
// token 8713,
ves_icall_System_Threading_Monitor_Monitor_get_lock_contention_count,
// token 8763,
ves_icall_System_Threading_Thread_InitInternal_raw,
// token 8764,
ves_icall_System_Threading_Thread_GetCurrentThread,
// token 8766,
ves_icall_System_Threading_InternalThread_Thread_free_internal_raw,
// token 8767,
ves_icall_System_Threading_Thread_GetState_raw,
// token 8768,
ves_icall_System_Threading_Thread_SetState_raw,
// token 8769,
ves_icall_System_Threading_Thread_ClrState_raw,
// token 8770,
ves_icall_System_Threading_Thread_SetName_icall_raw,
// token 8772,
ves_icall_System_Threading_Thread_YieldInternal,
// token 8774,
ves_icall_System_Threading_Thread_SetPriority_raw,
// token 9790,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_PrepareForAssemblyLoadContextRelease_raw,
// token 9794,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_GetLoadContextForAssembly_raw,
// token 9796,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFile_raw,
// token 9797,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalInitializeNativeALC_raw,
// token 9798,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFromStream_raw,
// token 9799,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalGetLoadedAssemblies_raw,
// token 10218,
ves_icall_System_GCHandle_InternalAlloc_raw,
// token 10219,
ves_icall_System_GCHandle_InternalFree_raw,
// token 10220,
ves_icall_System_GCHandle_InternalGet_raw,
// token 10221,
ves_icall_System_GCHandle_InternalSet_raw,
// token 10239,
ves_icall_System_Runtime_InteropServices_Marshal_GetLastPInvokeError,
// token 10240,
ves_icall_System_Runtime_InteropServices_Marshal_SetLastPInvokeError,
// token 10241,
ves_icall_System_Runtime_InteropServices_Marshal_StructureToPtr_raw,
// token 10285,
ves_icall_System_Runtime_InteropServices_NativeLibrary_LoadByName_raw,
// token 10350,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalGetHashCode_raw,
// token 10353,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetObjectValue_raw,
// token 10361,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetUninitializedObjectInternal_raw,
// token 10362,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InitializeArray_raw,
// token 10363,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetSpanDataFrom_raw,
// token 10364,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_SufficientExecutionStack,
// token 10365,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalBox_raw,
// token 10642,
ves_icall_System_Reflection_Assembly_GetEntryAssembly_raw,
// token 10646,
ves_icall_System_Reflection_Assembly_InternalLoad_raw,
// token 10647,
ves_icall_System_Reflection_Assembly_InternalGetType_raw,
// token 10674,
ves_icall_System_Reflection_AssemblyName_GetNativeName,
// token 10708,
ves_icall_MonoCustomAttrs_GetCustomAttributesInternal_raw,
// token 10715,
ves_icall_MonoCustomAttrs_GetCustomAttributesDataInternal_raw,
// token 10722,
ves_icall_MonoCustomAttrs_IsDefinedInternal_raw,
// token 10733,
ves_icall_System_Reflection_FieldInfo_internal_from_handle_type_raw,
// token 10737,
ves_icall_System_Reflection_FieldInfo_get_marshal_info_raw,
// token 10760,
ves_icall_System_Reflection_LoaderAllocatorScout_Destroy,
// token 10838,
ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceNames_raw,
// token 10840,
ves_icall_System_Reflection_RuntimeAssembly_GetExportedTypes_raw,
// token 10849,
ves_icall_System_Reflection_RuntimeAssembly_GetInfo_raw,
// token 10851,
ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceInternal_raw,
// token 10852,
ves_icall_System_Reflection_Assembly_GetManifestModuleInternal_raw,
// token 10859,
ves_icall_System_Reflection_RuntimeCustomAttributeData_ResolveArgumentsInternal_raw,
// token 10874,
ves_icall_RuntimeEventInfo_get_event_info_raw,
// token 10894,
ves_icall_reflection_get_token_raw,
// token 10895,
ves_icall_System_Reflection_EventInfo_internal_from_handle_type_raw,
// token 10903,
ves_icall_RuntimeFieldInfo_ResolveType_raw,
// token 10905,
ves_icall_RuntimeFieldInfo_GetParentType_raw,
// token 10912,
ves_icall_RuntimeFieldInfo_GetFieldOffset_raw,
// token 10913,
ves_icall_RuntimeFieldInfo_GetValueInternal_raw,
// token 10916,
ves_icall_RuntimeFieldInfo_SetValueInternal_raw,
// token 10918,
ves_icall_RuntimeFieldInfo_GetRawConstantValue_raw,
// token 10923,
ves_icall_reflection_get_token_raw,
// token 10929,
ves_icall_get_method_info_raw,
// token 10930,
ves_icall_get_method_attributes,
// token 10937,
ves_icall_System_Reflection_MonoMethodInfo_get_parameter_info_raw,
// token 10939,
ves_icall_System_MonoMethodInfo_get_retval_marshal_raw,
// token 10951,
ves_icall_System_Reflection_RuntimeMethodInfo_GetMethodFromHandleInternalType_native_raw,
// token 10954,
ves_icall_RuntimeMethodInfo_get_name_raw,
// token 10955,
ves_icall_RuntimeMethodInfo_get_base_method_raw,
// token 10956,
ves_icall_reflection_get_token_raw,
// token 10967,
ves_icall_InternalInvoke_raw,
// token 10977,
ves_icall_RuntimeMethodInfo_GetPInvoke_raw,
// token 10983,
ves_icall_RuntimeMethodInfo_MakeGenericMethod_impl_raw,
// token 10984,
ves_icall_RuntimeMethodInfo_GetGenericArguments_raw,
// token 10985,
ves_icall_RuntimeMethodInfo_GetGenericMethodDefinition_raw,
// token 10987,
ves_icall_RuntimeMethodInfo_get_IsGenericMethodDefinition_raw,
// token 10988,
ves_icall_RuntimeMethodInfo_get_IsGenericMethod_raw,
// token 11005,
ves_icall_InvokeClassConstructor_raw,
// token 11007,
ves_icall_InternalInvoke_raw,
// token 11022,
ves_icall_reflection_get_token_raw,
// token 11040,
ves_icall_System_Reflection_RuntimeModule_ResolveMethodToken_raw,
// token 11067,
ves_icall_RuntimePropertyInfo_get_property_info_raw,
// token 11097,
ves_icall_reflection_get_token_raw,
// token 11098,
ves_icall_System_Reflection_RuntimePropertyInfo_internal_from_handle_type_raw,
// token 11582,
ves_icall_DynamicMethod_create_dynamic_method_raw,
// token 11666,
ves_icall_AssemblyBuilder_basic_init_raw,
// token 11667,
ves_icall_AssemblyBuilder_UpdateNativeCustomAttributes_raw,
// token 11851,
ves_icall_ModuleBuilder_basic_init_raw,
// token 11852,
ves_icall_ModuleBuilder_set_wrappers_type_raw,
// token 11856,
ves_icall_ModuleBuilder_getUSIndex_raw,
// token 11857,
ves_icall_ModuleBuilder_getToken_raw,
// token 11858,
ves_icall_ModuleBuilder_getMethodToken_raw,
// token 11863,
ves_icall_ModuleBuilder_RegisterToken_raw,
// token 11914,
ves_icall_TypeBuilder_create_runtime_class_raw,
// token 12313,
ves_icall_System_IO_Stream_HasOverriddenBeginEndRead_raw,
// token 12314,
ves_icall_System_IO_Stream_HasOverriddenBeginEndWrite_raw,
// token 12510,
ves_icall_System_Diagnostics_Debugger_IsAttached_internal,
// token 12515,
ves_icall_System_Diagnostics_StackFrame_GetFrameInfo,
// token 12525,
ves_icall_System_Diagnostics_StackTrace_GetTrace,
// token 13361,
ves_icall_Mono_RuntimeClassHandle_GetTypeFromClass,
// token 13382,
ves_icall_Mono_RuntimeGPtrArrayHandle_GPtrArrayFree,
// token 13384,
ves_icall_Mono_SafeStringMarshal_StringToUtf8,
// token 13386,
ves_icall_Mono_SafeStringMarshal_GFree,
};
static uint8_t corlib_icall_flags [] = {
0,
0,
0,
0,
0,
4,
4,
0,
4,
0,
4,
4,
4,
0,
0,
0,
4,
4,
4,
4,
0,
4,
0,
0,
0,
4,
0,
0,
4,
4,
4,
4,
4,
0,
4,
4,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
0,
0,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
4,
4,
4,
4,
4,
4,
0,
4,
0,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
0,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
0,
0,
0,
0,
0,
0,
};
