   M S B A M L   `   `   `  ����|  xSystem.Windows.Controls.DataVisualization.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35�rclr-namespace:System.Windows.Controls.DataVisualization;assembly=System.Windows.Controls.DataVisualization.Toolkit)System.Windows.Controls.DataVisualization  5   	   �{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting  5   	    esem_homework_sma_by_ks=   7esem_homework_sma_by_ks.MetricsPairsVisualizationWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   �DVrclr-namespace:System.Windows.Controls.DataVisualization;assembly=System.Windows.Controls.DataVisualization.Toolkit     5   	   �DVC{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     5   	   -   5          � Title$%  MetricsPairsVisualizationWindow��5   	   $��508.647��61   $��705.422��6B   .��5      � .+�5   
   >   8System.Windows.Controls.DataVisualization.Charting.Chart  -   5        $��MetricPairChart��5   5   
 �� Top$ 80��6    �� Left$ 10��6$   $	��552��6L   $	��250��6X   
����İ�$
��Left=�6�   $	��Top=�6�      Series 5
      F   @System.Windows.Controls.DataVisualization.Charting.ScatterSeries  ?   9System.Windows.Controls.DataVisualization.Charting.Series   Title$ Scatter��6$   H   BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries   IndependentValueBinding 64   ��  �� Path$	 Key�   DependentValueBinding 6a   �� $ Value�   DataPointStyle 5      �� 5      	 �� 
TargetTypeI   CSystem.Windows.Controls.DataVisualization.Charting.ScatterDataPoint"	  6    .�5      �� 
 �� Property
 � �� �� Value
 ����6;   5      5      C   =System.Windows.Controls.DataVisualization.Charting.LineSeries  5      $ Linear��6!    60   �� $	 Key� 6]   �� $ Value� 5      �� 5      F   @System.Windows.Controls.DataVisualization.Charting.LineDataPoint"	  6    .�5      �� 
 � ��
 �����6;   5      5        5      $ Logarithmic��6!    65   �� $	 Key� 6b   �� $ Value� 5      �� 5      "	  6    .�5      �� 
 � ��
 �z���6;   5      5        5      $ 
Polynomial��6!    64   �� $	 Key� 6a   �� $ Value� 5       �� 5!      "	  6    .�5"      �� 
 � ��
 �  ��6;   5#      5%         Axes 5(      C   =System.Windows.Controls.DataVisualization.Charting.LinearAxis  -   5          Name$ YLinearAxis��5(   !   =	   7System.Windows.Controls.DataVisualization.Charting.Axis 	  Orientation$ Y=�66   D
   >System.Windows.Controls.DataVisualization.Charting.DisplayAxis 
  Title$  ��6F   
���   �
�������$��TimesNewRoman)�6u   $��14(�6�   $
��Bold"�6�     5)      -   5        $ XLinearAxis��5)   !   $ X=�66   $  ��6F   
���   �
�������$��TimesNewRoman)�6u   $��14(�6�   $
��Bold"�6�   5+      �� 5,   
   -   5         ��Name$ MetricsPairsListBox��5,      $
��Left=�6/   $	��250��6J   $��	557,0,0,0q�6W   $	��Top=�6j   $	��130��6�   6�   �� 5-   
   $��Correlation Coefficient:��6   $
��Left=�63   $��
10,255,0,0q�6N   $	��Top=�6b   �� 5.   
   -   5         ��Name$! CorrelationCoefficientLabel��5.      $�� ��65   $
��Left=�6@   $��143,255,0,0q�6[   $	��Top=�6p   �� 5/   
   $��Linear:��6   $
��Left=�6"   $��
10,286,0,0q�6=   $	��Top=�6Q   $��75��6i   �� 50   
   $��Logarithmic:��6   $
��Left=�6'   $��
10,317,0,0q�6B   $	��Top=�6V   �� 51   
   $��Polynomial:��6   $
��Left=�6&   $��
10,348,0,0q�6A   $	��Top=�6U   $��75��6m   �� 52   
   -   5         ��Name$# FirstLinearCoefficientTextBox��52      $
��Left=�69   $��23��6T   $��
90,290,0,0q�6`    �� TextWrapping$
 Wrap=�6t   $	��Top=�6�   $	��120��6�   �� 53   
   -   5        $( "FirstLogarithmicCoefficientTextBox��53      $
��Left=�6>   $��23��6Y   $��
90,321,0,0q�6e   $
 Wrap=�6y   $	��Top=�6�   $	��120��6�   �� 54   
   -	   5        $' !FirstPolynomialCoefficientTextBox��54      $
��Left=�6=   $��23��6X   $��
90,352,0,0q�6d   $
 Wrap=�6x   $	��Top=�6�   $	��120��6�   �� 55   
   $��x��6   $
��Left=�6   $��215,286,0,0q�67   $	��Top=�6L   $��40��6d   �� 56   
   -
   5        $$ SecondLinearCoefficientTextBox��56      $
��Left=�6:   $��23��6U   $��260,290,0,0q�6a   $
 Wrap=�6v   $	��Top=�6�   $	��120��6�   �� 57   
   $��log(x)��6   $
��Left=�6!   $��215,317,0,0q�6<   $	��Top=�6Q   �� 58   
   -   5        $) #SecondLogarithmicCoefficientTextBox��58      $
��Left=�6?   $��23��6Z   $��260,321,0,0q�6f   $
 Wrap=�6{   $	��Top=�6�   $	��120��6�   �� 59   
   $	��x^2��6   $
��Left=�6   $��215,348,0,0q�69   $	��Top=�6N   $��40��6f   �� 5:   
   -   5        $( "SecondPolynomialCoefficientTextBox��5:      $
��Left=�6>   $��23��6Y   $��260,352,0,0q�6e   $
 Wrap=�6z   $	��Top=�6�   $	��120��6�   �� 5;   
   $��x��6   $
��Left=�6   $��385,348,0,0q�67   $	��Top=�6L   �� 5<   
   -   5        $' !ThirdPolynomialCoefficientTextBox��5<      $
��Left=�6=   $��23��6X   $��406,352,0,0q�6d   $
 Wrap=�6y   $	��Top=�6�   $	��120��6�   �� 5=   
   -   5         ��Name$ PolynomialPlottingButton��5=      $
��Plot��63   $
��Left=�6B   $��531,351,0,0q�6]   $	��Top=�6r   $��75��6�   6�   �� 5>   
   -   5        $ LogarithmicPlottingButton��5>      $
��Plot��64   $
��Left=�6C   $��531,320,0,0q�6^   $	��Top=�6s   $��75��6�   6�   �� 5?   
   -   5        $ LinearPlottingButton��5?      $
��Plot��6/   $
��Left=�6>   $��531,289,0,0q�6Y   $	��Top=�6n   $��75��6�   6�   �� 5@   
   -   5        $ BestLineFitResultLabel��5@      $�� ��60   $
��Left=�6;   $��104,403,0,0q�6V   $	��Top=�6k   �� 5A   
   -   5        $$ BestLineFitDeterminationButton��5A      $��	Determine��69   $
��Left=�6M   $��
10,406,0,0q�6h   $	��Top=�6|   $��75��6�   6�   5B      5C      