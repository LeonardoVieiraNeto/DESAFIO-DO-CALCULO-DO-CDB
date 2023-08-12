import { Component,Inject, ChangeDetectionStrategy, ChangeDetectorRef } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-calculator-component',
  templateUrl: './calculator.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CalculatorComponent {
  public ResultadoBruto: number | undefined = 0.0;
  public ResultadoLiquido: number | undefined = 0.0;
  public valorInicial: number | undefined;
  public qtdMeses: number | undefined;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private cdRef: ChangeDetectorRef) {}

    enviarDados() {
      const body = {
        valorInicial: this.valorInicial,
        qtdMeses: this.qtdMeses
      };

      const headers = new HttpHeaders().set('Content-Type', 'application/json');
  
      this.http.post(this.baseUrl + 'cdbcalculator', body, { headers }).subscribe(
        (data: any) => {
          this.ResultadoBruto = data.resultadoBruto;
          this.ResultadoLiquido = data.resultadoLiquido;
          this.cdRef.detectChanges(); 
        },
        (error: any) => {
          console.error('Erro:', error);
        }
      );
    }

    validarCampos(): boolean {
      return this.qtdMeses === undefined || this.qtdMeses === null || this.qtdMeses <= 0 ||
             this.valorInicial === undefined || this.valorInicial === null || this.valorInicial === 0;
    }
  

   }

interface CdbCalculator {
  ResultadoBruto: number;
  ResultadoLiquido: number;
}
