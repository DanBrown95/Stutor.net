   M S B A M L   `   `   `  ����F  BLoginScreen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:LoginScreenLoginScreen  5   	   !    LoginScreen.RequestNewClass   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:LoginScreen     5   	     � Title$  RequestNewClass��5   	   $	��400��6!   $	��400��6.    � WindowStartupLocation$ CenterScreen=�6:   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� -   5         ��Name$ 	lblHeader��5      $��0��6#   $��2��60   $��Request a new class��6D   $��Center=�6b   $��Center=�6}   $��20(�6�   �� 5   
   -   5        $ lblSubjectArea��5      $��2��6(   $��0��65   $��Subject Area��6E   $��Center=�6\   $
��Left=�6w   �� 5   
   -   5         ��Name$ cmbSubjectArea��5      $��2��6+   $��1��68   $��20 15q�6H   �� 5   
   -   5        $ 
lblSubject��5      $��3��6$   $��0��61   $#��Enter subject you wish to add��6A   $��Center=�6i   $
��Left=�6�   �� 5   
   -   5         ��Name$ txtSubjectRequest��5      $��3��6-   $��1��6:   $��20 15q�6J    �� TextAlignment$ Center=�6Y   �� 5   
   -   5         ��Name$ 	btnSubmit��5      $��5��6$   $��0��61   $��Submit��6A   $��50 20q�6R   	 �� 	IsDefault	 . 6r   �� 5   
   -   5        $ 	btnCancel��5      $��5��6$   $��1��61   $��Cancel��6A   $��50 20q�6R   
 �� IsCancel
 . 6a   5      5      