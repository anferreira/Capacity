using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.ComponentModel;

namespace HotListReports.Windows.Util{

    public enum DisplayMode{
        HH_MM_SS,
        HH_MM,
        HH
    }

    

    /// <summary>
    /// Time Picker as a control that lets the user select a specific time
    /// </summary>
    //[TemplatePart(Name = "PART_Hours", Type=typeof(TextBox)),
    //TemplatePart(Name = "PART_Minutes", Type=typeof(TextBox)),
    //TemplatePart(Name = "PART_Seconds", Type=typeof(TextBox)),
    //TemplatePart(Name = "PART_IncreaseTime", Type=typeof(ButtonBase)),
    //TemplatePart(Name = "PART_DecrementTime", Type=typeof(ButtonBase))]
    public class TimePickerAux : Control
    {

        #region Constants
        public const double BIG = 120;
        public const double MEDIUM = 80;
        public const double SMALL = 50;
        #endregion Constants

        int HourMaxValue = 23;
        int MinuteMaxValue = 59;
        int SecondMaxValue = 59;
        int HourMinValue = 0;
        int MinuteMinValue = 0;
        int SecondMinValue = 0;        
        private DisplayMode _displayFormat = DisplayMode.HH_MM;
        private bool _startingControl = true;

        
        //data memebers to store the textboxes for hours, minutes and seconds
        TextBox hours, minutes, seconds;
        
        //the textbox that is selected
        TextBox currentlySelectedTextBox;
        
        #region Properties

        #region Displayed Format (Added Code)
        /// <summary>
        /// Gets or sets the format that the time will be displayed
        /// </summary>
        [Category("Domain"),
        Description("Gets or sets the format that the time will be displayed"),
        DefaultValue(DisplayMode.HH_MM)]
        public DisplayMode DisplayFormat
        {
            get { 
                return _displayFormat; }
            set { 
                _displayFormat =  value; 
                  reLoadFormat();
            }
        }
    
        //Setting the visibility of the textbox and the size of the control depending of the format that
        //I want to displayed it
        private void reLoadFormat(){
            switch (_displayFormat){
                case DisplayMode.HH_MM_SS: TotalWidth = BIG; SecondVisibility = true;MinuteVisibility = true;
                    break;
                case DisplayMode.HH_MM: TotalWidth = MEDIUM;SecondVisibility = false;MinuteVisibility = true;
                    break;
                case DisplayMode.HH: TotalWidth = SMALL;SecondVisibility = false;MinuteVisibility = false;
                    break;
            }            
        }

        // This is to change the control template size, setting it bigger or smaller depending of the Format 
        // that I want to displayed it
        internal double TotalWidth
        {
            get { return (double)GetValue(TotalWidthProperty); }
            set { 
                SetValue(TotalWidthProperty, value);}
        }
        // This is to change the control template size, setting it bigger or smaller depending of the Format 
        // that I want to displayed it
        internal static readonly DependencyProperty TotalWidthProperty =
            DependencyProperty.Register("TotalWidth", typeof(double),
            typeof(TimePickerAux), new UIPropertyMetadata((double)MEDIUM));

        // Collapse the SecondTextBox when its needed (I mind this is to set its Visibility)
        internal bool SecondVisibility
        {
            get { return (bool)GetValue(SecondVisibilityProperty); }
            set { SetValue(SecondVisibilityProperty, value); }
        }
        // Collapse the SecondTextBox when its needed (I mind this is to set its Visibility)
        internal static readonly DependencyProperty SecondVisibilityProperty =
            DependencyProperty.Register("SecondVisibility", typeof(bool),
            typeof(TimePickerAux));

        // Collapse the MinuteTextBox when its needed (I mind this is to set its Visibility)
        internal bool MinuteVisibility
        {
            get { return (bool)GetValue(MinuteVisibilityProperty); }
            set { SetValue(MinuteVisibilityProperty, value); }
        }

        // Collapse the MinuteTextBox when its needed (I mind this is to set its Visibility)
        internal static readonly DependencyProperty MinuteVisibilityProperty =
            DependencyProperty.Register("MinuteVisibility", typeof(bool),
            typeof(TimePickerAux));

        #endregion Displayed Format (Added Code)

        /// <summary>
        /// Gets or sets the selected timestamp 
        /// </summary>
        public DateTime Value
        {
            get { 
                return (DateTime)GetValue(ValueProperty); }
            set { 
                SetValue(ValueProperty, value); }
        }

