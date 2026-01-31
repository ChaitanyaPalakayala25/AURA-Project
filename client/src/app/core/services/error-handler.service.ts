import { ErrorHandler, Injectable } from '@angular/core';
import { ApplicationInsights } from '@microsoft/applicationinsights-web';
import { environment } from '../../../environments/environment';

@Injectable()
export class AppInsightsErrorHandler implements ErrorHandler {
    private appInsights: ApplicationInsights;

    constructor() {
        this.appInsights = new ApplicationInsights({
            config: {
                instrumentationKey: (environment as any).appInsightsKey,
                enableAutoRouteTracking: true
            }
        });
        if ((environment as any).appInsightsKey) {
            this.appInsights.loadAppInsights();
        }
    }

    handleError(error: any): void {
        this.appInsights.trackException({ exception: error });
        console.error(error);
    }
}
