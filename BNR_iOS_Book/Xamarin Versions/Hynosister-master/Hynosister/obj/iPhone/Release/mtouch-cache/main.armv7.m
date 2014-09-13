#include "monotouch/main.h"

extern void *mono_aot_module_Hynosister_info;
extern void *mono_aot_module_monotouch_info;
extern void *mono_aot_module_mscorlib_info;

void monotouch_register_modules ()
{
	mono_aot_register_module (mono_aot_module_Hynosister_info);
	mono_aot_register_module (mono_aot_module_monotouch_info);
	mono_aot_register_module (mono_aot_module_mscorlib_info);

}

void monotouch_register_assemblies ()
{
	monotouch_open_and_register ("monotouch.dll");

}

void monotouch_setup ()
{
	use_old_dynamic_registrar = FALSE;
	monotouch_create_classes ();
	monotouch_assembly_name = "Hynosister.exe";
	monotouch_use_new_assemblies = 0;
	mono_use_llvm = FALSE;
	monotouch_log_level = 0;
	monotouch_new_refcount = FALSE;
	monotouch_sgen = FALSE;
}

