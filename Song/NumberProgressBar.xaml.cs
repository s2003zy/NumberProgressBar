using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
// “用户控件”项模板在 http://go.microsoft.com/fwlink/?LinkId=234236 上提供

namespace Song
{
    public sealed partial class NumberProgressBar : UserControl
    {

   
        
        /**
        *    The max progress, default is 100
        */
        #region  Max
        public static readonly DependencyProperty MaxProperty = 
            DependencyProperty.Register ("Max",
                                         typeof(int),
                                         typeof(NumberProgressBar), 
                                         new PropertyMetadata(null, 
                                                              new PropertyChangedCallback(MaxPropertyChangeCallBack)
                                                              )
                                         );
        public static void MaxPropertyChangeCallBack(DependencyObject o,DependencyPropertyChangedEventArgs e)
        {
            NumberProgressBar _numberProgressBar = o as NumberProgressBar;

            if (_numberProgressBar != null)
            {
                _numberProgressBar.Max = Convert.ToInt32(e.NewValue.ToString());
            }
        }

        public int Max
        {
            get { return (int)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }
        #endregion

        /**
        * current progress, can not exceed the max progress.
        */
        #region Progress

        public static readonly DependencyProperty ProgressProperty =
            DependencyProperty.Register("Progress",
                                        typeof(int), 
                                        typeof(NumberProgressBar),
                                        new PropertyMetadata(null,
                                                             new PropertyChangedCallback(ProgressPropertyChangeCallBack)
                                                             )
                                       );

        public static void ProgressPropertyChangeCallBack(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            NumberProgressBar _numberProgressBar = o as NumberProgressBar;

            if (_numberProgressBar != null)
            {
                _numberProgressBar.Progress = Convert.ToInt32(e.NewValue.ToString());
            }
        }

        public int Progress
        {
            get { return (int)GetValue(ProgressProperty); }
            set {
                if (value > Max)
                {
                    value = Max;
                }
                SetValue(ProgressProperty, value);
                ChangeProgress();
              
            }
        }
        #endregion

        /**
        *    the bar unreached area color.
        */
        #region ProgressUnreachedColor

        public static readonly DependencyProperty ProgressUnreachedColorProperty =
            DependencyProperty.Register("ProgressUnreachedColor",
                                        typeof(Brush),
                                        typeof(NumberProgressBar),
                                        new PropertyMetadata(null,
                                                             new PropertyChangedCallback(ProgressUnreachedColorPropertyChangeCallBack)
                                                             )
                                       );

        public static void ProgressUnreachedColorPropertyChangeCallBack(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            NumberProgressBar _numberProgressBar = o as NumberProgressBar;

            if (_numberProgressBar != null)
            {
                _numberProgressBar.ProgressUnreachedColor = (Brush)e.NewValue;
            }
        }

        public Brush ProgressUnreachedColor
        {
            get { return (Brush)GetValue(ProgressUnreachedColorProperty); }
            set 
            {
                SetValue(ProgressUnreachedColorProperty, value);
                this.LayoutUnreachedRect.Fill = ProgressUnreachedColor;
            }
        }
        #endregion


        /**
        *    the progress area bar color
        */

        #region ProgressReachedColor


        public static readonly DependencyProperty ProgressReachedColorProperty =
            DependencyProperty.Register("ProgressReachedColor",
                                        typeof(Brush),
                                        typeof(NumberProgressBar),
                                        new PropertyMetadata(null,
                                                             new PropertyChangedCallback( ProgressReachedColorPropertyChangeCallBack)
                                                             )
                                       );
        public static void ProgressReachedColorPropertyChangeCallBack(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            NumberProgressBar _numberProgressBar = o as NumberProgressBar;

            if (_numberProgressBar != null)
            {
                _numberProgressBar.ProgressReachedColor = (Brush)e.NewValue;
            }
        }

        public Brush ProgressReachedColor
        {
            get { return (Brush)GetValue(ProgressReachedColorProperty); }
            set
            {
                SetValue(ProgressReachedColorProperty, value);
                this.LayoutReachedRect.Fill = ProgressReachedColor;
            }
        }

        #endregion


        /**
        *    the progress text color.
        */
        #region ProgressTextColor

        public static readonly DependencyProperty ProgressTextColorProperty =
            DependencyProperty.Register("ProgressTextColor",
                                        typeof(Brush),
                                        typeof(NumberProgressBar),
                                        new PropertyMetadata(null,
                                                             new PropertyChangedCallback(ProgressTextColorPropertyChangeCallBack)
                                                             )
                                       );
        public static void ProgressTextColorPropertyChangeCallBack(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            NumberProgressBar _numberProgressBar = o as NumberProgressBar;

            if (_numberProgressBar != null)
            {
                _numberProgressBar.ProgressTextColor = (Brush)e.NewValue;
            }
        }

        public Brush ProgressTextColor
        {
            get { return (Brush)GetValue(ProgressTextColorProperty); }
            set
            {
                SetValue(ProgressTextColorProperty, value);
                this.LayoutText.Foreground = ProgressTextColor;
            }
        }
        
        #endregion
        /**
        *    the progress text size
        */
        #region ProgressTextSize
  
        public static readonly DependencyProperty ProgressTextSizeProperty = 
            DependencyProperty.Register("ProgressTextSize",
                                        typeof(double),
                                        typeof(NumberProgressBar),
                                        new PropertyMetadata(null,
                                                             new PropertyChangedCallback(ProgressTextSizePropertyChangeCallBack)
                                                             )
                                       );
        public static void ProgressTextSizePropertyChangeCallBack(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            NumberProgressBar _numberProgressBar = o as NumberProgressBar;

            if (_numberProgressBar != null)
            {
                _numberProgressBar.ProgressTextSize = Convert.ToDouble(e.NewValue.ToString());
            }
        }

        public double ProgressTextSize
        {
            get { return (double)GetValue(ProgressTextSizeProperty); }
            set
            {
                SetValue(ProgressTextSizeProperty, value);
                this.LayoutText.FontSize = ProgressTextSize;
            }
        }
        #endregion

        /**
         * the height of the unreached area
        */
        #region ProgressUnreachedBarHeight

        public static readonly DependencyProperty ProgressUnreachedBarHeightProperty = 
            DependencyProperty.Register("ProgressUnreachedBarHeight",
                                        typeof(double), 
                                        typeof(NumberProgressBar),
                                        new PropertyMetadata(null, 
                                                             new PropertyChangedCallback(ProgressUnreachedBarHeightPropertyChangeCallBack)
                                                             )
                                       );
        public static void ProgressUnreachedBarHeightPropertyChangeCallBack(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            NumberProgressBar _numberProgressBar = o as NumberProgressBar;

            if (_numberProgressBar != null)
            {
                _numberProgressBar.ProgressUnreachedBarHeight = Convert.ToDouble(e.NewValue.ToString());
            }
        }

        public double ProgressUnreachedBarHeight
        {
            get { return (double)GetValue(ProgressUnreachedBarHeightProperty); }
            set
            {
                SetValue(ProgressUnreachedBarHeightProperty, value);
                this.LayoutUnreachedRect.Height = ProgressUnreachedBarHeight;
            }
        }
        #endregion

        /**
         * the height of the reached area
        */
        #region ProgressReachedBarHeight
        public static readonly DependencyProperty ProgressReachedBarHeightProperty =
            DependencyProperty.Register("ProgressReachedBarHeight",
                                         typeof(double),
                                         typeof(NumberProgressBar),
                                         new PropertyMetadata(null, 
                                                              new PropertyChangedCallback(ProgressReachedBarHeightPropertyChangeCallBack)
                                                              )
                                       );
        public static void ProgressReachedBarHeightPropertyChangeCallBack(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            NumberProgressBar _numberProgressBar = o as NumberProgressBar;

            if (_numberProgressBar != null)
            {
                _numberProgressBar.ProgressReachedBarHeight = Convert.ToDouble(e.NewValue.ToString());
            }
        }

        public double ProgressReachedBarHeight
        {
            get { return (double)GetValue(ProgressReachedBarHeightProperty); }
            set
            {
                SetValue(ProgressReachedBarHeightProperty, value);
                this.LayoutReachedRect.Height = ProgressReachedBarHeight;
            }
        }
        #endregion




        /* 
         * the preset style of the NumberProgressBar
         */
        #region ProgressBarStyle
        public static readonly DependencyProperty ProgressBarStyleProperty = 
            DependencyProperty.Register("ProgressBarStyle",
                                        typeof(string), 
                                        typeof(NumberProgressBar),
                                        new PropertyMetadata(null, 
                                                             new PropertyChangedCallback(ProgressBarStylePropertyChangeCallBack)
                                                             )
                                        );
        public static void ProgressBarStylePropertyChangeCallBack(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            NumberProgressBar _numberProgressBar = o as NumberProgressBar;

            if (_numberProgressBar != null)
            {
                _numberProgressBar.ProgressBarStyle = e.NewValue.ToString();
            }
        }

        public string ProgressBarStyle
        {
            get
            {
                string tmp = (string)GetValue(ProgressBarStyleProperty);

                if (tmp != null && tmp != " ") { return (string)GetValue(ProgressBarStyleProperty); }

                return "NumberProgressBar_Passing_Green";
            }
            set{ SetValue(ProgressBarStyleProperty, value); }
        }
        #endregion


        /*
         * the width of the NumberProgressBar`s layout
         */

        #region LayoutWidth
        public static readonly DependencyProperty LayoutWidthProperty =
          DependencyProperty.Register("LayoutWidth",
                                      typeof(double),
                                      typeof(NumberProgressBar),
                                      new PropertyMetadata(null,
                                                           new PropertyChangedCallback(LayoutWidthPropertyChangeCallBack)
                                                           )
                                      );
        public static void LayoutWidthPropertyChangeCallBack(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            NumberProgressBar _numberProgressBar = o as NumberProgressBar;

            if (_numberProgressBar != null)
            {
                _numberProgressBar.LayoutWidth = Convert.ToDouble(e.NewValue.ToString());
            }
        }

        public double LayoutWidth
        {
            get { return (double)GetValue(LayoutWidthProperty); }//LayoutRoot.Width; }
            set 
            {
                SetValue(LayoutWidthProperty, value);
                LayoutRoot.Width = value;
            }
        }
        #endregion


        /*
         * the hight of the NumberProgressBar`s layout
         */
        #region LayoutHeight
        public static readonly DependencyProperty LayoutHeightProperty =
        DependencyProperty.Register("LayoutHeight",
                                    typeof(double),
                                    typeof(NumberProgressBar),
                                    new PropertyMetadata(null,
                                                         new PropertyChangedCallback(LayoutHeightPropertyChangeCallBack)
                                                         )
                                    );
        public static void LayoutHeightPropertyChangeCallBack(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            NumberProgressBar _numberProgressBar = o as NumberProgressBar;

            if (_numberProgressBar != null)
            {
                _numberProgressBar.LayoutHeight = Convert.ToDouble(e.NewValue.ToString());
            }
        }
        public double LayoutHeight
        {
            get { return (double)GetValue(LayoutHeightProperty); }
            set 
            {
                SetValue(LayoutHeightProperty, value);
                LayoutRoot.Height = value; 
            }
        }
        #endregion

        public NumberProgressBar()
        {
            this.InitializeComponent();
            InitProperty();

        }
        public void InitProperty()
        {
            this.LayoutWidth = 300;
            this.LayoutHeight = 10;
            Max = 100;
        } 


        /// <summary>
        /// Update The NumberProgressBar( the Text,the ReachedBar width and the UnreachedBar width )
        /// </summary>
        private void ChangeProgress()
        {
            this.LayoutText.Text = this.Progress.ToString() + "%";

            this.LayoutText.UpdateLayout();

            this.LayoutUnreachedRect.Width = this.GetUnreachedBarLength();

            this.LayoutReachedRect.Width = this.GetReachedBarLength();

        }

        /// <summary>
        /// Get the total of the NumberProgressBar length,including the ReachedBar, the Text, and The UnreachedBar.
        /// </summary>
        /// <returns>totalBar length</returns>
        private double GetTotalBarLength()
        {
            double _length = LayoutRoot.Width - LayoutRoot.Margin.Left - LayoutRoot.Margin.Right;

            return _length;
        }


        /// <summary>
        /// Get the ReachedBar length.
        /// </summary>
        /// <returns>ReachedBar length</returns>
        private double GetReachedBarLength()
        {
            double _unreachedBarLength =  this.GetUnreachedBarLength();
         
            double _totalBarLength = this.GetTotalBarLength();
            
            double _reachedBarLength;
            
            if (_unreachedBarLength > 0)
            {
                _reachedBarLength = (this.Progress / (double)this.Max) * _totalBarLength;
            }
            else
            {
                _reachedBarLength = _totalBarLength - LayoutText.ActualWidth;
            }
            
            if (_reachedBarLength < 0)
                return 0;

            return _reachedBarLength;
        }

        /// <summary>
        /// Get the UnreachedBar length
        /// </summary>
        /// <returns>UnreachedBar length</returns>
        private double GetUnreachedBarLength()
        {

            double _totalBarLength = this.GetTotalBarLength();

            double _unreachedBarLength = (1.0 - (this.Progress / (double)this.Max)) * _totalBarLength - LayoutText.ActualWidth;
           
            if (_unreachedBarLength < 0)
                return 0;
            return _unreachedBarLength;
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.Style == null)
            {
                this.Style = (Style)this.Resources[ProgressBarStyle];
            }
            this.ChangeProgress();
        }

    }
}
