   M S B A M L   `   `   `  ����F  BLoginScreen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:LoginScreenLoginScreen  5   	   %    LoginScreen.TutorApprovalDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:LoginScreen     5   	     � Title$  TutorApprovalDialog��5   	   $	��300��6%   $	��400��62    � WindowStartupLocation$ CenterScreen=�6>   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� -   5         ��Name$ lblTitle��5      $��0��6"   $ ��Tutor Application Approval��6/   $��Center=�6T   $��Center=�6q   $��13(�6�   �� 5   
   -   5        $ 
lblMessage��5      $��2��6$   $:��4Would you like to APPROVE or DECLINE the request by:��61   $��Center=�6p   $��Center=�6�   $��13(�6�   �� 5   
   -   5        $ lblApplicant��5      $��3��6&   $�� ��63   $��Center=�6>   $��Center=�6[   $��16(�6v   � 5   
   $��5��6    � ColumnDefinitions 5      �� 5      �� 5      �� 5      .+�5      �� -   5         ��Name$ 
btnApprove��5      $��0��6)   $��Approve��69   $
��15 5q�6K   6Y   �� 5      -   5        $ 
btnDecline��5      $��1��6)   $��Decline��69   $
��15 5q�6K   6Y   �� 5      -   5        $ 	btnCancel��5      $��2��6(   $��Cancel��68   $
��15 5q�6I    �� IsCancel . 6W   5      5       5!      