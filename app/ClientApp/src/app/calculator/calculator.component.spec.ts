import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { CalculatorComponent } from './calculator.component';
import { HttpClientTestingModule } from '@angular/common/http/testing'; 
import { environment } from './environment'; 

describe('CalculatorComponent', () => {
  let component: CalculatorComponent;
  let fixture: ComponentFixture<CalculatorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [FormsModule, HttpClientTestingModule],
      declarations: [CalculatorComponent],
      providers: [
        { provide: 'BASE_URL', useValue: environment.BASE_URL } // Fornecendo BASE_URL no ambiente de teste
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CalculatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should disable the button when fields are invalid', () => {
    component.valorInicial = 0;
    component.qtdMeses = 1;
    fixture.detectChanges();

    const button = fixture.nativeElement.querySelector('button');
    expect(button.disabled).toBe(true);
  });


  it('teste quando deve calcular e exibir resultados corretos quando os campos são válidos', async () => {
    component.valorInicial = 1000;
    component.qtdMeses = 12;
    fixture.detectChanges();
  
    const button = fixture.nativeElement.querySelector('button');
    button.click();
    await fixture.whenStable();
    fixture.detectChanges();

    const resultadoBrutoElement = fixture.nativeElement.querySelector('#LabelResultadoBruto');
    const resultadoBrutoContent = resultadoBrutoElement.textContent;
    
    const resultadoLiquidoElement = fixture.nativeElement.querySelector('#LabelResultadoliquido');
    const resultadoLiquidoContent = resultadoLiquidoElement.textContent;
   
    expect(resultadoBrutoContent).toContain('R$'); 
    expect(resultadoBrutoContent).not.toBeNull();

    expect(resultadoLiquidoContent).toContain('R$'); 
    expect(resultadoLiquidoContent).not.toBeNull();
  });
});
