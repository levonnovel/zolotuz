using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zolotuz.Models
{
    public class Product
    {
        public int Id { get; set; }

        //public byte? manufacturer;
        //
        //public byte? color_palette;
        //
        //public byte? appearance;
        //
        //public byte? washable;
        //
        //public byte? smell;
        //
        //public byte? color;
        //
        //public byte? room_type;
        //
        //public byte? appointment;
        //
        //public byte? type;
        //
        //public byte? stencil_theme;
        //
        //public byte? place_of_use;
        //
        //public byte? created_for;
        //
        //public byte? finish_guarantee;
        //
        //public byte? effect;
        //
        //public byte? volume;
        //
        //public byte? duration_of_protection;
        //
        //public byte? surface_of_application;
        //
        //public byte? type_of_use;
        //
        //public byte? brush_type;
        //
        //public byte? width;
        //
        //public byte? fiber_material;
        //
        //public byte? structure;
        //
        //public byte? resistant;
        //
        //public byte? gluing_strength;
        //
        //public byte? capture_time;
        //
        //public byte? gluing_material;
        //
        //public byte? frost_resistance;
        //
        //public byte? heat_resistance;
        //
        //public byte? color_after_drying;
        //
        //public byte? external_material;
        //
        //public byte? application_type;

        public byte product_group_name { get; set; }
        public string product_type_name { get; set; }
        public string product_subType_name { get; set; }

        public string manufacturer_name;

        public string color_palette_name;

        public string appearance_name;

        public string washable_name;

        public string smell_name;

        public string color_name;

        public string room_type_name;

        public string appointment_name;

        public string type_name;

        public string stencil_theme_name;

        public string place_of_use_name;

        public string created_for_name;

        public string finish_guarantee_name;

        public string effect_name;

        public string volume_name;

        public string duration_of_protection_name;

        public string surface_of_application_name;

        public string type_of_use_name;

        public string brush_type_name;

        public string width_name;

        public string fiber_material_name;

        public string structure_name;

        public string resistant_name;

        public string gluing_strength_name;

        public string capture_time_name;

        public string gluing_material_name;

        public string frost_resistance_name;

        public string heat_resistance_name;

        public string color_after_drying_name;

        public string external_material_name;

        public string application_type_name;
    }
}
