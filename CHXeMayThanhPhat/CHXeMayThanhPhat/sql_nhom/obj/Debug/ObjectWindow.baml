   M S B A M L   `   `   `  ����X  TMoralesLarios.CustomsControls, Version=1.0.0.7, Culture=neutral, PublicKeyToken=nulltRclr-namespace:MoralesLarios.CustomsControls;assembly=MoralesLarios.CustomsControlsMoralesLarios.CustomsControls  5   	   C ?sql_nhom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:sql_nhomsql_nhom 5   	   7 clr-namespace:sql_nhom.Dang_nhapsql_nhom.Dang_nhap 5	   
      sql_nhom.ObjectWindow   5   	   fCustomsControlsRclr-namespace:MoralesLarios.CustomsControls;assembly=MoralesLarios.CustomsControls  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:sql_nhom     5   	   /uc clr-namespace:sql_nhom.Dang_nhap     5	   
   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   -   5          �Name$  window��5   	      ObjectVM � DataContext# [  5   	     MaterialDesignBody#���  5   	   $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5       � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ 	Loại xe��5   	   $	��500��6   $	��700��6&   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   � $��0��6   .+�5      %  sql_nhom.Dang_nhap.ControlBarUC  
	 � Tag	 6   �� *Title+
 �� ElementName$
 window��6J   5      � 5!   
   $��1��6    5"      �� 5#      $
��auto �6    60   �� 5$      $
��auto �6    60   �� 5%      $
��auto �6    60   �� 5&      6"   .+�5*      #  MaterialDesignThemes.Wpf.Card  $��0��6"   $��5q�6/   .��5+      � $��0 0 0 10q�6   .+�5,      �� $��5 5 15 5q�6h   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Mã loại��6z    % !MaterialDesignFloatingHintTextBox#��[ 6�   ��6   �� *MALOAI+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6�   �� 5-      $��5 5 15 5q�6i   $ Tên loại xe��6{   #��[ 6�   ��6   �� *	TENLOAI+$ PropertyChanged=�$ TwoWay=�6�   5.      5/        51      $��1��6"   $��5q�6/   .��52      -   'MoralesLarios.CustomsControls.SearchAll  -   5          Name$ 	searchall��52   ,   53        55      $��2��6"   $��5q�6/   .��56      � .+�57      �� $��Thêm��6<   $��5q�6K   $	��100��6V   ��6   �� *
AddCommand+6d   �� 58      $��Sửa��6=   $��5q�6L   $	��100��6W   ��6   �� *EditCommand+6e   �� 59      $��Xóa��6?   $��5q�6N   $	��100��6Y   ��6   �� *DeleteCommand+6g   5;      5<        5@      $��3��6"   $��5q�6/   $��Stretch=�6:   .��5A      �� $
��Auto=�6   .��5B      �� -   5         ��Name$
 list��5B      ��6-   �� *List+ �� SelectedItem 6J   �� *SelectedItem+$ TwoWay=� �� View 5C      �� 5D      .P�5E   "   �� $��
Mã loại��61    �� DisplayMemberBinding 6B   �� *MALOAI+6l   �� 5F   "   $��Tên loại xe��61    6F   �� *	TENLOAI+6q   5G      5I      5J      5K      5L      5M      5N      