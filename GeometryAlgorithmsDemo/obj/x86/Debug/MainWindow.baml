   M S B A M L   `   `   `  ����  GeometryAlgorithmsDemo?    9Introduction2Algorithms.GeometryAlgorithmsDemo.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  GeometryAlgorithmsDemo��5   	   $	��700��6?   $	��700��6L   .��5      � 
�������$��20q�6"    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5
   
   �� 5      $��* �6   6+   �� 5      $	��500 �6   6-   .+�5   
   �� -   5        $��scrollViewer��5      $��0��6+   $��Visible=�68   $��Visible=�6^   .��5      �� -   5         ��Name$ canvas��5      $��Visible=�5      $��Visible=�5      $
��Left=�5      
�������$	��600��5   0   $	��400��6?   z�5      V� 5      .~�5      ��  �� ScaleY$ -1Q�6)   T� 5       T� Y 6-   ��  �� ElementName$ canvas�� �� Path$ ActualHeight�5      5      5      �� 5   
    �� Orientation$ Vertical=�6   $��1��6,   	 � 	Resources	 5      
 �� 
TargetType �� Property �� Value��%R   '��       �� 5       "
 ��6   .�5!      ��  � ��$ 10q�6/   5"      5#      .+�5$      �� $ 
Horizontal=�6   $��45��63   .+�5%      �� -   5         ��Name$ btn_GRB��5%      $��GenerateSimplePolygon��6*   $��23��6J   $
��Left=�6V   $	��Top=�6r   $	��172��6�   6�   �� 5&      -   5        $ btn_clr��5&      $��Clear Canvas��6*   $��23��6A   $
��Left=�6M   $	��Top=�6h   $	��109��6�   6�   5'      5(      �� 5)   
   -   5         ��Name$ tb��5)      $	��500��6   $��1��6+   6=   5*      5+      