        /// <summary>
        /// Backing store for the selected timestamp 
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(DateTime),
            typeof(TimePickerAux), new FrameworkPropertyMetadata(new DateTime(1901, 1, 1, 0, 0, 0), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.AffectsRender, ValuePropertyChanged, ForceValidValue));

               

        //make sure tha the proper time is set
        private static object ForceValidValue(DependencyObject sender, object value)
        {
            TimePickerAux picker = (TimePickerAux)sender;
            DateTime time = (DateTime)value;
            if (picker.MinTime.Hours>=0 && picker.MinTime.Minutes>=0 && picker.MinTime.Seconds>=0){
                DateTime minTime = new DateTime(time.Year,time.Month,time.Day,picker.MinTime.Hours, picker.MinTime.Minutes, picker.MinTime.Seconds);
                DateTime maxTime = new DateTime(time.Year,time.Month,time.Day, picker.MaxTime.Hours, picker.MaxTime.Minutes, picker.MaxTime.Seconds);
                if (time < minTime)
                    return minTime;
                if (time > maxTime)
                    return maxTime;
            }
            return time;
        }

        private static void ValuePropertyChanged(DependencyObject sender, 
            DependencyPropertyChangedEventArgs e)
        {
           TimePickerAux timePicker = (TimePickerAux)sender;
            DateTime newTime = (DateTime)e.NewValue;
            DateTime oldTime = (DateTime)e.OldValue;

            if (!timePicker.isUpdatingTime)
            {
                timePicker.BeginUpdateSelectedTime();//signal that the selected time is being updated

                if (timePicker.SelectedHour != newTime.Hour)
                    timePicker.SelectedHour = newTime.Hour;

                if (timePicker.SelectedMinute != newTime.Minute)
                    timePicker.SelectedMinute = newTime.Minute;

                if (timePicker.SelectedSecond != newTime.Second)
                    timePicker.SelectedSecond = newTime.Second;
                timePicker.SelectedTime = new TimeSpan(newTime.Hour, newTime.Minute, newTime.Second);
                timePicker.EndUpdateSelectedTime();//signal that the selected time has been updated
                
            }
            if (!timePicker._startingControl)
                timePicker.OnValueChanged(timePicker.Value, oldTime);
        }


        /// <summary>
        /// Gets or sets the minimum time that can be selected
        /// </summary>
        public TimeSpan MinTime
        {
            get { return (TimeSpan)GetValue(MinTimeProperty); }
            set { SetValue(MinTimeProperty, value); }
        }

        /// <summary>
        /// Gets or sets the minimum time selected
        /// </summary>
        public static readonly DependencyProperty MinTimeProperty =
            DependencyProperty.Register("MinTime", typeof(TimeSpan), typeof(TimePickerAux), new UIPropertyMetadata(TimeSpan.MinValue,
                delegate(DependencyObject sender, DependencyPropertyChangedEventArgs e)
                {
                    TimePickerAux picker = (TimePickerAux)sender;
                    picker.HourMinValue = picker.MinTime.Hours;
                    picker.MinuteMinValue = picker.MinTime.Minutes;
                    picker.SecondMinValue = picker.MinTime.Seconds;
                    picker.CoerceValue(SelectedTimeProperty);//make sure to update the time if appropiate
                }));

        /// <summary>
        /// Gets or sets the maximum time that can be selected
        /// </summary>
        public TimeSpan MaxTime
        {
            get { return (TimeSpan)GetValue(MaxTimeProperty); }
            set { SetValue(MaxTimeProperty, value); }
        }

        /// <summary>
        /// Gets or sets the maximum time that can be selected
        /// </summary>
        public static readonly DependencyProperty MaxTimeProperty =
            DependencyProperty.Register("MaxTime", typeof(TimeSpan), typeof(TimePickerAux), new UIPropertyMetadata(TimeSpan.MaxValue,
                delegate(DependencyObject sender, DependencyPropertyChangedEventArgs e)
                {
                    TimePickerAux picker = (TimePickerAux)sender;
                    picker.HourMaxValue = picker.MaxTime.Hours;
                    picker.MinuteMaxValue = picker.MaxTime.Minutes;
                    picker.SecondMaxValue = picker.MaxTime.Seconds;
                    picker.CoerceValue(SelectedTimeProperty);//make sure to update the time if appropiate
                }));


