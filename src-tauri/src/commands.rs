#![allow(dead_code,)]
#![allow(non_camel_case_types,)]
#![allow(non_snake_case,)]
#![allow(non_upper_case_globals,)]
#![allow(unreachable_code,)]
#![allow(unused_attributes,)]
#![allow(unused_imports,)]
#![allow(unused_macros,)]
#![allow(unused_parens,)]
#![allow(unused_variables,)]
mod module_59e06e32 {
    pub mod Commands {
        use super::*;
        use fable_library_rust::String_::sprintf;
        #[tauri::command]
        pub fn greet(name: &str) -> String {
            sprintf!("Hello, {}! You\'ve been greeted from Rust!",
                     name).as_ref().to_string()
        }
    }
}
pub use module_59e06e32::*;
