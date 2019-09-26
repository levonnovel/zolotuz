using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zolotuz.Models
{
    public class ProductFilter
    {
        public byte Id { get; set; }

        public List<byte> manufacturer;

        public List<byte> color_palette;

        public List<byte> appearance;

        public List<byte> washable;

        public List<byte> smell;

        public List<byte> color;

        public List<byte> room_type;

        public List<byte> appointment;

        public List<byte> type;

        public List<byte> stencil_theme;

        public List<byte> place_of_use;

        public List<byte> created_for;

        public List<byte> finish_guarantee;

        public List<byte> effect;

        public List<byte> volume;

        public List<byte> duration_of_protection;

        public List<byte> surface_of_application;

        public List<byte> type_of_use;

        public List<byte> brush_type;

        public List<byte> width;

        public List<byte> fiber_material;

        public List<byte> structure;

        public List<byte> resistant;

        public List<byte> gluing_strength;

        public List<byte> capture_time;

        public List<byte> gluing_material;

        public List<byte> frost_resistance;

        public List<byte> heat_resistance;

        public List<byte> color_after_drying;

        public List<byte> external_material;

        public List<byte> application_type;

        public List<byte> paint_type;
        
        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        public int? Start { get; set; }

        public int? End { get; set; }
    }
}
