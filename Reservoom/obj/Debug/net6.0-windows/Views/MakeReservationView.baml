   M S B A M L   `   `   `  ����D  @Reservoom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Reservoom.ViewsReservoom.Views  5      )    #Reservoom.Views.MakeReservationView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Reservoom.Views     5        � 	Resources  5	      ��%    5
      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��Make Reservation��6!    
  Header#��[  69   � 5   
   $��1��6   $
��0 10q�6    5      �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �� $��0��6   $��Username��6%   �� 5      $��1��6   $��0 5 0 0q�6b   ��6#   �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�6b   5      � 5!   
   $��2��6   $
��0 10q�6    5"      �� 5#      $
��auto �6    �� 5$      $
��auto �6     � ColumnDefinitions 5&      �� 5'      $
��auto �6#    z� SharedSizeGroup$ FirstColumn��60   �� 5(      $
��auto �6#   $ SecondColumn��60   .+�5+      �� $��0��6   $��0��6%   $��	Floor No.��65   �� 5,      $��1��6   $��0��6#   $��0 5 0 0q�6u   ��63   �� *FloorNumber+$ PropertyChanged=�6u   �� 5.      $��0��6   $��1��6%   $��Room No.��65   $��20 0 0 0q�6E   �� 5/      $��1��6   $��1��6#   $��20 5 0 0q�6t   ��63   �� *
RoomNumber+$ PropertyChanged=�6t   50      � 52   
   $��3��6   $
��0 10q�6    53      �� 54      $
��auto �6    �� 55      $
��auto �6     57      �� 58      $
��auto �6#   $ FirstColumn��60   �� 59      $
��auto �6#   $ SecondColumn��60   .+�5<      �� $��0��6   $��0��6%   $��
Start Date��65   (  "System.Windows.Controls.DatePicker  5=      $��1��6   $��0��6&      Text$  ��66   $��0 5 0 0q�6>      SelectedDate 6O   �� *	StartDate+$ PropertyChanged=��� 5?      $��0��6   $��1��6%   $��End Date��65   $��20 0 0 0q�6E     5@      $��1��6   $��1��6&   $  ��66   $��20 5 0 0q�6>    6P   �� *	EndDate+$ PropertyChanged=�5A      �� 5C   
   $��4��6    �� Orientation$ 
Horizontal=�6"   $
��0 10q�6;   .+�5D      �� $��Submit��67   ��6   �� *SubmitCommand+67   �� 5E      $��Cancel��67   $��20 0 0 0q�6H   ��6   �� *CancelCommand+6H   5F      5G      5H      