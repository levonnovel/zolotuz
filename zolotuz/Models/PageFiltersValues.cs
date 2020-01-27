using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zolotuz.Models
{
    public class PageFiltersValues
    {
        public byte product_group { get; set; }
        public byte? product_type { get; set; }
        public byte? product_subType { get; set; }

        public List<byte> cat_manufacturer { get; set; }
        public List<byte> cat_color_palette { get; set; }
        public List<byte> cat_appearance { get; set; }
        public List<byte> cat_washable { get; set; }
        public List<byte> cat_smell { get; set; }
        public List<byte> cat_color { get; set; }
        public List<byte> cat_room_type { get; set; }
        public List<byte> cat_appointment { get; set; }
        public List<byte> cat_type { get; set; }
        public List<byte> cat_stencil_theme { get; set; }
        public List<byte> cat_place_of_use { get; set; }
        public List<byte> cat_created_for { get; set; }
        public List<byte> cat_finish_guarantee { get; set; }
        public List<byte> cat_effect { get; set; }
        public List<byte> cat_volume { get; set; }
        public List<byte> cat_duration_of_protection { get; set; }
        public List<byte> cat_surface_of_application { get; set; }
        public List<byte> cat_type_of_use { get; set; }
        public List<byte> cat_brush_type { get; set; }
        public List<byte> cat_width { get; set; }
        public List<byte> cat_fiber_material { get; set; }
        public List<byte> cat_structure { get; set; }
        public List<byte> cat_resistant { get; set; }
        public List<byte> cat_gluing_strength { get; set; }
        public List<byte> cat_capture_time { get; set; }
        public List<byte> cat_gluing_material { get; set; }
        public List<byte> cat_frost_resistance { get; set; }
        public List<byte> cat_heat_resistance { get; set; }
        public List<byte> cat_color_after_drying { get; set; }
        public List<byte> cat_external_material { get; set; }
        public List<byte> cat_application_type { get; set; }
        public List<byte> cat_consumption { get; set; }
        public List<byte> cat_application_temperature { get; set; }
    }
}
