   M S B A M L   `   `   `  ����I  ECrematorium.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Crematorium.UI.PagesCrematorium.UI.Pages  5      E'clr-namespace:Crematorium.UI.ConvertersCrematorium.UI.Converters  5      k:clr-namespace:Crematorium.UI.Converters.PropertyConverters,Crematorium.UI.Converters.PropertyConverters  5      )    #Crematorium.UI.Pages.UserOrdersPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Crematorium.UI.Pages     5      >
converters'clr-namespace:Crematorium.UI.Converters     5      Q
properties:clr-namespace:Crematorium.UI.Converters.PropertyConverters     5      -   5        
������   � 	Resources  5       �� MergedDictionaries �� Source2  ,Crematorium.UI.Converters.RoleToStrConverter   	RoleToStrI   CCrematorium.UI.Converters.PropertyConverters.StateToStringConverter  
StateToStrN   HCrematorium.UI.Converters.PropertyConverters.GetCustomerSurNameConverter  GetCustomerSurnameO   ICrematorium.UI.Converters.PropertyConverters.DateOfStartToStringConverter  GetDateOfStartM   GCrematorium.UI.Converters.PropertyConverters.GetCorposeSurNameConverter  GetCorposeSurnameG   ACrematorium.UI.Converters.PropertyConverters.GetHallNameConverter  GetHallName�� 5   
    5      �� 5      $; 5pack://application:,,,/Resourse/Styles/BtnStyles.xaml?�6%   �� 5      $< 6pack://application:,,,/Resourse/Styles/TextStyles.xaml?�6%   �� 5      $@ :pack://application:,,,/Resourse/Styles/ElementsStyles.xaml?�6%   �� 5      $@ :pack://application:,,,/Resourse/Styles/DataGridStyles.xaml?�6%   %�   &	        &	      &	 &     &	 9     &	 L     &	 _       5      6,     5      60     5      65     5      66     5      64     5      6.   5      .��5      ��  �� CornerRadius$ 10��6   ���	#FFF8D0D0._�5!   
   � -   5         �Name$ 
OrdersGrid��5!       � ColumnDefinitions 5#      �� 5$      $��20 �6#   �� 5%      �� 5&      �� 5'      �� 5(      �� 5)      $��20 �6#    � RowDefinitions 5+      �� 5,      $��50 �6    �� 5-      $��20 �6    �� 5.      $��20 �6    �� 5/      �� 50      �� 51      $��80 �6    �� 52      $��20 �6    .+�56      �� $��0��6   $��6��57      $��	My Orders��58      $��Center=�59      $��32(�5:      &   System.Windows.Controls.DataGrid  5=      -   5          Name$ OrdersDataGrid��5?      $��3��5=      $��2��6$   $��1��5>      $��4��6'      
IsReadOnly$
 True��5@        BaseDataGrid#��[ 5A      ��5B      �� *Orders+	 �� SelectedItem	 5C      �� 
 �� Path$
 SelectedOrder�   Columns 5D      0  *System.Windows.Controls.DataGridTextColumn  5E      ,	  &System.Windows.Controls.DataGridColumn 	  Header$ ID��6)    	  Width5
  /System.Windows.Controls.DataGridLengthConverter$ 50
 5F   )   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5G   )   �� *Id+  5H      $ Customer��6)   $ *
 5I   )    5J   )   �� $
 Customer� �� 	Converter# [   5L      $
 Date��6)   $	 120
 5M   )    65   �� $
 DateOfStart�# [   5O      $ State��6)   $	 120
 5P   )    65   �� $
 State�# [   5R      $ Corpose��6)   $ *
 5S   )    63   �� $
 	CorposeId�# [   5U      $
 Hall��6)   $	 180
 5V   )    65   �� $
 HallId�# [ 5Y      �� 5\      $��2��6   $��5��5]      $��90��5^      ���	#FFF53657  BaseBtnStyle#��[ 5a      ��5`      �� $
 ViewOrderCommand�.��5b      �� $��See all��6   5c      �� 5d      $��3��6   $��5��5e      $��90��5f      ���	#FFF53657#��[ 5i      ��5h      �� $
 CancelOrderCommand�.��5j      �� $��Cancel��6   5k       � 5n      -   5          �Name$ 
FrameUsers��5n      $��0��5o      $��6��6$   $��0��5p      $��8��6!   5r      5s      5t      