        /// <summary>
        /// Gets or sets the selected timestamp 
        /// </summary>
        public TimeSpan SelectedTime
        {
            get { return (TimeSpan)GetValue(SelectedTimeProperty); }
            set { SetValue(SelectedTimeProperty, value); }
        }

        /// <summary>
        /// Backing store for the selected timestamp 
        /// </summary>
        public static readonly DependencyProperty SelectedTimeProperty =
            DependencyProperty.Register("SelectedTime", typeof(TimeSpan),
            typeof(TimePickerAux), new UIPropertyMetadata(new TimeSpan(0, 0, 0), SelectedTimePropertyChanged, 
                ForceValidSelectedTime));

        //make sure tha the proper time is set
        private static object ForceValidSelectedTime(DependencyObject sender, object value)
        {
            TimePickerAux picker = (TimePickerAux)sender;
            TimeSpan time = (TimeSpan)value;
            if (time < picker.MinTime)
                return picker.MinTime;
            if (time > picker.MaxTime)
                return picker.MaxTime;
            return time;
        }

        private static void SelectedTimePropertyChanged(DependencyObject sender, 
            DependencyPropertyChangedEventArgs e)
        {
           TimePickerAux timePicker = (TimePickerAux)sender;
            TimeSpan newTime = (TimeSpan)e.NewValue;
            TimeSpan oldTime = (TimeSpan)e.OldValue;

            if (!timePicker.isUpdatingTime)
            {
                timePicker.BeginUpdateSelectedTime();//signal that the selected time is being updated

                if (timePicker.SelectedHour != newTime.Hours)
                    timePicker.SelectedHour = newTime.Hours;

                if (timePicker.SelectedMinute != newTime.Minutes)
                    timePicker.SelectedMinute = newTime.Minutes;

                if (timePicker.SelectedSecond != newTime.Seconds)
                    timePicker.SelectedSecond = newTime.Seconds;
                timePicker.Value = new DateTime(timePicker.Value.Year, timePicker.Value.Month, timePicker.Value.Day, newTime.Hours, newTime.Minutes, newTime.Seconds);
                
                timePicker.EndUpdateSelectedTime();//signal that the selected time has been updated
                
            }
            if (!timePicker._startingControl)
                timePicker.OnTimeSelectedChanged(timePicker.SelectedTime, oldTime);
        }

        /*Chaks*/
        /// <summary>
        /// Gets or sets the currently selected Time
        /// </summary>
        public string CurrentlySelectedTime
        {
            get { return (string)GetValue(CurrentlySelectedTimeProperty); }
            set { SetValue(CurrentlySelectedTimeProperty, value); }
        }

        /// <summary>
        /// Backing store for the currently selected time
        /// </summary>
        public static readonly DependencyProperty CurrentlySelectedTimeProperty =
            DependencyProperty.Register("CurrentlySelectedTime", typeof(string), typeof(TimePickerAux), 
                new UIPropertyMetadata("0:0:0",
                delegate(DependencyObject sender, DependencyPropertyChangedEventArgs e)
                {
                    TimePickerAux timePicker = (TimePickerAux)sender;

                    //strip hours,minutes and seconds from our string
                    string newValue = e.NewValue as String;

                    if (TimeHelper.ValidateInputTimeString(newValue))
                    {

                        string[] time = newValue.Split(':');

                        int tHour = Convert.ToInt32(time[0]);
                        int tMin = Convert.ToInt32(time[1]);
                        int tSec = Convert.ToInt32(time[2]);

                        //hour
                        int hour = MathUtil.ValidateNumber(tHour,
                            timePicker.HourMinValue, timePicker.HourMaxValue);
                        if (hour != timePicker.SelectedHour)
                            timePicker.SelectedHour = hour;

                        //min
                        int min = MathUtil.ValidateNumber(tMin,
                           timePicker.MinuteMinValue, timePicker.MinuteMaxValue);
                        if (min != timePicker.SelectedMinute)
                            timePicker.SelectedMinute = min;

                        //sec
                        int sec = MathUtil.ValidateNumber(tSec,
                           timePicker.SecondMinValue, timePicker.SecondMaxValue);
                        if (sec != timePicker.SelectedSecond)
                            timePicker.SelectedSecond = sec;

                        //set the new timespan
                        SetNewTime(timePicker);
                    }

                }));        
        /*Chaks*/

