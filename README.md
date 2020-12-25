# ManageMioStimulator
Программа стимулятор, с возможностью управления по сети

Для работы со стимулятором по сети необходимо передавать команды следующего формата: первые 4 байта - признак того, что это команда стимулятора: 22, далее 4 байта - код команды:

  0 - останавливает стимуляцию

  1 - запускает стимуляцию
  
  2 - задать амплитуду, далее 4 байта числа типа float, определяющих амплитуду в амперах
        
  3 - задать полярность, далее 4 байта целого числа 1 (прямая полярность) или -1 (обратная полярность)
  
  4 - задать длительность стимуляции, далее 4 байта числа float, определяющих длительность стимуляции в секундах
  
  5 - задать период стимуляции, далее 4 байта числа float, определяющих период стимуляции
  
  6 - задать количество стимулов, далее 2 байта числа ushort, определяющих количество стимулов
  
  7 - задать форму стимула, далее 4 байта целого числа - номер стимула:
        
        0 - Прямоугольная

        1 - Трапецевидная

        2 - Монополярный меандр
        
        3 - Биполярный меандр

        4 - Синусоида

        5 - Модальная синусоида
        
Для работы программы требуются следующие библиотеки: [FoundationLibrary](https://github.com/LaboratoryOfMedicalCybernetics/FoundationLibrary/releases), [NetManager](https://github.com/LaboratoryOfMedicalCybernetics/NetManager/releases), [NeuroMEP4StimulatorController](https://github.com/LaboratoryOfMedicalCybernetics/NeuroMEP4StimulatorController/releases)
