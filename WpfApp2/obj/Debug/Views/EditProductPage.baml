   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfApp2.ViewsWpfApp2.Views  5   	   #    WpfApp2.Views.EditProductPage   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:WpfApp2.Views     5   	     � Title$  EditProductPage��5   	   $	��300��6!   $	��400��6.   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0,0,0,10q�6   .+�5      �� $$��Название товара:��6   $
��Bold"�60   �� 5      -   5         ��Name$ ProductNameTextBox��5      $	��0,5q�62   5      �� 5   
   $��0,0,0,10q�6   $��1��6'   .+�5      �� $��Цена товара:��6   $
��Bold"�6,   �� 5      -   5        $ ProductPriceTextBox��5      $	��0,5q�63   5      �� 5   
   $��0,0,0,10q�6   $��2��6'   .+�5      �� $&�� Категория товара:��6   $
��Bold"�61   �� 5      -   5        $ ProductCategoryTextBox��5      $	��0,5q�66   5      �� 5    
    �� Orientation$ 
Horizontal=�6   $��3��6.   $��Right=�6;   .+�5!      �� -   5        $��Сохранить��5!      $	��100��6)   $��50��65   $��5q�6A   6L   �� 5"      -   5        $��Отмена��5"      $	��100��6&   $��50��62   $��5q�6>   6I   5#      5$      5%      