        /// <summary>
        /// Gets or sets the selected Hour
        /// </summary>
        public int SelectedHour
        {
            get { return (int)GetValue(SelectedHourProperty); }
            set { SetValue(SelectedHourProperty, value); }
        }

        /// <summary>
        /// Backing store for the selected hour
        /// </summary>
        public static readonly DependencyProperty SelectedHourProperty =
            DependencyProperty.Register("SelectedHour", typeof(int), typeof(TimePickerAux), new UIPropertyMetadata(0,
                delegate(DependencyObject sender, DependencyPropertyChangedEventArgs e) 
                {
                    TimePickerAux timePicker = (TimePickerAux)sender;
                    
                    //validate the hour set
                    int hour = MathUtil.ValidateNumber(timePicker.SelectedHour,
                        timePicker.HourMinValue, timePicker.HourMaxValue);
                    if (hour != timePicker.SelectedHour)
                        timePicker.SelectedHour = hour;

                    //set the new timespan
                    SetNewTime(timePicker); 
                
                }));

        /// <summary>
        /// Gets or sets the selected minutes
        /// </summary>
        public int SelectedMinute
        {
            get { return (int)GetValue(SelectedMinuteProperty); }
            set { SetValue(SelectedMinuteProperty, value); }
        }
        
        /// <summary>
        /// Backing store for the selected minsutes
        /// </summary>
        public static readonly DependencyProperty SelectedMinuteProperty =
            DependencyProperty.Register("SelectedMinute", typeof(int), typeof(TimePickerAux), new UIPropertyMetadata(0,
                delegate(DependencyObject sender, DependencyPropertyChangedEventArgs e) 
                {
                    TimePickerAux timePicker = (TimePickerAux)sender;

                    //validate the minute set
                    int min = MathUtil.ValidateNumber(timePicker.SelectedMinute,
                        timePicker.MinuteMinValue, timePicker.MinuteMaxValue);
                    if (min != timePicker.SelectedMinute)
                        timePicker.SelectedMinute = min;

                    //set the new timespan
                    SetNewTime(timePicker); 

                }));

        /// <summary>
        /// Gets or sets the selected second
        /// </summary>
        public int SelectedSecond
        {
            get { return (int)GetValue(SelectedSecondProperty); }
            set { SetValue(SelectedSecondProperty, value); }
        }

        /// <summary>
        /// Backing store for the selected second
        /// </summary>
        public static readonly DependencyProperty SelectedSecondProperty =
            DependencyProperty.Register("SelectedSecond", typeof(int), typeof(TimePickerAux), new UIPropertyMetadata(0,
                delegate(DependencyObject sender, DependencyPropertyChangedEventArgs e)
                {
                    TimePickerAux timePicker = (TimePickerAux)sender;

                    //validate the minute set
                    int sec = MathUtil.ValidateNumber(timePicker.SelectedSecond,
                        timePicker.SecondMinValue, timePicker.SecondMaxValue);
                    if (sec != timePicker.SelectedSecond)
                        timePicker.SelectedSecond = sec;

                    //set the new timespan
                    SetNewTime(timePicker);

                }));

        #endregion

        #region Events
        
        /// <summary>
        /// 
        /// </summary>
        public static readonly RoutedEvent SelectedTimeChangedEvent = EventManager.RegisterRoutedEvent("SelectedTimeChanged",
            RoutingStrategy.Bubble, typeof(TimeSelectedChangedEventHandler), typeof(TimePickerAux));

        public event TimeSelectedChangedEventHandler SelectedTimeChanged
        {
            add { AddHandler(SelectedTimeChangedEvent, value); }
            remove { RemoveHandler(SelectedTimeChangedEvent, value); }
        }

        /// <summary>
        /// Fires when the Value Changes
        /// </summary>
        public static readonly RoutedEvent ValueChangedEvent = EventManager.RegisterRoutedEvent("ValueChanged",
            RoutingStrategy.Bubble, typeof(ValueChangedEventHandler), typeof(TimePickerAux));

        public event ValueChangedEventHandler ValueChanged
        {
            add { AddHandler(ValueChangedEvent, value); }
            remove { RemoveHandler(ValueChangedEvent, value); }
        }

        #endregion

        #region Constructors / Initalizer
        /// <summary>
        /// Default constructor
        /// </summary>
        public TimePickerAux()
        {
            //SelectedTime = DateTime.Now.TimeOfDay;
            _startingControl = false;
        }

