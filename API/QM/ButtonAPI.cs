using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipse.API.QM
{
    public class ButtonAPI
    {
        // This API was created by c1tiz3n. https://github.com/c1tiz3n
        // With help and support from nitro and some others, thanks.
        public const string Identifier = "eclipse";

        public static List<SingleButton> allQMSingleButtons = new();
        public static List<ToggleButton> allQMToggleButtons = new();
        public static List<NestedButton> allQMNestedButtons = new();
        public static List<MenuPage> allQMMenuPages = new();
        public static List<Header> allQMHeaderPages = new();
        public static List<FoldoutHeader> allQMFoldoutHeaderPages = new();
        public static List<ButtonGroup> allQMButtonGroups = new();
        public static List<QMSlider> allQMSliders = new();
        public static List<Tab> allQMTabs = new();
        public static List<InfoMenu> allInfoMenus = new();
        public static List<InfoAction> allInfoActions = new();
        //public static List<Checkbox> allCheckBoxes = new();

    }

    public enum ButtonType
    {
        SingleButton,
        NestedButton,
        ToggleButton,
        SliderContainer,
        Slider,
        Header,
        FoldoutHeader,
        ButtonGroup,
        MenuPage,
        InfoMenu,
        InfoAction,
        Panel,
        Popup,
        Checkbox
    }
}
