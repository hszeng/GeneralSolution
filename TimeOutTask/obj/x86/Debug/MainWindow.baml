   M S B A M L   `   `   `  ����F  BTimeOutTask, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TimeOutTaskTimeOutTask  5   	       TimeOutTask.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   +localclr-namespace:TimeOutTask     5   	     � Title$  TaskTimeOutDemo��5   	   $	��480��6!   $	��650��6.    � DataContext 5         TimeOutTask.ViewModel  5   
   6    � 	Resources 5	       �� 
TargetType �� Property �� Value��%R  '��       '�� �     �� 5
   
   " ��6   .�5      ��  � ��$ 30��6'   64   �� 5       � ��$ 5q�6'   63   �� 5       � ��$ 80��6&   63   5      �� 5   
   " ��6   .�5      ��  � ��$	 120��6'   65   �� 5       � ��$ 5q�6'   63   �� 5       � ��$	 500��6&   64   5      5      .��5      �� .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Start Worker1��68   ��6   �� *Worker1Command+68   �� 5      
���������6.   �� *Worker1StatusCollection+5      �� 5   
   $ 
Horizontal=�6   .+�5      �� $��Start Worker2��69   ��6   �� *Worker2Command+69   �� 5      
���������6.   �� *Worker2StatusCollection+5      �� 5   
   $ 
Horizontal=�6   .+�5      �� $��Start Worker3��69   ��6   �� *Worker3Command+69   �� 5       
���������6-   �� *Worker3StatusCollection+5!      5"      5#      