        /// <summary>
        /// Static constructor
        /// </summary>
        static TimePickerAux()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimePickerAux), new FrameworkPropertyMetadata(typeof(TimePickerAux)));
        }

        /// <summary>
        /// override to hook to the Control template elements
        /// </summary>
        public override void OnApplyTemplate()
        {

            //get the hours textbox and hook the events to it
            hours = GetTemplateChild("PART_Hours") as TextBox;
            hours.PreviewTextInput += HoursTextChanged;
            hours.KeyUp += HoursKeyUp;
            hours.GotFocus += TextGotFocus;
            hours.GotMouseCapture += TextGotFocus;
            hours.LostFocus += TextLostFocus;
            
            //get the minutes textbox and hook the events to it
            minutes = GetTemplateChild("PART_Minutes") as TextBox;
            minutes.PreviewTextInput += MinutesTextChanged;
            minutes.KeyUp += MinutesKeyUp;
            minutes.GotFocus += TextGotFocus;
            minutes.GotMouseCapture += TextGotFocus;
            minutes.LostFocus += TextLostFocus;

            //get the seconds textbox and hook the events to it
            seconds = GetTemplateChild("PART_Seconds") as TextBox;
            seconds.PreviewTextInput += SecondsTextChanged;
            seconds.KeyUp += SecondsKeyUp;
            seconds.GotFocus += TextGotFocus;
            seconds.GotMouseCapture += TextGotFocus;
            seconds.LostFocus += TextLostFocus;

            //Get the increase button and hook to the click event
            ButtonBase increaseButton = GetTemplateChild("PART_IncreaseTime") as ButtonBase;
            increaseButton.Click += IncreaseTime;
            //Get the decrease button and hook to the click event
            ButtonBase decrementButton = GetTemplateChild("PART_DecrementTime") as ButtonBase;
            decrementButton.Click += DecrementTime;
            DisplayFormat = _displayFormat;
        }
 
        #endregion Constructors / Initalizer

        //Putting 00 when the TextBox losses the focus
        private void TextLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox selectedBox = (TextBox)sender;
            if (selectedBox.Text.Length==0 || selectedBox.Text.Equals("0"))
                selectedBox.Text="00";
            else if (selectedBox.Text.Length==1)
                selectedBox.Text = "0" + selectedBox.Text;
            
        }

        //Set the focus to the hour TextBox when the control get the focus
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            hours.Focus();
        }
        //event handler for the textboxes (hours, minutes, seconds)
        private void TextGotFocus(object sender, RoutedEventArgs e)
        {
            TextBox selectedBox = (TextBox)sender;
            //set the currently selected textbox. 
            //This field is used to check which entity(hour/minute/second) to increment/decrement when user clicks the buttuns
            currentlySelectedTextBox = selectedBox;
            
            //highlight all code so that it is easier to the user to enter new info in the text box
            selectedBox.SelectAll();
        }

        #region preview input handler
        //handle the preview event so that we validate the text before it is set in the textbox's text

        //event handler for the Hour TextBox
        private void HoursTextChanged(object sender, TextCompositionEventArgs e)
        {
            //delete the text that is highlight(selected)
            TrimSelectedText(hours);

            //Adjust the text according to the carrot index
            string newText = AdjustText(hours, e.Text);
            
            //validates that the hour is correct if not set a valid value (0 or 24)
            int hourNum = ValidateAndSetHour(newText);
            int result;
            //moves the carrot index or focus the neighbour
            AdjustCarretIndexOrMoveToNeighbour(hours, minutes);
            int caretIndex = hours.CaretIndex;
            int textLength = hours.Text.Length;
            if (int.TryParse(newText, out result) && (result<24) && (result>=0)){
                hours.Text = newText;
                if (!(textLength==0 && hours.Text.Length>textLength)){
                    hours.CaretIndex = hours.Text.Length;
                    if (hours.CaretIndex==2 && (_displayFormat== DisplayMode.HH_MM || _displayFormat== DisplayMode.HH_MM_SS))
                        minutes.Focus();
                }else
                    hours.CaretIndex = 1;

            }
            //handle the event so that it does not set the text, since we do it manually
            e.Handled = true;
        }
        
        //event handler for the Minute TextBox
        private void MinutesTextChanged(object sender, TextCompositionEventArgs e)
        {
            //delete the text that is highlight(selected)
            TrimSelectedText(minutes);

            //Adjust the text according to the carrot index
            string newText = AdjustText(minutes, e.Text);

            //validates that the minute is correct if not set a valid value (0 or 59)
            int minNum = ValidateAndSetMinute(newText);
            int result;
            //moves the carrot index or focus the neighbour
            AdjustCarretIndexOrMoveToNeighbour(minutes, seconds);
            int caretIndex = minutes.CaretIndex;
            int textLength = minutes.Text.Length;
            if (int.TryParse(newText, out result) && (result<60) && (result>=0)){
                minutes.Text = newText;
                if (!(textLength==0 && minutes.Text.Length>textLength)){
                    minutes.CaretIndex = minutes.Text.Length;
                    if (minutes.CaretIndex==2 && _displayFormat == DisplayMode.HH_MM_SS)
                        seconds.Focus();
                }else
                    minutes.CaretIndex = 1;
            }
            //handle the event so that it does not set the text, since we do it manually
            e.Handled = true;
        }

        //event handler for the Second TextBox
        private void SecondsTextChanged(object sender, TextCompositionEventArgs e)
        {
            //delete the text that is highlight(selected)
            TrimSelectedText(seconds);

            //Adjust the text according to the carrot index
            string newText = AdjustText(seconds, e.Text);

            //validates that the second is correct if not set a valid value (0 or 59)
            int secNum = ValidateAndSetSeconds(newText);
            
            //moves the carrot index or focus the neighbour
            AdjustCarretIndexOrMoveToNeighbour(seconds, null);
            int caretIndex = seconds.CaretIndex;
            int textLength = seconds.Text.Length;
            int result;
            if (int.TryParse(newText, out result) && (result<60) && (result>=0)){
                seconds.Text = newText;
                if (!(textLength==0 && seconds.Text.Length>textLength)){
                    seconds.CaretIndex = caretIndex;
                }else
                    seconds.CaretIndex = 1;
            }
            //handle the event so that it does not set the text, since we do it manually
            e.Handled = true;
        }

        #endregion

        #region key up handlers

        //increments/decrement the selected time accordingly to the selected control
        private bool IncrementDecrementTime(Key selectedKey)
        {
            if (selectedKey == Key.Up)
                IncrementDecrementTime(true);
            else if (selectedKey == Key.Down)
                IncrementDecrementTime(false);
            else
                return false;
            return true;
        }

        private void HoursKeyUp(object sender, KeyEventArgs e)
        {
            //focus the next control
            TryFocusNeighbourControl(hours, null, minutes, e.Key);

            if(!IncrementDecrementTime(e.Key))
                ValidateAndSetHour(hours.Text);
        }

        private void MinutesKeyUp(object sender, KeyEventArgs e)
        {
            //focus the next control
            TryFocusNeighbourControl(minutes, hours, seconds, e.Key);

            if (!IncrementDecrementTime(e.Key)) 
                ValidateAndSetMinute(minutes.Text);
        }

        private void SecondsKeyUp(object sender, KeyEventArgs e)
        {
            //focus the next control
            TryFocusNeighbourControl(seconds, minutes, null, e.Key);

            if (!IncrementDecrementTime(e.Key)) 
                ValidateAndSetSeconds(seconds.Text);
        }
        #endregion

        #region increase decrease button handlers

        //event handler for the decrease button click
        private void DecrementTime(object sender, RoutedEventArgs e)
        {
            IncrementDecrementTime(false);
        }

        private void IncreaseTime(object sender, RoutedEventArgs e)
        {
            IncrementDecrementTime(true);
        }

        #endregion

        #region Helper methods

        //construct the time in string format and return the string
        private static string BuildString(int nHour,int nMinutes,int nSeconds)
        {
            string CurrentTime = nHour.ToString() + ":" +
                                nMinutes.ToString() + ":" +
                                nSeconds.ToString();

            return CurrentTime;
        }

        //increment or decrement the time (hour/minute/second) currently in selected (determined by the currentlySelectedTextBox that is set in the GotFocus event of the textboxes)
        private void IncrementDecrementTime(bool increment)
        {
            //check if hour is selected if yes set it
            if (hours == currentlySelectedTextBox || _displayFormat == DisplayMode.HH)
                SelectedHour = MathUtil.IncrementDecrementNumber(hours.Text, HourMinValue, HourMaxValue, increment);

            //check if minute is selected if yes set it
            else if (minutes == currentlySelectedTextBox || _displayFormat == DisplayMode.HH_MM)
                SelectedMinute = MathUtil.IncrementDecrementNumber(minutes.Text, MinuteMinValue, MinuteMaxValue, increment);

            //if non of the above are selected assume that the seconds is selected
            else
                SelectedSecond = MathUtil.IncrementDecrementNumber(seconds.Text, SecondMinValue, SecondMaxValue, increment);
        }

        #region Validate and set properties
        //validates the hour passed as text and sets it to the SelectedHour property
        private int ValidateAndSetHour(string text)
        {
            int hourNum = MathUtil.ValidateNumber(text, HourMinValue, HourMaxValue);
            SelectedHour = hourNum;
            return hourNum;
        }

        //validates the minute passed as text and sets it to the SelectedMinute property
        private int ValidateAndSetMinute(string text)
        {
            int minNum = MathUtil.ValidateNumber(text, MinuteMinValue, MinuteMaxValue);
            SelectedMinute = minNum;
            return minNum;
        }

        //validates the second passed as text and sets it to the SelectedSecond property
        private int ValidateAndSetSeconds(string text)
        {
            int secNum = MathUtil.ValidateNumber(text, SecondMinValue, SecondMaxValue);
            SelectedSecond = secNum;
            return secNum;
        }
        #endregion

        //focuses the left/right control accordingly to the key passed. Pass null if there is not a neighbour control
        private static void TryFocusNeighbourControl(TextBox currentControl, TextBox leftControl, 
            TextBox rightControl, Key keyPressed)
        {
            if (keyPressed == Key.Left &&
                leftControl != null &&
                currentControl.CaretIndex == 0 )
            {
                leftControl.Focus();
            }

            else if (keyPressed == Key.Right &&
                 rightControl != null &&
                //if the caret index is the same as the length of the text and the user clicks right key it means that he wants to go to the next textbox
                 currentControl.CaretIndex == currentControl.Text.Length ) 
            {
                rightControl.Focus();
            }
        }

        //remove the left hand side number if the carrot index is 0 if the carrot index is 1 it removes the right hand side text
        private static string AdjustText(TextBox textBox, string newText)
        {
            //replace the new text with the old text if there are already 2 char in the textbox
            if (textBox.Text.Length == 2)
            {
                if (textBox.CaretIndex == 0)
                    return newText + textBox.Text[1];
                else
                    return textBox.Text[0] + newText;
            }
            else
            {
                return textBox.CaretIndex == 0 ?
                    newText + textBox.Text //if the carrot is in front the text append the new text infront
                    : textBox.Text + newText; //else put it in behind the existing text
            }

        }

        //moves the carrot for the textbox and if the carrot is at the end it will focus the neighbour
        private static void AdjustCarretIndexOrMoveToNeighbour(TextBox current, TextBox neighbour)
        {
            //if the current is near the end move to neighbour
            if ((current.Text.Length>1 && neighbour != null) || current.CaretIndex == 1 && neighbour != null)
                neighbour.Focus();

                //if the carrot is in the first index move the caret one index
            else if (current.CaretIndex == 0){
                current.CaretIndex++;
            }
        }

        //Removes the selected text
        private static void TrimSelectedText(TextBox textBox)
        {
            if (textBox.SelectionLength > 0)
                textBox.Text = textBox.Text.Remove(textBox.SelectionStart, textBox.SelectionLength);
        }
        
        //sets the selectedTime with the selectedhour, selectedminute and selectedsecond
        private static void SetNewTime(TimePickerAux timePicker)
        {
            if (!timePicker.isUpdatingTime)
            {
                TimeSpan newTime = new TimeSpan(
                    timePicker.SelectedHour,
                    timePicker.SelectedMinute,
                    timePicker.SelectedSecond);
                DateTime newDateTime = new DateTime(timePicker.Value.Year, timePicker.Value.Month, timePicker.Value.Day,
                    timePicker.SelectedHour,
                    timePicker.SelectedMinute,
                    timePicker.SelectedSecond);
                //check if the time is the same
                if (timePicker.SelectedTime != newTime)
                    timePicker.SelectedTime = newTime;
                if (timePicker.Value!= newDateTime)
                    timePicker.Value = newDateTime;

                timePicker.CurrentlySelectedTime = BuildString(timePicker.SelectedHour,
                                                                timePicker.SelectedMinute,
                                                                timePicker.SelectedSecond);
            }
        }
        private bool isUpdatingTime = false;
        //call this method while updating the SelectedTimeProperty from the control itself only
        private void BeginUpdateSelectedTime()
        {
            isUpdatingTime = true;
        }
        private void EndUpdateSelectedTime()
        {
            isUpdatingTime = false;
        }

        private void OnTimeSelectedChanged(TimeSpan newTime, TimeSpan oldTime)
        {
            TimeSelectedChangedRoutedEventArgs args = new TimeSelectedChangedRoutedEventArgs(SelectedTimeChangedEvent);
            args.NewTime = newTime;
            args.OldTime = oldTime;
            RaiseEvent(args);
        }

        private void OnValueChanged(DateTime newTime, DateTime oldTime)
        {
            ValueChangedRoutedEventArgs args = new ValueChangedRoutedEventArgs(ValueChangedEvent);
            args.NewTime = newTime;
            args.OldTime = oldTime;
            RaiseEvent(args);
        }

        #endregion

        //#region Unit Tests
        ///// <summary>
        ///// Exposes TryFocusNeighbourControl
        ///// </summary>
        ///// <param name="currentControl"></param>
        ///// <param name="leftControl"></param>
        ///// <param name="rightControl"></param>
        ///// <param name="keyPressed"></param>
        //[System.Diagnostics.Conditional(Globals.UnitTestSymbol)]
        //public static void ExposeTryFocusNeighbourControl(TextBox currentControl, TextBox leftControl,
        //    TextBox rightControl, Key keyPressed)
        //{
        //    TryFocusNeighbourControl(currentControl, leftControl, rightControl, keyPressed);
        //}
        ///// <summary>
        ///// Exposes the AdjustCarretIndexOrMoveToNeighbour
        ///// </summary>
        ///// <param name="current"></param>
        ///// <param name="neighbour"></param>
        //[System.Diagnostics.Conditional(Globals.UnitTestSymbol)]
        //public static void ExposeAdjustCarretIndexOrMoveToNeighbour(TextBox current, TextBox neighbour)
        //{
        //    AdjustCarretIndexOrMoveToNeighbour(current, neighbour);
        //}

        ///// <summary>
        ///// Exposes the TrimSelectedText method
        ///// </summary>
        ///// <param name="textBox"></param>
        //[System.Diagnostics.Conditional(Globals.UnitTestSymbol)]
        //public static void ExposeTrimSelectedText(TextBox textBox)
        //{
        //    TrimSelectedText(textBox);
        //}
        
        //#endregion
    }

    #region Routed Event

    /// <summary>
    /// Delegate for the TimeSelectedChanged event
    /// </summary>
    /// <param name="sender">The object raising the event</param>
    /// <param name="e">The routed event arguments</param>
    public delegate void TimeSelectedChangedEventHandler ( object sender, TimeSelectedChangedRoutedEventArgs e);

    /// <summary>
    /// Routed event arguments for the TimeSelectedChanged event
    /// </summary>
    public class TimeSelectedChangedRoutedEventArgs : RoutedEventArgs
    {
        /// <summary>
        /// Gets or sets the new time
        /// </summary>
        public TimeSpan NewTime { get; set; }

        /// <summary>
        /// Gets or sets the old time
        /// </summary>
        public TimeSpan OldTime { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="routedEvent">The event that is raised </param>
        public TimeSelectedChangedRoutedEventArgs(RoutedEvent routedEvent)
            : base(routedEvent) { }
    }


    /// <summary>
    /// Delegate for the ValueChanged event
    /// </summary>
    /// <param name="sender">The object raising the event</param>
    /// <param name="e">The routed event arguments</param>
    public delegate void ValueChangedEventHandler ( object sender, ValueChangedRoutedEventArgs e);

    /// <summary>
    /// Routed event arguments for the ValueChanged event
    /// </summary>
    public class ValueChangedRoutedEventArgs : RoutedEventArgs
    {
        /// <summary>
        /// Gets or sets the new time
        /// </summary>
        public DateTime NewTime { get; set; }

        /// <summary>
        /// Gets or sets the old time
        /// </summary>
        public DateTime OldTime { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="routedEvent">The event that is raised </param>
        public ValueChangedRoutedEventArgs(RoutedEvent routedEvent)
            : base(routedEvent) { }
    }


    #endregion
}
