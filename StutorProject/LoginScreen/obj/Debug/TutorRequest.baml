   M S B A M L   `   `   `  ����F  BLoginScreen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:LoginScreenLoginScreen  5   	       LoginScreen.TutorRequest   5   	   X TXceed.Wpf.Toolkit, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:LoginScreen     5   	     � Title$  TutorRequest��5   	   $	��450��6   $	��450��6+    � WindowStartupLocation$ CenterScreen=�67    � 
ResizeMode$ NoResize=�6\   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� -   5         ��Name$ lblRequestHeader��5      $��2��6*   $��0��6>   $��Requesting tutoring from:��6K   $��18(�6o   $��Center=�6}   $��Center=�6�   �� 5   
   -   5        $ lblTutorHeader��5      $��2��6(   $��1��6<   $��
Tutor Name��6I   $��18(�6^   $��Center=�6l   $	��Top=�6�   �� 5   
   -   5        $ lblSubjectName��5      $��2��6(   $��2��6<   $��SUBJECT��6I   $��20(�6[   $��Center=�6i   $	��Top=�6�   �� 5   
   -   5        $ lblRequestedDate��5      $��2��6*   $��3��6>   $��Requested date and time:��6K   $��20(�6n   $��Center=�6|   $��Bottom=�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 
datePicker��5      $��2��6)   $��4��6=   $��50 10q�6J   $��15(�6Y   $��Center=�6g   $	��245��6�      DisplayDate$ 
2016-11-11��6�    � 	Resources 5      :  4System.Windows.Controls.Primitives.DatePickerTextBox	 �� 
TargetType
 �� Property �� Value ��Name �� Path �� StringFormat �� RelativeSource �� AncestorType��%  '        �� 5      "	  6   .�5      �� 
 �@��
IsReadOnly . 63   �� 5      
 � �� 5       �� 5!      .R�5"   "   �� $ DatePickerTextBox��6*   $	��180��6E   ��5#   %   �� $ SelectedDate�$ 	yyy-MM-dd�� �� "  5%      5'      5(      5)      5*      "  Xceed.Wpf.Toolkit.TimePicker  5+   
   -   5          Name$ 
timePicker��5+      $��5��6.   $��2��6;   $��100 10q�6O   ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   AllowTextInput .  6_   �� 5,   
   -   5         ��Name$ 	btnSubmit��5,      $��0��6$   $��6��64   $��Submit��6A   $��50 15q�6R    �� 	IsDefault . 6r   �� 5-   
   -   5        $ 	btnCancel��5-      $��1��6$   $��6��64   $��Cancel��6A   $��50 15q�6R    �� IsCancel . 6a   5/      50      