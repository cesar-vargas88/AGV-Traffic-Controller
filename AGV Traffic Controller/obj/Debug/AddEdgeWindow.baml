   M S B A M L   `   `   `  ����Q  MAGV Traffic Controller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:AGV_Traffic_ControllerAGV_Traffic_Controller  5   	   *    $AGV_Traffic_Controller.AddEdgeWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:AGV_Traffic_Controller     5   	   $	��162��5   	   $	��315��6     � WindowStartupLocation$  CenterScreen=�6"    � 
ResizeMode$ NoResize=�6G    � ShowInTaskbar .   � WindowStyle$ 
ToolWindow=�6s   .��5	      � .+�5
   
   � $��0,0,0,0q�6   $��82��6    $	��Top=�6,   .+�5      �� -   5         ��Name$ cboxPredecessor��5      $
��Left=�61   $��90,0,0,0q�6L   $	��Top=�6^   $	��171��6v   $��25��6�   6�   �� 5      -   5        $ cboxSuccessor��5      $
��Left=�61   $��	90,27,0,0q�6L   $	��Top=�6_   $	��171��6w   $��25��6�   6�   �� 5      -   5        $ 
cboxWeight��5      $
��Left=�61   $��	90,54,0,0q�6L   $	��Top=�6_   $	��171��6w   $��25��6�   6�   �� 5      -   5         ��Name$ lblPredecessor��5      $��
Predecesor��61   $
��Left=�6F   $��22,0,0,0q�6a   $	��Top=�6s   $��12(�6�   �� 5      -   5        $ lblSuccessor��5      $��Sucesor��62   $
��Left=�6D   $��	22,27,0,0q�6_   $	��Top=�6r   $��12(�6�   �� 5      -   5        $ 	lblWeight��5      $
��Peso��61   $
��Left=�6@   $��	22,54,0,0q�6[   $	��Top=�6n   $��12(�6�   5      � 5   
   $��0,82,0,0q�6   
�������.+�5      �� -   5         ��Name$ btnAdd��5      $��Agregar��6*   $��75��6C   $��25��6N   $��Calibri)�6Z   $��14(�6o   $
��Left=�6}   $	��Top=�6�   $��120,12.5,0,0q�6�   �� 5      -   5        $ 	btnCancel��5      $��Cancelar��6)   $��75��6=   $��25��6H   $��Calibri)�6T   $��14(�6i   $
��Left=�6w   $	��Top=�6�   $��206,12.5,0,0q�6�   5      5      5      