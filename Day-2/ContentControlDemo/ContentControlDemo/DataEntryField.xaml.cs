using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContentControlDemo
{
    /// <summary>
    /// Interaction logic for DataEntryField.xaml
    /// </summary>
    public partial class DataEntryField : UserControl
    {
        public DataEntryField()
        {
            InitializeComponent();
        }

        

        public static readonly DependencyProperty FieldCaptionProperty =
            DependencyProperty.Register("FieldCaption", typeof (string), typeof (DataEntryField), new PropertyMetadata(default(string), FieldCaptionPropertyChanged));

        private static void FieldCaptionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var def = (DataEntryField) d;
            def.LblFieldName.Content = e.NewValue;
        }

        public string FieldCaption
        {
            get { return (string) GetValue(FieldCaptionProperty); }
            set
            {
                //LblFieldName.Content = value;
                SetValue(FieldCaptionProperty, value);
            }
        }

        public static readonly DependencyProperty FieldValueProperty =
            DependencyProperty.Register("FieldValue", typeof (string), typeof (DataEntryField), new PropertyMetadata(default(string), (
                o, args) =>
                {
                    var def = (DataEntryField) o;
                    def.TxtFieldValue.Text = args.NewValue.ToString();
                }));

        private string _normalValue;

        public string FieldValue
        {
            get { return (string) GetValue(FieldValueProperty); }
            set
            {
                //TxtFieldValue.Text = value;
                SetValue(FieldValueProperty, value);
            }
        }

        //CLR Property
        public string NormalValue
        {
            get
            {
                return _normalValue;
            }
            set
            {
                _normalValue = value;
                this.TbNormalValue.Text = value;
            }
        }
    }
}
